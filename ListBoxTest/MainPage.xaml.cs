using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ListBoxTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<Person> Persons { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            Persons = new ObservableCollection<Person>();
            Persons.Add(new Person() { Name = "Batman", DateOfBirth = new DateTime(2000, 1, 1), Domicile = "Gotham" });
            Persons.Add(new Person() { Name = "Chuck Norris", DateOfBirth = new DateTime(1900, 1, 1), Domicile = "Paris" });
        }
    }

    public class Person : BindableBase
    {
        private DateTimeOffset _dateOfBirth;
        public DateTimeOffset DateOfBirth
        {
            get { return this._dateOfBirth; }
            set
            {
                this.SetProperty(ref this._dateOfBirth, value);
                this.OnPropertyChanged("Age");
            }
        }

        public int Age
        {
            get
            {
                // Uh huh... http://stackoverflow.com/questions/4127363/date-difference-in-years-c-sharp
                return new DateTime(1, 1, 1).Add(new DateTimeOffset(DateTime.Today).Subtract(DateOfBirth)).Year - 1;
            }
        }

        private string _domicile;
        public string Domicile
        {
            get { return this._domicile; }
            set
            {
                this.SetProperty(ref this._domicile, value);
            }
        }

        private string _name;
        public string Name
        {
            get { return this._name; }
            set
            {
                this.SetProperty(ref this._name, value);
            }
        }
    }
}
