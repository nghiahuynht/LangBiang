using DAL.Models;
using DAL.Models.ConDao;
using DAL.Models.Ticket;
using DAL.Models.TicketOrder;
using DAL.Models.WebHookSePay;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IService
{
    public interface ITicketOrderService
    {
        List<DAL.Entities.TicketOrderSubNum> GetSubOrderCodeByOrderId(long orderId);
        SaveResultModel ChangeStatusTicketOrder(long OrderId, int newStatus, string userName, string paymentValue="",long paymentID=0);
        Task<DataTableResultModel<OrderGridModel>> SearchOrder(OrderFilterModel filter);
        Task<List<SubOrderPrintModel>> GetSubCodePrintInfo(long orderId);
        PrintPdfOrderModel GetPrintPdfSubOrderDetail(long subid);
        ReportSaleCounterModel ReportSaleCounterModel(SaleReportFilterModel filter);
        TicketOrderModel CheckPayment(string Description, double Amount);

        Task<SaveResultModel> SaveTranSePayWebHook(WebHookReceiveModel model);
        ResultModel SaveOrderToData(PostOrderSaveModel model, string userName, string gateName, int objType);
        void AssignSubIdForMapping(Int64 orderId);


    }
}
