using ReadingClub.models;
using System.Windows.Controls;

namespace ReadingClub.Controllers
{
    /// <summary>
    /// Logique d'interaction pour RoomDetailes.xaml
    /// </summary>
    public partial class RoomDetailes : UserControl
    {
        public int RoomId { get; set; }
        public RoomDetailes()
        {
            InitializeComponent();
        }
    }
}
