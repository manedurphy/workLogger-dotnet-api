The purpose of this mini-project was to familiarize myself with the .NET Core framework for building a restful API, as well as develop an 
understanding of how to deploy this application inside a Docker container. 

# What the Application Does
For the API, I've recreated two models from my WorkLogger application (https://github.com/manedurphy/Work-Log-App) -- User and Task. I set up controllers for
both models to receive HTTP requests and store data into a MySQL database. The connection between the controllers and database is mediated through individual
repositories set up for each model. Each repository inherits the properties of the BaseRepository class; and in turn, repositories for each model define its own
unique methods specific to the needs of the controller. By using the Repository Pattern in this manner, the controllers do not have direct access the
Database Context of the application, and instead, the Respitory acts as a mediator. Benefits of this pattern include encapsulating the common CRUD methods
shared between repositories such that any changes necessary to a method will be applied wherever it is used, as well as allows the application to manipulate the
data as is done here with the help of the AutoMapper package.

TLDR: .NET Core RESTful API with two models (User & Task) connected to MySQL Database. I make use of the Repository pattern, AutoMapper, and Data Transfer Objects

# Mapping
With the help of the AutoMapper package, within the controller logic, data that is received from the repository is then mapped to a Data Transfer Object which
holds the properties that are sent to the client. For the User model, data that is queried from the database contains the "password" and "tasks" properties (task 
being a SQL relationship). When the User object is mapped to the UserReadDto, the UserReadDto is then sent to the client without those properties. While the purpose 
of this mini-project was to practice and understand this concept, it is clear why excluding sensitive information such as a password would be important which is why
I chose to hide that property. For the Task model, the "UserId" property is not sent to the client (again, only excluding that property for practice).

TLDR: The AutoMapper library was used to select which properties from an object would be sent to the client (i.e. I excluded the "password" and "tasks" properties
from User)

# Validation
Validation for Post and Put requests is handled with the help of the FluentValidation library, where I ensure all necessary fields are filled correctly before
saving changes to the database. ActionResult (BadRequest and NotFound) are returned with respective messages to the client to describe the error that occurred,
ensuring that the client would be able to correct the mistake. Validation response messages are stored in a static class for ease of repetition.

TLDR: I used FluentValidation to ensure all data sent to each controller was filled out correctly. The client receives proper status codes and error messages when
something ges wrong

# Docker (Development)
For development, I used a docker-compose.yml file to create 2 services: MySQL and the Application. The MySQL container was built using the MySQL:5.7 image from
DockerHub, and the Envirnment variables to create the database credentials were set in a .env file on my local machine. The API container was built with a local 
Dockerfile with a dependency on the MySQL container as well as an Environment variable set for the connection string. The image for my API was pushed to my
DockerHub account for later use in deployment.

TLDR: Two docker containers set. One for a MySQL database and the other for the API.

# Deployment (an absolute headache)
Deployment of this application was done on an EC2 instance through AWS (free tier of course). Through the terminal, I accessed the EC2 instance via SSH and first
installed Docker on the machine:
  1. sudo yum update -y
  2. sudo amazon-linux-extras install docker
  3. sudo service docker start
  4. sudo usermon -a -G docker ec2-user (...to stop having to type "sudo")
 
 From here I created a container for a MySQL database with the following commands:
  1. docker network create api-net
  2. docker run -d -e MYSQL_DATABASE=<dbName> -e MYSQL_USER=<dbUsername> 
     -e MYSQL_PASSWORD=<password> -e MYSQL_ROOT_PASSWORD=<rootPassword>
     -p 3306:3306 --network api-net --rm --name mysqldb -v data:/var/lib/mysql mysql:5.7
  
Command description: This command runs the docker container in detached mode, sets the database credentials in envrionment variables with the -e flags, exposes
the default port of MySQL, names the container, sets it to remove on shutdown, assigns it to a docker network, and set a named volume for data persistance upon
container removal. By creating a docker network, I can set up my API container to communicate with the mysqldb container using its name in the connection string.

To ensure the database would be ready to make a connection with the yet-to-be-made API container, I ran the commands:
  1. docker exec -it mysqldb bash -l
  2. mysql -u <dbUsername> -p <password>
  3. Copied the SQL Script from the db.sql file in this repo into the command line

I did not want to have code set to run migrations at runtime, so I manually created the necessary tables by creating a SQL Script on my local machine using the
dotnet ef cli tool. A "hacky" step, but one I took for the sake of getting the application working online. 

Command for initializing API container:
  1. docker run --name work-logger --rm -p 80:80 -d -e MYSQL_CONNECTION="server=mysqldb;
     userid=<dbUsername>; pwd=<password>; port=3306; database=<dbName>" --network api-net <imageFromDockerHub>
 
 In the connection string I set as an Environment variable, we can see I addressed server as "mysqldb", again emphasizing I am able to reference the mysqldb 
 container by name when the containers are within the same docker network. On my local machine, this value is set to "localhost".
 
 # Conclusion
 With all of these steps completed, the applicatioon was online an operational, and tested using Postman as a client. I feel that this mini-project helped me
 develop a better understanding of common patterns seen in the .NET Core framework, how to set up Docker containers in development and production, as well as 
 understanding a way of deploying an application through a major cloud service. I am hoping to better familiarize myself with Object Oriented Programming through
 C# and .NET, as well as setup a fullstack project with another .NET RESTful API connected with a React application, and deployed on ECS with a load balancer.
 
 
 
 
 
 
