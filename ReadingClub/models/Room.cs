
namespace ReadingClub.models
{
    public class Room
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image {  get; set; }
        public int numberOfMembers { get; set; }
        public int numberOfBooks { get; set; }
        public Room(int ID, string Name, string Description, string Image, int numberOfMembers, int numberOfBooks)
        {
            this.ID = ID;
            this.Name = Name;
            this.Description = Description;
            this.Image = Image;
            this.numberOfMembers = numberOfMembers;
            this.numberOfBooks = numberOfBooks;
        }

    }
}
