using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.ConDao
{
    public class OrderFilterModel: DataTableDefaultParamModel
    {
        public int ChanelId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string PaymentMethod { get; set; }
        public int PaymentStatus { get; set; }
        public string GateCode { get; set; }
        public string Keyword { get; set; }
        
    }
}
