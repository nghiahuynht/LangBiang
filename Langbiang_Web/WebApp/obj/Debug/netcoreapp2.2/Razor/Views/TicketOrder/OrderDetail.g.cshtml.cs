#pragma checksum "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\TicketOrder\OrderDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b555d7afd55fe1577c86bbd295c0082329332c37"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_TicketOrder_OrderDetail), @"mvc.1.0.view", @"/Views/TicketOrder/OrderDetail.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/TicketOrder/OrderDetail.cshtml", typeof(AspNetCore.Views_TicketOrder_OrderDetail))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\TicketOrder\OrderDetail.cshtml"
using DAL;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b555d7afd55fe1577c86bbd295c0082329332c37", @"/Views/TicketOrder/OrderDetail.cshtml")]
    public class Views_TicketOrder_OrderDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DAL.Models.ConDao.OrderResultViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datepicker/datepicker3.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datatables-bs4/css/dataTables.bootstrap4.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/app-script/helper.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\TicketOrder\OrderDetail.cshtml"
  
    ViewData["Title"] = "Thông tin mua vé";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(159, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("styles", async() => {
                BeginContext(177, 8, true);
                WriteLiteral("\r\n\r\n    ");
                EndContext();
                BeginContext(185, 69, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "b555d7afd55fe1577c86bbd295c0082329332c374876", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(254, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(260, 87, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "b555d7afd55fe1577c86bbd295c0082329332c376208", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(347, 136, true);
                WriteLiteral("\r\n\r\n    <style>\r\n        .badge-status{margin-top:5px;font-weight:bold;}\r\n        .fa-eye{color:#0094ff;cursor:pointer;}\r\n    </style>\r\n");
                EndContext();
            }
            );
            BeginContext(486, 157, true);
            WriteLiteral("<section class=\"content-header\">\r\n    <div class=\"container-fluid\">\r\n        <div class=\"row mb-2\">\r\n            <div class=\"col-sm-6\">\r\n                <h1>");
            EndContext();
            BeginContext(645, 17, false);
#line 22 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\TicketOrder\OrderDetail.cshtml"
                Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(663, 169, true);
            WriteLiteral("</h1>\r\n            </div>\r\n            <div class=\"col-sm-6\">\r\n                <ol class=\"breadcrumb float-sm-right\">\r\n                    <li class=\"breadcrumb-item\">\r\n");
            EndContext();
#line 27 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\TicketOrder\OrderDetail.cshtml"
                          
                            if (Model.TicketOrder.PaymentStatus == 0)
                            {

#line default
#line hidden
            BeginContext(962, 139, true);
            WriteLiteral("                                <input type=\"button\" value=\"Huỷ order\" class=\"btn bg-danger\" id=\"btn-cancel\" style=\"margin-right:5px;\" />\r\n");
            EndContext();
#line 31 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\TicketOrder\OrderDetail.cshtml"
                            }
                            if (Model.TicketOrder.PaymentStatus == 0)
                            {

#line default
#line hidden
            BeginContext(1234, 151, true);
            WriteLiteral("                                <input type=\"button\" value=\"Xác nhận thanh toán\" class=\"btn bg-success\" id=\"btn-confirm\" style=\"margin-right:5px;\" />\r\n");
            EndContext();
#line 35 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\TicketOrder\OrderDetail.cshtml"
                            }

#line default
#line hidden
            BeginContext(1416, 253, true);
            WriteLiteral("                            <input type=\"button\" value=\"Gửi lại thông tin vé\" class=\"btn bg-primary\" id=\"btn-sendNoti\" style=\"margin-right:5px;\" />\r\n                            <a class=\"btn btn-default\" href=\"/ticketorder/index\">Trở lại danh sách</a>\r\n");
            EndContext();
            BeginContext(1696, 309, true);
            WriteLiteral(@"

                    </li>

                </ol>
            </div>
        </div>
    </div><!-- /.container-fluid -->
</section>
<section class=""content"">
    <div class=""card"">
        <div class=""card-body"">
            <form class=""form-horizontal"" id=""form-ticket-order"">
                ");
            EndContext();
            BeginContext(2006, 23, false);
#line 52 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\TicketOrder\OrderDetail.cshtml"
           Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(2029, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(2048, 37, false);
#line 53 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\TicketOrder\OrderDetail.cshtml"
           Write(Html.HiddenFor(x => x.TicketOrder.Id));

#line default
#line hidden
            EndContext();
            BeginContext(2085, 311, true);
            WriteLiteral(@"
                <div class=""row"">
                    <div class=""col-md-6"">
                        <div class=""form-group row"">
                            <label class=""col-md-3 col-form-label"">Mã khách hàng *</label>
                            <div class=""col-md-9"">
                                ");
            EndContext();
            BeginContext(2397, 78, false);
#line 59 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\TicketOrder\OrderDetail.cshtml"
                           Write(Html.TextBoxFor(x => x.Customer.CustomerCode, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(2475, 301, true);
            WriteLiteral(@"
                            </div>
                        </div>
                        <div class=""form-group row"">
                            <label class=""col-md-3 col-form-label"">Tên khách hàng *</label>
                            <div class=""col-md-9"">
                                ");
            EndContext();
            BeginContext(2777, 78, false);
#line 65 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\TicketOrder\OrderDetail.cshtml"
                           Write(Html.TextBoxFor(x => x.Customer.CustomerName, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(2855, 297, true);
            WriteLiteral(@"
                            </div>
                        </div>
                        <div class=""form-group row"">
                            <label class=""col-md-3 col-form-label"">Điện thoại *</label>
                            <div class=""col-md-9"">
                                ");
            EndContext();
            BeginContext(3153, 71, false);
#line 71 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\TicketOrder\OrderDetail.cshtml"
                           Write(Html.TextBoxFor(x => x.Customer.Phone, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(3224, 290, true);
            WriteLiteral(@"
                            </div>
                        </div>
                        <div class=""form-group row"">
                            <label class=""col-md-3 col-form-label"">Email</label>
                            <div class=""col-md-9"">
                                ");
            EndContext();
            BeginContext(3515, 71, false);
#line 77 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\TicketOrder\OrderDetail.cshtml"
                           Write(Html.TextBoxFor(x => x.Customer.Email, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(3586, 485, true);
            WriteLiteral(@"
                            </div>
                        </div>

                        <div class=""form-group row"">

                            <label class=""col-md-12 col-form-label"">Thông tin lấy hoá đơn</label>
                        </div>
                        <div class=""form-group row"">
                            <label class=""col-md-3 col-form-label"">Tên công ty</label>
                            <div class=""col-md-9"">
                                ");
            EndContext();
            BeginContext(4072, 76, false);
#line 88 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\TicketOrder\OrderDetail.cshtml"
                           Write(Html.TextBoxFor(x => x.Customer.AgencyName, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(4148, 288, true);
            WriteLiteral(@"
                            </div>
                        </div>
                        <div class=""form-group row"">
                            <label class=""col-md-3 col-form-label"">MST</label>
                            <div class=""col-md-9"">
                                ");
            EndContext();
            BeginContext(4437, 73, false);
#line 94 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\TicketOrder\OrderDetail.cshtml"
                           Write(Html.TextBoxFor(x => x.Customer.TaxCode, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(4510, 292, true);
            WriteLiteral(@"
                            </div>
                        </div>
                        <div class=""form-group row"">
                            <label class=""col-md-3 col-form-label"">Địa chỉ</label>
                            <div class=""col-md-9"">
                                ");
            EndContext();
            BeginContext(4803, 76, false);
#line 100 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\TicketOrder\OrderDetail.cshtml"
                           Write(Html.TextBoxFor(x => x.Customer.TaxAddress, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(4879, 369, true);
            WriteLiteral(@"
                            </div>
                        </div>
                    </div>

                    <div class=""col-md-6"">
                        <div class=""form-group row"">
                            <label class=""col-md-3 col-form-label"">Mã Order *</label>
                            <div class=""col-md-9"">
                                ");
            EndContext();
            BeginContext(5249, 71, false);
#line 109 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\TicketOrder\OrderDetail.cshtml"
                           Write(Html.TextBoxFor(x => x.TicketOrder.Id, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(5320, 338, true);
            WriteLiteral(@"
                            </div>
                        </div>

                        <div class=""form-group row"">
                            <label class=""col-md-3 col-form-label"">Ngày Order *</label>
                            <div class=""col-md-9"">
                                <input type=""text"" class=""form-control""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 5658, "\"", 5779, 1);
#line 116 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\TicketOrder\OrderDetail.cshtml"
WriteAttributeValue("", 5666, Model.TicketOrder.CreatedDate.HasValue?Model.TicketOrder.CreatedDate.Value.ToString("dd/MM/yyyy"):string.Empty, 5666, 113, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(5780, 343, true);
            WriteLiteral(@" />
                            </div>
                        </div>
                        <div class=""form-group row"">
                            <label class=""col-md-3 col-form-label"">Ngày thăm quan *</label>
                            <div class=""col-md-9"">
                                <input type=""text"" class=""form-control""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 6123, "\"", 6240, 1);
#line 122 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\TicketOrder\OrderDetail.cshtml"
WriteAttributeValue("", 6131, Model.TicketOrder.VisitDate.HasValue?Model.TicketOrder.VisitDate.Value.ToString("dd/MM/yyyy"):string.Empty, 6131, 109, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(6241, 297, true);
            WriteLiteral(@" />
                            </div>
                        </div>
                        <div class=""form-group row"">
                            <label class=""col-md-3 col-form-label"">Loại vé *</label>
                            <div class=""col-md-9"">
                                ");
            EndContext();
            BeginContext(6539, 79, false);
#line 128 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\TicketOrder\OrderDetail.cshtml"
                           Write(Html.TextBoxFor(x => x.TicketOrder.TicketCode, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(6618, 333, true);
            WriteLiteral(@"
                            </div>
                        </div>
                        <div class=""form-group row"">
                            <label class=""col-md-3 col-form-label"">Đơn giá *</label>
                            <div class=""col-md-9"">
                                <input type=""text"" class=""form-control""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 6951, "\"", 7000, 1);
#line 134 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\TicketOrder\OrderDetail.cshtml"
WriteAttributeValue("", 6959, Model.TicketOrder.Price.ToString("N0"), 6959, 41, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(7001, 337, true);
            WriteLiteral(@" />
                            </div>
                        </div>
                        <div class=""form-group row"">
                            <label class=""col-md-3 col-form-label"">Số lượng *</label>
                            <div class=""col-md-9"">
                                <input type=""text"" class=""form-control""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 7338, "\"", 7388, 1);
#line 140 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\TicketOrder\OrderDetail.cshtml"
WriteAttributeValue("", 7346, Model.TicketOrder.Quanti.ToString("N0"), 7346, 42, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(7389, 268, true);
            WriteLiteral(@" />
                            </div>
                        </div>
                        <div class=""form-group row"">
                            <label class=""col-md-3 col-form-label"">Thành tiền *</label>
                            <div class=""col-md-9"">
");
            EndContext();
#line 146 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\TicketOrder\OrderDetail.cshtml"
                                  
                                    decimal Fee = Model.TicketOrder.PaymentType == Contanst.PaymentType_TrucTiep ? Contanst.PaymentFee_TrucTiep : Contanst.PaymentFee_OnePay;
                                    decimal totalNoPayment = Model.TicketOrder.Total - Fee;
                                

#line default
#line hidden
            BeginContext(7996, 71, true);
            WriteLiteral("                                <input type=\"text\" class=\"form-control\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 8067, "\"", 8107, 1);
#line 150 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\TicketOrder\OrderDetail.cshtml"
WriteAttributeValue("", 8075, totalNoPayment.ToString("N0"), 8075, 32, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(8108, 265, true);
            WriteLiteral(@" />

                            </div>
                        </div>
                        <div class=""form-group row"">
                            <label class=""col-md-3 col-form-label"">Tuyến *</label>
                            <div class=""col-md-9"">
");
            EndContext();
#line 157 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\TicketOrder\OrderDetail.cshtml"
                                  
                                    var TuyenDetail = Model.GateListAll.FirstOrDefault(x => x.GateCode == Model.TicketOrder.GateName);
                                

#line default
#line hidden
            BeginContext(8580, 38, true);
            WriteLiteral("                                <span>");
            EndContext();
            BeginContext(8620, 57, false);
#line 160 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\TicketOrder\OrderDetail.cshtml"
                                  Write(TuyenDetail != null ? TuyenDetail.GateName : string.Empty);

#line default
#line hidden
            EndContext();
            BeginContext(8678, 271, true);
            WriteLiteral(@"</span>
                            </div>
                        </div>
                        <div class=""form-group row"">
                            <label class=""col-md-3 col-form-label"">Đối tượng *</label>
                            <div class=""col-md-9"">
");
            EndContext();
#line 166 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\TicketOrder\OrderDetail.cshtml"
                                  
                                    string objName = string.Empty;
                                    switch (Model.TicketOrder.ObjType)
                                    {
                                        case 1:
                                            objName = "Người lớn";
                                            break;
                                        case 2:
                                            objName = "Miễn giảm 50%";
                                            break;
                                        case 3:
                                            objName = "Học sinh/ sinh viên";
                                            break;
                                        case 4:
                                            objName = "Trẻ em/học sinh";
                                            break;
                                        case 5:
                                            objName = "Học sinh/sinh viên ở Côn Đảo";
                                            break;
                                        default:
                                            objName = "Chưa xác định";
                                            break;

                                    }

                                            

#line default
#line hidden
            BeginContext(10312, 38, true);
            WriteLiteral("                                <span>");
            EndContext();
            BeginContext(10352, 7, false);
#line 192 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\TicketOrder\OrderDetail.cshtml"
                                  Write(objName);

#line default
#line hidden
            EndContext();
            BeginContext(10360, 588, true);
            WriteLiteral(@"</span>
                            </div>
                        </div>
                    </div>

                </div>
                <hr />
                <table class=""table table-bordered"">
                    <thead>
                        <tr>
                            <th></th>
                            <th>STT</th>
                            <th>Mã tra cứu</th>
                            <th>Số HDDT</th>
                            <th>Mã tra cứu Misa</th>
                        </tr>
                    </thead>
                    <tbody>
");
            EndContext();
#line 210 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\TicketOrder\OrderDetail.cshtml"
                          
                                                if (Model.ListSubCode.Any())
                                                {
                                                    foreach (var item in Model.ListSubCode)
                                                    {

#line default
#line hidden
            BeginContext(11253, 123, true);
            WriteLiteral("                                    <tr>\r\n                                        <td width=\"40px\"><div class=\"text-center\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 11376, "\"", 11405, 3);
            WriteAttributeValue("", 11386, "ViewPDf(", 11386, 8, true);
#line 216 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\TicketOrder\OrderDetail.cshtml"
WriteAttributeValue("", 11394, item.Id, 11394, 10, false);

#line default
#line hidden
            WriteAttributeValue("", 11404, ")", 11404, 1, true);
            EndWriteAttribute();
            BeginContext(11406, 89, true);
            WriteLiteral("><span class=\"fa fa-eye\"></span></div></td>\r\n                                        <td>");
            EndContext();
            BeginContext(11497, 11, false);
#line 217 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\TicketOrder\OrderDetail.cshtml"
                                        Write(item.SubNum);

#line default
#line hidden
            EndContext();
            BeginContext(11509, 81, true);
            WriteLiteral("</td>\r\n                                        <td><span style=\"font-size:14pt;\">");
            EndContext();
            BeginContext(11592, 17, false);
#line 218 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\TicketOrder\OrderDetail.cshtml"
                                                                      Write(item.SubOrderCode);

#line default
#line hidden
            EndContext();
            BeginContext(11610, 58, true);
            WriteLiteral("</span></td>\r\n                                        <td>");
            EndContext();
            BeginContext(11670, 18, false);
#line 219 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\TicketOrder\OrderDetail.cshtml"
                                        Write(item.InvoiceNumber);

#line default
#line hidden
            EndContext();
            BeginContext(11689, 51, true);
            WriteLiteral("</td>\r\n                                        <td>");
            EndContext();
            BeginContext(11742, 18, false);
#line 220 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\TicketOrder\OrderDetail.cshtml"
                                        Write(item.TransactionID);

#line default
#line hidden
            EndContext();
            BeginContext(11761, 50, true);
            WriteLiteral("</td>\r\n                                    </tr>\r\n");
            EndContext();
#line 222 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\TicketOrder\OrderDetail.cshtml"
                                }
                                    }
                        

#line default
#line hidden
            BeginContext(11912, 441, true);
            WriteLiteral(@"                    </tbody>
                </table>
                <hr />
                <div class=""row"">


                    <div class=""col-md-3"">
                        <div class=""form-group"">
                            <label class=""col-md-12 col-form-label"">Tổng cần thanh toán *</label>
                            <div class=""col-md-12"">
                                <span class=""badge badge-info badge-status"">");
            EndContext();
            BeginContext(12355, 38, false);
#line 235 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\TicketOrder\OrderDetail.cshtml"
                                                                        Write(Model.TicketOrder.Total.ToString("N0"));

#line default
#line hidden
            EndContext();
            BeginContext(12394, 358, true);
            WriteLiteral(@" VNĐ</span>
                            </div>
                        </div>
                    </div>

                    <div class=""col-md-3"">
                        <div class=""form-group"">
                            <label class=""col-md-12 col-form-label"">Trạng thái thanh toán*</label>
                            <div class=""col-md-12"">
");
            EndContext();
#line 244 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\TicketOrder\OrderDetail.cshtml"
                                  
                                    if (Model.TicketOrder.PaymentStatus == 0)
                                    {

#line default
#line hidden
            BeginContext(12906, 119, true);
            WriteLiteral("                                        <span class=\"badge badge-warning badge-status\">Chờ xác nhận thanh toán</span>\r\n");
            EndContext();
#line 248 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\TicketOrder\OrderDetail.cshtml"
                                    }
                                    else if (Model.TicketOrder.PaymentStatus == 1)
                                    {

#line default
#line hidden
            BeginContext(13187, 107, true);
            WriteLiteral("                                        <span class=\"badge badge-success badge-status\">Đã xác nhận</span>\r\n");
            EndContext();
#line 252 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\TicketOrder\OrderDetail.cshtml"
                                    }
                                    else if (Model.TicketOrder.PaymentStatus == 2)
                                    {

#line default
#line hidden
            BeginContext(13456, 98, true);
            WriteLiteral("                                        <span class=\"badge badge-danger badge-status\">Huỷ</span>\r\n");
            EndContext();
#line 256 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\TicketOrder\OrderDetail.cshtml"
                                    }
                                

#line default
#line hidden
            BeginContext(13628, 195, true);
            WriteLiteral("                            </div>\r\n                        </div>\r\n                    </div>\r\n\r\n                </div>\r\n\r\n            </form>\r\n\r\n        </div>\r\n    </div>\r\n\r\n\r\n\r\n</section>\r\n\r\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(13840, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(13846, 46, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b555d7afd55fe1577c86bbd295c0082329332c3733407", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(13892, 4665, true);
                WriteLiteral(@"
    <script>
        $(document).ready(function ()
        {
            $(""#btn-confirm"").click(function ()
            {
                                                ChangeStatusPayment(1);
                                            });

            $(""#btn-cancel"").click(function ()
            {
                                                ChangeStatusPayment(2);
                                            });
            $(""#btn-sendNoti"").click(function () {
                                                SendNoti();
                                            });

                                        })

        function ChangeStatusPayment(newStatus) {
                                            let orderId = $(""#TicketOrder_Id"").val();

                                            let messageConfirm = newStatus == 1 ? ""xác nhận"" : ""huỷ"";
                                            bootbox.confirm(""Bạn có chắc muốn "" + messageConfirm+"" giao dịch mua vé này"", function (");
                WriteLiteral(@"confi) {
                                                if (confi)
                                                {
                    $.ajax({
                                                    type: ""GET"",
                        contentType: 'application/json; charset=utf-8',
                        url: ""/TicketOrder/ChangeStatusOrder?orderId="" + orderId + ""&newStatus="" + newStatus,
                        success: function (result) {

                                                            if (result.isSuccess == true) {
                                                                bootbox.alert(AlertSuccess(""Chuyển trạng thái thành công""), function () {

                                                                    location.href = ""/TicketOrder/OrderDetail/"" + orderId;
                                                                    SendNoti();
                                                                });

                                                         ");
                WriteLiteral(@"   } else {
                                                                bootbox.alert(AlertFail(""Chuyển trạng thái không thành công""), function () {
                                                                    location.href = ""/TicketOrder/OrderDetail/"" + orderId;
                                                                });
                                                            }


                                                        }
                                                    });
                                                }
                                            });


                                        }
                                        function SendNoti() {
                                            let orderId = $(""#TicketOrder_Id"").val();
                                            let crsfToken = document?.querySelector(""#form-ticket-order > input[type=hidden]:nth-child(1)"")?.getAttribute('value');
            $.ajax({
         ");
                WriteLiteral(@"                                   type: ""GET"",
                contentType: 'application/json; charset=utf-8',
                headers: {
                                                    'RequestVerificationToken': crsfToken
                },
                url: ""/ConDao/SendNoti?id="" + orderId,
                success: function (result) {
                                                    debugger;
                                                    if (result.isSuccess == true) {
                                                        bootbox.alert(AlertSuccess(""Gửi zalo/email thành công""), function () {
                                                            location.href = ""/TicketOrder/OrderDetail/"" + orderId;
                                                        });

                                                    } else {
                                                        bootbox.alert(AlertFail(result.desc), function () {
                                           ");
                WriteLiteral(@"                 location.href = ""/TicketOrder/OrderDetail/"" + orderId;
                                                        });
                                                    }


                                                }
                                            });
                                        }

                                        function ViewPDf(subId) {
                                         window.open(""/ticketorder/GetPDFForPrint/"" + subId, 'Xem pdf');
                                        }
    </script>
");
                EndContext();
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DAL.Models.ConDao.OrderResultViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591