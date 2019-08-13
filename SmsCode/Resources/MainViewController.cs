using System;
using CoreGraphics;
using UIKit;

namespace SmsCode
{
    public partial class MainViewController : UIViewController
    {
        private UIButton btnSms;
        private UIButton btnVideos;
        public MainViewController() : base("MainViewController", null)
        {
            btnSms = UIButton.FromType(UIButtonType.System);
            btnSms.SetTitle("Test Sms Code", UIControlState.Normal);
            btnSms.BackgroundColor = UIColor.White;
            btnSms.Frame = new CGRect(20, 200, 200, 50);
            btnSms.TouchUpInside += btnSms_TouchUpInside;

            btnVideos = UIButton.FromType(UIButtonType.System);
            btnVideos.SetTitle("Test Youtube videos", UIControlState.Normal);
            btnVideos.BackgroundColor = UIColor.White;
            btnVideos.Frame = new CGRect(20, 300, 200, 50);
            btnVideos.TouchUpInside += btnVideos_TouchUpInside;
        }

        private void btnVideos_TouchUpInside(object sender, EventArgs e)
        {
            var youtubeController = new YoutubeViewController();
            this.NavigationController.PushViewController(youtubeController, false);
        }

        private void btnSms_TouchUpInside(object sender, EventArgs e)
        {
            var smsController = new SmsViewController();
            this.NavigationController.PushViewController(smsController, false);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.View.AddSubview(btnSms);
            this.View.AddSubview(btnVideos);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

