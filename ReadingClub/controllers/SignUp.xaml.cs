using ReadingClub.database;
using ReadingClub.models;
using ReadingClub.utils.shared;
using ReadingClub.utils.validation;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ReadingClub.Controllers
{
    public partial class SignUp : Page
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void GoToSignInPage (object sender, MouseButtonEventArgs e)
        {
            SignIn signInPage = new SignIn();
            this.NavigationService.Navigate(signInPage);
        }

        private void SignUpHandler (object sender, EventArgs e)
        {
            string firstName = firstNameInput.Text;
            string lastName = lastNameInput.Text;
            string email = emailInput.Text;
            string userName = userNameInput.Text;
            string password = passwordIput.Password;

            User userData = new User(firstName, lastName, email, userName, password);
            var errors = UserValidation.SignUpValidation(userData);

            if (errors.HasErrors())
            {
                // Handle the errors
                firstNameErrorLabel.Content = errors.FirstNameError;
                lastNameErrorLabel.Content = errors.LastNameError;
                emailErrorLabel.Content = errors.EmailError;
                usernameErrorLabel.Content = errors.UserNameError;
                passwordErrorLabel.Content = errors.PasswordError;
            } else
            {
                // Go with the signup logic
                firstNameErrorLabel.Content = "";
                lastNameErrorLabel.Content = "";
                emailErrorLabel.Content =  "";
                usernameErrorLabel.Content = "";
                passwordErrorLabel.Content = "";

                AuthActionResult result = DatabaseHelper.SignUp(userData);
          
                if (result.Status == OperationStatus.SUCCESS)
                {
                    MessageBox.Show(result.Message + "                      ", "Registration Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    firstNameInput.Text = "";
                    lastNameInput.Text = "";
                    emailInput.Text = "";
                    userNameInput.Text = "";
                    passwordIput.Password = "";
                }
                else
                {
                    MessageBox.Show(result.Message + "                      ", "Registration Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }


        }
    }
}