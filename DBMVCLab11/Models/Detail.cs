namespace DBMVCLab11.Models
{
    public class Detail
    {
        public int DetailID { get; set; }
        public Product product { get; set; }
        public int productID { get; set; }
        public int Amount { get; set; }
        public float price { get; set; }
        public float subtotal { get; set; }

    }

}
