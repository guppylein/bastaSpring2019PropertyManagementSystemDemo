namespace Basta.PropertyManagementSystemDemo.Entities
{
    public class Room
    {
        public Room(int id, int hotelId, int roomTypeId, string roomnumber, RoomState roomState)
        {
            Id = id;
            HotelId = hotelId;
            RoomTypeId = roomTypeId;
            Roomnumber = roomnumber;
            RoomState = roomState;
        }

        public int Id { get; private set; }
        public int HotelId { get; private set; }
        public int RoomTypeId { get; private set; }
        public string Roomnumber { get; private set; }
        public RoomState RoomState { get; private set; }
    }
}
