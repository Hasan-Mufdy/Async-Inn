using Async_Inn.Models;
using Async_Inn.Models.Services;

namespace Async_Inn_Test
{
    public class UnitTest1
    {

        [Fact]
        public async void Test_Creating_New_Hotel()
        {
            // Arrange
            var hotelName = "Hotel1";
            var streetAddress = "st";
            var city = "City";
            var phone = "546465";
            var state = "a";

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
        public async void Test_Deleting_Hotel()
        {
            var hotel = await CreateHotel();

            var hotelservice = new HotelServices(_db);
            var deletedhotel = await hotelservice.Delete(hotel.Id);

            Assert.NotNull(deletedhotel);
            Assert.Equal(hotel.Id, deletedhotel.ID);
        }

        [Fact]
        public async void Test_Adding_Hotel()
        {
            var Hotel = await CreateHotel();

            var Hotelservics = new HotelServices(_db);

            var Hotelid = await Hotelservics.GetHotelId(Hotel.Id);

            Assert.NotEqual(0, Hotelid.ID);

        }

        [Fact]
        public async void Test_Creating_And_Saving_Room()
        {
            // Arrange
            var roomName = "Room1";
            var layout = 2;

            // Act
            var room = await CreateAndSaveRoom(new Room
            {
                Name = roomName,
                Layout = layout
            });

            // Assert
            Assert.NotNull(room);
            Assert.Equal(roomName, room.Name);
            Assert.Equal(layout, room.Layout);
        }


    }
}