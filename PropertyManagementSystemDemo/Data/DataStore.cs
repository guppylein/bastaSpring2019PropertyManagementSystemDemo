using Basta.PropertyManagementSystemDemo.Entities;

namespace Basta.PropertyManagementSystemDemo.Data
{
    public static class DataStore
    {
        public static void BuildData()
        {
            var hotel1 = new Hotel { Id = 1, Name = "Marriott Frankfurt" };

            var hotel2 = new Hotel { Id = 2, Name = "Novotel Frankfurt" };

            var singleRoomHotel1 = new RoomType(1, 1, "Single room", 1);
            var doubleRoomHotel1 = new RoomType(2, 1, "Double room", 2);
            var doubleRoomHotel2 = new RoomType(3, 2, "Double room", 2);

            var zimmer1Hotel1 = new Room(1, 1, 1, "1-01", RoomState.Available);
            var zimmer2Hotel1 = new Room(2, 1, 2, "1-02", RoomState.Available);
            var zimmer3Hotel1 = new Room(3, 1, 2, "1-03", RoomState.OutOfOrder);
        }
    }
}
