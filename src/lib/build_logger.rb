
def configure_logger(logger:) 

    logger.formatter = proc do |severity, datetime, progname, message|
        _format_message(severity, datetime, progname, message)
    end

end

def _format_message(severity, datetime, progname, message)
    color_code = _get_color(severity: severity, message: message)
    "\e[#{color_code}m#{datetime} #{severity} #{message}\e[0m\n"
end

def _get_color(severity:, message:)
            
    color = 37

    case severity
    when "INFO"
        color =  32
    when "WARNING"
        color =  33
    when "WARN"
        color =  33
    when "DEBUG"
        color =  36
    when "ERROR"
        color =  31
    when "VERBOSE"
        color =  37
    end

    return color
end