#!/usr/bin/ruby 

require_relative 'lib/build_helpers.rb'
require_relative 'lib/build_logger.rb'
require_relative 'lib/build_publish.rb'

$logger = Logger.new(STDOUT)
configure_logger(logger: $logger) 

current_folder = File.expand_path(File.dirname(__FILE__))
$logger.debug "Running in folder: #{current_folder}"

$logger.debug "Parsing command line params"

options = {
    :site_cache_path       => "./.docs-build",
    :www_docker_container  => "subpoint/docs-web",
    :local                  => false
}

parser = OptionParser.new do|opts|

    opts.banner = ""
   
    opts.on('-s', '--site-cache-path=VALUE', 'Where to build doco web site') do |name|
      options[:site_cache_path] = name;
    end

    opts.on('-w', '--www-container=VALUE', 'Container for serving web content') do |name|
      options[:netlify_docker_container] = name;
    end     

    opts.on('-l', '--local', 'No volume mapping') do |name|
      options[:local] = true;
    end     
    
end

parser.parse!

$logger.debug "Running with options:"
$logger.debug options.to_yaml

tmp_folders = get_tmp_folders(options: options)
doco_site_cache = tmp_folders[:doco_site_cache]

container_tag = options[:www_docker_container]

$logger.info("Starting nginx container...")
$logger.debug(" - container: #{container_tag}")
$logger.debug(" - folder: #{doco_site_cache}")

local = options[:local] == true

cmd = [
  "docker run --rm -it",
  local ? "" : "-v #{doco_site_cache}:/var/www",
  "-p 80:80",
  container_tag
].join(" ")

cmd(cmd)

$logger.info("Completed!")

exit(0)