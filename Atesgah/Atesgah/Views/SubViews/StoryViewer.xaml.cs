using Atesgah.ViewModels.Implement.SubViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Atesgah.Views.SubViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StoryViewer : ContentView
    {
        public StoryViewerVM ViewModel;
        public StoryViewer()
        {
            InitializeComponent();
            video.PlaybackControls.IsVisible = false;
            video.HeightRequest = Application.Current.MainPage.Height;
            video.WidthRequest = Application.Current.MainPage.Width;

            swipeScreen.HeightRequest = Application.Current.MainPage.Height;
            swipeScreen.WidthRequest = Application.Current.MainPage.Width;

        }

        public async void OpenStoryAnimation()
        {
            ViewModel.OnAppearing();
            await this.LayoutTo(new Rectangle(20, 20, 0, 0), 0);
            var detailRect = new Rectangle(0, 0, Application.Current.MainPage.Width, Application.Current.MainPage.Height);
            await this.LayoutTo(detailRect, 800, Easing.SpringOut);
        }
        public async void OpenStoryAnimation(Point openLocation)
        {
            ViewModel.OnAppearing();
            await this.LayoutTo(new Rectangle(openLocation, new Size(0, 0)), 0);
            var detailRect = new Rectangle(0, 0, Application.Current.MainPage.Width, Application.Current.MainPage.Height);
            await this.LayoutTo(detailRect, 800, Easing.SpringOut);
        }
        public async void NextStoryAnimation()
        {
            ViewModel.OnAppearing();
            await this.LayoutTo(new Rectangle(Application.Current.MainPage.Width, 0, 0, Application.Current.MainPage.Height), 0);
            var detailRect = new Rectangle(0, 0, Application.Current.MainPage.Width, Application.Current.MainPage.Height);
            await this.LayoutTo(detailRect, 500, Easing.CubicIn);
        }
        public async void PreviousStoryAnimation()
        {
            ViewModel.OnAppearing();
            await this.LayoutTo(new Rectangle(0, 0 / 2, 0, Application.Current.MainPage.Height), 0);
            var detailRect = new Rectangle(0, 0, Application.Current.MainPage.Width, Application.Current.MainPage.Height);
            await this.LayoutTo(detailRect, 500, Easing.CubicIn);
        }

        private void SwipedStory(object sender, SwipedEventArgs e)
        {
            switch (e.Direction)
            {
                case SwipeDirection.Left:
                    {
                        ViewModel.GetNextStory();
                        break;
                    }

                case SwipeDirection.Right:
                    {
                        ViewModel.GetPreviousStory();
                        break;
                    }

                case SwipeDirection.Down:
                    {
                        ViewModel.ClosedStory();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void PressPause(object sender, EventArgs e)
        {
            ViewModel.PlayOrPause();
        }
    }
}