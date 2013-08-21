using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class DepositAccounts : Accounts, IDepositable, IWithdrawable
    {
        public int NumberOfMonths
        {
            get;
            private set;
        }

        public DepositAccounts(CustomerType customer, decimal balance, decimal interestRate, int numberOfMonths)
            : base(customer, balance, interestRate)
        {
            this.NumberOfMonths = numberOfMonths;
        }

        public void Deposit(decimal money)
        {
            this.Balance += money;
        }

        public void Withdraw(decimal money)
        {
            this.Balance -= money;
        }

        public override decimal CalculateInterestAmount()
        {
            if (this.Balance > 0 && this.Balance < 1000)
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
