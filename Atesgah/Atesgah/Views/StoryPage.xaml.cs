using Atesgah.ViewModels.Implement;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Atesgah.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StoryPage : ContentPage
    {
        public StoryVM ViewModel;
        public StoryPage()
        {
            InitializeComponent();
        }

        private void OpenStory(object sender, System.EventArgs e)
        {
            ViewModel.OpenStoryViewer.Execute(((TappedEventArgs)e).Parameter);
        }
    }
}