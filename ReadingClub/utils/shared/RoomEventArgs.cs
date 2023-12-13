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
}
