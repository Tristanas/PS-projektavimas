using KreditoKortos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegavimoSchemosKortos
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

            RegularCard card = new RegularCard(myAccount);
            // PremiumCard premiumCard = new PremiumCard(myAccount);
            // MasterCard masterCard = new MasterCard(myAccount);
            Order order = card.OrderCard();
            if (order != null)
            {
                Console.WriteLine($"Ordering {order.itemName} for {order.price + order.transferPrice}. The order will arrive in {order.arrivalDate}");
            }


            Console.WriteLine($"Your bank account has: {myAccount.getSum()} {myAccount.usedCurrency.Name}");
            Console.WriteLine("You're requesting a loan, enter sum:");
            float sum = float.Parse(Console.ReadLine());
            card.GetLoan(sum);

            float transferSum1 = 10f, transferSum2 = 120f, withrawSum1 = 50f, withrawSum2 = 50f;
            Console.WriteLine($"Before carrying out any operations your bank account is {myAccount.getSum()} {myAccount.usedCurrency.Name}");

            card.Transfer(transferSum1, myFriend, card);
            printStatusUpdate(transferSum1, myFriend, myAccount);
            card.Transfer(transferSum2, anotherFriend, card);
            printStatusUpdate(transferSum2, anotherFriend, myAccount);

            card.Withdraw(withrawSum1, euro, "LT", card);
            printStatusUpdate(withrawSum1, euro, "LT", myAccount);
            card.Withdraw(withrawSum2, euro, "LV", card);
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
