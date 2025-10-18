namespace PRN232.Lab2.CoffeeStore.Data
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public int OrderId { get; set; }
        public virtual Order Order { get; set; } = null!;  

    }
}