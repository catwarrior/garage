## excutable image.
docker run -it --name web -v $(pwd):/project -w /project node:4 bash

or

docker run --rm -v $(pwd):/project -w /project %imageid% %cmd%
### Step 1
docker run创建了一个yi'ge镜像的一个实例。该实例中执行了一个%cmd%命令。原则上，这不会影响主机系统。 

 -v $(pwd):/project将当前目录挂载到容器中，作为/project目录。这样以来，容器就可以读写主机系统的当前目录了。 

 -w /project设置了/project作为工作目录。这意味着执行%cmd%命令将在project目录中有效。 

 --rm将在执行完毕后删除容器。甩掉包袱！ 

### Step
Dockefile
FROM maven:3.3.3-jdk-8
WORKDIR /project
ENTRYPOINT ["mvn"]
CMD ["-h"]

The using command

user:project$ docker run --rm \ 
              -v $(pwd):/project \ 
              my_mvn clean install

## Dockhubs
https://hub.tenxcloud.com

## Docker tips
http://www.cnblogs.com/elnino/p/3899136.html
