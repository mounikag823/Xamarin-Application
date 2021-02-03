using System;
using System.Collections.Generic;
using SpectrumTest.ViewModels;
using SpectrumTest.Views;
using Xamarin.Forms;

namespace SpectrumTest
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            //Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
