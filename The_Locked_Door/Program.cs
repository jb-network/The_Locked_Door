// This is challenge work for the "C# Players Guide"
// Level 24 "The Locked Door" Challenge
//The door has four states Open, Closed, Locked, Unlocked
// To unlock a code must be used
// The user must be able to change the code, if the current code is provided. 

Console.WriteLine("Welcome to Door Master 2000!");
Console.WriteLine("Please set a intial numeric passcode for the door");
int IntialPin = Convert.ToInt32(Console.ReadLine());
Door NewDoor = new Door(IntialPin);
Console.WriteLine("Press any key to begin");
Console.ReadKey();
Console.Clear();




while (true)
{
    
    string menu = UserMenu(NewDoor, IntialPin);
    Console.ReadKey();


}

string UserMenu(Door newDoor, int intialPin)
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
    return null;
}

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
public enum DoorStatus { Open, Closed, Locked, Unlocked }