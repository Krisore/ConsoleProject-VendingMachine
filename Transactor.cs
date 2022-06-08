namespace VendingMachine
{
    internal class Transactor
    {
        private int _amountAvailable;

        public Transactor()
        {
            this._amountAvailable = 100;
        }

        private bool ValidateBill(int bill)
        {
            if (100 % bill == 0)
            {
                return true;
            }

            return false;
        }

        private void SubBill(int change)
        {
            this._amountAvailable -= change;
        }
        public bool GetChange(int userAmount)
        {
            if (userAmount > 0)
            {
                SubBill(userAmount);
                return true;
            }
            else return false;
        }

        public bool AddAmount(int bill)
        {
            if (ValidateBill(bill))
            {

                this._amountAvailable += bill;
                return true;
            }

            return false;
        }


    }

}
