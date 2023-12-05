using ReadingClub.models;
using System.Windows.Controls;

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

            if (loggedInUser != null)
            {
                fullNameTextBlock.Text = loggedInUser.firstName + " " + loggedInUser.lastName;
                userNameTextBlock.Text = loggedInUser.username;
                userFirstLetter.Text = loggedInUser.firstName.ToUpper().Substring(0, 1);
            }
        }
    }
}
