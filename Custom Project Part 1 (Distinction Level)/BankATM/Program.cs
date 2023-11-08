// See https://aka.ms/new-console-template for more information
using BankATM;

////////////////////////New Bank//////////////////////////////////////////
Bank bank1 = new Bank("TechcomBank");
//////////////////////////////////////////////////////////////////////////


/////////////////////////////////////Customer 1///////////////////////////
////////////New Customer1///////////
string name1 = "An Le";
string phone1 = "09083423333";
string email1 = "anle@email.com";
string address1 = "12 Vu Pham Ham, Cau Giay, Ha Noi";
Customer customer1 = new Customer(name1, phone1, email1, address1);
////////////Customer1's daily spending account///////
string id1 = "342323123445";
int pin1 = 2345;
Account spending1 = new CurrentAccount(id1, customer1, pin1);
////////////Customer1's saving account///////////
string id2 = "245645623242";
Account saving1 = new SavingsAccount(id2, customer1, pin1); 
///////////Associate Customer1 accounts with bank1//////
bank1.Accounts.Add(spending1);
bank1.Accounts.Add(saving1);
////////////////////////////////////////////////////////////////////////// 


/////////////////////////////////////Customer 2///////////////////////////
///New Customer2
string name2 = "Le An";
string phone2 = "08345902345";
string email2 = "le@email.com";
string address2 = "5 Pham Ngoc Thach, Dong Da, Ha Noi";
Customer customer2 = new Customer(name2, phone2, email2, address2);
////////////Customer2's daily spending account///////
string id3 = "123432512344";
int pin2 = 6789;
Account spending2 = new CurrentAccount(id3, customer2, pin2);
////////////Customer2's saving account///////////
string id4 = "745623456782";
Account saving2 = new SavingsAccount(id4, customer2, pin2);
///////////Associate Customer2 accounts with bank1//////
bank1.Accounts.Add(spending2);
bank1.Accounts.Add(saving2);
////////////////////////////////////////////////////////////////////////// 


//////////////////////////////////////////////////////////////////////////
//////////////New ATM associated with bank1///////////////
string location = "361 Truong Chinh";
ATM atm = new ATM(bank1, location);
//////////////////////////////////////////////////////////////////////////

bool active = true;
bool loggedIn = false;
Console.WriteLine("Welcome to the ATM\n");
double num = Double.Parse(Console.ReadLine());

//Console.WriteLine(String.Format("{0:n}", num));
//Console.WriteLine(num.ToString("N2"));
///Console.WriteLine(num.ToString("#,##0.00"));
string input;


while (active == true)
{
    string typeSelect;

    Console.WriteLine("1. Login\n2. Exit\n" +
        "\nPlease select one of the options above:");
    input = Console.ReadLine();

    /// Letting the user select which account type they would like to use
    void accountSelect()
    {
        Console.WriteLine("Please select an account to proceed:\n" +
        "1. Spending\n" +
        "2. Saving\n");
        input = Console.ReadLine();
        atm.SelectAccountType(input, atm.CurrentUser.Name);
    }

    switch (input)
    {
        case "Login":
            Console.Write("Enter you PIN number: ");
            input = Console.ReadLine();
            int pin = Convert.ToInt32(input);
            if (atm.ValidatePin(pin))
            {
                Console.Clear();
                Console.WriteLine("Logged In success\n");
                Console.WriteLine($"Welcome {atm.CurrentUser.Name}\n");
                loggedIn = true;

                while (loggedIn == true)
                {
                    Console.WriteLine("1. View Transactions\n" +
                        "2. Withdraw\n" +
                        "3. Deposit\n" +
                        "4. Transfer\n" +
                        "5. View Account Details\n" +
                        "6. Check Personal Info\n" +
                        "7. Update Personal Info\n");
                    Console.WriteLine("Please select one of the options above: ");
                    input = Console.ReadLine();

                    switch (input)
                    {
                        case "Logout":
                            atm.CurrentAccount = null;
                            atm.AccountType = AccountType.None;
                            Console.WriteLine("Logged Out.");
                            Console.Clear();
                            Console.WriteLine("Welcome to the ATM\n");
                            loggedIn = false;
                            break;

                        case "View Transactions":
                            Console.Clear();
                            accountSelect();
                            atm.OptionProcessing("View Transactions", atm.CurrentAccount);
                            break;

                        case "Withdraw":
                            Console.Clear();
                            accountSelect();
                            atm.OptionProcessing("Withdraw", atm.CurrentAccount);
                            break;

                        case "Deposit":
                            Console.Clear();
                            accountSelect();
                            atm.OptionProcessing("Deposit", atm.CurrentAccount);
                            break;

                        case "Transfer":
                            Console.Clear();
                            accountSelect();
                            atm.OptionProcessing("Transfer", atm.CurrentAccount);
                            break;

                        case "View Account Details":
                            Console.Clear();
                            accountSelect();
                            atm.OptionProcessing("View Account Details", atm.CurrentAccount);
                            break;

                        case "Check Personal Info":
                            Console.Clear();
                            atm.OptionProcessing("Check Personal Info", atm.CurrentAccount);
                            break;

                        case "Update Personal Info":
                            Console.Clear();
                            atm.OptionProcessing("Update Personal Info", atm.CurrentAccount);
                            break;

                        case "ATM details":
                            Console.WriteLine(atm.DetailsATM);
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Authentication Failed: Wrong PIN\n");
            }
            break;

        case "Exit":
            Console.WriteLine("ATM exited.");
            active = false;
            break;
    }
}