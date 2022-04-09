using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sem4lab2._1
{
	abstract class Person
	{
		public string lastName { get; set; } = "Tsal'";
		public string firstName { get; set; } = "Vitaliy";
		public string middleName { get; set; } = "Olegovich";
		public string dateOfBirth { get; set; } = "19.11.1990";
		public string telephoneNumber { get; set; } = "+380935617360";
		public string passportID { get; set; } = "PID123456789";
		public int age { get; set; } = 31;
		public string sex { get; set; } = "M";
		public Person() : this("Tsal'", "Vitaliy", "Olegovich")
		{

		}
		public Person(string _lastName, string _firstName, string _middleName) : this(_lastName, _firstName, _middleName, "19.11.1990",
			"+380935617360", "PID123456789", 31, "M")
		{

		}
		public Person(string _lastName, string _firstName, string _middleName, string _dateOfBirth, string _telephoneNumber,
			string _passportID, int _age, string _sex)
		{
			lastName = _lastName; firstName = _firstName; middleName = _middleName;
			dateOfBirth = _dateOfBirth; telephoneNumber = _telephoneNumber; passportID = _passportID;
			age = _age; sex = _sex;
		}
		public string getFullName { get { return lastName + " " + firstName + " " + middleName; } }
		public abstract string selfDescribe();
	}
}
