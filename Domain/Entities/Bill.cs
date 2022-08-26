using Domain.ValuesObjects;

namespace Domain.Entities
{
    public class Bill
    {
        public Bill(string name, decimal amount, string tag, DateTime purchaseDate, Payment? payment)
        {
            Name = name;
            Amount = amount;
            Tag = tag;
            PurchaseDate = purchaseDate;
            Payment = payment;
        }

        public string Name { get; set; }

        public decimal Amount { get; set; }

        public string Tag { get; set; }

        public DateTime PurchaseDate { get; set; } = DateTime.Now;

        public Payment? Payment { get; set; }
    }
}