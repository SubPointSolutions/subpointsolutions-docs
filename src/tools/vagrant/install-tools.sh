# ruby/git is used to execute docker-ized builds under Windows -> Vagrant -> Ruby -> Docker
# MacBook users Ruby -> Docker directly without Vagrant jump

echo 'Installing ruby...'
pkg install ruby && which ruby && ruby --version

echo 'Installing git...'
pkg install git && which git && git --version