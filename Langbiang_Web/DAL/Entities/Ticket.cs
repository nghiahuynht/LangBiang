using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Ticket : EntityCommonField
    {
        /// <summary>
        /// Mã vé
        /// </summary>
        public string Code {get; set;}
        /// <summary>
        /// giá vé
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Mô tả
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Tên chi nhánh/ địa điểm
        /// </summary>
        public int BranchId { get; set; }
        /// <summary>
        /// Mẫu biên lai
        /// </summary>
        public string BillTemplate { get; set; }
        /// <summary>
        /// Mẫu hợp đồng điện tử
        /// </summary>
        public string EContractTemplate { get; set; }
        /// <summary>
        /// Tình trạng vé: true: xóa, false chưa xóa
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// Loại vé: vé lẻ / vé đoàn
        /// </summary>
        public string LoaiIn { get; set; }
        /// <summary>
        /// số hiệu
        /// </summary>
        public string KyHieu { get; set; }
        public decimal? VAT { get; set; }
        public string TicketGroup { get; set; }
    }
}
