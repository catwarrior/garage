## composer
``` Dockerfile
FROM ubuntu:14.04
RUN apt-get install -qqy php5-cli php5-json curl
RUN curl -sS https://getcomposer.org/installer | php
VOLUME ["/srv"]
WORKDIR /srv
# not recommended, but it works, 
# you could also create seperate user, but have to handle permission stuff.
USER root
ENTRYPOINT ["/composer.phar"]
```
