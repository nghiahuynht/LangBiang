using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.IService;
using DAL.Models;
using DAL.Models.Customer;
using DAL.Models.SoatVe;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class SoatVeController : AppBaseController
    {
        private ISoatVeService soatVeService;

        public SoatVeController(ISoatVeService soatVeService)
        {
            this.soatVeService = soatVeService;
        }

        public IActionResult Index()
        {
            ViewBag.GateList = soatVeService.GetGateDDLByUser(AuthenInfo().UserName);
            return View();
        }

        [HttpGet]
        public JsonResult ScanAction(Int64 ticketCode, string gateCode)
        {
            var res = soatVeService.UpdateScanResult(ticketCode, gateCode);
            return Json(res);
        }

        [HttpGet]
        public JsonResult DetailCheckTicketAction(string gateCode)
        {
            var res = soatVeService.DetailCheckTicketResult(gateCode);
            return Json(res);
        }


        public IActionResult SearchInOutHistory()
        {
            var modelSearch = new InOutFilterModel
            {
                FromDate = DAL.Helper.FirtDayOfMonth(),
                ToDate = DateTime.Now.ToString("dd/MM/yyyy")

            };
            return View(modelSearch);
        }


        [HttpPost]
        public DataTableResultModel<HistoryInOutModel> SearchInOutPaging(InOutFilterModel filter)
        {
            var res = soatVeService.SearchInOutPaging(filter);
            return res;
        }



    }
}