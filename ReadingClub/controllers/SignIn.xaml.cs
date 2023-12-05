using ReadingClub.database;
using ReadingClub.utils.shared;
using ReadingClub.utils.validation;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ReadingClub.Controllers
{
    /// <summary>
    /// Logique d'interaction pour SignIn.xaml
    /// </summary>
    public partial class SignIn : Page
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void GoToSignUpPage(object sender, MouseButtonEventArgs e)
        {
            SignUp signUpPage = new SignUp();
            this.NavigationService.Navigate(signUpPage);
        }

        private void SignInHandler (object sender, EventArgs e)
        {
            string email = emailInput.Text;
            string password = passwordIput.Password;

            var errors = UserValidation.SignInValidation(email, password);

            if (errors.HasErrors())
            {
                emailErrorLabel.Content = errors.EmailError;
                passwordErrorLabel.Content = errors.PasswordError;
            } else
            {
                emailErrorLabel.Content = "";
                passwordErrorLabel.Content = "";

                AuthActionResult result = DatabaseHelper.SignIn(email, password);
                if (result.Status == OperationStatus.SUCCESS)
                {
                    //MessageBox.Show(result.Message + "                      ", "Login Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.NavigationService.Navigate(new Dashboard(result.user));
                }
                else
                {
                    MessageBox.Show(result.Message + "                      ", "Login Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }


        }
    }
}
