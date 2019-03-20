using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinDemo;
using XamarinDemo.Droid;

[assembly: ExportRenderer(typeof(CustomSwitch), typeof(CustomSwitchRenderer))]
namespace XamarinDemo.Droid
{
    public class CustomSwitchRenderer : ViewRenderer<CustomSwitch, CheckBox>
    {
        public CustomSwitchRenderer(Context context) : base(context)
        {

        }
        private CheckBox nativeView;

        protected override void OnElementChanged(ElementChangedEventArgs<CustomSwitch> e)
        {
            base.OnElementChanged(e);
            nativeView = new CheckBox(Forms.Context);
            nativeView.CheckedChange += NativeView_CheckedChange;
            nativeView.Checked = Element.IsToggled;
            Element.Toggled += Element_Toggled;
            SetNativeControl(nativeView);
        }

        private void NativeView_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            this.Element.IsToggled = (sender as CheckBox).Checked;
        }

        private void Element_Toggled(object sender, ToggledEventArgs e)
        {
            if (this.nativeView != null)
                this.nativeView.Checked = (sender as CustomSwitch).IsToggled;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (nativeView != null)
                {
                    nativeView.CheckedChange -= NativeView_CheckedChange;
                    this.nativeView.RemoveFromParent();
                    this.nativeView = null;
                }
                if (this.Element != null)
                {
                    this.Element.Toggled -= Element_Toggled;
                }
            }
            base.Dispose(disposing);
        }
    }
}