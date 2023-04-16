using Atesgah.ViewModels.Implement;
using Atesgah.ViewModels.Implement.SubViewModels;
using Atesgah.Views;
using Atesgah.Views.SubViews;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Atesgah
{
    public partial class Application : Xamarin.Forms.Application
    {
        public NavigationPage Navigation;
        public Application ()
        {
            InitializeComponent();

            Navigation = new NavigationPage();

            Navigation.Popped += NavigationPopped;

            MainPage = Navigation;

        }

        private void NavigationPopped(object sender, NavigationEventArgs e)
        {
            if (e.Page is StoryPage)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    var contentPage = (StoryPage)e.Page;
                    var contentView = (StoryViewer)contentPage.Content;
                    StoryViewerVM viewModel = (StoryViewerVM)contentView.BindingContext;
                    viewModel.Dispose();
                });
            }
        }

        protected override async void OnStart()
        {
            WelcomeVM viewModel = new WelcomeVM();

            await Navigation.PushAsync(viewModel.View);

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
