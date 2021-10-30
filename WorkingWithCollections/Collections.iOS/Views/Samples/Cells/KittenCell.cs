using CoreGraphics;
using Foundation;
using MvvmCross.Binding.iOS.Views;
using System;
using UIKit;

namespace Collections.Touch
{
  [Register(nameof(KittenCell))]
  public partial class KittenCell : MvxTableViewCell
  {
    private const string BindingText = "Name Name;ImageUrl ImageUrl";

    private MvxImageViewLoader _imageHelper;

    public KittenCell() : base(BindingText) => InitialiseImageHelper();

    public KittenCell(IntPtr handle) : base(BindingText, handle) => InitialiseImageHelper();

    public string Name
    {
      get => MainLabel.Text;
      set => MainLabel.Text = value; 
    }

    public string ImageUrl
    {
      get => _imageHelper.ImageUrl;
      set => _imageHelper.ImageUrl = value;
    }

    public static float GetCellHeight() => 120f;

    public override void TouchesBegan(NSSet touches, UIEvent evt) => AnimateToScale(1.2f);

    public override void TouchesCancelled(NSSet touches, UIEvent evt) => AnimateToScale(1.0f);

    public override void TouchesEnded(NSSet touches, UIEvent evt) => AnimateToScale(1.0f);

    private void AnimateToScale(float scale)
    {
      UIView.BeginAnimations("animateToScale");
      UIView.SetAnimationCurve(UIViewAnimationCurve.EaseIn);
      UIView.SetAnimationDuration(0.5);
      Transform = CGAffineTransform.MakeScale(scale, 1.0f);
      UIView.CommitAnimations();
    }

    private void InitialiseImageHelper()
      => _imageHelper = new MvxImageViewLoader(() => KittenImageView);
  }
}
