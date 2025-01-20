using DAL.IService;
using DAL.Models;
using DAL.Models.Report;
using DAL.Models.Ticket;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class ReportController : Controller
    {
        private readonly ITicketService ticketService;
        private readonly IReportService reportService;
        private readonly ICustomerService customerService;
        private IUserInfoService userService;
        private ISoatVeService soatVeService;

        public ReportController(ITicketService ticketService
            , IReportService reportService
            , ICustomerService customerService
            , IUserInfoService userService
            , ISoatVeService soatVeService)
        {
            this.ticketService = ticketService;
            this.reportService = reportService;
            this.customerService = customerService;
            this.userService = userService;
            this.soatVeService = soatVeService;
        }
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// View Báo cáo loại vé
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> TicketTypeReport()
        {
            var searchModel = new TicketTypeRPFilter
            {
                FromDate = DateTime.Now.ToString("dd/MM/yyyy"),
                ToDate = DateTime.Now.ToString("dd/MM/yyyy")
            };
            ViewBag.LstAllTicket = ticketService.GetAllTicket();
            ViewBag.LstUser = await userService.ListAllUserInfo();
            ViewBag.GateList = soatVeService.GetAllGateFullInfo();
            return View(searchModel);
        }

        /// <summary>
        /// Báo cáo doanh số bán theo loại vé
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ResGetRPSales GetReportSalesByTicketType([FromBody] TicketTypeRPFilter filter)
        {

            var res =  reportService.GetReportSalesByTicketType(filter).GetAwaiter().GetResult();
            
           
            List<MockupData> mockupData = new List<MockupData>
                {
                    new MockupData
                    {
                        GateCode = "Tuyen_1",
                        GateName = "Đảo côn sơn - Vòng các đảo nhỏ",
                        Price = 60000,
                        SlSale = 5,
                        AmountSale = 300000
                    },
                    new MockupData
                    {
                        GateCode = "Tuyen_2",
                        GateName = "Đảo Côn Sơn - Hòn Tài - Hòn Bảy Cạnh",
                        Price = 60000,
                        SlSale = 5,
                        AmountSale = 300000
                    },
                    new MockupData
                    {
                        GateCode = "Tuyen_3",
                        GateName = "Đảo Côn Sơn  - Hòn Bảy Cạnh - Hòn Cau",
                        Price = 60000,
                        SlSale = 5,
                        AmountSale = 300000
                    },
                    new MockupData
                    {
                        GateCode = "Tuyen_6",
                        GateName = "Đảo Côn Sơn - Hòn Bà - Hòn Tre Lớn",
                        Price = 60000,
                        SlSale = 5,
                        AmountSale = 300000
                    },
                     new MockupData
                    {
                        GateCode = "Tuyen_7",
                        GateName = "Đảo Côn Sơn - Hòn Trứng - Vịnh Đầm Tre",
                        Price = 50000,
                        SlSale = 10,
                        AmountSale = 500000
                    },
                      new MockupData
                    {
                        GateCode = "Tuyen_8",
                        GateName = "Ma Thiên Lãnh - Hang Đức Mẹ - Bãi Ông Đụng",
                        Price = 50000,
                        SlSale = 10,
                        AmountSale = 500000
                    },
                       new MockupData
                    {
                        GateCode = "Tuyen_9",
                        GateName = "Ma Thiên Lãnh - Hang Đức Mẹ - Đất Thắm - Bãi Bàng",
                        Price = 50000,
                        SlSale = 5,
                        AmountSale = 250000
                    }
                };
            ResGetRPSales ResSale = new ResGetRPSales()
            {
                SellQuantity = 45,
             
                TotalSales = 2100000,
                Data = mockupData
            };
            return ResSale;
        }


        [HttpGet]
        public List<ColumnChartModel> GetColumnChartValue(int year)
        {
            var res = reportService.GetColumnCharteport(year);
            return res;
        }



        public async Task<IActionResult> ReportSaleByCustType()
        {
            var searchModel = new SaleHistoryFilterModel
            {
                SaleChanelId = 0,
                UserName = "",
                FromDate = DateTime.Now.AddDays(-7).ToString("dd/MM/yyyy"),
                ToDate = DateTime.Now.ToString("dd/MM/yyyy"),
                TicketCode = ""
            };
            ViewBag.LstAllTicket = ticketService.GetAllTicket();
            var roleUser = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value;
            if (roleUser.ToUpper() == "ADMIN")
            {
                ViewBag.LstUser = await userService.ListAllUserInfo();
            }
            else
            {
                var allUserInfo = await userService.ListAllUserInfo();
                ViewBag.LstUser = allUserInfo.FindAll(x => x.UserName == User.Identity.Name);
            }
            ViewBag.GateList = soatVeService.GetAllGateFullInfo();
            return View(searchModel);
        }

        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<DataTableResultModel<ReportBanVeByCustTypeGridModel>> GetReportSaleByCustType(SaleHistoryFilterModel filter)
        {
            var res = await reportService.BaoCaoBanVeTheoLoaiKH(filter,false);
            return res;
        }

    }
}