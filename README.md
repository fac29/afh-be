# afh-be
Back-end repo for movies library project by Alex, Fearghal and Halimah

1. Clone the repo.
2. Run ```dotnet restore```
3. In your command terminal ```cd afh-api```
4. run ```dotnet run```
5. Make sure the localhost has ```/swagger/index.html``` at the end 
 
## Endpoints

### Users:
-   `GET /User/{id}` - Retrieve a user by id
-   `PATCH /User/{id}` - Edit a user by id
-   `DELETE /User/{id}` - Delete a user by id
-   `POST /User` - Add a user

### Movies (Patch doesn't currently work): 
-   `GET /Movie` - Get all movies
-   `GET /Movie/{id}` - Retrieve a movie by id
-   `PATCH /Movie/{id}` - Edit a movie by id
-   `DELETE /Movie/{id}` - Delete a movie by id
-   `POST /Movie` - Add a movie

### Collections: 
-   `GET /Collection` - Get all collections
-   `GET /Collection/{id}` - Retrieve a collection by id
-   `PATCH /Collection/{id}` - Edit a collection by id
-   `DELETE /Collection/{id}` - Delete a collection by id
-   `POST /Collection` - Add a collection

### Testing: 

1. cd into afh-be.Tests
2. Run ```dotnet test```

## Schema

![Movies Library (2)](https://github.com/user-attachments/assets/b67cf89e-b29c-48a4-a04b-59ade87e7704)
