namespace Basta.PropertyManagementSystemDemo.ViewModels
{
    public class RoomViewModel
    {
        public RoomViewModel(int id, int hotelId, string name)
        {
            Id = id;
            HotelId = hotelId;
            Name = name;
        }

        public int Id { get; }
        public int HotelId { get; }
        public string Name { get; }
    }
}
