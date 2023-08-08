using Async_Inn.Models;
using Async_Inn.Models.Services;

namespace Async_Inn_Test
{
    public class UnitTest1 : Mock
    {

        [Fact]
        public async void Test_Creating_New_Hotel()
        {

            // Arrange
            var hotelName = "Hotel1";
            var streetAddress = "st";
            var city = "Amman";
            var phone = "5465465";
            var state = "1";

            // Act
            var hotel = await CreateHotel(new Hotel
            {
                Name = hotelName,
                StreetAddress = streetAddress,
                City = city,
                Phone = phone,
                State = state
            });

            // Assert
            Assert.NotNull(hotel);
            Assert.Equal(hotelName, hotel.Name);
            Assert.Equal(streetAddress, hotel.StreetAddress);
            Assert.Equal(city, hotel.City);
            Assert.Equal(phone, hotel.Phone);
            Assert.Equal(state, hotel.State);
        }


        [Fact]
        public async void Test_Adding_Hotel()
        {
            var hotelName = "Hotel1";
            var streetAddress = "st";
            var city = "Amman";
            var phone = "5465465";
            var state = "1";

            var hotel = await CreateHotel(new Hotel
            {
                Name = hotelName,
                StreetAddress = streetAddress,
                City = city,
                Phone = phone,
                State = state
            });

            var Hotelservics = new HotelService(_db);

            var Hotelid = await Hotelservics.GetHotel(hotel.ID);

            Assert.NotEqual(0, Hotelid.ID);


        }



        [Fact]
        public async void Test_Adding_New_Room()
        {
            // Arrange
            var Name = "room";
            var Layout = 2;
            
            // Act
            var room = await CreateAndSaveRoom(new Room
            {
                Name = Name,
                Layout = 1 
            });

            // Assert
            Assert.NotNull(room);
            Assert.Equal(Name, room.Name);
            Assert.Equal(Layout, room.Layout);
            
        }
        [Fact]
        public async void Test_Creating_New_Room()
        {
            // Arrange
            var roomName = "room";
            var layout = 2;

            // Act
            var room = await CreateAndSaveRoom(new Room
            {
                Name = roomName,
                Layout = layout
            });

            // Assert
            var Roomservices = new RoomService(_db);

            var roomNAME = await Roomservices.GetRoom(room.Id);

            Assert.NotEqual("", roomNAME.Name);
        }

        [Fact]
        public async void Test_Deleting_Room()
        {
            // Arrange
            var roomName = "room";
            var layout = 2;

            var room = await CreateAndSaveRoom(new Room
            {
                Name = roomName,
                Layout = layout
            });

            var roomService = new RoomService(_db);

            // Act
            var deletedRoom = await roomService.Delete(room.Id);

            // Assert
            Assert.NotNull(deletedRoom);
            Assert.Equal(roomName, deletedRoom.Name);
            Assert.Equal(layout, deletedRoom.Layout);
        }


        [Fact]
        public async void Test_Getting_All_Hotels()
        {
            // Arrange
            var hotel1 = await CreateHotel(new Hotel
            {
                Name = "Hotel1",
                StreetAddress = "Address1",
                City = "City1",
                Phone = "12345",
                State = "State1"
            });

            var hotel2 = await CreateHotel(new Hotel
            {
                Name = "Hotel2",
                StreetAddress = "Address2",
                City = "City2",
                Phone = "67890",
                State = "State2"
            });

            var hotelService = new HotelService(_db);

            // Act
            var hotels = await hotelService.GetHotels();

            // Assert
            Assert.Equal(5, hotels.Count);
            Assert.Contains(hotels, h => h.Name == hotel1.Name);
            Assert.Contains(hotels, h => h.Name == hotel2.Name);
        }

        [Fact]
        public async void Test_Getting_All_Rooms()
        {
            // Arrange
            var room1 = await CreateAndSaveRoom(new Room
            {
                Name = "Room1",
                Layout = 1
            });

            var room2 = await CreateAndSaveRoom(new Room
            {
                Name = "Room2",
                Layout = 2
            });

            var roomService = new RoomService(_db);

            // Act
            var rooms = await roomService.GetRooms();

            // Assert
            Assert.Equal(5, rooms.Count);
            Assert.Contains(rooms, r => r.Name == room1.Name);
            Assert.Contains(rooms, r => r.Name == room2.Name);
        }



        [Fact]
        public async void Test_Getting_Room_By_Id()
        {
            // Arrange
            var room = await CreateAndSaveRoom(new Room
            {
                Name = "Room1",
                Layout = 1
            });

            var roomService = new RoomService(_db);

            // Act
            var retrievedRoom = await roomService.GetRoom(room.Id);

            // Assert
            Assert.NotNull(retrievedRoom);
            Assert.Equal(room.Name, retrievedRoom.Name);
            Assert.Equal(room.Layout, retrievedRoom.Layout);
        }

        [Fact]
        public async void Test_Getting_Hotel_By_Id()
        {
            // Arrange
            var hotel = await CreateHotel(new Hotel
            {
                Name = "Hotel1",
                StreetAddress = "Address1",
                City = "City1",
                Phone = "12345",
                State = "State1"
            });

            var hotelService = new HotelService(_db);

            // Act
            var retrievedHotel = await hotelService.GetHotel(hotel.ID);

            // Assert
            Assert.NotNull(retrievedHotel);
            Assert.Equal(hotel.Name, retrievedHotel.Name);
            Assert.Equal(hotel.StreetAddress, retrievedHotel.StreetAddress);
            Assert.Equal(hotel.City, retrievedHotel.City);
            Assert.Equal(hotel.Phone, retrievedHotel.Phone);
            Assert.Equal(hotel.State, retrievedHotel.State);
        }


        //[Fact]
        //public async void Test_Deleting_Hotel()
        //{
        //    var hotelName = "Hotel1";
        //    var streetAddress = "st";
        //    var city = "Amman";
        //    var phone = "5465465";
        //    var state = "1";

        //    var hotel = await CreateHotel(new Hotel
        //    {
        //        Name = hotelName,
        //        StreetAddress = streetAddress,
        //        City = city,
        //        Phone = phone,
        //        State = state
        //    });




        //    //var hotelService = new HotelService(_db);
        //    //var hotelID = await hotelService.GetHotel(1);
        //    var deletedHotel = await hotelService.Delete(hotel.ID);

        //    Assert.Equal(hotel.Name, deletedHotel.Name);
        //    //Assert.Equal(deletedHotel.Name, hotel.Name);


        //    //Assert.Null(deletedHotel);
        //    //Assert.Equal(deletedHotel.Name, hotel.Name);
        //}

    }
}