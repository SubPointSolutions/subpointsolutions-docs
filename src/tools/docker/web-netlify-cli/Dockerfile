FROM node:9.11.1-alpine

ARG NETLIFYCLI_VERSION=latest

# netlify-cli install
RUN npm install netlify-cli@${NETLIFYCLI_VERSION} -g --unsafe-perm

# netlify-cli validation
RUN which netlify && netlify --version