# TC2

docker run --name ubuntu -e HOST_IP=192.168.1.166  -v //d/GitHub  -t -i  ubuntu /bin/bash 
docker run --name mysql -e MYSQL_ROOT_PASSWORD=1234 MYSQL_DATABASE=test-dbdocker -v //data:/var/lib/msql:rw -p 3308:3306 -d mysql 
docker run --name mysql -e MYSQL_ROOT_PASSWOR D=1234 -e MYSQL_DATABASE=test-dbdocker //data:/var/lib/msql:rw -p 3308:3306 -d mysql 
docker run --name mysql -e MYSQL_ROOT_PASSWORD=1234 -e MYSQL_DATABASE=test-dbdocker -v //d/t:/var/lib/mysql -p 3308:3306 -d mysql 
docker run --name ubuntu -e HOST_IP=192.168.1.166  -v //d/GitHub:/test  -t -i  ubuntu /bin/bash 

docker run -it --rm --name my-running-script -v //d/GitHub:/test  -w /test python:3 python test.py 
docker build -t test-python . 
docker run -it --rm --name my-running-app test-python 



 

Dotnet 

 

docker build -t aspnetapp . 
docker build --pull -t aspnetapp . 
docker run --name aspnetapp --rm -it -p 8080:80 /aspnetapp 

docker run -it --rm -p 8080:80 --name testapp aspnetapp 

 
create a virtual environment 
py -m venv env

start the env
    source env/Scripts/activate

freeze dependencies
    pip freeze > req.txt

install dependencies
    pip install -r req.txt

install local dependencies
     pip install "\backend\libs\mysqlclient-1.4.4-cp37-cp37m-win32.whl"

