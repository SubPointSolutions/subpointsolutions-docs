#!/usr/bin/ruby 

require_relative 'lib/build_logger.rb'
require_relative 'lib/build_helpers.rb'

$logger = Logger.new(STDOUT)
configure_logger(logger: $logger) 

current_folder = File.expand_path(File.dirname(__FILE__))
$logger.debug "Running in folder: #{current_folder}"

$logger.debug "Parsing command line params"

options = {
    :config => "dev",
    :current_folder => current_folder
}

parser = OptionParser.new do|opts|

    opts.banner = ""
   
    opts.on('-c', '--config=VALUE', 'Config to use') do |value|
      options[:config] = value;
    end
end

parser.parse!
options[:current_folder] = current_folder


$logger.debug "Running with options:"
$logger.debug options.to_yaml

$logger.debug("Reading docs metadata configuration")
git_metadata = load_git_metadata(config_name: options[:config], file_path:  current_folder + "/build.yaml")

$logger.info("Building docker containers...")

exec_build_docker_containers(options: options, git_metadata: git_metadata)
$logger.info("Completed!")

exit(0)