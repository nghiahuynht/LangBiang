#pragma checksum "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\Invoice\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "05dd8a59b41d8944f7cadf039d0e2f237dfda9d7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Invoice_Index), @"mvc.1.0.view", @"/Views/Invoice/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Invoice/Index.cshtml", typeof(AspNetCore.Views_Invoice_Index))]
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
#line 8 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\Invoice\Index.cshtml"
using DAL;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"05dd8a59b41d8944f7cadf039d0e2f237dfda9d7", @"/Views/Invoice/Index.cshtml")]
    public class Views_Invoice_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DAL.Models.Invoice.InvoiceFilterModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datepicker/datepicker3.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datatables-bs4/css/dataTables.bootstrap4.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datatables-fixedcolumns/css/fixedColumns.bootstrap4.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datepicker/bootstrap-datepicker.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datatable/jquery.datatable.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datatables-bs4/js/dataTables.bootstrap4.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datatables-fixedcolumns/js/dataTables.fixedColumns.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\Invoice\Index.cshtml"
  
    string titleRefix = Model.InvoiceType == "so" ? "bán hàng" : "mua hàng";
    ViewData["Title"] = "Danh sách đơn " + titleRefix;
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(234, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("styles", async() => {
                BeginContext(264, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(270, 69, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "05dd8a59b41d8944f7cadf039d0e2f237dfda9d76464", async() => {
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
                BeginContext(339, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(345, 87, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "05dd8a59b41d8944f7cadf039d0e2f237dfda9d77796", async() => {
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
                BeginContext(432, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(438, 98, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "05dd8a59b41d8944f7cadf039d0e2f237dfda9d79128", async() => {
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
                BeginContext(536, 4, true);
                WriteLiteral("\r\n\r\n");
                EndContext();
            }
            );
            BeginContext(543, 157, true);
            WriteLiteral("<section class=\"content-header\">\r\n    <div class=\"container-fluid\">\r\n        <div class=\"row mb-2\">\r\n            <div class=\"col-sm-6\">\r\n                <h1>");
            EndContext();
            BeginContext(702, 17, false);
#line 19 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\Invoice\Index.cshtml"
                Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(720, 254, true);
            WriteLiteral("</h1>\r\n            </div>\r\n            <div class=\"col-sm-6\">\r\n                <ol class=\"breadcrumb float-sm-right\">\r\n                    <li class=\"breadcrumb-item\"><a href=\"#\">Trang chủ</a></li>\r\n                    <li class=\"breadcrumb-item active\">");
            EndContext();
            BeginContext(976, 17, false);
#line 24 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\Invoice\Index.cshtml"
                                                   Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(994, 136, true);
            WriteLiteral("</li>\r\n                </ol>\r\n            </div>\r\n        </div>\r\n    </div><!-- /.container-fluid -->\r\n</section>\r\n<input type=\"hidden\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1130, "\"", 1156, 1);
#line 30 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\Invoice\Index.cshtml"
WriteAttributeValue("", 1138, Model.InvoiceType, 1138, 18, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1157, 394, true);
            WriteLiteral(@" id=""hid-invoicetype"" />
<section class=""content"">
    <div class=""card"">
        <div class=""card-header"">
            <div class=""row"">
                <div class=""col-sm-2"">
                    <label>Tình trạng</label>
                    <select class=""form-control"" id=""ddl-status-invoice"">
                        <option class="""">Tất cả</option>
                        <option");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1551, "\"", 1588, 1);
#line 39 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\Invoice\Index.cshtml"
WriteAttributeValue("", 1559, Contanst.InvoiceStatus_ConNo, 1559, 29, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1589, 49, true);
            WriteLiteral(">Còn nợ</option>\r\n                        <option");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1638, "\"", 1681, 1);
#line 40 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\Invoice\Index.cshtml"
WriteAttributeValue("", 1646, Contanst.InvoiceStatus_DaThanhToan, 1646, 35, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1682, 56, true);
            WriteLiteral(">Đã thanh toán</option>\r\n                        <option");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1738, "\"", 1773, 1);
#line 41 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\Invoice\Index.cshtml"
WriteAttributeValue("", 1746, Contanst.InvoiceStatus_Huy, 1746, 27, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1774, 262, true);
            WriteLiteral(@">Hủy</option>
                    </select>
                </div>
                <div class=""col-sm-2"">
                    <label>Từ ngày</label>
                    <div class=""input-group date"">
                        <input type=""text"" id=""FromDate""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2036, "\"", 2061, 1);
#line 47 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\Invoice\Index.cshtml"
WriteAttributeValue("", 2044, Model.FromDate, 2044, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2062, 383, true);
            WriteLiteral(@" class=""form-control"">
                        <span class=""input-group-addon group-date-icon""><i class=""far fa-calendar-alt""></i></span>
                    </div>
                </div>
                <div class=""col-sm-2"">
                    <label>Đến ngày</label>
                    <div class=""input-group date"">
                        <input type=""text"" id=""ToDate""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2445, "\"", 2468, 1);
#line 54 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\Invoice\Index.cshtml"
WriteAttributeValue("", 2453, Model.ToDate, 2453, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2469, 1624, true);
            WriteLiteral(@" class=""form-control"">
                        <span class=""input-group-addon group-date-icon""><i class=""far fa-calendar-alt""></i></span>
                    </div>
                </div>
                <div class=""col-sm-2"">
                    <label>Tìm theo mã đơn/khách hàng/ NCC</label>
                    <input type=""text"" class=""form-control"" id=""txtkeyword"" />
                </div>
                <div class=""col-sm-2"">
                    <input type=""button"" value=""Tìm"" class=""btn btn-default btn-filter"" id=""btn-search"" />
                </div>
            </div>

        </div>
        <div class=""card-body"">
            <div class=""text-right"">
                <a class=""btn btn-sm btn-primary"" href=""/product/productdetail""><i class=""fa fa-plus-circle""></i>&nbsp;Tạo mới</a>
                <button class=""btn btn-sm btn-success""><i class=""fa fa-download""></i>&nbsp;Export excel</button>
                <button class=""btn btn-sm btn-success""><i class=""fa fa-upload""></i>&nbsp;Impo");
            WriteLiteral(@"rt excel</button>
            </div>
            <table class=""table table-bordered table-hover dataTable"" id=""table-invoice"" width=""100%"">
                <thead>
                    <tr>
                        <th>Mã đơn hàng</th>
                        <th>Ngày</th>
                        <th>Giá trị</th>
                        <th>Tình trạng</th>
                        <th>Đối tác</th>
                        <th>Ghi chú</th>
                        <th></th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>
</section>
");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(4110, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(4116, 68, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "05dd8a59b41d8944f7cadf039d0e2f237dfda9d717378", async() => {
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
                BeginContext(4184, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(4190, 63, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "05dd8a59b41d8944f7cadf039d0e2f237dfda9d718634", async() => {
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
                BeginContext(4253, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(4259, 76, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "05dd8a59b41d8944f7cadf039d0e2f237dfda9d719890", async() => {
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
                BeginContext(4335, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(4341, 87, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "05dd8a59b41d8944f7cadf039d0e2f237dfda9d721146", async() => {
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
                BeginContext(4428, 2696, true);
                WriteLiteral(@"

    <script>
        var tableId = ""#table-invoice"";
        var ajaxURL = ""/invoice/searchinvoice"";
        var columnData = [
            { ""data"": ""code"" },
            { ""data"": ""invoiceDate"" },
            { ""data"": ""invoiceTotal"" },
            {
                ""data"": ""invoiceStatus"", ""render"": function (data, type, row, meta) {
                    return RenderStatusInvoice(data);
                }
            },
            { ""data"": ""objName"" },
            { ""data"": ""note"" },
            {
                ""data"": ""id"", ""render"": function (data, type, row, meta) {
                    return RenderTableAction(data);
                }
            },


        ];




        $(document).ready(function () {

            SearchInvoice();
            $(""#btn-search"").click(function () {
                SearchInvoice();
            });

            $("".date"").datepicker({
                format: ""dd/mm/yyyy""
            }).on('changeDate', function (e) {
           ");
                WriteLiteral(@"     $(this).datepicker('hide');
            });

        })

        function SearchInvoice() {
            var searchModel = {
                invoiceType: $(""#hid-invoicetype"").val(),
                invoiceStatus: $(""#ddl-status-invoice"").val(),
                fromDate: ConverFormatDate($(""#FromDate"").val()),
                toDate: ConverFormatDate($(""#ToDate"").val()),
                keyword: $(""#keyword"").val()
            };

            GenrateDataTableSearch(tableId, ajaxURL, columnData, searchModel);



        }
        function RenderTableAction(invoiceId) {
            var html = ""<div class='div-table-action'>"" +
                ""<i class='fa fa-edit' onclick='GotoInvoiceDetail("" + invoiceId + "")'></i>&nbsp;"" +
                ""</div>"";
            return html;
        }
        function GotoInvoiceDetail(invoiceId) {
            var invoicetype = $(""#hid-invoicetype"").val();
            var urlEdit = ""/invoice/invoicedetail/"" + invoicetype + ""/"" + invoiceId;
      ");
                WriteLiteral(@"      window.open(urlEdit, '_blank');
        }
        function RenderStatusInvoice(status) {
            var statusHTML = """";
            if (status == ""ConNo"") {
                statusHTML = ""<span class='badge badge-primary badge-status'>Đơn nợ</span>"";
            }
            else if (status == ""DaThanhToan"") {
                statusHTML = ""<span class='badge badge-success badge-status'>Đã thanh toán</span>"";
            }
            else if (status == ""Huy"") {
                statusHTML = ""<span class='badge badge-danger badge-status'>Hủy</span>"";
            }
            return statusHTML;
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DAL.Models.Invoice.InvoiceFilterModel> Html { get; private set; }
    }
}
#pragma warning restore 1591