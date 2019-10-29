using KreditoKortos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardStrategy
{
    class Program
    {
        static void Main(string[] args)
        {
            // Client code:
            // Setting up currencies:
            Currency euro = new Currency() { Name = "Euro", ValueInEuro = 1 };
            Currency byteCoin = new Currency() { Name = "ByteCoin", ValueInEuro = 8.5f };
            Currency dollar = new Currency() { Name = "Dollar", ValueInEuro = 1.234f };

            // Setting up examplary accounts:
            Account myAccount = new Account("LT113423444", euro, 100f);
            Account myFriend = new Account("US131234923485", byteCoin);
            Account anotherFriend = new Account("LT10005000043", dollar);

            string selection;
            CreditCard myCard;
            Console.WriteLine("Select your card by writing the index of desired card:");
            Console.WriteLine("1. Regular card, 2. Premium, 3. Master card.");
            IPaymentStrategy paymentStrategy;
            ILoanStrategy loanStrategy;

            selection = Console.ReadLine();
            switch (selection.First())
            {
                case '1':
                    paymentStrategy = new RegularPaymentStrategy();
                    loanStrategy = new LoanWithDepositStrategy();
                    myCard = new CreditCard(myAccount, paymentStrategy, loanStrategy);
                    break;
                case '2':
                    paymentStrategy = new PremiumPaymentStrategy();
                    loanStrategy = new LoanWithDepositStrategy(100, 20000);
                    myCard = new CreditCard(myAccount, paymentStrategy, loanStrategy);
                    break;
                case '3':
                    loanStrategy = new LoanDepositlessStrategy(100, 200000);
                    paymentStrategy = new MasterPaymentStrategy();
                    myCard = new CreditCard(myAccount, paymentStrategy, loanStrategy);
                    break;
                default:
                    Console.WriteLine("Wrong selection. Good bye.");
                    return;
            }

            // Predefined scenario:
            Console.WriteLine($"Your bank account has: {myAccount.getSum()} {myAccount.usedCurrency.Name}");
            Console.WriteLine("You're requesting a loan, enter sum:");
            float sum = float.Parse(Console.ReadLine());
            myCard.GetALoan(sum);

            float transferSum1 = 10f, transferSum2 = 120f, withrawSum1 = 50f, withrawSum2 = 50f;
            Console.WriteLine($"Before carrying out any operations your bank account is {myAccount.getSum()} {myAccount.usedCurrency.Name}");

            myCard.TransferMoney(transferSum1, myFriend);
            printStatusUpdate(transferSum1, myFriend, myAccount);
            myCard.TransferMoney(transferSum2, anotherFriend);
            printStatusUpdate(transferSum2, anotherFriend, myAccount);

            myCard.WithrawMoney(withrawSum1, euro, "LT");
            printStatusUpdate(withrawSum1, euro, "LT", myAccount);
            myCard.WithrawMoney(withrawSum2, euro, "LV");
            printStatusUpdate(withrawSum2, euro, "LV", myAccount);
            Console.ReadKey();
        }

        static void printStatusUpdate(float sum, Account recipient, Account payer)
        {
            Console.WriteLine("You transfered {0} {1} to your friend. Your bank account now has: {2} {3}.",
                sum, recipient.usedCurrency.Name, payer.getSum(), payer.usedCurrency.Name);
        }
        static void printStatusUpdate(float sum, Currency currency, string country, Account account)
        {
            Console.WriteLine($"You withdrew {sum} {currency.Name} in {country}. "
                + $"Your bank account now has: {account.getSum()} {account.usedCurrency.Name}.");
        }
    }
}
