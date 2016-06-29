using ExampleApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace ExampleApp.Pages
{
    public class ExamplePage : ContentPage
    {
        ExamplePageViewModel ViewModel = new ExamplePageViewModel();
        public ExamplePage()
        {
            BindingContext = ViewModel;
            Title = "Service Stack bug";
            var action = new Button
            {
                Text = "Press me!"
            };
            action.SetBinding<ExamplePageViewModel>(Button.CommandProperty, (x => x.BugCommand));
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Press the button and watch console log." },
                    action,
                }
            };
        }
    }
}
