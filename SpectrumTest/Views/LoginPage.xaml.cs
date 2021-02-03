using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using SpectrumTest.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SpectrumTest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = App.Container.Resolve<LoginViewModel>();
        }
    }
}