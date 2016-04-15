## excutable image.
docker run -it --name web -v $(pwd):/project -w /project node:4 bash

or

docker run --rm -v $(pwd):/project -w /project %imageid% %cmd%
