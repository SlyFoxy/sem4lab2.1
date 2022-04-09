using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sem4lab2._1
{
    sealed class Client : Person
    {
        public string company { get; set; }
		public Client() : this("Tsal'", "Vitaliy", "Olegovich")
        {

        }
		public Client(string _lastName, string _firstName, string _middleName) : this(_lastName, _firstName, _middleName,
			"19.11.1990", "+380935617360", "AsusGromyako", "PID123456789", 31, "M")
        {

        }
		public Client(string _lastName, string _firstName, string _middleName, string _dateOfBirth, string _telephoneNumber,
			string _company, string _passportID, int _age, string _sex) : base(_lastName, _firstName, _middleName,
				_dateOfBirth, _telephoneNumber, _passportID, _age, _sex)
        {
            company = _company;
        }
        public override string selfDescribe()
        {
            return "Client: " + getFullName;
        }
    }
}
