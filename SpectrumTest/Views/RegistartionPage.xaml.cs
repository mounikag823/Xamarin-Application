using System;
using System.Collections.Generic;
using Autofac;
using SpectrumTest.ViewModels;
using Xamarin.Forms;

namespace SpectrumTest.Views
{
    public partial class RegistartionPage : ContentPage
    {
        public RegistartionPage()
        {
            InitializeComponent();
            this.BindingContext = App.Container.Resolve<RegistartionViewModel>();
        }
    }
}
