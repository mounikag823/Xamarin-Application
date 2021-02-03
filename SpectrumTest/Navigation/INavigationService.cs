using System;
using System.Threading.Tasks;
using SpectrumTest.ViewModels;

namespace SpectrumTest.Navigation
{
    public interface INavigationService
    {
        Task PushAsync<TViewModel>(string parameters = null) where TViewModel : BaseViewModel;
        Task PopAsync();
        Task InsertAsRoot<TViewModel>(string parameters = null) where TViewModel : BaseViewModel;
        Task GoBackAsync();
        void GoToMainFlow();
        void GoToLoginFlow();
    }
}
