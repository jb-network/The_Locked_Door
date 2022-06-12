// This is challenge work for the "C# Players Guide"
// Level 24 "The Locked Door" Challenge
//The door has four states Open, Closed, Locked, Unlocked
// To unlock a code must be used
// The user must be able to change the code, if the current code is provided. 

//Get pin and create a door object named NewDoor
int PinNumber = DoorSetup();
Door NewDoor = new Door(PinNumber);

while (true)
{
    string UserChoice = UserMenu(NewDoor, PinNumber );
    DoorAction(NewDoor, PinNumber, UserChoice);
}

//Local Methods
//Set pin method
int DoorSetup()
{
    Console.WriteLine("Welcome to Door Master 2000!");
    Console.WriteLine("Please set a intial numeric passcode for the door");
    int IntialPin = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Press any key to begin");
    Console.ReadKey();
    Console.Clear();
    return IntialPin;
}
//Menu method, passes letter to main, unless the user exits the program. 
string UserMenu(Door newDoor, int intialPin)
{
    string UserAction;
    do
    {
        Console.WriteLine("**************************************************");
        Console.WriteLine("* DOOR MASTER 2000                               *");
        Console.WriteLine($"* Current Door Status: \t{newDoor.doorstatus}    ");
        Console.WriteLine("**************************************************");
        Console.WriteLine("* Please make a selection:                       *");
        Console.WriteLine("* - (O)pen                                       *");
        Console.WriteLine("* - (C)lose                                      *");
        Console.WriteLine("* - (L)ock                                       *");
        Console.WriteLine("* - (U)nlock                                     *");
        Console.WriteLine("* - (S)et Pin                                    *");
        Console.WriteLine("* - (E)xit                                       *");
        Console.WriteLine("**************************************************");
        UserAction = Console.ReadLine().ToLower();

        if (UserAction != "o" && UserAction != "c" && UserAction != "l" && UserAction != "u" && UserAction != "s" && UserAction != "e")
        {
            Console.WriteLine($"Your selection: {UserAction} is not a menu option");
            Console.WriteLine("Press any key to try again");
            Console.ReadKey();
            Console.Clear();
        }
        else if (UserAction == "e")
        {
            Console.WriteLine("'Exit' program selected");
            Console.WriteLine("Press any key to close the program");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
    while (UserAction != "o" && UserAction != "c" && UserAction != "l" && UserAction != "u" && UserAction != "s" );
    return UserAction;
}

//Switch to call methods to set the Door object based on user selection made in UserMenu
void DoorAction(Door newDoor, int pinNumber, string userChoice)
{
    
    switch (userChoice)
    {
        case "o":
            NewDoor.Open();
            break;
        case "c":
            NewDoor.Close();
            break;
        case "l":
            newDoor.Lock();
            break;
        case "u":
            newDoor.Unlock();
            break;
        case "s":
            newDoor.SetPin();
            break;
    }
}

//Class

public class Door
{
    public DoorStatus doorstatus { get; private set; }
    private int passcode;

    public Door(int SetPassCode)
    {
        doorstatus = DoorStatus.Closed;
        passcode = SetPassCode;
    }

    internal void SetPin()
    {
        Console.WriteLine("You chose to 'Set' a new pin");
        Console.WriteLine("Press any key to try and set a new pin");
        Console.ReadKey();
        Console.Clear();
        while (true)
        {
            Console.WriteLine("To reset the lock pin number, please enter the current pin: ");
            int CurrentPin = Convert.ToInt32(Console.ReadLine());

            if (CurrentPin == passcode)
            {
                Console.WriteLine("The number you entered is correct.");
                Console.Write("Please enter a new pin number: ");
                int NewPin = Convert.ToInt32(Console.ReadLine());
                passcode = NewPin;
                Console.WriteLine($"\nPin Number reset to: {NewPin}");
                Console.WriteLine("Press any key to return to the program");
                Console.ReadKey();
                Console.Clear();
                break;
            }
            else
            {
                Console.WriteLine("The pin you entered was incorrect");
                Console.WriteLine("Press any key to try again");
                Console.ReadKey();
                Console.Clear();
                continue;
            }
        }
    }

    internal void Unlock()
    {
        Console.WriteLine("You chose to 'Unlock' the door");
        Console.WriteLine("Press any key to try and unlock the door");
        Console.ReadKey();
        Console.Clear();
            if (doorstatus == DoorStatus.Locked)
            {
                while (true)
                {                        
                    Console.WriteLine("Please enter the current pin to unlock the door");
                    int CurrentPin = Convert.ToInt32(Console.ReadLine());

                    if (CurrentPin == passcode)
                    {
                        doorstatus = DoorStatus.Closed;
                        Console.WriteLine("The Door has changed from Locked to Closed");
                        Console.WriteLine("Press any key to return to the program");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("The pin you entered was incorrect, please try again");
                        Console.WriteLine("Press any key to try again");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    }
                }                 
            }
            else
            {
                Console.WriteLine($"The door is currently: {doorstatus}. It must be 'Locked' to 'Unlock' it.");
                Console.WriteLine("Press any key to return to the program");
                Console.ReadKey();
                Console.Clear();
            }        
    }
    internal void Lock()
    {
        Console.WriteLine("You chose to 'Lock' the door");
        Console.WriteLine("Press any key to try and Lock the door");
        Console.ReadKey();
        Console.Clear();

        if (doorstatus == DoorStatus.Closed)
        {
            doorstatus = DoorStatus.Locked;
            Console.WriteLine("The door has changed from Closed to Locked");
            Console.WriteLine("Press any key to return to the program");
            Console.ReadKey();
            Console.Clear();
        }
        else
        {
            Console.WriteLine($"The door is currently: {doorstatus}. It must be 'Closed' to 'Lock' it.");
            Console.WriteLine("Press any key to return to the program");
            Console.ReadKey();
            Console.Clear();
        }

    }
    internal void Close()
    {
        Console.WriteLine("You chose to 'Close' the door");
        Console.WriteLine("Press any key to try and Close the door");
        Console.ReadKey();
        Console.Clear();
        if (doorstatus == DoorStatus.Open)
        {
            doorstatus = DoorStatus.Closed;
            Console.WriteLine("The door has changed from Open to Closed");
            Console.WriteLine("Press any key to return to the program");
            Console.ReadKey();
            Console.Clear();
        }
        else
        {
            Console.WriteLine($"The door is currently: {doorstatus}. It must be 'Open' to 'Close' it.");
            Console.WriteLine("Press any key to return to the program");
            Console.ReadKey();
            Console.Clear();
        }
    }

    internal void Open()
    {

        Console.WriteLine("You chose to 'Open' the door");
        Console.WriteLine("Press any key to try and Open the door");
        Console.ReadKey();
        Console.Clear();
        if (doorstatus == DoorStatus.Closed)
        {
            doorstatus = DoorStatus.Open;
            Console.WriteLine("The door has changed from Closed to Open");
            Console.WriteLine("Press any key to return to the program");
            Console.ReadKey();
            Console.Clear();
        }
        else
        {
            Console.WriteLine($"The door is currently: {doorstatus}. It must be 'Closed' to 'Open' it.");
            Console.WriteLine("Press any key to return to the program");
            Console.ReadKey();
            Console.Clear();
        }
    }
}

//Enum
public enum DoorStatus { Open, Closed, Locked, Unlocked }