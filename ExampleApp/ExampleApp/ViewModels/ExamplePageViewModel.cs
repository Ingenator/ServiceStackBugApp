using ExampleApp.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExampleApp.ViewModels
{
    public class ExamplePageViewModel
    {
        public static void Init()
        {
            DependencyService.Register<IExampleService, ExampleApp.Services.ExampleService>();
        }
        protected IExampleService ExampleService { get; } = DependencyService.Get<IExampleService>();

        private Command bugCommand;
        public Command BugCommand
        {
            get
            {
                return bugCommand ?? (bugCommand = new Command(async () =>
                {
                    await ExecuteBugCommand();
                }));
            }
        }

        protected async Task ExecuteBugCommand()
        {
            Debug.WriteLine("Executing..");
                try
                {
                var isOk = await ExampleService.ReproduceBug();
                    if (isOk)
                    {
                        Debug.WriteLine("Executed OK");
                        await App.Current.MainPage.DisplayAlert("Example","Executed Ok","Ok");
                    }
                    else
                    {
                        Debug.WriteLine("Executed Failed");
                        await App.Current.MainPage.DisplayAlert("Example", "Executed Failed", "Ok");
                }
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Executed error: " + e.Message);
                }
        }
    }
}
