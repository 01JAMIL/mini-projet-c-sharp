using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingClub.models
{
    public class Book
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Language { get; set; }
        public string AuthorName { get; set; }
        public int NumberOfPages { get; set; }
        public int NumberOfLikes { get; set; }
        public int RoomId { get; set; }
        public bool Favorite { get; set; }
        public bool CurrentlyReading { get; set; }
        public bool WantToRead { get; set; }

        public Book (int id, string name, string description, string image, string language, string authorName, int numberOfPages, int numberOfLikes, int roomId, bool favorite, bool currentlyReading, bool wantToRead)
        {
            ID = id;
            Name = name;
            Description = description;
            Image = image;
            Language = language;
            AuthorName = authorName;
            NumberOfPages = numberOfPages;
            NumberOfLikes = numberOfLikes;
            RoomId = roomId;
            Favorite = favorite;
            CurrentlyReading = currentlyReading;
            WantToRead = wantToRead;
        }
    }
}
