

def exec_publish_website(git_metadata:, options:) 

    tmp_folders = get_tmp_folders(options: options)

    doco_git_cache  = tmp_folders[:doco_git_cache] 
    doco_site_cache = tmp_folders[:doco_site_cache]

    is_local_build = options[:is_local_build]
    config         = options[:config]

    $logger.info "Publishing web site"
    $logger.debug " - is_local_build: #{is_local_build}"
    $logger.debug " - src: #{doco_site_cache}"
    $logger.debug " - config: #{config}"

    docker_netlify_container = options[:netlify_docker_container];

    netlify_site_id_id = "SPS_NETLIFY_SITE_ID_#{config.upcase}"
    netlify_api_key_id = "SPS_NETLIFY_API_KEY"

    netlify_site_id = ENV[netlify_site_id_id]
    netlify_api_key = ENV[netlify_api_key_id]

    require_value docker_netlify_container, "docker_netlify_container"
    require_value doco_site_cache, "doco_site_cache"
    require_value netlify_site_id, "netlify_site_id is empty, use ENV variable: #{netlify_site_id_id}"
    require_value netlify_api_key, "netlify_api_key is empty, use ENV variable: #{netlify_api_key_id}"

    if is_local_build == true
        cmd = [
            "ls -Rl #{doco_site_cache}",
            [
                "netlify deploy",
                "-t #{netlify_api_key}",
                "-s #{netlify_site_id}",
                "-p #{doco_site_cache}",
                " > netlify.log"
            ].join(" ")
        ].join(" && ")
    else 
        cmd = [
            [
                "docker run --rm -i",
                "-v #{doco_site_cache}:/app",
                "#{docker_netlify_container}",
                [
                    "sh << COMMANDS",
                        "ls -Rl /app",
                        "which netlify && netlify --version",

                        "echo 'Publishing netlify site from /app folder'",
                        [
                            "netlify deploy",
                            "-t '#{netlify_api_key}'",
                            "-s '#{netlify_site_id}'",
                            "-p '/app'",
                            " > netlify.log"
                        ].join(" "),
                        "echo 'Completed publishing!'",
                    "COMMANDS"
                ].join("\n")
            ].join(" "),
        ].join(" && ")
    end

    $logger.info "   - validating publishing folder: #{doco_site_cache}"
    validate_publishing_folder(
        git_metadata: git_metadata, 
        folder_path: doco_site_cache,
        options: options)

    $logger.info "   - running publishing..."
    cmd(cmd, silent: true)

    $logger.info "   - completed publishing!"
end

def validate_publishing_folder(git_metadata:, folder_path:, options:)
    
    tmp_folders = get_tmp_folders(options: options)

    tmp_folders = get_tmp_folders(options: options)
    docs_dst_folder = tmp_folders[:doco_site_cache]
    
    is_valid = true
    errors = []

    git_metadata.each do | metadata |

        $logger.info "processing: #{metadata["title"]}"
        check_folder_path =  File.join(docs_dst_folder, metadata["dst_folder"])

        $logger.info "Expecting one or more files under: #{check_folder_path}"

        files = Dir[check_folder_path + "/*"]

        if files.length <= 2
            $logger.error "  [-] FAIL"
            errors << "Found only 2 entries under: #{check_folder_path}"
        else 
            $logger.info "  [+] OK - #{files.length} entries under #{check_folder_path}"
        end
    end

    if errors.length > 0 

        errors << "vuepress generated only /404.html AND /assets entries or less, that's error"
        error_message = "\n - " + errors.join("\n - ")

        $logger.error error_message
        raise error_message
    end
end

