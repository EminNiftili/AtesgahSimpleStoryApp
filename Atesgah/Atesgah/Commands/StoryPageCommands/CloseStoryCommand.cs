using Atesgah.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atesgah.Commands.StoryPageCommands
{
    public class CloseStoryCommand : BaseCommand
    {
        private StoryPage View;

        public CloseStoryCommand(StoryPage view)
        {
            View = view;
        }
        public override async void Execute(object parameter)
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
