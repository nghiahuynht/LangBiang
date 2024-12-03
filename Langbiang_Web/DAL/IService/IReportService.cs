using DAL.Models;
using DAL.Models.Report;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IService
{
    public interface IReportService
    {
        /// <summary>
        /// Lấy báo cáo doanh số bán theo loại vé
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<ResGetRPSales> GetReportSalesByTicketType(TicketTypeRPFilter filter);

        List<StaffSaleCounterModel> ReportStaffSaleCounter(string dateView);
        List<SaleTicketMisaStatusModel> ReportTicketMisaStatus(string fromDate, string toDate);

        List<ColumnChartModel> GetColumnCharteport(int year);
        Task<ResGetRPByPartner> GetReportSalesByPartner(TicketTypeRPFilter filter);
    }
}
