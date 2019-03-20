using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinDemo
{
    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            this.Username = null;
            this.Password = null;
            this.IsValidLogin = false;
            this.IsBusy = false;
            this.LoginCommand = new Command(ExecuteLoginCommand);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void ExecuteLoginCommand(object obj)
        {
            IsBusy = true;
            if(!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
            {
                IsValidLogin = true;
            }
            await Task.Delay(2500);
            IsBusy = false;
        }

        public string Username { get; set; }
        public string Password { get; set; }
        private bool isValidLogin;
        public bool IsValidLogin {
            get { return this.isValidLogin; }
            set
            {
                this.isValidLogin = value;
                OnPropertyChanged("IsValidLogin");
            }
        }
        private bool isBusy;
        public bool IsBusy
        {
            get { return this.isBusy; }
            set
            {
                this.isBusy = value;
                OnPropertyChanged("IsBusy");
            }
        }
        public Command LoginCommand { get; set; }
    }
}
