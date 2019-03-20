using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinDemo
{
    public class AnimatorButton : RelativeLayout
    {
        public AnimatorButton()
        {
            this.HeightRequest = 50;
            this.WidthRequest = 100;
            Children.Add(new Button(), Constraint.Constant(0), Constraint.Constant(0), Constraint.RelativeToParent((p) => { return p.Width; }), Constraint.RelativeToParent((p) => { return p.Height; }));

            Children.Add(new ActivityIndicator
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                HeightRequest = 30,
                WidthRequest = 30
            }, Constraint.RelativeToParent((p) => { return p.Width / 2 - 15; }), Constraint.RelativeToParent((p) => { return p.Height / 2 - 15; }));
        }

        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(AnimatorButton), string.Empty, propertyChanged: OnTextChanged);

        public static readonly BindableProperty IsBusyProperty = BindableProperty.Create(nameof(IsBusy), typeof(bool), typeof(AnimatorButton), false, propertyChanged: OnIsBusyChanged);

        public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(IsBusy), typeof(ICommand), typeof(AnimatorButton), null, propertyChanged: OnCommandChanged);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public bool IsBusy
        {
            get { return (bool)GetValue(IsBusyProperty); }
            set { SetValue(IsBusyProperty, value); }
        }

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        static void OnTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as AnimatorButton;

            if (control == null)
            {
                return;
            }

            SetTextBasedOnBusy(control, control.IsBusy, newValue as string);
        }

        static void OnIsBusyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as AnimatorButton;

            if (control == null)
            {
                return;
            }

            SetTextBasedOnBusy(control, (bool)newValue, control.Text);
        }

        static void SetTextBasedOnBusy(AnimatorButton control, bool isBusy, string text)
        {
            var activityIndicator = GetActivityIndicator(control);
            var button = GetButton(control);

            if (activityIndicator == null || button == null)
            {
                return;
            }

            activityIndicator.IsVisible = activityIndicator.IsRunning = isBusy;
            button.Text = isBusy ? string.Empty : control.Text;
        }

        static void OnCommandChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as AnimatorButton;
            var button = GetButton(control);
            if (control == null || button == null)
            {
                return;
            }
            button.Command = control.Command;
        }

        static ActivityIndicator GetActivityIndicator(AnimatorButton control)
        {
            return control.Children[1] as ActivityIndicator;
        }

        static Button GetButton(AnimatorButton control)
        {
            return control.Children[0] as Button;
        }
    }
}
