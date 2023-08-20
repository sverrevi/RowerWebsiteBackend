# RowerWebsiteBackend

# Summary
This repository consists of the code for the backend of a personal fullstack web application project. The backend currently generates two model objects; Rower and RowingClub. These two objects have a many to many relationship, as one rower can be member of multiple rowing clubs, while one rowing club can have multiple members (rowers).

The endpoints generated are tested using [Swagger UI](https://swagger.io/tools/swagger-ui/). The backend utilizes an Azure SQL database, and Object Relational Mappings (ORM) are used with [Entity Framework 7.0.9](https://learn.microsoft.com/en-us/aspnet/entity-framework).
