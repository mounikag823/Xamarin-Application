using System;
using System.Windows.Input;
using SpectrumTest.Database.Repository;
using SpectrumTest.Dialog;
using SpectrumTest.Models;
using SpectrumTest.Navigation;
using SpectrumTest.Validation;
using Xamarin.Forms;

namespace SpectrumTest.ViewModels
{
    public class RegistartionViewModel : BaseViewModel
    {
        private INavigationService _navigationService;
        private IDialogMessage _dialogMessage;
        private IRepository<User> _userRepository;

        public ValidatableObject<string> FirstName { get; set; } = new ValidatableObject<string>();
        public ValidatableObject<string> LastName { get; set; } = new ValidatableObject<string>();
        public ValidatableObject<DateTime> BirthDay { get; set; } = new ValidatableObject<DateTime>() { Value = DateTime.Now };
        public ValidatableObject<string> PhoneNumber { get; set; } = new ValidatableObject<string>();
        public ValidatableObject<string> Password { get; set; } = new ValidatableObject<string>();
        

        public RegistartionViewModel()
        {
            AddValidationRules();
        }

        public void AddValidationRules()
        {
            FirstName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "First Name Required" });
            LastName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Last Name Required" });
            BirthDay.Validations.Add(new HasValidAgeRule<DateTime> { ValidationMessage = "You must be 18 years of age or older" });
            PhoneNumber.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Phone Number Required" });
            PhoneNumber.Validations.Add(new IsLenghtValidRule<string> { ValidationMessage = "Phone Number should have a maximun of 10 digits and minimun of 8", MaximunLenght = 10, MinimunLenght = 8 });

           
        }

        public ICommand SignUpCommand => new Command(async () =>
        {
            if (AreFieldsValid())
            {
                await App.Current.MainPage.DisplayAlert("Welcome", "", "Ok");
            }
        });

        bool AreFieldsValid()
        {
            bool isFirstNameValid = FirstName.Validate();
            bool isLastNameValid = LastName.Validate();
            bool isBirthDayValid = BirthDay.Validate();
            bool isPhoneNumberValid = PhoneNumber.Validate();
            bool isPasswordValid = Password.Validate();
           

            return isFirstNameValid && isLastNameValid && isBirthDayValid
                   && isPhoneNumberValid && isPasswordValid;
        }
    }
}
