namespace VendingMachine
{
    internal abstract class Item
    {
        public string ItemName { get; }
        public int Price { get; }
        public string Type { get; }

        public Item(string itemName, int price, string type)
        {
            this.ItemName = itemName;
            this.Price = price;
            this.Type = type;
        }

        public abstract string DisplayMessage();
    }

    class SnackItem : Item
    {
        public SnackItem(string name, int price) : base(name, price, "Snack")
        {

        }

        public override string DisplayMessage()
        {
            return $"Name: {ItemName} Price:${Price} Type: {Type}";
        }
    }

    class DrinkItem : Item
    {
        public DrinkItem(string name, int price) : base(name, price, "Drink")
        {

        }

        public override string DisplayMessage()
        {
            return $"Name: {ItemName} Price:${Price} Type: {Type}";
        }
    }

    class ChocolateItem : Item
    {
        public ChocolateItem(string name, int price) : base(name, price, "Chocolate")
        {

        }

        public override string DisplayMessage()
        {
            return $"Name: {ItemName} Price:${Price} Type: {Type}";
        }
    }
}
