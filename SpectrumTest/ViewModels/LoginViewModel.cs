using SpectrumTest.Database.Repository;
using SpectrumTest.Dialog;
using SpectrumTest.Models;
using SpectrumTest.Navigation;
using SpectrumTest.Security;
using SpectrumTest.Validation;
using SpectrumTest.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SpectrumTest.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private INavigationService _navigationService;
        private IDialogMessage _dialogMessage;
        private IRepository<User> _userRepository;



        private ValidatableObject<string> _email;
        public ValidatableObject<string> Email
        {
            get => _email;
            set { SetProperty(ref _email, value); }
        }

        private ValidatableObject<string> _password;
        public ValidatableObject<string> Password
        {
            get => _password;
            set { SetProperty(ref _password, value); }
        }

        public ICommand RegisterCommand { get => new Command(async () => await GoToRegister()); }
        public ICommand LoginCommand { get => new Command(async () => await LoginUser(), () => IsNotBusy); }

        public LoginViewModel(INavigationService navigationService, IDialogMessage message,
                                 IRepository<User> userRepository)
        {
            _navigationService = navigationService;
            _dialogMessage = message;
            _userRepository = userRepository;
            AddValidations();
        }

        private async Task LoginUser()
        {
            if (!EntriesCorrectlyPopulated())
            {
                return;
            }
            IsBusy = true;
            var user = (await _userRepository.GetAllAsync())
                .FirstOrDefault(x => x.Email == Email.Value);
            if (user == null)
            {
                await _dialogMessage.DisplayAlert("Alert", "Email amd Password not available", "Ok");
                IsBusy = false;
                return;
            }
            else
            if (!SecurePasswordHasher.Verify(Password.Value, user.HashedPassword))
            {
                await _dialogMessage.DisplayAlert("Alert", "Password not valid", "Ok");
                IsBusy = false;
                return;
            }
            else
            {
                await _dialogMessage.DisplayAlert("Alert", "Login is sucessfull", "Ok");
                IsBusy = false;
                return;
            }
            IsBusy = false;
        }

        private async Task DisplayCredentialsError()
        {
            await _dialogMessage.DisplayAlert("Login Error", "Wrong Crenditals", "Ok");
            Password.Value = "";
        }

        private async Task GoToRegister()
        {
            await _navigationService.InsertAsRoot<RegistartionViewModel>();
        }

        private void AddValidations()
        {
            _email = new ValidatableObject<string>();
            _password = new ValidatableObject<string>();

            _email.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Email is empty." });
            _email.Validations.Add(new EmailRule<string> { ValidationMessage = "Email is not in correct format." });

            _password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Password is empty." });

            OnPropertyChanged(nameof(_email));
            OnPropertyChanged(nameof(_password));
        }

        private bool EntriesCorrectlyPopulated()
        {
            _email.Validate();
            _password.Validate();

            return _email.IsValid && _password.IsValid;
        }
    }
}
