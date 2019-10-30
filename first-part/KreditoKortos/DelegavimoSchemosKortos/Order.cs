namespace DelegavimoSchemosKortos
{
    public class Order
    {
        public string itemName;
        public string arrivalDate;
        public float price;
        public float transferPrice;

        public Order(string itemName, string arrivalDate, float price, float transferPrice = 0f)
        {
            this.itemName = itemName;
            this.arrivalDate = arrivalDate;
            this.price = price;
            this.transferPrice = transferPrice;
        }
    }
}