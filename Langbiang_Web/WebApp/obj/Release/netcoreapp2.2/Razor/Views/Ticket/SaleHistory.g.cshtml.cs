#pragma checksum "D:\Projects\OnGit\LangBiang\LangbiAng_Source\Langbiang_Web\WebApp\Views\Ticket\SaleHistory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "64997b156ad9ca84d2f26e849dd6a4188189a815"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Ticket_SaleHistory), @"mvc.1.0.view", @"/Views/Ticket/SaleHistory.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Ticket/SaleHistory.cshtml", typeof(AspNetCore.Views_Ticket_SaleHistory))]
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
#line 7 "D:\Projects\OnGit\LangBiang\LangbiAng_Source\Langbiang_Web\WebApp\Views\Ticket\SaleHistory.cshtml"
using DAL.Entities;

#line default
#line hidden
#line 8 "D:\Projects\OnGit\LangBiang\LangbiAng_Source\Langbiang_Web\WebApp\Views\Ticket\SaleHistory.cshtml"
using DAL.Models.Ticket;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"64997b156ad9ca84d2f26e849dd6a4188189a815", @"/Views/Ticket/SaleHistory.cshtml")]
    public class Views_Ticket_SaleHistory : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DAL.Models.Ticket.SaleHistoryFilterModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datepicker/datepicker3.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datatables-bs4/css/dataTables.bootstrap4.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datatables-fixedcolumns/css/fixedColumns.bootstrap4.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datatable/jquery.datatable.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datatables-bs4/js/dataTables.bootstrap4.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datatables-fixedcolumns/js/dataTables.fixedColumns.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datepicker/bootstrap-datepicker.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "D:\Projects\OnGit\LangBiang\LangbiAng_Source\Langbiang_Web\WebApp\Views\Ticket\SaleHistory.cshtml"
  
    ViewData["Title"] = "Lịch sử bán vé";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(146, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("styles", async() => {
                BeginContext(211, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(217, 69, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "64997b156ad9ca84d2f26e849dd6a4188189a8156650", async() => {
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
                BeginContext(286, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(292, 87, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "64997b156ad9ca84d2f26e849dd6a4188189a8157982", async() => {
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
                BeginContext(379, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(385, 98, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "64997b156ad9ca84d2f26e849dd6a4188189a8159314", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(483, 173, true);
                WriteLiteral("\r\n    <style>\r\n        .datepicker table tr td.disabled,\r\n        .datepicker table tr td.disabled:hover {\r\n            background-color: #e6d2d2;\r\n        }\r\n    </style>\r\n");
                EndContext();
            }
            );
            BeginContext(659, 157, true);
            WriteLiteral("<section class=\"content-header\">\r\n    <div class=\"container-fluid\">\r\n        <div class=\"row mb-2\">\r\n            <div class=\"col-sm-6\">\r\n                <h1>");
            EndContext();
            BeginContext(818, 17, false);
#line 24 "D:\Projects\OnGit\LangBiang\LangbiAng_Source\Langbiang_Web\WebApp\Views\Ticket\SaleHistory.cshtml"
                Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(836, 254, true);
            WriteLiteral("</h1>\r\n            </div>\r\n            <div class=\"col-sm-6\">\r\n                <ol class=\"breadcrumb float-sm-right\">\r\n                    <li class=\"breadcrumb-item\"><a href=\"#\">Trang chủ</a></li>\r\n                    <li class=\"breadcrumb-item active\">");
            EndContext();
            BeginContext(1092, 17, false);
#line 29 "D:\Projects\OnGit\LangBiang\LangbiAng_Source\Langbiang_Web\WebApp\Views\Ticket\SaleHistory.cshtml"
                                                   Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(1110, 147, true);
            WriteLiteral("</li>\r\n                </ol>\r\n            </div>\r\n        </div>\r\n    </div><!-- /.container-fluid -->\r\n</section>\r\n<section class=\"content\">\r\n    ");
            EndContext();
            BeginContext(1258, 23, false);
#line 36 "D:\Projects\OnGit\LangBiang\LangbiAng_Source\Langbiang_Web\WebApp\Views\Ticket\SaleHistory.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(1281, 660, true);
            WriteLiteral(@"
    <div class=""card"">
        <div class=""card-header"">
            <div class=""row"">
                <div class=""col-sm-2"">
                    <label>Hình thức bán vé</label>
                    <select class=""form-control"" id=""ddl-sale-chanel"">
                        <option value=""0"">Tất cả</option>
                        <option value=""1"">Website bán vé</option>
                        <option value=""2"">Bán tại quầy</option>
                    </select>
                </div>
                <div class=""col-sm-2"">
                    <label>Nhân viên</label>
                    <select class=""form-control"" id=""ddl-employee"">

");
            EndContext();
#line 52 "D:\Projects\OnGit\LangBiang\LangbiAng_Source\Langbiang_Web\WebApp\Views\Ticket\SaleHistory.cshtml"
                          
                            var lstUser = (List<UserInfo>)ViewBag.LstUser;
                            if (lstUser.Count() > 1) // lớn hơn 1 là admin
                            {

#line default
#line hidden
            BeginContext(2152, 66, true);
            WriteLiteral("                                <option value=\"\">Tất cả</option>\r\n");
            EndContext();
#line 57 "D:\Projects\OnGit\LangBiang\LangbiAng_Source\Langbiang_Web\WebApp\Views\Ticket\SaleHistory.cshtml"
                            }
                            foreach (var user in lstUser)
                            {

#line default
#line hidden
            BeginContext(2339, 39, true);
            WriteLiteral("                                <option");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2378, "\"", 2400, 1);
#line 60 "D:\Projects\OnGit\LangBiang\LangbiAng_Source\Langbiang_Web\WebApp\Views\Ticket\SaleHistory.cshtml"
WriteAttributeValue("", 2386, user.UserName, 2386, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2401, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(2403, 13, false);
#line 60 "D:\Projects\OnGit\LangBiang\LangbiAng_Source\Langbiang_Web\WebApp\Views\Ticket\SaleHistory.cshtml"
                                                          Write(user.FullName);

#line default
#line hidden
            EndContext();
            BeginContext(2416, 11, true);
            WriteLiteral("</option>\r\n");
            EndContext();
#line 61 "D:\Projects\OnGit\LangBiang\LangbiAng_Source\Langbiang_Web\WebApp\Views\Ticket\SaleHistory.cshtml"
                            }
                        

#line default
#line hidden
            BeginContext(2485, 263, true);
            WriteLiteral(@"                    </select>
                </div>
                <div class=""col-sm-2"">
                    <label>Từ ngày</label>
                    <div class=""input-group date"" id=""FromDatePK"">
                        <input type=""text"" id=""FromDate""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2748, "\"", 2773, 1);
#line 68 "D:\Projects\OnGit\LangBiang\LangbiAng_Source\Langbiang_Web\WebApp\Views\Ticket\SaleHistory.cshtml"
WriteAttributeValue("", 2756, Model.FromDate, 2756, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2774, 397, true);
            WriteLiteral(@" class=""form-control"">
                        <span class=""input-group-addon group-date-icon""><i class=""far fa-calendar-alt""></i></span>
                    </div>
                </div>
                <div class=""col-sm-2"">
                    <label>Đến ngày</label>
                    <div class=""input-group date"" id=""ToDatePK"">
                        <input type=""text"" id=""ToDate""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 3171, "\"", 3194, 1);
#line 75 "D:\Projects\OnGit\LangBiang\LangbiAng_Source\Langbiang_Web\WebApp\Views\Ticket\SaleHistory.cshtml"
WriteAttributeValue("", 3179, Model.ToDate, 3179, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3195, 414, true);
            WriteLiteral(@" class=""form-control"">
                        <span class=""input-group-addon group-date-icon""><i class=""far fa-calendar-alt""></i></span>
                    </div>
                </div>
                <div class=""col-sm-2"">
                    <label>Tuyến thăm quan</label>
                    <select class=""form-control"" id=""ddl-gatecode"">
                        <option value=""All"">Tất cả</option>
");
            EndContext();
#line 83 "D:\Projects\OnGit\LangBiang\LangbiAng_Source\Langbiang_Web\WebApp\Views\Ticket\SaleHistory.cshtml"
                          
                            var lstGate = (List<GateListModel>)ViewBag.GateList;
                            foreach (var item in lstGate)
                            {

#line default
#line hidden
            BeginContext(3809, 39, true);
            WriteLiteral("                                <option");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 3848, "\"", 3872, 1);
#line 87 "D:\Projects\OnGit\LangBiang\LangbiAng_Source\Langbiang_Web\WebApp\Views\Ticket\SaleHistory.cshtml"
WriteAttributeValue("", 3856, item.GateCode, 3856, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3873, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(3876, 13, false);
#line 87 "D:\Projects\OnGit\LangBiang\LangbiAng_Source\Langbiang_Web\WebApp\Views\Ticket\SaleHistory.cshtml"
                                                             Write(item.GateName);

#line default
#line hidden
            EndContext();
            BeginContext(3890, 11, true);
            WriteLiteral("</option>\r\n");
            EndContext();
#line 88 "D:\Projects\OnGit\LangBiang\LangbiAng_Source\Langbiang_Web\WebApp\Views\Ticket\SaleHistory.cshtml"
                            }
                        

#line default
#line hidden
            BeginContext(3959, 3022, true);
            WriteLiteral(@"                    </select>
                </div>
                
                <div class=""col-sm-2"">
                    <input type=""button"" value=""OK"" class=""btn btn-primary btn-filter"" id=""btn-search"" />
                   
                   
                </div>

            </div>
        </div>

        <div class=""card-body "">
            <div class=""row"">
                <div class=""col-sm-3"">
                    <div class=""info-box"">
                        <span class=""info-box-icon bg-green""><i class=""fa fa-flag""></i></span>
                        <div class=""info-box-content"">
                            <span class=""info-box-text"">Tổng số lượng vé bán</span>
                            <span class=""info-box-number"" id=""counter-SL-TrenVe"">0</span>
                        </div>
                    </div>
                </div>
                <div class=""col-sm-3"">
                    <div class=""info-box"">
                        <span class=""info-box-icon bg");
            WriteLiteral(@"-green""><i class=""fa fa-flag""></i></span>
                        <div class=""info-box-content"">
                            <span class=""info-box-text"">Tổng số lượng đơn hàng</span>
                            <span class=""info-box-number"" id=""counter-SL-InRa"">0</span>
                        </div>
                    </div>
                </div>
                <div class=""col-sm-3"">
                    <div class=""info-box"">
                        <span class=""info-box-icon bg-green""><i class=""fa fa-flag""></i></span>
                        <div class=""info-box-content"">
                            <span class=""info-box-text"">Tổng doanh số bán</span>
                            <span class=""info-box-number"" id=""counter-doanhso"">0</span>
                        </div>
                    </div>
                </div>
                <div class=""col-sm-3""></div>
            </div>
            <table class=""table table-bordered table-hover dataTable"" id=""table-salehistory"">
             ");
            WriteLiteral(@"   <thead>
                    <tr>
                        <th width=""40px"">Tải về PDF</th>
                        <th width=""40px"">STT</th>
                        <th width=""100px"">Mã vé</th>
                        <th width=""150px"">Mã tra cứu</th>
                        <th width=""100px"">Loại Vé</th>
                        <th width=""200px"">Tên khách hàng</th>
                        <th width=""200px"">Tuyến thăm quan</th>
                        <th width=""100px"">Giá vé</th>
                        <th width=""50px"">Số lượng</th>
                        <th width=""100px"">Thành tiền</th>
                        <th width=""100px"">Người bán</th>
                        <th width=""100px"">Ngày bán</th>
                        <th width=""150px"">Số biên lai Misa</th>
                        <th width=""150px"">Mã tra cứu Misa</th>
                    </tr>
                </thead>
            </table>

        </div>
    </div>
</section>
");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(6998, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(7004, 63, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "64997b156ad9ca84d2f26e849dd6a4188189a81522314", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(7067, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(7073, 76, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "64997b156ad9ca84d2f26e849dd6a4188189a81523570", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(7149, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(7155, 87, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "64997b156ad9ca84d2f26e849dd6a4188189a81524826", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(7242, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(7248, 68, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "64997b156ad9ca84d2f26e849dd6a4188189a81526082", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(7316, 7210, true);
                WriteLiteral(@"

    <script>
        var tableId = ""#table-salehistory"";
        var ajaxURL = ""/Ticket/GetSaleHistory"";
        var columnData = [
            {
                ""data"": ""id"", ""render"": function (data, type, row, meta) {
                    return RenderPdfView(data);
                }
            },
            { ""data"": ""rowNumber"" },
            { ""data"": ""ticketCode"" },
            { ""data"": ""subOrderCode"" },
            { ""data"": ""loaiIn"" },
            { ""data"": ""customerName"" },
            { ""data"": ""gateName"" },
            {
                ""data"": ""price"", ""render"": function (data, type, row, meta) {
                    return RenderNumerFormat(data);
                }
            },
            {
                ""data"": ""quanti"", ""render"": function (data, type, row, meta) {
                    return RenderNumerFormat(data);
                }
            },
            {
                ""data"": ""totalAfterVAT"", ""render"": function (data, type, row, meta) {
           ");
                WriteLiteral(@"         return RenderNumerFormat(data);
                }
            },
            { ""data"": ""fullName"" },
            {
                ""data"": ""createdDate"", ""render"": function (data, type, row, meta) {
                    return RenderDateComlumnGrid(data);
                }
            },
            { ""data"": ""invoiceNumber"" },
            { ""data"": ""transactionID"" },



        ];
        $(document).ready(function () {
            $(""#btn-export-excel"").click(function () {
                ExportExcel();
            });
            $("".date"").datepicker({
                format: ""dd/mm/yyyy""
            }).on('changeDate', function (e) {
                $(this).datepicker('hide');
            });


            $(document).keypress(function (e)
            {
                if (e.which == 13) {
                    GetCounterFilter();
                }
            });


            GetCounterFilter();
            $(""#btn-search"").click(function () {
                G");
                WriteLiteral(@"etCounterFilter();
            });



            $(""#ddl-sale-chanel"").change(function () {
                GetAllUserforDDL($(this).val());
                
            });


        });

        function GotoTicketDetail(ticketId) {
            location.href = ""/Ticket/TicketDetail/"" + ticketId;
        }
        function RenderNumerFormat(data) {
            var res = """";
            if (data !== undefined) {
                res = data.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,');
            }
            return ""<div style='width:100%;text-align:right;'>"" + res + ""</div>"";
        }
        function GetSaleHistory() {
            
            var dataSearch = {
                SaleChanelId: $(""#ddl-sale-chanel"").val(),
                GateCode: $(""#ddl-gatecode"").val(),
                UserName: $(""#ddl-employee"").val(),
                FromDate: ConverFormatDate($(""#FromDate"").val()),
                ToDate: ConverFormatDate($(""#ToDate"").val()),
                Ti");
                WriteLiteral(@"cketCode: $(""#TicketCode"").val(),
                Keyword: $(""#txt-keyword"").val(),
            };
            GenrateDataTableSearch(tableId, ajaxURL, columnData, dataSearch, 10,""vé"");

        }

        function ExportExcel() {
            var dataSearch = {
                SaleChanelId: $(""#ddl-sale-chanel"").val(),
                GateCode: $(""#ddl-gatecode"").val(),
                UserName: $(""#ddl-employee"").val(),
                FromDate: ConverFormatDate($(""#FromDate"").val()),
                ToDate: ConverFormatDate($(""#ToDate"").val()),
                TicketCode: $(""#TicketCode"").val(),
            };

            var dataSearch = JSON.stringify(dataSearch);
            location.href = ""/ticket/ExportGetSaleHistory?filter="" + dataSearch;
        }

        function GetAllUserforDDL(chanelId) {
            let htmlUserOption = ""<option value=''>Tất cả</option>"";

            if (chanelId == ""2"") {
                $.ajax({
                    type: ""GET"",
                  ");
                WriteLiteral(@"  url: ""/Account/GetListAllUserInfo"",
                    success: function (res) {

                        if (res !== null && res.length > 0)
                        {
                            $.each(res, function (i, item)
                            {
                                htmlUserOption = htmlUserOption + ""<option value='"" + item.userName + ""' >"" + item.fullName + ""</option>""
                            });
                            $(""#ddl-employee"").html(htmlUserOption);
                        }

                    }
                });
            } else {
                htmlUserOption = ""<option value=''>Tất cả</option>"";
                $(""#ddl-employee"").html(htmlUserOption);
            }

            
        }
        function RenderPdfView(subId) {
            var html = ""<div class='div-table-action'>"" +
                ""<i class='fa fa-eye' onclick='ViewPDf("" + subId + "")'></i>&nbsp;"" +
                ""</div>"";
            return html;
        }
");
                WriteLiteral(@"        function ViewPDf(subId) {
            printPdf(""https://vuonquocgiacondao.gamanjsc.com/ticketorder/GetPDFForPrint/"" + subId);
           //window.open(""/ticketorder/ViewTicketOrderPdf?subOrderId="" + subId, 'Xem pdf');
        }

        function GetCounterFilter()
        {

            var dataSearch = {
                SaleChanelId: $(""#ddl-sale-chanel"").val(),
                GateCode: $(""#ddl-gatecode"").val(),
                UserName: $(""#ddl-employee"").val(),
                FromDate: ConverFormatDate($(""#FromDate"").val()),
                ToDate: ConverFormatDate($(""#ToDate"").val()),
                TicketCode: $(""#TicketCode"").val()
            };

            $.ajax({
                type: ""POST"",
                contentType: 'application/json; charset=utf-8',
                url: ""/Ticket/GetSaleReportCounter"",
                dataType: 'json',
                headers: {
                    'RequestVerificationToken': TokenHeaderValue()
                },
           ");
                WriteLiteral(@"     data: JSON.stringify(dataSearch),
                success: function (res) {
                    $(""#counter-SL-TrenVe"").html(res.totalQuantiOnTicket);
                    $(""#counter-SL-InRa"").html(res.totalQuantiPrint);
                    $(""#counter-doanhso"").html(res.totalVAT);
                    GetSaleHistory();
                }
            });
        }
        function printPdf(url) {
            var iframe = document.createElement('iframe');
            // iframe.id = 'pdfIframe'
            iframe.className = 'pdfIframe'
            document.body.appendChild(iframe);
            iframe.style.display = 'none';
            iframe.onload = function () {
                setTimeout(function () {
                    iframe.focus();
                    iframe.contentWindow.print();
                    URL.revokeObjectURL(url)
                    // document.body.removeChild(iframe)
                }, 1);
            };
            iframe.src = url;
            // URL.revokeOb");
                WriteLiteral("jectURL(url)\r\n        }\r\n\r\n    </script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DAL.Models.Ticket.SaleHistoryFilterModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
