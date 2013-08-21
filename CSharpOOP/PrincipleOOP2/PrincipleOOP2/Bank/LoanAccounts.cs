using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class LoanAccounts : Accounts, IDepositable
    {
        public int NumberOfMonths
        {
            get;
            private set;
        }

        public LoanAccounts(CustomerType customer, decimal balance, decimal interestRate, int numberOfMonths)
            : base(customer, balance, interestRate)
        {
            this.NumberOfMonths = numberOfMonths;
        }

        public void Deposit(decimal money)
        {
            this.Balance += money;
        }

        public override decimal CalculateInterestAmount()
        {
            if (this.Customer == CustomerType.Individual && this.NumberOfMonths <= 3)
            {
                return 0m;
            }
            else if (this.Customer == CustomerType.Company && this.NumberOfMonths <= 2)
            {
                return 0m;
            }
            else
            {
                return this.NumberOfMonths * this.InterestRate;
            }
        }
    }
}
