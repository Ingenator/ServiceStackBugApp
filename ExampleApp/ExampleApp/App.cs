using ExampleApp.Pages;
using ExampleApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ExampleApp
{
    public class App : Application
    {
        public App()
        {
            ExamplePageViewModel.Init();
            // The root page of your application
            MainPage = new ExamplePage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
