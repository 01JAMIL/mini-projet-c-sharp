namespace ReadingClub.utils.shared
{
    public class RoomEventArgs: EventArgs
    {
        public int RoomId { get; private set; }
        public RoomEventArgs(int roomId)
        {
            RoomId = roomId;
        }
    }

    public class BookEventArgs : EventArgs
    {
        public int BookId { get; }

        public BookEventArgs(int bookId)
        {
            BookId = bookId;
        }
    }

}
