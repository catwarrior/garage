## dockerize `composer`
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

Usage:
``` bash
docker run -i -t -v ~/xxx/xxx:/srv composer create-project symfony/framework-standard-edition AcmeDemo
```
or add alias first
``` bash
alias composer='docker run -i -t -v $PWD:/srv composer'
```
and then

``` bash
composer create-project symfony/framework-standard-edition AcmeDemo
```
