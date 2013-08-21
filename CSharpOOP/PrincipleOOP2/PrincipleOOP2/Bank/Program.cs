using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            Accounts[] accounts = 
            {
                new DepositAccounts(CustomerType.Company, 999m, 0.13m, 8),
                new DepositAccounts(CustomerType.Individual, 1150m, 0.13m, 8),

                new LoanAccounts(CustomerType.Company, 2327.83m, 0.33m,  10),
                new LoanAccounts(CustomerType.Individual, 3658.43m, 0.33m, 7),

                new MortgageAccounts(CustomerType.Company, 1496.43m, 0.42m, 9),
                new MortgageAccounts(CustomerType.Individual, 1789.99m, 0.41m, 5)
            };

            foreach (var account in accounts)
            {
                Console.WriteLine(account.CalculateInterestAmount());
            }

            Console.WriteLine();

            DepositAccounts depositAcc = new DepositAccounts(CustomerType.Company, 2162.35m, 0.11m, 5);
            depositAcc.Deposit(6000m);
            depositAcc.Withdraw(4000m);
            Console.WriteLine(depositAcc.Balance);
            Console.WriteLine(depositAcc.CalculateInterestAmount());







        }
    }
}
