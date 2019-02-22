using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Lab1.Tools;
using Lab1.Tools.Managers;

namespace Lab1.Tools
{
    internal class EnterDateViewModel : BaseViewModel
    {
        private DateTime _dateOfBirthday;
        private string _age;
        private string _chinise;
        private string _west;
        private RelayCommand<object> _calculateCommand;
        private static string[] _chineseHoroscope = {"Monkey",  "Rooster", "Dog",  "Pig",
            "Rat", "Bul", "Tiger", "Rabbit","Dragon", "Snake","Horse",  "Sheep"   };

        private static string[] _westHoroscope =
        {
            "Aquarius",
            "Pisces",
            "Aries",
            "Taurus" ,
            "Gemini" ,
            "Cancer" ,
            "Leo" ,
            "Virgo" ,
            "Libra",
            "Scorpio" ,
            "Sagittarius" ,
            "Capricorn"
        };

        private static int[] _westBeginDates = { 21, 21, 21, 21, 21, 22, 23, 24, 24, 24, 23, 22 };

        public DateTime DateOfBirthday
        {
            get { return _dateOfBirthday; }
            set
            {
                _dateOfBirthday = value;
                OnPropertyChanged("DateOfBirthday");
            }
        }

        public string Age
        {
            get { return _age; }
            set
            {
                _age = value;
                OnPropertyChanged("Age");
            }
        }

        public string Chinise
        {
            get { return _chinise; }
            set
            {
                _chinise = value;
                OnPropertyChanged("Chinise");
            }
        }

        public string West
        {
            get { return _west; }
            set
            {
                _west = value;
                OnPropertyChanged("West");
            }
        }

        //обрахування знаку китайського гороскопу
        public string CalculateChineese()
        {
            return _chineseHoroscope[_dateOfBirthday.Year % 12];
        }

        //обрахування знаку західного гороскопу
        private string CalculateWest()
        {
            if (_dateOfBirthday.Day < _westBeginDates[_dateOfBirthday.Month - 1])
            {
                if (_dateOfBirthday.Month == 1)
                    return _westHoroscope[11];
                else return _westHoroscope[_dateOfBirthday.Month - 2];
            }
            else return  _westHoroscope[_dateOfBirthday.Month - 1];
        }

        //перевірка, чи введена дата народження правильна
        public bool IsCorrectDateOfBirthday()
        {
            return (DateTime.Now > _dateOfBirthday && CalculateAge() < 135);
        }
        //обрахування віку
        public int CalculateAge()
        {
            DateTime currentDate = DateTime.Now;
            if (currentDate.Month > _dateOfBirthday.Month)
                return currentDate.Year - _dateOfBirthday.Year;
            else if(currentDate.Month == _dateOfBirthday.Month && currentDate.Day >= _dateOfBirthday.Day) return currentDate.Year - _dateOfBirthday.Year;
            else return currentDate.Year - _dateOfBirthday.Year - 1;
        }
        //перевірка, чи день народження сьогодні
        private bool IsBirthdayToday()
        {
            DateTime currentDate = DateTime.Now;
            return (currentDate.Month == _dateOfBirthday.Month && currentDate.Day == _dateOfBirthday.Day);
        }
        
        public RelayCommand<Object> CalculateCommand
        {
            get
            {
                return _calculateCommand ?? (_calculateCommand = new RelayCommand<object>( MainCalculate ));
            }
        }

        //ініціалізація змінних
        private void Initializing()
        {
            if (!IsCorrectDateOfBirthday()) throw new Exception("Uncorrect date");
            Age = $"Age = {CalculateAge()}";
            West = "West horoscope: "+CalculateWest();
            Chinise = "Chinise horoscope: "+CalculateChineese();
           
        }
        
        private async void MainCalculate(object obj)
        {

            try
            {
                LoaderManeger.Instance.ShowLoader();
                await Task.Run(() => Thread.Sleep(2000));
                Initializing();
                LoaderManeger.Instance.HideLoader();
                if (IsBirthdayToday()) MessageBox.Show("Happy Birthday!!!!");
            }
            catch (Exception e)
            {
                LoaderManeger.Instance.HideLoader();
                MessageBox.Show("Uncorrect date", "Сообщение", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
            
        }

    }
}
