// This is challenge work for the "C# Players Guide"
// Level 24 "The Locked Door" Challenge
//The door has four states Open, Closed, Locked, Unlocked
// To unlock a code must be used
// The user must be able to change the code, if the current code is provided. 


int PinNumber = DoorSetup();
Door NewDoor = new Door(PinNumber);


while (true)
{
    string UserChoice = UserMenu(NewDoor, PinNumber );
    
    //for testing...remove
    Console.WriteLine($"end program: {UserChoice}");
    Console.WriteLine("Press any key to end program");
    Console.ReadKey();
    break;
    //for testing...remove
}

//Local Methods

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
        Console.WriteLine("* - (C)losed                                     *");
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
    }
    while (UserAction != "o" && UserAction != "c" && UserAction != "l" && UserAction != "u" && UserAction != "s" && UserAction != "e");
    return UserAction;
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
}
//Enum
public enum DoorStatus { Open, Closed, Locked, Unlocked }