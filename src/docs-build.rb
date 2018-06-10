#!/usr/bin/ruby 

require_relative 'lib/build_logger.rb'
require_relative 'lib/build_helpers.rb'

$logger = Logger.new(STDOUT)
configure_logger(logger: $logger) 

current_folder = File.expand_path(File.dirname(__FILE__))
config_file    = current_folder + "/build.yaml"

$logger.debug "Running in folder: #{current_folder}"

$logger.debug "Parsing command line params"

options = {
    :config                    => "dev",
    :git_cache_path            => "./.docs-source",
    :site_cache_path           => "./.docs-build",
    :is_local_build            => false,
    :vuepress_docker_container => "subpoint/vuepress"
}

parser = OptionParser.new do|opts|

    opts.banner = ""
   
    opts.on('-c', '--config=VALUE', 'Config to use') do |value|
      options[:config] = value;
    end

    opts.on('-s', '--site-cache-path=VALUE', 'Where to build doco web site') do |name|
      options[:site_cache_path] = name;
    end

    opts.on('-p', '--parallel=VALUE', 'Enable parallel build') do |name|
      options[:enable_parallel_build] = true;
    end
    
    opts.on('-v', '--vuepress-container=VALUE', 'Container for vuepress') do |name|
      options[:vuepress_docker_container] = name;
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

$logger.info("Building documentation...")

build_documentation(git_metadata: git_metadata["repos"], options: options)
$logger.info("Completed!")

exit(0)