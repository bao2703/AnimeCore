namespace Entities.Domain
{
    public class InvoiceDetail
    {
        public int InvoiceId { get; set; }

        public Invoice Invoice { get; set; }

        public int AdvertisementId { get; set; }

        public Advertisement Advertisement { get; set; }

        public long Price { get; set; }
    }
}