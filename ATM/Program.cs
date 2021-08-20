using System;

namespace ATM
{
    /* Amount samples
     * Should dispense:
     * 197
     * Should not dispense:
     * 123, 126
     */

    public class Program
    {
        private IDispenseHandler handler;
        private static string password = "123";

        public Program()
        {
            // Initialize the handler
            handler = new MoneyDispenser(50, 5, 2);

            // You can change quantities and limits of each currency
            IDispenseHandler handler2 = new MoneyDispenser(20, 5, 2);
            IDispenseHandler handler3 = new MoneyDispenser(10, 5);
            IDispenseHandler handler4 = new MoneyDispenser(5, 3);
            IDispenseHandler handler5 = new MoneyDispenser(2, 3);

            // Set the chain of responsibility
            handler.SetNextHandler(handler2);
            handler2.SetNextHandler(handler3);
            handler3.SetNextHandler(handler4);
            handler4.SetNextHandler(handler5);
        }

        public static void Main(string[] args)
        {
            try
            {
                string pin = null;
                while (pin != password)
                {
                    Console.WriteLine("Enter your pin code:");
                    pin = Console.ReadLine();

                    if (pin != password)
                        Console.WriteLine("Incorrect pin");
                }

                int amount = 0;
                Console.WriteLine("Enter amount to dispense:");
                if (!int.TryParse(Console.ReadLine(), out amount))
                {
                    Console.WriteLine("Invalid amount. Please make sure to use only numbers");
                }

                Program program = new Program();
                var results = program.handler.Dispense(new Currency(amount), null);

                foreach (var result in results)
                {
                    Console.WriteLine($"Dispensing {result.Key} {result.Value}$ note");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
