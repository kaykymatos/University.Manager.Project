# University.Manager.Project
# How use
To start this project you will need docker into your computer and a rabbitmq application, for this install docker https://www.docker.com/products/docker-desktop/, after this you will need rabbitmq container, to download this application run this command: `docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3.13-management`.
When you run this command, if you dont have the rabbitmq installed, he will install to you.

Ok, now you have a rabbitmq we need to make a update of migrations in your computer, to do this ru the command `update-database` into Visual studio, with the IdentityServer project, and Api project selected to start, and select the infra.Data project from all projects, example:
![SetProjectToStart](https://github.com/kaykymatos/University.Manager.Project/assets/64444829/227a4275-fc31-4fb7-a1bc-e7cf94f9ba38)
![InfraData](https://github.com/kaykymatos/University.Manager.Project/assets/64444829/600c530e-1c5e-42cb-b49f-f1f0a57a9836)
![Update-database](https://github.com/kaykymatos/University.Manager.Project/assets/64444829/7b48616a-7eb7-4389-874f-d4eeb407e06e)

 After all this you will run all apis projects, the api projects has the name Api in the end, for example: `University.Manager.Project.Course.Api`, you need to run the IdentityServer project to make the authentication.
 Inside os the IdetityServer project has configured some users with diferent roles, when you start the application they will be registrated inside of local database, where you can modify the name, email, and some other informations, you can customize your user if you want, see the next image.
![Users](https://github.com/kaykymatos/University.Manager.Project/assets/64444829/a3087822-f11d-41cd-be23-e415911608fa)
 After all this you can use the project and make tests.
