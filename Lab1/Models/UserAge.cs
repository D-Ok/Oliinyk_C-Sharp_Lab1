using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Models
{
    internal class UserAge
    {
        private DateTime _dateOfBirthday;
        private int _age;

        public UserAge(DateTime date)
        {
            _dateOfBirthday = date;
            _age = CalculateAge();
        }

        private int CalculateAge()
        {
            DateTime currentDate = DateTime.Now;
            if (currentDate.Month > _dateOfBirthday.Month)
                return currentDate.Year - _dateOfBirthday.Year;
            else if (currentDate.Month == _dateOfBirthday.Month && currentDate.Day >= _dateOfBirthday.Day) return currentDate.Year - _dateOfBirthday.Year;
            else return currentDate.Year - _dateOfBirthday.Year - 1;
        }

        public DateTime DateOfBirthday
        {
            get { return _dateOfBirthday; }
            set { _dateOfBirthday = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }
    }
}
