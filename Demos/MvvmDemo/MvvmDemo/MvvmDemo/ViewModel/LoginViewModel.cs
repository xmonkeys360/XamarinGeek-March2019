using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MvvmDemo.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
      
        public LoginViewModel()
        {
            SubmitBtnCMD = new Command(Submit);
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private string _UserName;
        public string UserName
        {
            get { return _UserName; }
            set
            {
                _UserName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("UserName"));

            }

        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }



        public ICommand SubmitBtnCMD { protected set; get; }

        public async void Submit()
        {
           

            if(UserName =="abhi" && Password=="abhi")
            {
               
                   await Application.Current.MainPage.Navigation.PushAsync(new View.HomePage());
                    
               
            }
            else
            {
                Device.BeginInvokeOnMainThread(async () => 
                {
                    await Application.Current.MainPage.DisplayAlert("Alert", "Login Fail", "Ok");
                });
            }
           
        }

       
    }
}
