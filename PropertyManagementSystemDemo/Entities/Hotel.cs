namespace Basta.PropertyManagementSystemDemo.Entities
{
    public class Hotel
    {
        public Hotel()
        {
           
        }
        public Hotel(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
