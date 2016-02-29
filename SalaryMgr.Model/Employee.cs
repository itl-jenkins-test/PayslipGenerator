using System;
using System.Globalization;

namespace SalaryMgr.Model
{
    public class Employee
    {
        private string firstName;
        private string lastName;
        private int salary;
        private decimal? superRate;
        private DateTime? startDate;
        private DateTime? endDate;

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
            get { return firstName; }
            private set
            {
                if(String.IsNullOrEmpty(value))
                    throw new ArgumentException("First Name must be provided");
                else
                {
                    firstName = value;
                }
            } 
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            private set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("Last Name must be provided");
                else
                {
                    lastName = value;
                }

            }
        }

        public int Salary { get { return salary; }
           private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Salary is a positive value");
                }
                salary = value;
            }
        }

        
        public decimal? SuperRate {
            get { return superRate; }
            private set {
                if (!value.HasValue)
                {
                    throw new ArgumentException("Super Rate must be provided");
                }
                if (value >= 0 && value <= 50)
                {
                    superRate = value;
                }
                else
                {
                    throw new ArgumentException("Super Rate value must be between 0 and 50 both inclusive");
                }
            }
        }

        
        public DateTime? StartDate {
            get { return startDate;}
            private set
            {
                if (value.HasValue)
                {
                    startDate = value;
                }
                else
                {
                    throw new ArgumentException("Start Date must be provided");
                }
            }
        }

        
        public DateTime? EndDate {
            get { return endDate;}
            private set
            {
                if (!value.HasValue)
                {
                    throw new ArgumentException("End Date must be provided");
                }
                if (DateTime.Compare(StartDate.Value,value.Value) < 0)
                {
                    endDate = value;
                }
                else
                {
                    throw new ArgumentException("End Date has to be greater than Start Date");
                }
            }
        }
    }
}