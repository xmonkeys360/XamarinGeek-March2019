using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using XamarinDemo;
using XamarinDemo.UWP;

[assembly: ExportRenderer(typeof(CustomSwitch), typeof(CustomSwitchRenderer))]
namespace XamarinDemo.UWP
{
    public class CustomSwitchRenderer : ViewRenderer<CustomSwitch, Border>
    {
        private CheckBox nativeView;

        protected override void OnElementChanged(ElementChangedEventArgs<CustomSwitch> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                var border = new Border() { Padding = new Windows.UI.Xaml.Thickness(5, 0, 0, 0) };
                border.BorderThickness = new Windows.UI.Xaml.Thickness(0);
                border.BorderBrush = new SolidColorBrush(Colors.Gray);
                this.nativeView = new CheckBox();

                this.nativeView.IsChecked = this.Element.IsToggled;
                Element.Toggled += this.Element_Toggled;
                border.Child = this.nativeView;
                this.SetNativeControl(border);
                this.nativeView.Checked += this.NativeView_Checked;
                this.nativeView.Unchecked += this.NativeView_Unchecked;
            }
        }

        private void NativeView_Checked(object sender, RoutedEventArgs e)
        {
            if (this.Element != null)
            {
                this.Element.IsToggled = (bool)(sender as CheckBox).IsChecked;
            }
        }

        private void Element_Toggled(object sender, ToggledEventArgs e)
        {
            if (this.nativeView != null)
            {
                this.nativeView.IsChecked = (sender as CustomSwitch).IsToggled;
            }
        }

        private void NativeView_Unchecked(object sender, RoutedEventArgs e)
        {
            if (this.Element != null)
            {
                this.Element.IsToggled = (bool)(sender as CheckBox).IsChecked;
            }
        }
    }
}
