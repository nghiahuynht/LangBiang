using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.TicketOrder
{
    public class PostOrderSaveModel
    {
        public string TicketCode { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public int Quanti { get; set; }
        public decimal Price { get; set; }
        public string BienSoXe { get; set; }
        public string GateName { get; set; }
    }
}
