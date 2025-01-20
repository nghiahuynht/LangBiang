using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entities;
using DAL.IService;
using DAL.Models;
using DAL.Models.ConDao;
using DAL.Models.TicketOrder;
using DAL.Models.Zalo;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OfficeOpenXml;
using QRCoder;
using Rotativa;
using Rotativa.AspNetCore;
using WebApp.Infrastructure.Configuration;
using WebApp.Model;

namespace WebApp.Controllers
{
    public class TicketOrderController : AppBaseController
    {

        private readonly ITicketService ticketService;
        private readonly ITicketOrderService ticketOrderService;
        private readonly ICustomerService customerService;
        private readonly IPaymentService paymentService;
        private readonly IResultCodeService codeService;
        private readonly IZaloService zaloService;
        private readonly IEmailService emailService;
        private readonly ISoatVeService soatVeService;

        public TicketOrderController(ITicketService ticketService
            , ITicketOrderService ticketOrderService
            , ICustomerService customerService
            , IPaymentService paymentService
            , IResultCodeService codeService
            , IZaloService zaloService
            , IEmailService emailService
            ,ISoatVeService soatVeService)
        {
            this.ticketService = ticketService;
            this.ticketOrderService = ticketOrderService;
            this.customerService = customerService;
            this.paymentService = paymentService;
            this.codeService = codeService;
            this.zaloService = zaloService;
            this.emailService = emailService;
            this.soatVeService = soatVeService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.GroupTicketList = ticketService.GetTicketGroupDDL();
            ViewBag.ListCustType = await customerService.LstAllCustomerType();
            ViewBag.TicketList = ticketService.GetAllTicket();
            return View();
        }



        public IActionResult OrderDetail(long? id)
        {
            OrderResultViewModel viewmodel = new OrderResultViewModel();
            try
            {
                if (id.HasValue)
                {
                    viewmodel.TicketOrder = ticketService.GetTicketOrderbyId(id.Value);
                    viewmodel.Customer = customerService.GetCustomerByCode(viewmodel.TicketOrder.CustomerCode).Result;
                    viewmodel.ListSubCode = ticketOrderService.GetSubOrderCodeByOrderId(id.Value);

                }
            }
            catch (Exception ex)
            {
                viewmodel.TicketOrder = new DAL.Entities.TicketOrder();
                viewmodel.Customer = new DAL.Entities.Customer();
                viewmodel.ListSubCode = new List<DAL.Entities.TicketOrderSubNum>();
            }
            viewmodel.GateListAll = ticketService.GetAllGatelist();


            return View(viewmodel);
        }


        [HttpGet]
        public JsonResult ChangePaymentStatusOrder(long orderId,int newStatus)
        {
            var res = ticketOrderService.ChangePaymentStatusTicketOrder(orderId, newStatus,AuthenInfo().UserName);
            if (newStatus == 1 && res.IsSuccess)
            {
                var objOD = ticketService.GetOrderInfo(orderId);

                if (newStatus == 1) // đã xác nhận thanh toán
                {
                   ticketService.CreateTicketSubOrder(orderId, objOD.Quanti, objOD.TicketCode, objOD.Price);
                    
                    CreateQRCode(orderId);
                    
                }
            }
            return Json(res);
        }


        [HttpGet]
        public JsonResult ChangeStatusOrder(long orderId, string newStatus)
        {
            SaveResultModel res = new SaveResultModel();
            return Json(res);
        }



        [HttpPost]
        public async Task<DataTableResultModel<OrderGridModel>> SearchOrder(OrderFilterModel filter)
        {
            filter.PartnerCode = AuthenInfo().PartnerCode;
            var res = await ticketOrderService.SearchOrder(filter);
            return res;
        }


        public IActionResult ViewTicketOrderPdf(int subOrderId)
        {
            try
            {
                string rootFolder = Path.GetFullPath(AppSettingServices.Get.GeneralSettings.RootFolder);//config["General:RootFolder"];
                using (QRCodeGenerator QrGenerator = new QRCodeGenerator())
                {
                    QRCodeData QrCodeInfo = QrGenerator.CreateQrCode(subOrderId.ToString(), QRCodeGenerator.ECCLevel.Q);
                    QRCode QrCode = new QRCode(QrCodeInfo);
                    using (Bitmap bitMap = QrCode.GetGraphic(20))
                    {
                        string fileFullPath = string.Format(rootFolder, subOrderId);
                        if (!System.IO.File.Exists(fileFullPath))
                        {
                            bitMap.Save(fileFullPath, ImageFormat.Jpeg);
                        }

                        //bitMap.Dispose();
                    }

                }
            }
            catch(Exception ex)
            {

            }
           

            var subDetail = ticketOrderService.GetPrintPdfSubOrderDetail(subOrderId);
            subDetail.TotalByText = TienBangChu(subDetail.TotalAfterVAT.ToString());


            return new ViewAsPdf(subDetail)
            {
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape,
                PageSize = Rotativa.AspNetCore.Options.Size.A4,
                PageMargins = { Left = 5, Bottom = 5, Right = 5, Top = 5 },
                //PageWidth = 300,
                // PageHeight = 1500,
                // CustomSwitches = "--disable-smart-shrinking"
            };
        }

        public string TienBangChu(string tien)
        {
            string totalFormat = tien.Replace(",", "");
            string totalDesc = WebApp.Model.Helper.NumToText(totalFormat);

            try
            {
                string firstRefix = totalDesc.Substring(0, 1).ToUpper();
                string lastRefix = totalDesc.Substring(1, totalDesc.Length - 1).ToLower();
                string resultTotalDec = firstRefix + lastRefix;
                return resultTotalDec;
            }
            catch (Exception ex)
            {
                return "0 đồng";
            }


        }


        private void CreateQRCode(long orderId)
        {


            var log = new StringBuilder();
            try
            {

                string qrCodeFolder = Path.GetFullPath(AppSettingServices.Get.GeneralSettings.QRCodeFolder);//config["General:RootFolder"];
                log.AppendLine($"QRCodeFolder: {qrCodeFolder}");

                var lstSubCode = ticketOrderService.GetSubCodePrintInfo(orderId).Result;
                if (lstSubCode.Any())
                {
                    foreach (var subCode in lstSubCode)
                    {
                        log.AppendLine($"SubCode: {JsonConvert.SerializeObject(subCode)}");
                        using (QRCodeGenerator QrGenerator = new QRCodeGenerator())
                        {
                            QRCodeData QrCodeInfo = QrGenerator.CreateQrCode(subCode.SubId.ToString(), QRCodeGenerator.ECCLevel.Q);
                            QRCode QrCode = new QRCode(QrCodeInfo);
                            using (Bitmap bitMap = QrCode.GetGraphic(20))
                            {
                                string fileFullPath = string.Format(qrCodeFolder, subCode.SubId);
                                if (!System.IO.File.Exists(fileFullPath))
                                {
                                    bitMap.Save(fileFullPath, ImageFormat.Jpeg);
                                }

                                //bitMap.Dispose();
                            }




                        }
                    }

                }

            }
            catch (Exception ex)
            {
                log.AppendLine($"[Exception]: {ex}");
            }
            finally
            {
                WriteLog.writeToLogFile(log.ToString());
            }

        }



        private void CreateQRCodeLangbianLand(long orderId)
        {
  

            var log = new StringBuilder();
            try
            {
                
                string qrCodeFolder = Path.GetFullPath(AppSettingServices.Get.GeneralSettings.QRCodeFolder);//config["General:RootFolder"];
                log.AppendLine($"QRCodeFolder: {qrCodeFolder}");
                
                var lstSubCode = ticketOrderService.GetSubCodePrintInfo(orderId).Result;
                if (lstSubCode.Any())
                {
                    foreach (var subCode in lstSubCode)
                    {
                        log.AppendLine($"SubCode: {JsonConvert.SerializeObject(subCode)}");
                        using (QRCodeGenerator QrGenerator = new QRCodeGenerator())
                        {
                            QRCodeData QrCodeInfo = QrGenerator.CreateQrCode(subCode.CardNum, QRCodeGenerator.ECCLevel.Q);
                            QRCode QrCode = new QRCode(QrCodeInfo);
                            using (Bitmap bitMap = QrCode.GetGraphic(20))
                            {
                                string fileFullPath = string.Format(qrCodeFolder, subCode.SubId);
                                if (!System.IO.File.Exists(fileFullPath))
                                {
                                    bitMap.Save(fileFullPath, ImageFormat.Jpeg);
                                }

                                //bitMap.Dispose();
                            }




                        }
                    }
                   
                }

            }
            catch (Exception ex)
            {
                log.AppendLine($"[Exception]: {ex}");
            }
            finally
            {
                WriteLog.writeToLogFile(log.ToString());
            }

        }






        #region =============== Màn hình bán vé ===============

        public async Task<IActionResult> SaleScreen()
        {
            ViewBag.CustomerList = await customerService.GetAllCustomer();
            ViewBag.GateList = soatVeService.GetAllGateFullInfo();
            ViewBag.TicketList = ticketService.GetAllTicket();
            ViewBag.GroupTicketList = ticketService.GetTicketGroupDDL();
            ViewBag.ListCustType = await customerService.LstAllCustomerType();
            return View();
        }


        


        [HttpPost]
        public IActionResult SaleOrderAction([FromBody] PostOrderSaveModel model)
        {
            var viewModel = new SaveOrderSuccessViewModel();
            if (!string.IsNullOrEmpty(AuthenInfo().UserName))
            {

                var lstSubCode = new List<SubOrderPrintModel>();
                if (!string.IsNullOrEmpty(AuthenInfo().UserName))
                {
                    var res = ticketOrderService.SaveOrderToData(model, AuthenInfo().UserName,model.GateName);
                    CreateQRCodeLangbianLand(res.ValueReturn);
                    lstSubCode = ticketOrderService.GetSubCodePrintInfo(res.ValueReturn).Result;
                    viewModel.OrderId = res.ValueReturn;
                    viewModel.LstSubCode = lstSubCode;
                }

                

                return Json(viewModel);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }


        }









        [HttpGet]
        public IActionResult GetPDFForPrint(int subId)// dành cho kiểu in lẻ và in gộp
        {

            var subDetail = ticketOrderService.GetPrintPdfSubOrderDetail(subId);
            // Get list gate by zone code
            subDetail.ListGate = soatVeService.GetGateByParentCode(subDetail.ZoneCode);
           
            subDetail.TotalByText = TienBangChu(subDetail.TotalAfterVAT.ToString());
            return View(subDetail);
        }


        public IActionResult PrintQRview(long orderId)
        {
            OrderResultViewModel viewmodel = new OrderResultViewModel();
            viewmodel.TicketOrder = ticketService.GetTicketOrderbyId(orderId);
            viewmodel.Customer = customerService.GetCustomerByCode(viewmodel.TicketOrder.CustomerCode).Result;
            viewmodel.ListSubCode = ticketOrderService.GetSubOrderCodeByOrderId(orderId);
            return View(viewmodel);
        }

        [HttpGet]
        public async Task<FileContentResult> ExportExcelSubOrderByOrderId(long orderId)
        {
            var lstSubCode =await ticketOrderService.GetSubCodePrintInfo(orderId);
            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("Sheet1");
            Color colFromHex = ColorTranslator.FromHtml("#3377ff");
            Color colFromHexTextHeader = ColorTranslator.FromHtml("#ffffff");

            workSheet.Cells["A1"].Value = "STT";
            workSheet.Cells["B1"].Value = "Mã đơn";
            workSheet.Cells["C1"].Value = "Mã vé tra cứu";
            workSheet.Cells["D1"].Value = "Mã vé cho đối tác";

            workSheet.Cells[1, 1, 1, 11].Style.Font.Bold = true;
            int rowData = 2;
            int stt = 1;
            foreach (var item in lstSubCode)
            {

                workSheet.Cells["A" + rowData].Value = stt;
                workSheet.Cells["B" + rowData].Value = orderId.ToString();
                workSheet.Cells["C" + rowData].Value = item.SubOrderCode;
                workSheet.Cells["D" + rowData].Value = item.CardNum;
                rowData++;
                stt++;
            }
            workSheet.Column(1).Width = 10;
            workSheet.Column(2).Width = 10;
            workSheet.Column(3).Width = 20;
            workSheet.Column(4).Width = 20;
            return File(excel.GetAsByteArray(), ExcelExportHelper.ExcelContentType, "DanhSachMaVeChoDoiTac.xlsx");

        }


        #endregion




        #region ============== SaleScreen custom version for LangbiAng==============

        //public async Task<IActionResult> SaleScreenLangbiAng()
        //{
        //    ViewBag.CustomerList = await customerService.GetAllCustomer();
        //    ViewBag.GateList = soatVeService.GetAllGateFullInfo();
        //    ViewBag.TicketList = ticketService.GetAllTicket();
        //    ViewBag.GroupTicketList = ticketService.GetTicketGroupDDL();
        //    return View();
        //}



        #endregion




    }
}