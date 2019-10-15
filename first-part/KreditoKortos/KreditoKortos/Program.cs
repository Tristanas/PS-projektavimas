using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KreditoKortos
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
            Account myAccount = new Account("LT113423444", euro, 500f);
            Account myFriend = new Account("US131234923485", byteCoin);
            Account anotherFriend = new Account("LT10005000043", dollar);

            string selection;
            CreditCard myCard;
            Console.WriteLine("Select your card by writing the index of desired card:");
            Console.WriteLine("1. Regular card, 2. Premium, 3. Master card.");

            selection = Console.ReadLine();
            switch (selection.First())
            {
                case '1':
                    myCard = new RegularCard(myAccount);
                    break;
                case '2':
                    myCard = new PremiumCard(myAccount);
                    break;
                case '3':
                    myCard = new MasterCard(myAccount);
                    break;
                default:
                    Console.WriteLine("Wrong selection. Good bye.");
                    return;
            }

            // Predefined scenario:
            myCard.TransferMoney(10f, myFriend);
            myCard.TransferMoney(120f, anotherFriend);
            myCard.WithrawMoney(50f, euro, "LT");
            myCard.WithrawMoney(50f, euro, "LV");
        }
    }
}
