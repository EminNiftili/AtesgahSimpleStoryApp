using Atesgah.Helpers;
using Atesgah.ViewModels.Implement;
using Atesgah.ViewModels.Implement.SubViewModels;
using Atesgah.Views;
using Atesgah.Views.SubViews;
using Xamarin.Forms;

namespace Atesgah.Commands.StoryPageCommands
{
    public class OpenStoryCommand : BaseCommand
    {
        private StoryPage View;

        public OpenStoryCommand(StoryPage view)
        {
            View = view;
        }

        public override async void Execute(object parameter)
        {
            int id = 0;
            if(!int.TryParse(parameter.ToString(), out id))
            {
                return;
            }

            StoryViewerVM storyViewer = new StoryViewerVM(id, View);

            storyViewer.View.OpenStoryAnimation();
        }
    }
}
