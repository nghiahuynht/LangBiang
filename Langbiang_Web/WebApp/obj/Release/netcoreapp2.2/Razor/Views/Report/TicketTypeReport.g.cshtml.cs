#pragma checksum "D:\Projects\OnGit\LangBiang\LangbiAng_Source\Langbiang_Web\WebApp\Views\Report\TicketTypeReport.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "14bcfb4660da67e000bb94d75a80262e01c0bb42"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Report_TicketTypeReport), @"mvc.1.0.view", @"/Views/Report/TicketTypeReport.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Report/TicketTypeReport.cshtml", typeof(AspNetCore.Views_Report_TicketTypeReport))]
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
#line 7 "D:\Projects\OnGit\LangBiang\LangbiAng_Source\Langbiang_Web\WebApp\Views\Report\TicketTypeReport.cshtml"
using DAL.Entities;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"14bcfb4660da67e000bb94d75a80262e01c0bb42", @"/Views/Report/TicketTypeReport.cshtml")]
    public class Views_Report_TicketTypeReport : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DAL.Models.Report.TicketTypeRPFilter>
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
#line 2 "D:\Projects\OnGit\LangBiang\LangbiAng_Source\Langbiang_Web\WebApp\Views\Report\TicketTypeReport.cshtml"
  
    ViewData["Title"] = "Báo cáo bán vé theo tuyến thăm quan";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(163, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("styles", async() => {
                BeginContext(202, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(208, 69, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "14bcfb4660da67e000bb94d75a80262e01c0bb426546", async() => {
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
                BeginContext(277, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(283, 87, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "14bcfb4660da67e000bb94d75a80262e01c0bb427878", async() => {
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
                BeginContext(370, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(376, 98, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "14bcfb4660da67e000bb94d75a80262e01c0bb429210", async() => {
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
                BeginContext(474, 245, true);
                WriteLiteral("\r\n    <style>\r\n        .datepicker table tr td.disabled,\r\n        .datepicker table tr td.disabled:hover {\r\n            background-color: #e6d2d2;\r\n        }\r\n        .RowTotal {\r\n            background-color: #9fbbd7;\r\n        }\r\n    </style>\r\n");
                EndContext();
            }
            );
            BeginContext(722, 157, true);
            WriteLiteral("<section class=\"content-header\">\r\n    <div class=\"container-fluid\">\r\n        <div class=\"row mb-2\">\r\n            <div class=\"col-sm-6\">\r\n                <h1>");
            EndContext();
            BeginContext(881, 17, false);
#line 26 "D:\Projects\OnGit\LangBiang\LangbiAng_Source\Langbiang_Web\WebApp\Views\Report\TicketTypeReport.cshtml"
                Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(899, 254, true);
            WriteLiteral("</h1>\r\n            </div>\r\n            <div class=\"col-sm-6\">\r\n                <ol class=\"breadcrumb float-sm-right\">\r\n                    <li class=\"breadcrumb-item\"><a href=\"#\">Trang chủ</a></li>\r\n                    <li class=\"breadcrumb-item active\">");
            EndContext();
            BeginContext(1155, 17, false);
#line 31 "D:\Projects\OnGit\LangBiang\LangbiAng_Source\Langbiang_Web\WebApp\Views\Report\TicketTypeReport.cshtml"
                                                   Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(1173, 147, true);
            WriteLiteral("</li>\r\n                </ol>\r\n            </div>\r\n        </div>\r\n    </div><!-- /.container-fluid -->\r\n</section>\r\n<section class=\"content\">\r\n    ");
            EndContext();
            BeginContext(1321, 23, false);
#line 38 "D:\Projects\OnGit\LangBiang\LangbiAng_Source\Langbiang_Web\WebApp\Views\Report\TicketTypeReport.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(1344, 310, true);
            WriteLiteral(@"
    <div class=""card"">
        <div class=""card-header"">
            <div class=""row"">

                <div class=""col-sm-2"">
                    <label>Nhân viên</label>
                    <select class=""form-control"" id=""ddl-employee"">
                        <option value=""All"">Tất cả</option>
");
            EndContext();
#line 47 "D:\Projects\OnGit\LangBiang\LangbiAng_Source\Langbiang_Web\WebApp\Views\Report\TicketTypeReport.cshtml"
                          
                            var lstUser = (List<UserInfo>)ViewBag.LstUser;
                            foreach (var user in lstUser.Where(x => !x.UserName.ToLower().StartsWith("zone")))
                            {

#line default
#line hidden
            BeginContext(1901, 39, true);
            WriteLiteral("                                <option");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1940, "\"", 1962, 1);
#line 51 "D:\Projects\OnGit\LangBiang\LangbiAng_Source\Langbiang_Web\WebApp\Views\Report\TicketTypeReport.cshtml"
WriteAttributeValue("", 1948, user.UserName, 1948, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1963, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1965, 13, false);
#line 51 "D:\Projects\OnGit\LangBiang\LangbiAng_Source\Langbiang_Web\WebApp\Views\Report\TicketTypeReport.cshtml"
                                                          Write(user.FullName);

#line default
#line hidden
            EndContext();
            BeginContext(1978, 11, true);
            WriteLiteral("</option>\r\n");
            EndContext();
#line 52 "D:\Projects\OnGit\LangBiang\LangbiAng_Source\Langbiang_Web\WebApp\Views\Report\TicketTypeReport.cshtml"
                            }
                        

#line default
#line hidden
            BeginContext(2047, 263, true);
            WriteLiteral(@"                    </select>
                </div>
                <div class=""col-sm-2"">
                    <label>Từ ngày</label>
                    <div class=""input-group date"" id=""FromDatePK"">
                        <input type=""text"" id=""FromDate""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2310, "\"", 2335, 1);
#line 59 "D:\Projects\OnGit\LangBiang\LangbiAng_Source\Langbiang_Web\WebApp\Views\Report\TicketTypeReport.cshtml"
WriteAttributeValue("", 2318, Model.FromDate, 2318, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2336, 397, true);
            WriteLiteral(@" class=""form-control"">
                        <span class=""input-group-addon group-date-icon""><i class=""far fa-calendar-alt""></i></span>
                    </div>
                </div>
                <div class=""col-sm-2"">
                    <label>Đến ngày</label>
                    <div class=""input-group date"" id=""ToDatePK"">
                        <input type=""text"" id=""ToDate""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2733, "\"", 2756, 1);
#line 66 "D:\Projects\OnGit\LangBiang\LangbiAng_Source\Langbiang_Web\WebApp\Views\Report\TicketTypeReport.cshtml"
WriteAttributeValue("", 2741, Model.ToDate, 2741, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2757, 192, true);
            WriteLiteral(" class=\"form-control\">\r\n                        <span class=\"input-group-addon group-date-icon\"><i class=\"far fa-calendar-alt\"></i></span>\r\n                    </div>\r\n                </div>\r\n");
            EndContext();
            BeginContext(3143, 177, true);
            WriteLiteral("\r\n                <div class=\"col-sm-2\">\r\n                    <input type=\"button\" value=\"OK\" class=\"btn btn-primary btn-filter\" id=\"btn-search\" />\r\n                    &nbsp;\r\n");
            EndContext();
            BeginContext(3475, 1719, true);
            WriteLiteral(@"                </div>
            </div>
        </div>

        <div class=""card-body "">
            <div class=""row"">
                <div class=""col-sm-3"">
                    <div class=""info-box"">
                        <span class=""info-box-icon bg-green""><i class=""fa fa-flag""></i></span>
                        <div class=""info-box-content"">
                            <span class=""info-box-text"">Tổng SL bán</span>
                            <span class=""info-box-number"" id=""counter-SL-ve"">0</span>
                        </div>
                    </div>
                    <div class=""info-box"">
                        <span class=""info-box-icon bg-green""><i class=""fa fa-flag""></i></span>
                        <div class=""info-box-content"">
                            <span class=""info-box-text"">Tổng doanh số bán</span>
                            <span class=""info-box-number"" id=""counter-doanhso"">0</span>
                        </div>
                    </div>
           ");
            WriteLiteral(@"     </div>
                <div class=""col-sm-9"">
                    <table class=""table table-bordered table-hover dataTable"" id=""table-TitcketTypeRP"" width=""100%"">
                        <thead>
                            <tr>
                                <th>Mã tuyến</th>
                                <th>Tên tuyến</th>
                                <th>Mệnh giá</th>
                                <th>Tổng SL bán</th>
                                <th>Tổng doanh số bán</th>
                            </tr>
                        </thead>
                    </table>
                </div>

            </div>


        </div>
    </div>
</section>
");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(5211, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(5217, 63, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "14bcfb4660da67e000bb94d75a80262e01c0bb4218755", async() => {
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
                BeginContext(5280, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(5286, 76, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "14bcfb4660da67e000bb94d75a80262e01c0bb4220011", async() => {
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
                BeginContext(5362, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(5368, 87, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "14bcfb4660da67e000bb94d75a80262e01c0bb4221267", async() => {
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
                BeginContext(5455, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(5461, 68, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "14bcfb4660da67e000bb94d75a80262e01c0bb4222523", async() => {
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
                BeginContext(5529, 3836, true);
                WriteLiteral(@"

    <script>
        var tableId = ""#table-TitcketTypeRP"";
        var ajaxURL = ""/report/GetReportSalesByTicketType"";
        var columnData = [
            //{ ""data"": ""id"" },
            { ""data"": ""gateCode"" },
            { ""data"": ""gateName"" },
            { ""data"": ""price"" },

            {
                ""data"": ""slSale"", ""render"": function (data, type, row, meta) {
                    return RenderNumerFormat(data);
                }
            },
            {
                ""data"": ""amountSale""
            },

        ];
        $(document).ready(function () {
            $("".date"").datepicker({
                format: ""dd/mm/yyyy""
            }).on('changeDate', function (e) {
                $(this).datepicker('hide');
            });


            $(document).keypress(function (e) {
                if (e.which == 13) {
                    GetReportSalesByTickerType();
                }
            });
            GetReportSalesByTickerType();
            $(");
                WriteLiteral(@"""#btn-search"").click(function () {
                GetReportSalesByTickerType();
            });
        });
        function RenderNumerFormat(data) {
            var res = """";
            if (data !== undefined) {
                res = data?.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,');
            }
            return ""<div style='width:100%;text-align:right;'>"" + res + ""</div>"";
        }
        function GetReportSalesByTickerType() {

            var counterFilter = {
                UserName: $(""#ddl-employee"").val(),
                FromDate: ConverFormatDate($(""#FromDate"").val()),
                ToDate: ConverFormatDate($(""#ToDate"").val()),
                Keyword: $(""#keyword"").val()
            };

            $.ajax({
                type: ""POST"",
                contentType: 'application/json; charset=utf-8',
                url: ""/report/GetReportSalesByTicketType"",
                dataType: 'json',
                headers: {
                    'RequestVerific");
                WriteLiteral(@"ationToken': TokenHeaderValue()
                },
                data: JSON.stringify(counterFilter),
                success: function (res) {
                    $(""#counter-SL-ve"").html(res.sellQuantity.toLocaleString());
                    $(""#counter-doanhso"").html(res.totalSales.toLocaleString());
                    var tableSales = $(tableId).DataTable({
                        ""processing"": true,
                        ""responsive"": true,
                        ""searching"": false,
                        ""lengthChange"": false,
                        ""paging"": true,
                        ""iDisplayLength"": 20,
                        ""columns"": columnData,
                        ""ordering"": false,
                        ""scrollY"": ""400px"",
                        ""scrollX"": true,
                        ""scrollCollapse"": true,
                        ""language"": {
                            ""zeroRecords"": ""Không tìm thấy dữ liệu"",
                            ""infoEmpty"": ");
                WriteLiteral(@"""0/0 Kết quả""
                        },
                        data: res.data,
                        ""destroy"": true,
                        ""fnRowCallback"": function (nRow, aData, iDisplayIndex, iDisplayIndexFull) {
                            if (aData.loaiVe == ""Tổng"") {
                                $(`td`, nRow).addClass(""RowTotal"");
                            }
                        }
                    });
                    //var allSelectedData = tableSales.rows().data();
                    //for (var index = 0; index < allSelectedData.filter(x => x.loaiVe == ""Tổng"").length; index++) {
                    //    allSelectedData[index]
                    //}
                }
            });
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DAL.Models.Report.TicketTypeRPFilter> Html { get; private set; }
    }
}
#pragma warning restore 1591
