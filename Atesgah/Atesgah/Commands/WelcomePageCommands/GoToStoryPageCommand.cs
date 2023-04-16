using Atesgah.ViewModels.Implement;

namespace Atesgah.Commands.WelcomePageCommands
{
    public class GoToStoryPageCommand : BaseCommand
    {
        public override async void Execute(object parameter)
        {
            StoryVM viewModel = new StoryVM();

            await Application.Current.MainPage.Navigation.PushAsync(viewModel.View);
        }
    }
}
