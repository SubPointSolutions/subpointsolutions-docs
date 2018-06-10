
require 'tmpdir'
require 'fileutils'
require 'yaml'
require 'logger'
require 'optparse'

def require_value(value, comment) 

    if value.nil? || value.to_s.empty?
        $logger.error comment
        raise comment
    end

end

def cmd(cmd, silent: false) 

    if silent != true
        $logger.debug "Running cmd: #{cmd}"
    end

    system(cmd)
    exit_code = $?.exitstatus

    $logger.debug $?             
    $logger.debug exit_code

    $logger.debug("Exited with: #{exit_code}")

    if exit_code != 0
        $logger.debug("Failed running cmd, exiting with -1")
        exit(-1)
    else
        $logger.debug("Success while running cmd, continue...")
    end
end

def load_git_metadata(config_name:, file_path: "build.yaml")

    $logger.info "Loading config: #{config_name} from file: #{file_path}"

    if !File.exist? file_path
        $logger.error "   - file does not exit: #{file_path}"
        exit(1)
    end
    
    configs = YAML.load_file(file_path)["config"]

    if configs.has_key? config_name
        $logger.debug "   - using config: #{config_name}"
    else
        $logger.error "   - cannot find config: #{config_name}"
        #$logger.debug configs.to_yaml
        exit(1)
    end

    result = configs[config_name]
    $logger.debug(result.to_yaml)

    result
end

def checkout_repo(folder:, repo_url:, repo_branch:, options:)

    repo_subfolder = File.basename(repo_url, ".*")
    repo_subfolder_path =  File.join(folder, repo_subfolder)

    repo_subfolder_path = File.expand_path(repo_subfolder_path)

    $logger.info "fetching latest repo: #{repo_url}"
    $logger.debug "   - subfolder: #{repo_subfolder}"

    if !File.exist? repo_subfolder_path
        $logger.debug "   - git repo does not exist. first git clone: #{repo_subfolder_path}"
        FileUtils.mkdir_p repo_subfolder_path

        cmd = [
            "test -f ~/.gitconfig || git config --global http.sslVerify false",
            "cd #{folder}",
            "git clone #{repo_url}"
        ].join(" && ")

        cmd(cmd)
    else 
        $logger.debug "   - git repo exists: #{repo_subfolder_path}"
    end

    cmd = [
        "cd #{repo_subfolder_path}",
        "git checkout #{repo_branch}"
    ].join(" && ")

    $logger.info "   - git checkout #{repo_branch}"
    $logger.debug "   - running: #{cmd}" 
    cmd(cmd)
    
    cmd = [
        "cd #{repo_subfolder_path}",
        "git pull"
    ].join(" && ")

    $logger.info "   - git pull..."
    cmd(cmd)

    cmd = [
        "cd #{repo_subfolder_path}",
        "git status"
    ].join(" && ")

    $logger.info "   - git status..."
    cmd(cmd)

end

def build_site(repo_folder_path:, git_metadata:, dst_root_path:, options: )

    is_local_build = options[:is_local_build]
    docker_vuepress_container = options[:vuepress_docker_container]

    site_title = git_metadata["title"]

    docs_src_folder =  File.join(repo_folder_path, git_metadata["src_folder"])
    docs_dst_folder =  File.join(dst_root_path, git_metadata["dst_folder"])

    $logger.info "building site: #{repo_folder_path}"
    $logger.debug "   src: #{docs_src_folder}"
    $logger.debug "   dst: #{docs_dst_folder}"

    $logger.debug "   deleting old folder: #{docs_dst_folder}"
    FileUtils.rm_rf(docs_dst_folder)

    $logger.debug "   running vuepress build -d #{docs_dst_folder}"

    if is_local_build == true
        cmd = [
            "cd #{docs_src_folder}",
            "vuepress build -d #{docs_dst_folder}"
        ].join(" && ")
    else 
        cmd = [
            [
                "docker run --rm -i",
                "-v #{docs_src_folder}:/app",
                "-v #{docs_dst_folder}:/target",
                "#{docker_vuepress_container}",
                [
                    "sh << COMMANDS",
                        "mkdir /target-tmp",
                        
                        "echo 'Generating docs in /target-tmp'",
                        "cd /app && vuepress build -d /target-tmp",

                        "echo 'Copying docs from /target-tmp to /target'",                        
                        "cp -a /target-tmp/. /target",

                        "echo 'Completed generating docs!'",
                    "COMMANDS"
                ].join("\n")
            ].join(" "),
        ].join(" && ")
    end

    $logger.debug "   - running build: #{docs_dst_folder}"
    cmd(cmd)

    $logger.info "   -completed build site [#{site_title}] at: #{docs_dst_folder}"

end

def checkout_repos(git_metadata:, doco_git_cache:, options:)
    
    enable_parallel_build = options[:enable_parallel_build]
    
    if enable_parallel_build

        threads = []

        git_metadata.each do | metadata |
            $logger.info "processing: #{metadata["title"]}"

            threads << Thread.new {
                checkout_repo(
                    folder: doco_git_cache,
                    repo_url: metadata["url"],
                    repo_branch: metadata["branch"],
                    options: options
                )
            }
        end

        $logger.debug "Waiting all thread to complete..."
        threads.each { |t| t.join }
    else 
        git_metadata.each do | metadata |
            $logger.info "processing: #{metadata["title"]}"

            checkout_repo(
                folder: doco_git_cache,
                repo_url: metadata["url"],
                repo_branch: metadata["branch"],
                options: options
            )
        end
    end

    $logger.info "Completed checking out repos!"

end

def build_sites(git_metadata:, doco_git_cache:, doco_site_cache:, options:) 
    
    enable_parallel_build = options[:enable_parallel_build]
    
    if enable_parallel_build
        threads = []

        git_metadata.each do | metadata |
            
            threads << Thread.new {
                repo_subfolder = File.basename(metadata["url"], ".*")
                repo_subfolder_path =  File.join(doco_git_cache, repo_subfolder)

                build_site(
                    repo_folder_path: repo_subfolder_path,
                    git_metadata: metadata,
                    dst_root_path: doco_site_cache,
                    options: options
                )
            }

        end

        $logger.debug "Waiting all thread to complete..."
        threads.each { |t| t.join }
    else
        git_metadata.each do | metadata |
            
            repo_subfolder = File.basename(metadata["url"], ".*")
            repo_subfolder_path =  File.join(doco_git_cache, repo_subfolder)

            build_site(
                repo_folder_path: repo_subfolder_path,
                git_metadata: metadata,
                dst_root_path: doco_site_cache,
                options: options
            )
        end
    end

    $logger.info "Completed building web sites!"

end

def build_docs_web_container(doco_site_cache:, options:)

    is_local_build = options[:is_local_build]

    if is_local_build != true
        docs_web_container = options[:docs_docker_container]

        cmd = [
            [
                "docker build",
                "--no-cache",
                #"--build-arg DOCS_SRC='#{doco_site_cache}'",
                "--tag #{docs_web_container} ."
            ].join(" "),
        ].join(" && ")

        $logger.debug "   - running build: #{cmd}"
        cmd(cmd)

        $logger.info "Completed building web container: #{docs_web_container}"
    end
end

def get_tmp_folders(options:)

    temp_dir = Dir.tmpdir()
    doco_git_cache =  File.join(temp_dir, 'subpoint-docs-repos')
    doco_site_cache =  File.join(temp_dir, 'subpoint-docs-site')
   
    if !options[:git_cache_path].nil?
        doco_git_cache = options[:git_cache_path];
    end

    if !options[:site_cache_path].nil?
        doco_site_cache = options[:site_cache_path];
    end

    doco_git_cache  = File.expand_path doco_git_cache
    doco_site_cache = File.expand_path doco_site_cache

    FileUtils.mkdir_p doco_git_cache
    FileUtils.mkdir_p doco_site_cache

    $logger.debug " - git cache dir : #{doco_git_cache}"
    $logger.debug " - site cache dir: #{doco_site_cache}"

    {
        :doco_git_cache => doco_git_cache,
        :doco_site_cache => doco_site_cache
    }
end

def build_documentation(git_metadata:, options: )

    tmp_folders = get_tmp_folders(options: options)

    doco_git_cache  = tmp_folders[:doco_git_cache] 
    doco_site_cache = tmp_folders[:doco_site_cache]

    $logger.info "building subsites..."
    build_sites( 
        git_metadata: git_metadata,
        doco_git_cache: doco_git_cache,
        doco_site_cache: doco_site_cache,
        options: options
    )

    $logger.info "Completed building site at: #{doco_site_cache}"

end

def fetch_repos(git_metadata:, options:)

    tmp_folders = get_tmp_folders(options: options)
    doco_git_cache  = tmp_folders[:doco_git_cache] 
   
    $logger.info "Fetching repos into: #{doco_git_cache}"
    checkout_repos( 
        git_metadata: git_metadata,
        doco_git_cache: doco_git_cache,
        options: options
    )
end


def exec_build_docker_containers(git_metadata:, options: )

    config = options[:config]
    current_folder = options[:current_folder]
    
    docker_builds = git_metadata["docker-build"]

    require_value current_folder, "current_folder"

    if !docker_builds.nil?
        $logger.debug "Building docker containers for profile: #{config}"

        enable_parallel_build = options[:enable_parallel_build]
    
        if enable_parallel_build
            $logger.debug "Parallel build!"
            threads = []
    
            docker_builds.each do | docker_build_cmd |
                
                threads << Thread.new {
                    cmd = [
                        "cd #{current_folder}",
                        docker_build_cmd,
                    ].join(" && ")

                    cmd(cmd)
                }
    
            end
    
            $logger.debug "Waiting all thread to complete..."
            threads.each { |t| t.join }
        else
            $logger.debug "Sync build!"
            docker_builds.each do | docker_build_cmd |
                
                cmd = [
                    "cd #{current_folder}",
                    docker_build_cmd,
                ].join(" && ")

                cmd(cmd)
            end
        end
    
        $logger.info "Completed building web sites!"
    else 
        err_message = "Cannot find docker containers build for profile:  #{config}"

        $logger.debug err_message
        raise err_message

    end

end