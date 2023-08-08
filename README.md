# Async-Inn

- name: Hasan Mufdy
- date: 16/7/2023

## ERD diagram:

![ERD](/assets/async-inn-erd.png)

## ERD diagram explanation:

this ERD is for a hotel system.
hotel name: Async Inn.

1. Location:
   the hotel has multiple locations, each one of them has a unique ID, name, city, state, address, and phone number.

2. Room:
   each room has a unique number, location_ID (which is related to the location entity), nickname, and pet permission.

- each location has rooms, and each room type exists in multiple hotel locations.

3. Amenity:
   each amenity contains a unique ID and a name.

4. Room_Amenity:
   each room has a Room_Number (which is related to the Room entity), price, and a unique ID.

- each room has amenities, and each amenity is added to multiple rooms.

- conclusion:
  Async Inn has branches in multiple locations, each branch has different room numbers and feature. rooms also vary based on amenities, features, the permission to have pets, prices, and so on.
  this system works as a management tool for the hotel and its assets.


## An example of how data is saved in the database:

![ERD](/assets/hoteldb.png)


## App architecture:

this app uses MVC design patterns, which helps organizing the code and making it easier to maintain.
this design seperate models, views, and controllers.
the implementation has three entities, which are:

- Hotel
- Room
- Amenity

each entity has a controller, interface, and a service class.

- controller: Acts as an intermediary between the Model and View, handling user input and updating the Model and View accordingly.
- Model: Represents the data and business logic of the application.
- view: handles the app's data presentation and user interaction. and it is not implemented yet in this app.

right now, the data appears as a JSON data in the browser, and an interface will be implemented in the future.


## Identity:

https://codefellows.github.io/code-401-dotnet-guide/curriculum/class-18/resources/identity.html

### file changes in the project:

there are some new files are added to implement user authentication in the project:
- UserConntroller
- ApplicationUser
- IdentityUserService
- Iuser
- LoginDTO
- RegisterUserDTO
- UserDTO

### steps for users to register and login:

1. users first have to register and enter their info:

![register](/assets/reg1.png)

2. registering response:

![register response](/assets/reg2.png)

3. users now can login using their username and password:

![login](/assets/log1.png)

4. if the login is successful:

![login successfuly](/assets/logsc.png)

