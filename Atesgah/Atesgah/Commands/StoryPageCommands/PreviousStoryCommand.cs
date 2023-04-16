using Atesgah.ViewModels.Implement.SubViewModels;
using Atesgah.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atesgah.Commands.StoryPageCommands
{
    public class PreviousStoryCommand : BaseCommand
    {
        private StoryPage View;

        public PreviousStoryCommand(StoryPage view)
        {
            View = view;
        }
        public override void Execute(object parameter)
        {
            int id = 0;
            if (!int.TryParse(parameter.ToString(), out id))
            {
                return;
            }

            StoryViewerVM storyViewer = new StoryViewerVM(id, View);


            storyViewer.View.PreviousStoryAnimation();
        }
    }
}
