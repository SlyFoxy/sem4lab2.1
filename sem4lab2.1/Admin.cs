namespace sem4lab2._1
{
    public sealed class Admin : Person, IPrintable
    {
        public string adminID { get; set; }
        public new string firstName { get; set; }
		public Admin() : this("Tsal'", "Vitaliy", "Olegovich")
        {

        }
		public Admin(string _lastName, string _firstName, string _middleName) : this(_lastName, _firstName, _middleName,
			"19.11.1990", "+380935617360", "PID123456789", 31, "M", "AID123456789")
        {

        }
		public Admin(string _lastName, string _firstName, string _middleName, string _dateOfBirth, string _telephoneNumber,
			string _passportID, int _age, string _sex, string _adminID) : base(_lastName, _firstName, _middleName, _dateOfBirth,
				_telephoneNumber, _passportID, _age, _sex)
        {
			adminID = _adminID;
            firstName = _firstName;
        }
        public override string selfDescribe()
        {
            return "Admin: " + getFullName;
        }

        public string this[int index] => "Admin" + index;
        public string PrintContent { get => firstName; }
        public void Print(MessageSender sender)
        {
            sender(PrintContent);
        }

        public void Draw(string something, MessageSender sender)
        {
            sender("Drawed Admin " + something);
        }
    }
}
