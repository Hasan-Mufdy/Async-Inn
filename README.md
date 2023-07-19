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