using MediatR;

namespace Domain.Commands.v1
{
    public class BillCreated : IRequest
    {
        public BillCreated(string name, string paymentMethod, DateTime paymentDate)
        {
            Name = name;
            PaymentMethod = paymentMethod;
            PaymentDate = paymentDate;
        }

        public string Name { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}