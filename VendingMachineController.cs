namespace VendingMachine
{
    internal class VendingMachineController
    {

        int input = 0;
        private readonly Item[,] _shelve;
        private readonly Display _machineDisplay;
        private readonly Transactor _machineTransactor;
        private readonly Keypad _machineKeypad;
        private int _userAmount;

        public VendingMachineController(Item[,] items)
        {
            this._shelve = items;
            this._machineKeypad = new Keypad();
            this._machineDisplay = new Display();
            this._machineTransactor = new Transactor();
            this._userAmount = 0;
        }

        public void TurnOn()
        {
            _machineDisplay.WelcomeMessage();
            while (true)
            {
                _machineDisplay.DisplayMethod();
                _machineDisplay.DisplayMethod("Please Enter Your Selection: \n");
                input = _machineKeypad.ReadKeyInput();

                switch (input)
                {
                    case 1:
                        _machineDisplay.DisplayMethod("Insert Bill:$ ");
                        var bill = _machineKeypad.ReadKeyInput();
                        if (_machineTransactor.AddAmount(bill))
                        {
                            _userAmount += bill;
                            _machineDisplay.DisplayMethod($"Your Current Bill Balance:${_userAmount}");
                            Thread.Sleep(3000);
                        }
                        else
                        {
                            Console.WriteLine("You Entered Invalid Bill");
                            _machineDisplay.DisplayMethod($"Your Current Bill Balance ${_userAmount}");
                        }
                        break;
                    case 2:
                        _machineDisplay.DisplayMethod(this._shelve);
                        _machineDisplay.DisplayMethod($"Your Current Balance ${_userAmount} \n");
                        Console.Write("Select Slot : ");
                        int slot = _machineKeypad.ReadKeyInput();
                        BuyProduct(slot);
                        break;
                    case 3:
                        if (_machineTransactor.GetChange(_userAmount))
                        {
                            _machineDisplay.DisplayMethod($"Please Collect your change ${_userAmount} from Change Dispenser");
                        }
                        break;
                    case 4:
                        if (_userAmount == 0)
                        {
                            _machineDisplay.DisplayMethod("Thank You for Using the Vendy!\n");
                            Thread.Sleep(2000);
                            Console.Clear();
                            _machineDisplay.WelcomeMessage();
                        }
                        else
                        {
                            _machineDisplay.DisplayMethod("OOPS! You Forgot to Collect your change");
                            _machineDisplay.DisplayMethod(("Please Collect Your Change $" + _userAmount + " from the Cash Dispenser\n"));
                            _machineDisplay.DisplayMethod("Thank You for Using the Vendy!\n");
                            _userAmount = 0;
                            Thread.Sleep(4000);
                            Console.Clear();
                            _machineDisplay.WelcomeMessage();
                        }
                        break;
                    default:
                        Console.Clear();
                        _machineDisplay.DisplayMethod("Please Make a Valid Selection\n");
                        Thread.Sleep(1000);
                        break;

                }
            }

        }
        private void BuyProduct(int slot)
        {

            int column = (slot % 10) - 1;
            int row = (slot / 10) - 1;
            if ((row >= 0 && row <= 2) && (column >= 0 && column <= 3))
            {
                if (_shelve[row, column] != null)
                {
                    if (_shelve[row, column].Price <= _userAmount)
                    {
                        Console.Clear();
                        _machineDisplay.DisplayMethod("You've Bought:");
                        _machineDisplay.DisplayMethod(_shelve[row, column].DisplayMessage() + "\n");
                        _machineDisplay.DisplayMethod("Please Pick your " + _shelve[row, column].ItemName + " from the Dispenser\n");
                        _userAmount -= this._shelve[row, column].Price;
                        _shelve[row, column] = null;

                        Thread.Sleep(1000);
                    }
                    else
                    {
                        _machineDisplay.DisplayMethod("\nSorry You don't have Enough Balance to buy: " + _shelve[row, column].ItemName + "\n");
                    }
                }
                else
                {
                    _machineDisplay.DisplayMethod("\nThe Selected Slot # is Empty\n");
                }
            }
            else
            {
                _machineDisplay.DisplayMethod("\nYou've Entered an Invalid Slot Number\n");
            }
        }
    }
}
