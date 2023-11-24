// See https://aka.ms/new-console-template for more information
using BankATM;
using System.Globalization;

//////////////////////// New Bank //////////////////////////////////////////
Bank bank1 = new Bank("TechcomBank");
//////////////////////////////////////////////////////////////////////////


///////////////////////////////////// Customer 1 ///////////////////////////
//////////// New Customer1 ///////////
string name1 = "An Le";
string phone1 = "09083423333";
string email1 = "anle@email.com";
string address1 = "12 Vu Pham Ham, Cau Giay, Ha Noi";
Customer customer1 = new Customer(name1, phone1, email1, address1);
//////////// Customer1's daily spending account ///////
string id1 = "342323123445";
int pin1 = 2345;
Account spending1 = new CurrentAccount(id1, customer1, pin1);
//////////// Customer1's saving account ///////////
string id2 = "245645623242";
Account saving1 = new SavingsAccount(id2, customer1, pin1);
/////////// Associate Customer1 accounts with bank1 //////
bank1.Accounts.Add(spending1);
bank1.Accounts.Add(saving1);
////////////////////////////////////////////////////////////////////////// 


//////////////////////////////////// /Customer 2 ///////////////////////////
//////////// New Customer2 ///////////
string name2 = "Le An";
string phone2 = "08345902345";
string email2 = "le@email.com";
string address2 = "5 Pham Ngoc Thach, Dong Da, Ha Noi";
Customer customer2 = new Customer(name2, phone2, email2, address2);
//////////// Customer2's daily spending account ///////
string id3 = "123432512344";
int pin2 = 6789;
Account spending2 = new CurrentAccount(id3, customer2, pin2);
//////////// Customer2's saving account ///////////
string id4 = "745623456782";
Account saving2 = new SavingsAccount(id4, customer2, pin2);
/////////// Associate Customer2 accounts with bank1 //////
bank1.Accounts.Add(spending2);
bank1.Accounts.Add(saving2);
////////////////////////////////////////////////////////////////////////// 


//////////////////////////////////////////////////////////////////////////
////////////// New ATM associated with bank1 ///////////////
string location = "361 Truong Chinh";
ATM atm = new ATM(bank1, location);
//////////////////////////////////////////////////////////////////////////

bool active = true;
bool loggedIn = false;

Console.WriteLine("Welcome to the ATM\n");
/*double num = double.Parse(Console.ReadLine());


NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
Console.WriteLine(num.ToString("C", nfi));*/


//// Validate user's input that they are integers only
bool ValidateDigit(string selection)
{
    if (!selection.All(char.IsDigit))
    {
        Console.WriteLine("Please write your selection as integers only\n");
        return false;
    }
    else if(selection == "")
    {
        Console.WriteLine("Empty input detected. Please choose one of the options in numbers\n"); 
        return false;
    }
    else
    {
        return true;
    }
}


while (active == true)
{
    string input;
    int optionSelected;

    //// Letting the user select which account type they would like to use
    bool accountSelected()
    {
        Console.WriteLine("Please select an account to proceed (Select in Number):\n" +
        "1. Spending\n" +
        "2. Saving\n");
        Console.WriteLine("Note: Press 'Enter' again to cancel");
        input = Console.ReadLine();

        if (ValidateDigit(input) && input == "1" || input == "2")
        {
            optionSelected = int.Parse(input);
            atm.SelectAccountType(optionSelected, atm.CurrentUser.Name);
            return true;
        }
        else
        {
            Console.WriteLine("Invalid Account Type\n");
            return false;
        }
    }


/////////////////////////////////////// Bank ATM UI //////////////////////////////////////////
    Console.WriteLine("1. Login\n2. Exit\n" +
        "\nPlease select one of the options above:");
    input = Console.ReadLine();

    if (ValidateDigit(input))
    {
        optionSelected = int.Parse(input);
        switch (optionSelected)
        {
            case 1:
                // Note: Refer to the top part of the file for login details
                Console.Write("Enter you PIN number: ");
                input = Console.ReadLine();

                if (ValidateDigit(input))
                {
                    int pin = int.Parse(input);

                    if (atm.ValidatePin(pin))
                    {
                        Console.Clear();
                        Console.WriteLine("Logged In success\n");
                        Console.WriteLine($"Welcome {atm.CurrentUser.Name}\n");
                        loggedIn = true;

                ////////////////////// Begin second menu after successful login ///////////////
                        while (loggedIn == true)
                        {
                            Console.WriteLine("1. View Transactions\n" +
                                "2. Withdraw\n" +
                                "3. Deposit\n" +
                                "4. Transfer\n" +
                                "5. View Account Details\n" +
                                "6. Check Personal Info\n" +
                                "7. Update Personal Info\n" +
                                "8. About This ATM\n" +
                                "9. Logout\n");
                            Console.WriteLine("Please select one of the options above (Select in Number): ");

                            input = Console.ReadLine();

                            if (ValidateDigit(input))
                            {
                                optionSelected = int.Parse(input);

                ////////////////////////// Selections for second menu /////////////////////////
                                switch (optionSelected)
                                {
                                    case 1: //// View Transactions
                                        Console.Clear();
                                        if (!accountSelected())
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            atm.OptionProcessing("View Transactions", atm.CurrentAccount);
                                        }
                                        break;

                                    case 2://// Withdraw
                                        Console.Clear();
                                        if (!accountSelected())
                                        {
                                            break;
                                        }
                                        else
                                        {

                                            atm.OptionProcessing("Withdraw", atm.CurrentAccount);
                                        }
                                        break;

                                    case 3://// Deposit
                                        Console.Clear();
                                        if (!accountSelected())
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            atm.OptionProcessing("Deposit", atm.CurrentAccount);
                                        }
                                        break;

                                    case 4://// Transfer
                                        Console.Clear();
                                        if (!accountSelected())
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            atm.OptionProcessing("Transfer", atm.CurrentAccount);
                                        }
                                        break;

                                    case 5: //// View Account Details
                                        Console.Clear();
                                        if (!accountSelected())
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            atm.OptionProcessing("View Account Details", atm.CurrentAccount);
                                        }
                                        break;

                                    case 6://// Check Personal Info
                                        Console.Clear();
                                        atm.OptionProcessing("Check Personal Info", atm.CurrentAccount);
                                        break;

                                    case 7://// Update Personal Info
                                        Console.Clear();
                                        atm.OptionProcessing("Update Personal Info", atm.CurrentAccount);
                                        break;

                                    case 8://// About This ATM
                                        Console.WriteLine(atm.DetailsATM);
                                        break;

                                    case 9://// Logout
                                        atm.CurrentAccount = null;
                                        atm.AccountType = AccountType.None;
                                        Console.WriteLine("Logged Out.");
                                        Console.Clear();
                                        Console.WriteLine("Welcome to the ATM\n");
                                        loggedIn = false;
                                        break;

                                    default://// When user input wrong options
                                        Console.WriteLine("Invalid selection, please choose from the options above");
                                        break;
                                }
                            }
                        }
                    }
                    else
                    {
                        //// Returns message to user after failed login
                        Console.WriteLine("Authentication Failed: Wrong PIN\n");
                    }
                }
                break;

            /////////// Logout at Homescreen //////////////
            case 2:
                Console.WriteLine("ATM exited.");
                active = false;
                break;
        }
    }
}
