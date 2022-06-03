namespace VendingMachine
{
    internal class Keypad
    {
        public int ReadKeyInput()
        {
            int input = Convert.ToInt32(Console.ReadLine());
            return input;
        }
    }
}
