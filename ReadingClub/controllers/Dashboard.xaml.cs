using ReadingClub.models;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace ReadingClub.Controllers
{
    /// <summary>
    /// Logique d'interaction pour Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page
    {
        private User loggedInUser;
        public Dashboard(User user)
        {
            InitializeComponent();
            loggedInUser = user;

            LoadUserData();

            RoomList roomList = new RoomList();
            roomList.RoomNavigateButtonClicked += RoomList_RoomNavigateButtonClicked;
            outletGrid.Children.Add(roomList);
        }

        private void LoadUserData()
        {
            if (loggedInUser != null)
            {
                fullNameTextBlock.Text = loggedInUser.firstName + " " + loggedInUser.lastName;
                userNameTextBlock.Text = loggedInUser.username;
                userFirstLetter.Text = loggedInUser.firstName.ToUpper().Substring(0, 1);
            }
        }

        private void RoomList_RoomNavigateButtonClicked(object sender, EventArgs e)
        {
            RoomDetailes newContent = new RoomDetailes();
            outletGrid.Children.Clear();
            outletGrid.Children.Add(newContent);
        }
    }
}
