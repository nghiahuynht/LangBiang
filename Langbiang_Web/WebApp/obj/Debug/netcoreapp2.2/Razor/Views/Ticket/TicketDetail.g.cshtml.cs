#pragma checksum "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\Ticket\TicketDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eaaec3f404aeaf033774fc5057487db7211b4655"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Ticket_TicketDetail), @"mvc.1.0.view", @"/Views/Ticket/TicketDetail.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Ticket/TicketDetail.cshtml", typeof(AspNetCore.Views_Ticket_TicketDetail))]
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
#line 2 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\Ticket\TicketDetail.cshtml"
using DAL.Entities;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eaaec3f404aeaf033774fc5057487db7211b4655", @"/Views/Ticket/TicketDetail.cshtml")]
    public class Views_Ticket_TicketDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DAL.Entities.Ticket>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/jquery.validate.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\Ticket\TicketDetail.cshtml"
  
    ViewData["Title"] = "Thông tin Vé";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(144, 161, true);
            WriteLiteral("\r\n\r\n<section class=\"content-header\">\r\n    <div class=\"container-fluid\">\r\n        <div class=\"row mb-2\">\r\n            <div class=\"col-sm-6\">\r\n                <h1>");
            EndContext();
            BeginContext(307, 17, false);
#line 13 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\Ticket\TicketDetail.cshtml"
                Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(325, 568, true);
            WriteLiteral(@"</h1>
            </div>
            <div class=""col-sm-6"">
                <ol class=""breadcrumb float-sm-right"">
                    <li class=""breadcrumb-item"">
                        <input type=""button"" value=""Lưu"" class=""btn bg-primary"" id=""btn-save"" />
                    </li>

                </ol>
            </div>
        </div>
    </div><!-- /.container-fluid -->
</section>

<section class=""content"">
    <div class=""card"">
        <div class=""card-body"">
            <form class=""form-horizontal"" id=""form-ticket"">
                ");
            EndContext();
            BeginContext(894, 25, false);
#line 31 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\Ticket\TicketDetail.cshtml"
           Write(Html.HiddenFor(x => x.Id));

#line default
#line hidden
            EndContext();
            BeginContext(919, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(938, 32, false);
#line 32 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\Ticket\TicketDetail.cshtml"
           Write(Html.HiddenFor(x => x.CreatedBy));

#line default
#line hidden
            EndContext();
            BeginContext(970, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(989, 34, false);
#line 33 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\Ticket\TicketDetail.cshtml"
           Write(Html.HiddenFor(x => x.CreatedDate));

#line default
#line hidden
            EndContext();
            BeginContext(1023, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(1042, 32, false);
#line 34 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\Ticket\TicketDetail.cshtml"
           Write(Html.HiddenFor(x => x.UpdatedBy));

#line default
#line hidden
            EndContext();
            BeginContext(1074, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(1093, 34, false);
#line 35 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\Ticket\TicketDetail.cshtml"
           Write(Html.HiddenFor(x => x.UpdatedDate));

#line default
#line hidden
            EndContext();
            BeginContext(1127, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(1146, 32, false);
#line 36 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\Ticket\TicketDetail.cshtml"
           Write(Html.HiddenFor(x => x.IsDeleted));

#line default
#line hidden
            EndContext();
            BeginContext(1178, 310, true);
            WriteLiteral(@"
     
                <div class=""row"">
                    <div class=""col-md-6"">
                        <div class=""form-group row"">
                            <label class=""col-md-3 col-form-label"">Mã Vé *</label>
                            <div class=""col-md-9"">
                                ");
            EndContext();
            BeginContext(1489, 61, false);
#line 43 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\Ticket\TicketDetail.cshtml"
                           Write(Html.TextBoxFor(x => x.Code, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(1550, 355, true);
            WriteLiteral(@"
                            </div>
                        </div>
                        <div class=""form-group row"">
                            <label class=""col-md-3 col-form-label"">Loại vé</label>
                            <div class=""col-md-9"">
                                <select class=""form-control"" id=""TicketType"" name=""BranchId"">
");
            EndContext();
#line 50 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\Ticket\TicketDetail.cshtml"
                                      
                                        var LstTicketType = (List<LoaiIn>)ViewBag.LstLoaiIn;
                                        foreach (var item in LstTicketType)
                                        {
                                            string loaiIn = Model != null && !string.IsNullOrEmpty(Model.LoaiIn) ? Model.LoaiIn : "";
                                            string selected = item.Code == loaiIn ? "selected='selected'" : string.Empty;

#line default
#line hidden
            BeginContext(2417, 51, true);
            WriteLiteral("                                            <option");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2468, "\"", 2486, 1);
#line 56 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\Ticket\TicketDetail.cshtml"
WriteAttributeValue("", 2476, item.Code, 2476, 10, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2487, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(2490, 8, false);
#line 56 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\Ticket\TicketDetail.cshtml"
                                                                   Write(selected);

#line default
#line hidden
            EndContext();
            BeginContext(2499, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(2501, 16, false);
#line 56 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\Ticket\TicketDetail.cshtml"
                                                                              Write(item.Description);

#line default
#line hidden
            EndContext();
            BeginContext(2517, 11, true);
            WriteLiteral("</option>\r\n");
            EndContext();
#line 57 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\Ticket\TicketDetail.cshtml"
                                        }
                                    

#line default
#line hidden
            BeginContext(2610, 336, true);
            WriteLiteral(@"                                </select>
                            </div>
                        </div>

                        <div class=""form-group row"">
                            <label class=""col-md-3 col-form-label"">Giá vé *</label>
                            <div class=""col-md-9"">
                                ");
            EndContext();
            BeginContext(2947, 80, false);
#line 66 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\Ticket\TicketDetail.cshtml"
                           Write(Html.TextBoxFor(x => x.Price, new { @class = "form-control", @type = "number" }));

#line default
#line hidden
            EndContext();
            BeginContext(3027, 290, true);
            WriteLiteral(@"
                            </div>
                        </div>
                        <div class=""form-group row"">
                            <label class=""col-md-3 col-form-label"">Mô tả</label>
                            <div class=""col-md-9"">
                                ");
            EndContext();
            BeginContext(3318, 82, false);
#line 72 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\Ticket\TicketDetail.cshtml"
                           Write(Html.TextAreaFor(x => x.Description, new { @class = "form-control", @rows = "5" }));

#line default
#line hidden
            EndContext();
            BeginContext(3400, 431, true);
            WriteLiteral(@"
                            </div>
                        </div>
                    </div>

                    <div class=""col-md-6"">
                        <div class=""form-group row"">
                            <label class=""col-md-3 col-form-label"">Điểm bán vé</label>
                            <div class=""col-md-9"">
                                <select class=""form-control"" id=""BranchId"" name=""BranchId"">
");
            EndContext();
#line 82 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\Ticket\TicketDetail.cshtml"
                                      
                                        var LstBranch = (List<Branch>)ViewBag.LstBranch;
                                        foreach (var item in LstBranch)
                                        {
                                            int branchId = Model != null && Model.BranchId > 0 ? Model.BranchId : 0;
                                            string selected = item.Id == branchId ? "selected='selected'" : string.Empty;

#line default
#line hidden
            BeginContext(4318, 51, true);
            WriteLiteral("                                            <option");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 4369, "\"", 4385, 1);
#line 88 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\Ticket\TicketDetail.cshtml"
WriteAttributeValue("", 4377, item.Id, 4377, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4386, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(4389, 8, false);
#line 88 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\Ticket\TicketDetail.cshtml"
                                                                 Write(selected);

#line default
#line hidden
            EndContext();
            BeginContext(4398, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(4400, 11, false);
#line 88 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\Ticket\TicketDetail.cshtml"
                                                                            Write(item.NameVN);

#line default
#line hidden
            EndContext();
            BeginContext(4411, 11, true);
            WriteLiteral("</option>\r\n");
            EndContext();
#line 89 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\Ticket\TicketDetail.cshtml"
                                        }
                                    

#line default
#line hidden
            BeginContext(4504, 338, true);
            WriteLiteral(@"                                </select>
                            </div>
                        </div>
                        <div class=""form-group row"">
                            <label class=""col-md-3 col-form-label"">Mẫu biên lai</label>
                            <div class=""col-md-9"">
                                ");
            EndContext();
            BeginContext(4843, 69, false);
#line 97 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\Ticket\TicketDetail.cshtml"
                           Write(Html.TextBoxFor(x => x.BillTemplate, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(4912, 301, true);
            WriteLiteral(@"
                            </div>
                        </div>
                        <div class=""form-group row"">
                            <label class=""col-md-3 col-form-label"">Kí hiệu biên lai</label>
                            <div class=""col-md-9"">
                                ");
            EndContext();
            BeginContext(5214, 74, false);
#line 103 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\Ticket\TicketDetail.cshtml"
                           Write(Html.TextBoxFor(x => x.EContractTemplate, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(5288, 199, true);
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n\r\n                </div>\r\n\r\n\r\n            </form>\r\n\r\n        </div>\r\n    </div>\r\n\r\n\r\n\r\n</section>\r\n\r\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(5504, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(5510, 47, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eaaec3f404aeaf033774fc5057487db7211b465516236", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(5557, 1799, true);
                WriteLiteral(@"
    <script>
        $(document).ready(function () {
            $(""#btn-save"").click(function () {
                SaveTicket();
            });
        })
        function ValidTicket() {
            var resutlValid = $(""#form-ticket"").validate({
                rules: {
                    ""Code"": ""required"",
                    ""Price"": ""required"",
                },
                messages: {
                    ""Code"": ""Thông tin bắt buộc!"",
                    ""Price"": ""Thông tin bắt buộc!""
                }
            }).form();
            return resutlValid;
        }
        function SaveTicket() {
            var valid = ValidTicket();
            if (valid) {
                var saveData = FormToObject(""#form-ticket"", """");
                saveData.BranchId = parseInt($(""#BranchId"").val());
                saveData.LoaiIn = $(""#TicketType"").val();
                $.ajax({
                    type: ""POST"",
                    contentType: 'application/json; charset=ut");
                WriteLiteral(@"f-8',
                    url: ""/Ticket/SaveTicket"",
                    dataType: 'json',
                    data: JSON.stringify(saveData),
                    beforeSend: function () {

                    },
                    success: function (res) {
                        if (res.isSuccess === true) {
                            bootbox.alert(AlertSuccess(""Lưu dữ liệu thành công""), function () {
                                location.href = ""/Ticket/TicketDetail/"" + res.valueReturn;
                            });
                        } else {
                            bootbox.alert(AlertFail(res.errorMessage));
                        }

                    }
                });


            }



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