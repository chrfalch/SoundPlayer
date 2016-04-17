using SoundPlayer.Win;
using System;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms;

[assembly: Dependency(typeof(WindowsSoundProvider))]
namespace SoundPlayer.Win
{
    public class WindowsSoundProvider : ISoundProvider
    {
        public Task PlaySoundAsync(string filename)
        {
            if (!Windows.UI.Xaml.Application.Current.Resources.ContainsKey("GlobalMedia"))
            {
                // On Windows, the MediaElement has to be in the Visual Tree to work.
                // To make things simpler, we just add a global MediaElement in the Application ResourceDictionary
                // See App.xaml.cs, line 67
                throw new Exception("Please add a global MediaElement with key 'GlobalMedia'.");
            }

            MediaElement player = Windows.UI.Xaml.Application.Current.Resources["GlobalMedia"] as MediaElement;
            player.Source = new Uri("ms-appx:///" + filename);

            var tcs = new TaskCompletionSource<bool>();
            RoutedEventHandler callback = null;
            callback = (sender, e) =>
            {
                player.MediaEnded -= callback;
                tcs.SetResult(true);
            };
            player.MediaEnded += callback;
            player.Play();
            return tcs.Task;
        }
    }
}
