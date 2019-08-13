// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace SmsCode
{
    [Register ("YoutubeViewController")]
    partial class YoutubeViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgView1 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgView2 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        YouTube.Player.PlayerView youtubePlayer { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView youtubeView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (imgView1 != null) {
                imgView1.Dispose ();
                imgView1 = null;
            }

            if (imgView2 != null) {
                imgView2.Dispose ();
                imgView2 = null;
            }

            if (youtubePlayer != null) {
                youtubePlayer.Dispose ();
                youtubePlayer = null;
            }

            if (youtubeView != null) {
                youtubeView.Dispose ();
                youtubeView = null;
            }
        }
    }
}