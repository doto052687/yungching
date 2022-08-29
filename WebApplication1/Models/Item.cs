using static System.Formats.Asn1.AsnWriter;

namespace WebApplication1.Models
{
    public class Item
    {
        public string id { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }

        public Item()
        {
            id = string.Empty;
            name = string.Empty;
            quantity = 0;
            price = 0;
        }

        public Item(string _id,string _name,int _quantity,int _price)
        {
            id = _id;
            name = _name;
            quantity = _quantity;
            price = _price;
        }
    }
}
