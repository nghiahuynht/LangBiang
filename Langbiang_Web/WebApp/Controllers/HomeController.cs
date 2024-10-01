using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DAL.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : AppBaseController
    {
        private IReportService reportService;
        public HomeController(IUserInfoService userInfoService, IReportService reportService)
        {
            this.reportService = reportService;
        }

        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
               return RedirectToAction("Login","Account");
            }
            else
            {
                return View();
            }
           
        }
        [Authorize(Roles ="Admin")]
        public IActionResult Privacy()
        {
            var test = User.Identity.Name;
            return View();
        }
        [Authorize(Roles = "Sale")]
        public IActionResult Contact()
        {

            return View();
        }

        #region Dashbroad
        public PartialViewResult _PartialStaffSaleCounter(string dateView)
        {
            var res = reportService.ReportStaffSaleCounter(dateView);
            return PartialView(res);
        }

        public PartialViewResult _PartialTicketSaleMisaStatus(string fromDate, string toDate)
        {
            var res = reportService.ReportTicketMisaStatus(fromDate, toDate);
            return PartialView(res);
        }
        #endregion
    }
}
