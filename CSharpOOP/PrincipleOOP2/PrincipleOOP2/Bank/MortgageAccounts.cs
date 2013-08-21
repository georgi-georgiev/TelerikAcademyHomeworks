using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class MortgageAccounts : Accounts, IDepositable
    {
        public int NumberOfMonths
        {
            get;
            private set;
        }

        public MortgageAccounts(CustomerType customer, decimal balance, decimal interestRate, int numberOfMonths)
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
            if (this.Customer == CustomerType.Individual && this.NumberOfMonths <= 6)
            {
                return 0m;
            }
            else if (this.Customer == CustomerType.Company && this.NumberOfMonths <= 12)
            {
                return this.InterestRate * this.NumberOfMonths / 2m;
            }
            else
            {
                return this.InterestRate * this.NumberOfMonths;
            }
            
        }
    }
}
