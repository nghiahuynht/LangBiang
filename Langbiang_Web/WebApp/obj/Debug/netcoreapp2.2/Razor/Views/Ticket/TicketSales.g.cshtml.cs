#pragma checksum "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\Ticket\TicketSales.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b706c8888f3e5c1c09c325052bbcea002e1cabd4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Ticket_TicketSales), @"mvc.1.0.view", @"/Views/Ticket/TicketSales.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Ticket/TicketSales.cshtml", typeof(AspNetCore.Views_Ticket_TicketSales))]
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
#line 2 "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\Ticket\TicketSales.cshtml"
using DAL.Entities;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b706c8888f3e5c1c09c325052bbcea002e1cabd4", @"/Views/Ticket/TicketSales.cshtml")]
    public class Views_Ticket_TicketSales : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DAL.Entities.Ticket>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datatables-bs4/css/dataTables.bootstrap4.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datatables-fixedcolumns/css/fixedColumns.bootstrap4.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datatable/jquery.datatable.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datatables-bs4/js/dataTables.bootstrap4.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datatables-fixedcolumns/js/dataTables.fixedColumns.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\Ticket\TicketSales.cshtml"
  
    ViewData["Title"] = "Bán vé";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            DefineSection("styles", async() => {
                BeginContext(154, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(160, 87, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "b706c8888f3e5c1c09c325052bbcea002e1cabd45556", async() => {
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
                BeginContext(247, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(253, 98, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "b706c8888f3e5c1c09c325052bbcea002e1cabd46888", async() => {
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
                BeginContext(351, 1227, true);
                WriteLiteral(@"
    <style>
        
        label {
            position: absolute;
            font-size: 1rem;
            //left: 10px;
            top: 0%;
            transform: translateY(-50%);
            background-color: white;
            color: gray;
            padding: 0 0.3rem;
            margin: 0 0.5rem;
            transition: .1s ease-out;
            transform-origin: left top;
            pointer-events: none;
        }

        input, select {
            font-size: 1rem;
            outline: none;
            border: 1px solid gray;
            border-radius: 5px;
            padding: 1rem 0.7rem;
            color: gray;
            transition: 0.1s ease-out;
        }

            input:focus, select:focus {
                border-color: #6200EE;
            }

                input:focus + label, select:focus + label {
                    color: #6200EE;
                    top: 0;
                    transform: translateY(-50%) scale(.9);
                }

");
                WriteLiteral("            input:not(:placeholder-shown) + label, select:not(:placeholder-shown) + label {\r\n                top: 0;\r\n                transform: translateY(-50%) scale(.9);\r\n            }\r\n    </style>\r\n");
                EndContext();
            }
            );
            BeginContext(1581, 159, true);
            WriteLiteral("\r\n<section class=\"content-header\">\r\n    <div class=\"container-fluid\">\r\n        <div class=\"row mb-2\">\r\n            <div class=\"col-sm-6\">\r\n                <h1>");
            EndContext();
            BeginContext(1742, 17, false);
#line 58 "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\Ticket\TicketSales.cshtml"
                Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(1760, 1280, true);
            WriteLiteral(@"</h1>
            </div>
        </div>
    </div><!-- /.container-fluid -->
</section>

<section class=""content"">
    <div class=""card"">
        <div class=""card-body"">
            <div class=""row"">
                <div class=""col-md-6"" style=""padding-right:5px; width: 100%"">
                    <table class=""table table-bordered table-hover dataTable"" id=""table-ticket"" width=""100%"">
                        <thead>
                            <tr>
                                <th>Id</th>
                                <th>Mã Ticket</th>
                                <th>Mô tả</th>
                                <th>Giá vé</th>
                                <th>Loại In</th>
                            </tr>
                        </thead>
                    </table>
                </div>
                <div class=""col-md-6"" style=""margin-top:6px"">
                    <div class=""form-group row"">
                        <div class=""col-md-12 form-outline"">
               ");
            WriteLiteral(@"             <div id=""divCustomerType"" style=""border: 1px solid #dee2e6; width: 100%"">
                                
                                <select class=""form-control"" id=""CustomerCode"" name=""CustomerCode"" style=""margin: 15px; width:95% "">
");
            EndContext();
#line 87 "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\Ticket\TicketSales.cshtml"
                                      
                                        var lstCustomer = (List<Customer>)ViewBag.LstCustomer;
                                        foreach (var item in lstCustomer)
                                        {

#line default
#line hidden
            BeginContext(3294, 51, true);
            WriteLiteral("                                            <option");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 3345, "\"", 3371, 1);
#line 91 "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\Ticket\TicketSales.cshtml"
WriteAttributeValue("", 3353, item.CustomerCode, 3353, 18, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3372, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(3374, 17, false);
#line 91 "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\Ticket\TicketSales.cshtml"
                                                                          Write(item.CustomerName);

#line default
#line hidden
            EndContext();
            BeginContext(3391, 11, true);
            WriteLiteral("</option>\r\n");
            EndContext();
#line 92 "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\Ticket\TicketSales.cshtml"
                                        }
                                    

#line default
#line hidden
            BeginContext(3484, 676, true);
            WriteLiteral(@"                                </select>
                            </div>
                            <label class=""form-label"" for=""divCustomerType"">Chọn khách hàng</label>

                        </div>
                    </div>
                    <div class=""form-group row"" style="" margin: 0px; margin-top: 20px"">
                        <div class=""col-md-6 form-outline"" style="" padding: 0px; padding-right: 20px"">
                            <div id=""divTicketType"" style=""border: 1px solid #dee2e6; width: 100%"">
                                <select disabled  class=""form-control"" id=""LoaiInCode"" name=""LoaiInCode"" style=""margin: 15px; width:90% "">
");
            EndContext();
#line 104 "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\Ticket\TicketSales.cshtml"
                                      
                                        var LstLoaiIn = (List<LoaiIn>)ViewBag.LstLoaiIn;
                                        foreach (var item in LstLoaiIn)
                                        {

#line default
#line hidden
            BeginContext(4406, 51, true);
            WriteLiteral("                                            <option");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 4457, "\"", 4475, 1);
#line 108 "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\Ticket\TicketSales.cshtml"
WriteAttributeValue("", 4465, item.Code, 4465, 10, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4476, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(4478, 16, false);
#line 108 "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\Ticket\TicketSales.cshtml"
                                                                  Write(item.Description);

#line default
#line hidden
            EndContext();
            BeginContext(4494, 11, true);
            WriteLiteral("</option>\r\n");
            EndContext();
#line 109 "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\Ticket\TicketSales.cshtml"
                                        }
                                    

#line default
#line hidden
            BeginContext(4587, 1678, true);
            WriteLiteral(@"                                </select>
                            </div>
                            <label class=""form-label"" for=""divTicketType"">KIỂU IN</label>
                        </div>
                        <div class=""col-md-6 form-outline"" style="" padding: 0px; padding-left: 20px"">
                            <div id=""divNumberTicket"" style=""border: 1px solid #dee2e6; width: 100% "">
                                <input type=""number"" min=""1"" value=""1"" class=""form-control"" id=""QuantityTicket"" style=""margin: 15px; width:90% "" />
                            </div>
                            <label class=""form-label"" for=""divNumberTicket"" style=""left: 20px"">SỐ LƯỢNG</label>
                        </div>
                    </div>
                    <div class=""form-group row"" style="" margin-top: 40px"">
                        <div class=""col-md-3 row"">
                            <label style=""font-weight: bold; font-size: 20px"">Tổng tiền: </label>
                        </div>");
            WriteLiteral(@"
                        <div class=""col-md-6 row"">
                            <label style=""color: #5ba513; font-weight: bold; font-size: 20px"" id=""TotalTicket"">0</label>
                        </div>

                    </div>
                    <div class=""form-group row"" style="" margin-top: 40px"">
                        <input disabled type=""button"" style=""background-color:blueviolet; color:white; width:100%; margin-left: 20%; margin-right:20%"" value=""BÁN VÉ"" class=""btn btn-default btn-filter"" id=""btn-sales"" />
                    </div>
                </div>
            </div>
        </div>
    </div>



</section>

");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(6282, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(6288, 63, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b706c8888f3e5c1c09c325052bbcea002e1cabd417450", async() => {
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
                BeginContext(6351, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(6357, 76, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b706c8888f3e5c1c09c325052bbcea002e1cabd418706", async() => {
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
                BeginContext(6433, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(6439, 87, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b706c8888f3e5c1c09c325052bbcea002e1cabd419962", async() => {
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
                BeginContext(6526, 2942, true);
                WriteLiteral(@"

    <script>
        var tableId = ""#table-ticket"";
        var ajaxURL = ""/Ticket/SearchTicket"";
        var ticketCode = """";
        var price = 0;
        var columnData = [
            { ""data"": ""id"", visible: false },
            { ""data"": ""code"" },
            { ""data"": ""description"" },
            { ""data"": ""price"" },
            { ""data"": ""loaiIn"", visible: false }
        ];
        $(document).ready(function () {
            LoadTicket();
            $(""#QuantityTicket"").on(""change"", function (e) {
                var num = parseInt($(this).val());
                if (num < 1) {
                    $(this).val(1);
                }
                if (price != 0)
                    $(""#TotalTicket"").text(getTotal().toLocaleString());
            });
            $('#table-ticket tbody').on('click', 'tr', function (e) {
                $(""#btn-sales"").removeAttr('disabled');
                $(this).siblings().css(""background-color"", """");
                $(this).css(""backg");
                WriteLiteral(@"round-color"", ""#dee2e6"");
                var currentRow = $(tableId).DataTable().row(this).data();
                ticketCode = currentRow.code;
                price = currentRow.price;
                var loaiIn = currentRow.loaiIn;
                $(""#LoaiInCode"").val(loaiIn);
                $(""#TotalTicket"").text(getTotal().toLocaleString());
            });
            $(""#btn-sales"").click(function () {
                SaveTicket();
            });

        })
        function getTotal() {
            var num = parseInt($(""#QuantityTicket"").val());
            return price * num;
        }
        function LoadTicket() {

            var dataSearch = {
                BranchId: 0,
                Keyword: """"
            };
            GenrateDataTableSearch(tableId, ajaxURL, columnData, dataSearch, 10);
        }
        function SaveTicket() {
            var objData =
                {
                    CustomerCode: $(""#CustomerCode"").val(),
                    LoaiIn");
                WriteLiteral(@"Code:$(""#LoaiInCode"").val(),
                    Quantity: parseInt($(""#QuantityTicket"").val()),
                    TicketCode: ticketCode
                };
            
            $.ajax({
                type: ""POST"",
                contentType: 'application/json; charset=utf-8',
                url: ""/Ticket/SaveTicketOrder"",
                dataType: 'json',
                data: JSON.stringify(objData),
                beforeSend: function () {
                },
                success: function (res) {
                    if (res.isSuccess === true) {
                        bootbox.alert(AlertSuccess(""Lưu dữ liệu thành công""), function () {
                        });
                    } else {
                        bootbox.alert(AlertFail(res.errorMessage));
                    }

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DAL.Entities.Ticket> Html { get; private set; }
    }
}
#pragma warning restore 1591
