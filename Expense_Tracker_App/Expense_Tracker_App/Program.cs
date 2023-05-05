namespace Expense_Tracker_App
{
    class Transaction
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public string Date { get; set; }
    }

    class Application
    {
        List<Transaction> transactions;

        public Application()
        {
            transactions = new List<Transaction>();
        }

        public void AddTransaction(Transaction transaction)
        {
            transactions.Add(transaction);
        }

        public List<Transaction> ViewExpenses()
        {
            List<Transaction> expenses = new List<Transaction>();
            foreach (Transaction e in transactions)
            {
                if (e.Amount < 0)
                {
                    expenses.Add(e);
                }
            }
            return expenses;
        }

        public List<Transaction> ViewIncomes()
        {
            List<Transaction> incomes = new List<Transaction>();
            foreach (Transaction i in transactions)
            {
                if (i.Amount > 0)
                {
                    incomes.Add(i);
                }
            }
            return incomes;
        }

        public int CheckAvailableBalance()
        {
            int balance = 0;
            foreach (Transaction b in transactions)
            {
                balance += b.Amount;
            }
            return balance;
        }



        internal class Program
        {
            static void Main(string[] args)
            {
                Application obj = new Application();

                string ans = "";
                do
                {
                    Console.WriteLine("Welcome to Expense Tracker App");
                    Console.WriteLine("1. Add Transaction");
                    Console.WriteLine("2. View Expenses");
                    Console.WriteLine("3. View Incomes");
                    Console.WriteLine("4. Check Available Balance");
                    int choice = 0;
                    try
                    {
                        Console.WriteLine("Enter ur Choice");
                        choice = Convert.ToInt16(Console.ReadLine());
                    }
                    catch (FormatException)
                    {

                        Console.WriteLine("You can enter only Numbers");
                    }
                    switch (choice)
                    {
                        case 1:
                            {
                                Console.WriteLine("Enter Transaction Title");
                                string title = Console.ReadLine();
                                Console.WriteLine("Enter Transaction Description");
                                string description = Console.ReadLine();
                                Console.WriteLine("Enter Transaction Amount");
                                int amount = Convert.ToInt16(Console.ReadLine());
                                Console.WriteLine("Enter Transaction Date (in format DD/MM/YYYY)");
                                string date = Console.ReadLine();
                                obj.AddTransaction(new Transaction() { Title = title, Description = description, Amount = amount, Date = date });
                                Console.WriteLine("Transaction added successfully!");
                                break;

                            }
                        case 2:
                            {
                                foreach (Transaction item in obj.ViewExpenses())
                                {
                                    Console.WriteLine($"{item.Title} {item.Description} {item.Amount} {item.Date}");
                                }
                                break;
                            }
                        case 3:
                            {
                                foreach (Transaction itemm in obj.ViewIncomes())
                                {
                                    Console.WriteLine($"{itemm.Title} {itemm.Description} {itemm.Amount} {itemm.Date}");
                                }
                                break;
                            }
                        case 4:
                            {
                                Console.WriteLine($"Available Balance: {obj.CheckAvailableBalance()}");
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Wrong Choice Entered");
                                break;
                            }
                    }
                    Console.WriteLine("Do you wish to continue? [y/n] ");
                    ans = Console.ReadLine();
                } while (ans.ToLower() == "y");
            }
        }
    }

}