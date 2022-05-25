using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sem4lab2._1
{
    public class CreditCard
    {
        public int Id { get; set; }
        public string CardNumber { get; set; } = "1111 2222 3333 4444";
        public Account Account { get; set; } = null;
        public float CardBalance { get; set; } = 0;
        public DateTime CardExpDate { get; set; } = new DateTime(2026, 12, 31);
        public int CardCVV { get; set; } = 123;
        public bool IsBlocked { get; set; } = false;
        public float CreditLimit { get; set; } = 10000;
        //public int getCardNumber { get { return cardNumber; } }
    }
}
