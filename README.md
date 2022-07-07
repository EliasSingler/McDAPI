# IO.Swagger - ASP.NET Core 2.0 Server

This is a test API for McDonald's internship 2022. The API is able to get, create, and delete employees. An employee has an id, a name, and a title.

## Run

Linux/OS X:

```
sh build.sh
```

Windows:

```
build.bat
```

## Run in Docker

```
cd src/IO.Swagger
docker build -t io.swagger .
docker run -p 5000:5000 io.swagger
```
