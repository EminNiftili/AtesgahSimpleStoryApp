using Atesgah.Commands;
using Atesgah.Commands.StoryPageCommands;
using Atesgah.Helpers;
using Atesgah.Models;
using Atesgah.Views;
using System.Collections.ObjectModel;

namespace Atesgah.ViewModels.Implement
{
    //Story View Model or StoryVM
    public class StoryVM : PageVM<StoryPage>
    {
        private StoryPageModel _model;
        public StoryVM() : base(new StoryPage())
        {
            _model = new StoryPageModel();
            _model.Stories = MockDataGenerator.GenerateStories();

            View.BindingContext = this;
            View.ViewModel = this;
        }

        public ObservableCollection<StoryModel> Stories
        {
            get
            {
                if (_model == null)
                {
                    return new ObservableCollection<StoryModel>();
                }
                return new ObservableCollection<StoryModel>(_model.Stories);
            }
            set
            {
                PropertyChange(nameof(Stories));
            }
        }


        public BaseCommand OpenStoryViewer => new OpenStoryCommand(View);
    }
}
