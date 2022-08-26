namespace Domain.ValuesObjects
{
    public class Payment
    {
        public Payment(DateTime date, string method)
        {
            Date = date;
            Method = method;
        }

        public DateTime Date { get; set; }

        public string Method { get; set; }
    }
}