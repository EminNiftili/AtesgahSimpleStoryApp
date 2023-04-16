using Atesgah.Commands;
using Atesgah.Commands.StoryPageCommands;
using Atesgah.Helpers;
using Atesgah.Models;
using Atesgah.Views;
using Atesgah.Views.SubViews;
using LibVLCSharp.Shared;
using System;
using System.Timers;
using Xamarin.Forms;

namespace Atesgah.ViewModels.Implement.SubViewModels
{
    //StoryViewer View Model or StoryViewerVM
    public class StoryViewerVM : ViewVM<StoryViewer, StoryPage>, IDisposable
    {
        private bool _isPause = false;
        private bool _isRecursiveFlag = true;
        private StoryModel story;


        public StoryViewerVM(int id, StoryPage parentPage) : base(new StoryViewer(), parentPage)
        {
            story = MockDataGenerator.GetStory(id);

            View.BindingContext = this;

            View.ViewModel = this;

            parentPage.Content = View;

            CloseStory = new CloseStoryCommand(Parent); 
            NextStory = new NextStoryCommand(Parent);
            PreviousStory = new PreviousStoryCommand(Parent);
        }

        public string VideoSourceLink
        {
            get
            {
                return story.VideoSourceLink;
            }
        }

        public BaseCommand CloseStory;
        public BaseCommand NextStory;
        public BaseCommand PreviousStory;

        #region ProgressBarV1
        private readonly double _maxProgressValue = 5; // Maximum Second

        private double _progressPercent = 0; // Progress Percent value

        private void MediaPlayerTimeChanged(object sender, MediaPlayerTimeChangedEventArgs e)
        {
            var time = e.Time / 1000.0;

            var percent = time / _maxProgressValue;
            Progress = percent;

            if (time > _maxProgressValue)
            {
                GetNextStory();
            }
        }
        #endregion

        private double progressValue = 0;

        private Timer _timer;
        public double Progress
        {
            get
            {
                return _progressPercent;
            }
            set
            {
                if(_progressPercent <= 1)
                {
                    _progressPercent = value;
                    PropertyChange(nameof(Progress));
                }
            }
        }

        private LibVLC _libVLC;
        public LibVLC LibVLC
        {
            get => _libVLC;
            set 
            {
                _libVLC = value;
                PropertyChange(nameof(LibVLC)); 
            }

        }

        private MediaPlayer _mediaPlayer;


        public MediaPlayer MediaPlayer
        {
            get => _mediaPlayer;
            set
            {
                _mediaPlayer = value;
                PropertyChange(nameof(MediaPlayer));
            }
        }

        public void OnAppearing()
        {
            story.IsWatched = true;

            //Comment if you setup ProgressBarV1 --> line 44
            #region ProgressBarV2
            _timer = new Timer();
            _timer.Interval = 10;
            _timer.Elapsed += ProgressTimerElapsed;
            #endregion
            Core.Initialize();

            LibVLC = new LibVLC();

            var media = new Media(LibVLC,
                new Uri(story.VideoSourceLink));

            MediaPlayer = new MediaPlayer(media) { EnableHardwareDecoding = true };
            MediaPlayer.Stopped += MediaPlayerStopped;
            //MediaPlayer.TimeChanged += MediaPlayerTimeChanged;   //Uncomment if you setup ProgressBarV1 --> line 44
            MediaPlayer.Play();
            _timer.Start();
        }

        private void ProgressTimerElapsed(object sender, ElapsedEventArgs e)
        {
            progressValue += 0.01;

            var percent = progressValue / _maxProgressValue;
            Progress = percent;

            if (progressValue > _maxProgressValue)
            {
                _timer.Stop();
                GetNextStory();
            }
        }


        private void MediaPlayerStopped(object sender, EventArgs e)
        {
            if (_isRecursiveFlag)
            {
                GetNextStory();
            }
        }

        public void GetNextStory()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if (story.NextId.HasValue)
                {
                    NextStory?.Execute(story.NextId.Value);
                }
                else
                {
                    CloseStory?.Execute(null);
                }
                Dispose();
            });
        }

        public void GetPreviousStory()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if (story.PreviousId.HasValue)
                {
                    PreviousStory?.Execute(story.PreviousId.Value);
                    Dispose();
                }
            });
        }
        public void ClosedStory()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                CloseStory?.Execute(null);
                Dispose();
            });
        }

        public void Dispose()
        {
            _isRecursiveFlag = false;
            MediaPlayer.Stop();
            NextStory = null;
            PreviousStory = null;
            CloseStory = null;
        }

        public void PlayOrPause()
        {
            if (_isPause)
            {
                _isPause = !_isPause;
                _isRecursiveFlag = true;
                _timer.Start();
                MediaPlayer.Play();
            }
            else
            {
                _isPause = !_isPause;
                _isRecursiveFlag = false;
                _timer.Stop();
                if (MediaPlayer.CanPause)
                {
                    MediaPlayer.Pause();
                }
            }
        }
    }
}
