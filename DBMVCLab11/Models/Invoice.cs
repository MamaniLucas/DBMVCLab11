namespace DBMVCLab11.Models
{
    public class Invoice
    {

        public int InvoiceID { get; set; }
        public Customer Customer { get; set; }
        public int CutsomerID { get; set; }
        public DateTime Date { get; set;}
        public string InvoiceNumber {  get; set; }
        public float Total { get; set; }


    }
}
