echo "Building test containers..."
ruby /src/docs-docker.rb  -c test
echo "Building dev containers..."
ruby /src/docs-docker.rb  -c dev