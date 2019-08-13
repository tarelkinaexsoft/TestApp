using System.Threading.Tasks;
using CoreFoundation;
using Foundation;
using UIKit;

namespace SmsCode
{
    public partial class YoutubeViewController : UIViewController
    {
        private readonly string videoId1 = "o9P4B0iPHpI";
        private readonly string videoId2 = "N7LJM4AJYTk";

        public YoutubeViewController() : base("YoutubeViewController", null)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            SetImages();
            var singleTap1 = new UITapGestureRecognizer(imgView1_TapDetected);
            singleTap1.NumberOfTapsRequired = 1;
            imgView1.AddGestureRecognizer(singleTap1);

            var singleTap2 = new UITapGestureRecognizer(imgView2_TapDetected);
            singleTap2.NumberOfTapsRequired = 1;
            imgView2.AddGestureRecognizer(singleTap2);
            //youtubeView.LoadVideoById("QPngpHrP924");

            var singleTap3 = new UITapGestureRecognizer(youtubeView_TapDetected);
            singleTap3.NumberOfTapsRequired = 1;
            youtubeView.AddGestureRecognizer(singleTap3);
        }

        private void imgView1_TapDetected()
        {
            PlayVideo(videoId1);
        }

        private void imgView2_TapDetected()
        {
            PlayVideo(videoId2);
        }

        private void youtubeView_TapDetected()
        {
            youtubeView.Hidden = true;
            this.View.LayoutIfNeeded();
            youtubePlayer.StopVideo();
        }

        private void PlayVideo(string videoId)
        {
            youtubeView.Hidden = false;
            this.View.LayoutIfNeeded();

            youtubePlayer.LoadVideoById(videoId);
        }

        private async Task SetImages()
        {
            var image = await GetYoutubeVideoThumbnail(videoId1);
            imgView1.Image = image;

            image = await GetYoutubeVideoThumbnail(videoId2);
            imgView2.Image = image;
        }

        private async Task<UIImage> GetYoutubeVideoThumbnail(string videoId)
        {
            var task = new Task<UIImage>(() =>
            {
                var url = $"https://img.youtube.com/vi/{videoId}/0.jpg";
                using (var nsUrl = new NSUrl(url))
                using (var data = NSData.FromUrl(nsUrl))
                {
                    return UIImage.LoadFromData(data);
                }
            });
            task.Start();

            return await task;
        }
    }
}

