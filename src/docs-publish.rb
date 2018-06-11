#!/usr/bin/ruby 

require_relative 'lib/build_helpers.rb'
require_relative 'lib/build_logger.rb'
require_relative 'lib/build_publish.rb'

$logger = Logger.new(STDOUT)
configure_logger(logger: $logger) 

current_folder = File.expand_path(File.dirname(__FILE__))
config_file    = current_folder + "/build.yaml"
$logger.debug "Running in folder: #{current_folder}"

$logger.debug "Parsing command line params"

options = {
    :site_cache_path           => current_folder + "/.docs-build",
    :is_local_build            => false,
    :netlify_docker_container  => "subpoint/netlify-cli"
}

parser = OptionParser.new do|opts|

    opts.banner = ""
   
    opts.on('-c', '--config=VALUE', 'Config to use') do |value|
		  options[:config] = value;
	  end

    opts.on('-s', '--site-cache-path=VALUE', 'Where to build doco web site') do |name|
      options[:site_cache_path] = name;
    end

    opts.on('-p', '--parallel', 'Enable parallel build') do |name|
	  	options[:enable_parallel_build] = true;
    end

    opts.on('-n', '--netlify-container=VALUE', 'Container for netlify-cli') do |name|
      options[:netlify_docker_container] = name;
    end
      
    opts.on('-l', '--local', 'Local build, no docker containers will be used') do |name|
      options[:is_local_build] = true;
    end
    
end

parser.parse!

$logger.debug "Running with options:"
$logger.debug options.to_yaml

$logger.debug("Reading docs metadata configuration")
git_metadata = load_git_metadata(config_name: options[:config], file_path: config_file)

$logger.info("Publishing web site...")

exec_publish_website(git_metadata: git_metadata["repos"], options: options)
$logger.info("Completed!")

exit(0)