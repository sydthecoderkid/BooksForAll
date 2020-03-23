using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Xaml;
using CoreGraphics;
using UIKit;

namespace BooksForAll
{
    public class CustomViewController : UIViewController
    {
        public CustomViewController()
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.BackgroundColor = UIColor.White;
            Title = "My Custom View Controller";

            var btn = UIButton.FromType(UIButtonType.System);
            btn.Frame = new CGRect(20, 200, 280, 44);
            btn.SetTitle("Click Me", UIControlState.Normal);

            var user = new UIViewController();
            user.View.BackgroundColor = UIColor.Magenta;

            btn.TouchUpInside += (sender, e) =>
            {
                this.NavigationController.PushViewController(user, true);
            };

            View.AddSubview(btn);

        }
    }
}