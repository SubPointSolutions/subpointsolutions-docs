FROM node:9.11.1-alpine

ARG VUEPRESS_VERSION=latest

# vue press install
# https://vuepress.vuejs.org/
RUN npm install -g vuepress@${VUEPRESS_VERSION}

# fixes temporary prettier issue
# Module build failed: Error: No parser and no file path given, couldn't infer a parser.
# https://stackoverflow.com/questions/50555953/vue-webpack-template-missing-parser
RUN cd /usr/local/lib/node_modules/vuepress \
    && npm i prettier@~1.12.0

# viepress validation
RUN  mkdir -p /tmp/vuepress-app \
    && cd /tmp/vuepress-app \
    && echo '# Hello VuePress' > README.md \
    && vuepress --version \
    && vuepress build 

WORKDIR /app