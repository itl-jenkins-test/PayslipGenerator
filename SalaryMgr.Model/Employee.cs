using System;
using System.Globalization;

namespace SalaryMgr.Model
{
    public class Employee
    {
        private string _firstName;
        private string _lastName;
        private int _salary;
        private decimal? _superRate;
        private DateTime? _startDate;
        private DateTime? _endDate;

        public Employee()
        {
            
        }

        //Closing out the properties so they can't be set any other way than the constructor
        public Employee(string fname, string lname, int sal, decimal rate, string startDate, string endDate)
        {
            FirstName = fname;
            LastName = lname;
            Salary = sal;
            SuperRate = rate;
            
            //TODO should move this into the property eventually
            if(String.IsNullOrEmpty(startDate))
                throw new ArgumentException("Start Date must be provided and in the format yyyy-mm-dd");
             else
                StartDate = DateTime.ParseExact(startDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            if (String.IsNullOrEmpty(endDate))
                throw new ArgumentException("End Date must be provided and in the format yyyy-mm-dd");
            else
                EndDate = DateTime.ParseExact(endDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        }

        
        public string FirstName {
            get { return _firstName; }
            set
            {
                if(String.IsNullOrEmpty(value))
                    throw new ArgumentException("First Name must be provided");

                _firstName = value;                
            } 
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("Last Name must be provided");

                _lastName = value;                
            }
        }

        public int Salary { get { return _salary; }
           set
            {
                if (value < 0)
                    throw new ArgumentException("Salary is a positive value");

                _salary = value;
            }
        }

        
        public decimal? SuperRate {
            get { return _superRate; }
            set {
                if (!value.HasValue)
                    throw new ArgumentException("Super Rate must be provided");

                if (value < 0 || value > 50)
                    throw new ArgumentException("Super Rate value must be between 0 and 50 both inclusive"); 
                
                _superRate = value;
            }
        }

        
        public DateTime? StartDate {
            get { return _startDate;}
            set
            {
                if (!value.HasValue)                
                    throw new ArgumentException("Start Date must be provided");

                _startDate = value;
            }
        }

        
        public DateTime? EndDate {
            get { return _endDate;}
            set
            {
                if (!value.HasValue)
                    throw new ArgumentException("End Date must be provided");
                if (DateTime.Compare(StartDate.Value,value.Value) >= 0)
                    throw new ArgumentException("End Date has to be greater than Start Date");

                _endDate = value;
            }
        }
    }
}