using Atesgah.ViewModels.Implement;
using Atesgah.ViewModels.Implement.SubViewModels;
using Atesgah.Views;

namespace Atesgah.Commands.StoryPageCommands
{
    public class NextStoryCommand : BaseCommand
    {
        private StoryPage View;

        public NextStoryCommand(StoryPage view)
        {
            View = view;
        }
        public override async void Execute(object parameter)
        {
            int id = 0;
            if (!int.TryParse(parameter.ToString(), out id))
            {
                return;
            }

            StoryViewerVM storyViewer = new StoryViewerVM(id, View);

            storyViewer.View.NextStoryAnimation();
        }
    }
}
