namespace Basta.PropertyManagementSystemDemo.Entities
{
    public class RoomType
    {
        public RoomType(int id, int hotelId, string typ, int capacity)
        {
            Id = id;
            HotelId = hotelId;
            Typ = typ;
            Capacity = capacity;
        }

        public int Id { get; private set; }
        public int HotelId { get; private set; }
        public string Typ { get; private set; }
        public int Capacity { get; private set; }
    }
}
