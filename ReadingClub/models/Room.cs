
namespace ReadingClub.models
{
    public class Room
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string Image {  get; set; }

        public Room(int ID, string Name, string Description, string Image)
        {
            this.ID = ID;
            this.Name = Name;
            this.Description = Description;
            this.Image = Image;
        }

    }
}
