using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SpectrumTest.Services;
using SpectrumTest.Views;
using Autofac;
using System.Reflection;
using SpectrumTest.Database.Repository;
using SpectrumTest.Models;

namespace SpectrumTest
{
    public partial class App : Application
    {
        public static IContainer Container;

        public App()
        {
            InitializeComponent();

            //class used for registration
            var builder = new ContainerBuilder();
            //scan and register all classes in the assembly
            var dataAccess = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(dataAccess)
                   .AsImplementedInterfaces()
                   .AsSelf();
            builder.RegisterType<Repository<User>>().As<IRepository<User>>();

            //get container
            Container = builder.Build();

            //MainPage = new LoginShell();
            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
