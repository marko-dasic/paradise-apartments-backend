The project was developed in ASP .NET Core.
Dotnet version 7.

The project represents a system that contains an API serving clients.
The application is intended for renting apartments for a specific period.

The application consists of 4 class libraries and 1 API:

- Domain
- DataAccess
- Application
- Implementation
- RESTful API

The application is used by unauthorized users, authorized users, and administrators.
There are no strictly defined roles; instead, privileges are managed at the Use Case level.
Each user has a collection of use case identifiers that they are allowed to execute.

During registration, the user is granted only the most basic functionalities.
Rights to additional use cases can be assigned to them by an administrator.

Administrator can:

- Update, delete, and view all users
- Delete comments
- View all reservations and delete them
- Add a city
- Add a category
- Assign certain privileges to other users (IdUseCase)
- Add a list of specifications (Wi-Fi, Parking, Air Conditioning, Elevator)
- Assign specifications to a specific apartment
- Add and update apartment prices
- Delete apartment ratings


Authorized user can:

- Log out
- Comment on an apartment
- Rate an apartment
- Create a reservation
- Create report items
- View and delete reports
- Delete their own account
- Delete apartment ratings
- Update their own account


Unauthorized user can:

- Log in
- Registration
- View all apartments as well as their specifications



Comments can have child comments, but they don’t necessarily have to.

The “UserUseCase” table is used for recording and keeping track of all executed operations.

No user can rate the same apartment more than once.

Users have their roles in the form of UseCase IDs.

Filtering and pagination are enabled on the main tables: Apartment, Reservation, User

For authorization, a JWT token is used.

Each endpoint contains a detailed description of its function within the system.


<img width="1344" height="937" alt="image" src="https://github.com/user-attachments/assets/a189aba3-dcbc-460d-98de-4fb8ce5e180e" />






