using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.TicketOrder
{
    public class SubOrderCodeModel
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public int SubNum { get; set; }
        public string SubOrderCode { get; set; }
        public decimal? Price { get; set; }
        public int? VAT { get; set; }
        public decimal? TotalAfterVAT { get; set; }
        public string InvoiceNumber { get; set; }
        public string TransactionId { get; set; }
    }
}
