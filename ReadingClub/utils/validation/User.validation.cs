using ReadingClub.models;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ReadingClub.utils.validation
{

    internal class SignUpValidationSchema
    {
        public string FirstNameError { get; set; }
        public string LastNameError { get; set;}
        public string EmailError { get; set; }
        public string UserNameError { get; set; }
        public string PasswordError { get; set; }

        public bool HasErrors()
        {
            return !string.IsNullOrEmpty(FirstNameError) ||
                   !string.IsNullOrEmpty(LastNameError) ||
                   !string.IsNullOrEmpty(EmailError) ||
                   !string.IsNullOrEmpty(UserNameError) ||
                   !string.IsNullOrEmpty(PasswordError);
        }
    }

    internal class SignInValidationSchema
    {
        public string EmailError { get; set; }
        public string PasswordError { get; set; }

        public bool HasErrors()
        {
            return !string.IsNullOrEmpty(EmailError) || !string.IsNullOrEmpty(PasswordError);
        }
    }

    internal class UserValidation
    {
        public static SignUpValidationSchema SignUpValidation(User user)
        {
            var errors = new SignUpValidationSchema();

            if (string.IsNullOrWhiteSpace(user.firstName))
            {
                errors.FirstNameError = "First name is required";
            }

            if (string.IsNullOrWhiteSpace(user.lastName))
            {
                errors.LastNameError = "Last name is required";
            }

            if(string.IsNullOrWhiteSpace(user.email))
            {
                errors.EmailError = "Email is required";
            }
            else if(!IsValidEmail(user.email))
            {
                errors.EmailError = "Incorrect email format";
            }

            if (string.IsNullOrWhiteSpace(user.username))
            {
                errors.UserNameError = "Username is required";
            }

            if (string.IsNullOrWhiteSpace(user.password))
            {
                errors.PasswordError = "Password is required";
            }else if (user.password.Length < 8) 
            {
                errors.PasswordError = "Password must be at least 8 characters long";    
            }

            return errors;
        }

        public static SignInValidationSchema SignInValidation(string email, string password)
        {
            var errors = new SignInValidationSchema();

            if (string.IsNullOrWhiteSpace(email))
            {
                errors.EmailError = "Email is required";
            }
            else if (!IsValidEmail(email))
            {
                errors.EmailError = "Incorrect email format";
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                errors.PasswordError = "Password is required";
            }
            else if (password.Length < 8)
            {
                errors.PasswordError = "Password must be at least 8 characters long";
            }

            return errors;
        }

        private static bool IsValidEmail(string email)
        {
            try
            {
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper, RegexOptions.None, TimeSpan.FromMilliseconds(200));

                static string DomainMapper(Match match)
                {
                    var domainName = match.Groups[2].Value;
                    try
                    {
                        domainName = new IdnMapping().GetAscii(domainName);
                    }
                    catch (ArgumentException)
                    {
                        return string.Empty;
                    }
                    return match.Groups[1].Value + domainName;
                }

                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase,
                    TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}
