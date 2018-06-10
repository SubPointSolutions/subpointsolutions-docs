

def exec_publish_website(options:) 

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
                        "ls -la /app",
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

    $logger.info "   - running publishing..."
    cmd(cmd, silent: true)

    $logger.info "   - completed publishing!"



end