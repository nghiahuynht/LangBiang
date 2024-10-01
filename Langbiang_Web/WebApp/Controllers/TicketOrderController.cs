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

        public IActionResult Index()
        {
            ViewBag.GateList = soatVeService.GetAllGateFullInfo();
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
        public async Task<JsonResult> ChangeStatusOrder(long orderId,int newStatus)
        {
            var res = ticketOrderService.ChangeStatusTicketOrder(orderId, newStatus,AuthenInfo().UserName);
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

        [HttpPost]
        public async Task<DataTableResultModel<OrderGridModel>> SearchOrder(OrderFilterModel filter)
        {
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
                ticketOrderService.AssignSubIdForMapping(orderId);
                string rootFolder = Path.GetFullPath(AppSettingServices.Get.GeneralSettings.RootFolder);//config["General:RootFolder"];
                log.AppendLine($"RootFolder: {rootFolder}");
                
                var lstSubCode = ticketOrderService.GetSubCodePrintInfo(orderId).Result;
                if (lstSubCode.Any())
                {
                    foreach (var subCode in lstSubCode)
                    {
                        log.AppendLine($"SubCode: {JsonConvert.SerializeObject(subCode)}");
                        using (QRCodeGenerator QrGenerator = new QRCodeGenerator())
                        {
                            QRCodeData QrCodeInfo = QrGenerator.CreateQrCode(subCode.CardNum.ToString(), QRCodeGenerator.ECCLevel.Q);
                            QRCode QrCode = new QRCode(QrCodeInfo);
                            using (Bitmap bitMap = QrCode.GetGraphic(20))
                            {
                                string fileFullPath = string.Format(rootFolder, subCode.SubId);
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
            return View();
        }


        //[HttpPost]
        //public IActionResult SaveOrderByGate([FromBody] PostTuyenOrderSaveModel model)
        //{
        //    var lstSubCode = new List<SubOrderPrintModel>();
        //    if (!string.IsNullOrEmpty(AuthenInfo().UserName))
        //    {
        //        var ticketInfo = ticketService.GetTicketByGate(model.PrintType);
        //        if (ticketInfo != null)
        //        {

        //            var modalSale = new PostOrderSaveModel
        //            {
        //                CustomerCode = model.CustomerCode,
        //                TicketCode = ticketInfo.Code,
        //                Price = model.Price,
        //                Quanti = model.Quanti

        //            };

        //            var res = ticketOrderService.SaveOrderToData(modalSale, AuthenInfo().UserName, model.GateCode,model.ObjType);
        //            CreateQRCode(res.ValueReturn);
        //            lstSubCode = ticketOrderService.GetSubCodePrintInfo(res.ValueReturn).Result;
        //        }

                



        //        return Json(lstSubCode);
        //    }
        //    else
        //    {
        //        return RedirectToAction("Login", "Account");
        //    }

        //}


        [HttpPost]
        public IActionResult SaleOrderAction([FromBody] PostOrderSaveModel model)
        {

            if (!string.IsNullOrEmpty(AuthenInfo().UserName))
            {

                var lstSubCode = new List<SubOrderPrintModel>();
                if (!string.IsNullOrEmpty(AuthenInfo().UserName))
                {
                    var res = ticketOrderService.SaveOrderToData(model, AuthenInfo().UserName,string.Empty,1);
                    CreateQRCode(res.ValueReturn);
                    lstSubCode = ticketOrderService.GetSubCodePrintInfo(res.ValueReturn).Result;

                }

                

                return Json(lstSubCode);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }


        }





        public IActionResult GetPDFForPrint(int id)
        
        {

            var subDetail = ticketOrderService.GetPrintPdfSubOrderDetail(id);
            // Get list gate by zone code
            subDetail.ListGate = soatVeService.GetGateByParentCode(subDetail.ZoneCode);
           
            subDetail.TotalByText = TienBangChu(subDetail.TotalAfterVAT.ToString());
            return View(subDetail);
            //return new ViewAsPdf(subDetail)
            //{
            //    PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
            //    // PageSize = Rotativa.AspNetCore.Options.Size.A5,

            //    PageWidth = 400,
            //    PageHeight = 550,
            //    CustomSwitches = "--disable-smart-shrinking",
            //};
        }



        public IActionResult htmlprint(int id)
        {

            var subDetail = ticketOrderService.GetPrintPdfSubOrderDetail(id);
            subDetail.TotalByText = TienBangChu(subDetail.TotalAfterVAT.ToString());

            return View(subDetail);
        }




        #endregion






    }
}