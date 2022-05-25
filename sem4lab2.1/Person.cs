using System;

namespace sem4lab2._1
{
	public abstract class Person
	{
		public int Id { get; set; }
		public string LastName { get; set; } = "Tsal'";
		public string FirstName { get; set; } = "Vitaliy";
		public string MiddleName { get; set; } = "Olegovich";
		public DateTime DateOfBirth { get; set; } = new DateTime(1990,11,19);
		public string TelephoneNumber { get; set; } = "+380935617360";
		public string PassportID { get; set; } = "PID123456789";		
		public string Sex { get; set; } = "M";
		public string Login { get; set; } = "login";
		public string Password { get; set; } = "password";
		/*public Person() : this("Tsal'", "Vitaliy", "Olegovich")
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
		
		public abstract string selfDescribe();*/
		public string FullName => LastName + " " + FirstName + " " + MiddleName;
	}
}
