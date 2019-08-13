using CoreGraphics;
using Foundation;
using System;
using UIKit;

namespace SmsCode
{
    public partial class SmsViewController : UIViewController
    {
        private UITextField[] txtCodeFields;

        public SmsViewController()
        {
            txtCodeFields = new UITextField[4];

            for (int i = 0; i < 4; i++)
            {
                txtCodeFields[i] = new UITextField
                {
                    UserInteractionEnabled = true,
                    Frame = new CGRect(20 + i * 80, 200, 40, 40),
                    BackgroundColor = UIColor.White,
                    TextColor = UIColor.Magenta,
                    KeyboardType = UIKeyboardType.NumberPad,
                    Delegate = new TestDelegate()
                };
                txtCodeFields[i].EditingChanged += TextCode_EditingChanged;
            }


            if (UIDevice.CurrentDevice.CheckSystemVersion(12, 0))
            {
                txtCodeFields[0].TextContentType = UITextContentType.OneTimeCode;
            }
            this.Title = "Sms controller";

        }

        private void TextCode_EditingChanged(object sender, EventArgs e)
        {
            if (sender is UITextField uiTextField)
            {
                int j = 0;
                for (int i = 0; i < txtCodeFields.Length; i++)
                {
                    if (uiTextField == txtCodeFields[i])
                    {
                        j = i;
                        break;
                    }
                }
                for (int i = j+1; i < txtCodeFields.Length; i++)
                {
                    txtCodeFields[i].Text = string.Empty;
                }
                if (j != txtCodeFields.Length - 1 && !string.IsNullOrWhiteSpace(txtCodeFields[j].Text))
                {
                    txtCodeFields[j + 1].BecomeFirstResponder();
                }
                else if (j == txtCodeFields.Length - 1)
                {
                    txtCodeFields[j].ResignFirstResponder();
                }
            }
        }

        private class TestDelegate : UITextFieldDelegate
        {
            public override bool ShouldChangeCharacters(UITextField textField, NSRange range, string replacementString)
            {
                return textField.Text.Length - range.Length + replacementString.Length <= 1;
            }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            foreach (var field in txtCodeFields)
            {
                View.AddSubview(field);
            }
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
