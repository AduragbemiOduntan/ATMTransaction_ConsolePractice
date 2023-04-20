
while (true)
{
    int value;
    Console.WriteLine("Welcome to the ATM machine!\r\nPlease choose an option:\r\n1. Check balance\r\n2. Withdraw cash\r\n3. Transfer\r\n4. Deposit cash\r\n5. Exit\r\n");
    bool input = int.TryParse(Console.ReadLine(), out value);

    if (input)
    {
        switch (value)
        {
            case 1:
                ProgramsAcct.Balance();
                break;
            case 2:
                Console.WriteLine("Enter the amount");
                string? withdrawalAmount = Console.ReadLine();
                ProgramsAcct.Withdrawal(withdrawalAmount);
                break;
            case 3:
                Console.WriteLine("Enter amount");
                double tranferAmount = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter receiver's account number");
                string? receiverAcct = (Console.ReadLine());
                if(receiverAcct.Length != 10)
                {
                    Console.WriteLine("Invalid account number. Try again...");
                    continue;
                }
                Console.WriteLine("Enter bank");
                string? receiverBank = Console.ReadLine();
                
                ProgramsAcct.Transfer(tranferAmount, receiverAcct, receiverBank);
                break;
            case 4:
                Console.WriteLine("Enter ammount");
                double depositAmount = double.Parse(Console.ReadLine());
                ProgramsAcct.Deposit(depositAmount);
                break;
            case 5:
                Console.WriteLine("Thank you for using our service. Goodbye!...");
                break;
            default:
                Console.WriteLine("Invalid input. Please input a valid number.");
                continue;
        }
    }
    else
    {
        Console.WriteLine("invalid input, try again...");
        continue;
    }
    Console.WriteLine("Would you like to carry out other transaction?\nPress y to continue or any key to exit.");
    //string? actionInput = Console.ReadLine();
    if (Console.ReadLine() == "y") continue;
    break;
    Console.WriteLine("\n");
}

//Methds
static class ProgramsAcct
{
    public static double accountBalance { get; set; } = 2500000;
    public static void Balance()
    {
        Console.WriteLine($"Your account balance is ${accountBalance}");
    }
    public static void Withdrawal(string amount)
    {
        bool convertedAmount = (double.TryParse(amount, out double value));
        if ((amount != null) && convertedAmount)
        {
            if (value < accountBalance)
            {
                accountBalance -= value;
                Console.WriteLine($"Trasaction Successful.\nYour current account balance is {accountBalance}");
            }
            else Console.WriteLine("Insufficient balance");
        }
        Console.WriteLine("Input a valid amount");
    }
    public static void Deposit(double amount)
    {
         accountBalance += amount;
        Console.WriteLine($"Trasaction Successful, ${amount} was deposited to your account. Your current accaount balance ia {accountBalance}");
    }
    public static void Transfer(double amount, string receiverAccount, string receiverBank)
    {
        if (amount < accountBalance)
        {
            double balance = accountBalance - amount;
            Console.WriteLine($"Trasaction Successful.\nAmount Tranfered: ${amount}\nDestination: {receiverAccount}\nBank: {receiverBank}\n Account Balance: {accountBalance}");
        }
        else Console.WriteLine("Insufficient balance");
    }
}
