namespace Basta.PropertyManagementSystemDemo.ViewModels
{
    public class RoomViewModel
    {
        public RoomViewModel() { }

        public RoomViewModel(int id, int hotelId, string name, int capacity)
        {
            Id = id;
            HotelId = hotelId;
            Name = name;
            Capacity = capacity;
        }

        public int Id { get; set; }
        public int HotelId { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
    }
}
