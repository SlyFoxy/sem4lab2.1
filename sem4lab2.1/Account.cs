using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sem4lab2._1
{
    public class Account
    {
        public int Id { get; set; }
        public string AccountName { get; set; } = "Account";
        public Client Client { get; set; } = null;
        public int ClientId { get; set; }
        //public vector<CreditCard*> creditCards;
        public BindingList<CreditCard> CreditCards { get; set; } = new BindingList<CreditCard>();  //????
        public string AccountID { get; set; } = "a1234";
        public DateTime AccountCreationDate { get; set; } = DateTime.Now;
        
        /*public Account() : this("accname", Client _accountOwner)
        {
        }*/
        /*public Account(string _accountName, Client _accountOwner)
            : this(_accountName, _accountOwner, "accountID", "01/01/2000", 500000)
        {
        }
        public Account(string _accountName, Client _accountOwner, string _accountID, string _accountCreationDate, float _creditLimit)
        {
            accountName = _accountName; accountOwner = _accountOwner; accountID = _accountID;
            accountCreationDate = _accountCreationDate; creditLimit = _creditLimit;
        }*/
       /* public void addCreditCard(CreditCard creditCard)
        {
            creditCards.Add(creditCard);
        }*/
        //public string getAccountName { get { return accountName; } }
    }
}
