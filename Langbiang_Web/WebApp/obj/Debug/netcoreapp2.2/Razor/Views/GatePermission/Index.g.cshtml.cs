#pragma checksum "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\GatePermission\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cb1140a525bc5bc14c89616975a3c6cc43c6ddaa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_GatePermission_Index), @"mvc.1.0.view", @"/Views/GatePermission/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/GatePermission/Index.cshtml", typeof(AspNetCore.Views_GatePermission_Index))]
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
#line 7 "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\GatePermission\Index.cshtml"
using DAL.Entities;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cb1140a525bc5bc14c89616975a3c6cc43c6ddaa", @"/Views/GatePermission/Index.cshtml")]
    public class Views_GatePermission_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datatables-bs4/css/dataTables.bootstrap4.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datatables-fixedcolumns/css/fixedColumns.bootstrap4.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datatable/jquery.datatable.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datatables-bs4/js/dataTables.bootstrap4.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datatables-fixedcolumns/js/dataTables.fixedColumns.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/jquery.validate.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\GatePermission\Index.cshtml"
  
    ViewData["Title"] = "Danh sách tuyến thăm quan";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(110, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("styles", async() => {
                BeginContext(149, 8, true);
                WriteLiteral("\r\n\r\n    ");
                EndContext();
                BeginContext(157, 87, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "cb1140a525bc5bc14c89616975a3c6cc43c6ddaa6150", async() => {
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
                BeginContext(244, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(250, 98, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "cb1140a525bc5bc14c89616975a3c6cc43c6ddaa7482", async() => {
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
                BeginContext(348, 4, true);
                WriteLiteral("\r\n\r\n");
                EndContext();
            }
            );
            BeginContext(355, 157, true);
            WriteLiteral("<section class=\"content-header\">\r\n    <div class=\"container-fluid\">\r\n        <div class=\"row mb-2\">\r\n            <div class=\"col-sm-6\">\r\n                <h1>");
            EndContext();
            BeginContext(514, 17, false);
#line 18 "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\GatePermission\Index.cshtml"
                Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(532, 254, true);
            WriteLiteral("</h1>\r\n            </div>\r\n            <div class=\"col-sm-6\">\r\n                <ol class=\"breadcrumb float-sm-right\">\r\n                    <li class=\"breadcrumb-item\"><a href=\"#\">Trang chủ</a></li>\r\n                    <li class=\"breadcrumb-item active\">");
            EndContext();
            BeginContext(788, 17, false);
#line 23 "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\GatePermission\Index.cshtml"
                                                   Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(806, 2062, true);
            WriteLiteral(@"</li>
                </ol>
            </div>
        </div>
    </div><!-- /.container-fluid -->
</section>

<section class=""content"">
    <div class=""card"">
        <div class=""card-header"">
            <div class=""row"">
                <div class=""col-sm-10"">
                    <label>Tìm theo mã, tên tuyến</label>
                    <input type=""text"" class=""form-control"" id=""txtkeyword"" />
                </div>
                <div class=""col-sm-2"">
                    <input type=""button"" value=""Tìm"" class=""btn btn-primary btn-filter"" id=""btn-search"" />
                </div>
               
            </div>
        </div>

        <div class=""card-body "">

            <table class=""table table-bordered table-hover dataTable"" id=""table-GatePermission"" width=""100%"">
                <thead>
                    <tr>
                        <th>Mã tuyến</th>
                        <th>Tên tuyến</th>
                        <th>Nhân viên Soát vé</th>
                     ");
            WriteLiteral(@"   <th></th>
                    </tr>
                </thead>
            </table>

        </div>
    </div>
</section>

<!--Modal phân quyền soát vè-->
<div class=""modal fade show"" id=""modal-Gate-Permisson"" aria-modal=""true"" role=""dialog"">
    <div class=""modal-dialog "">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <input style=""display:none"" id=""txtGateCode"" />
                <h4 class=""modal-title"">Phân quyền soát vé</h4>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">×</span>
                </button>
            </div>
            <div class=""modal-body"">
                <div class=""row"">
                    <div class=""col-sm-4""><label class=""col-form-label"">Nhân viên</label></div>
                    <div class=""col-sm-8"">
                        <select class=""form-control selectpicker"" id=""txtUserName"" data-style=""btn-info"" data-live-sear");
            WriteLiteral("ch=\"true\">\r\n\r\n");
            EndContext();
#line 79 "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\GatePermission\Index.cshtml"
                              
                                var customerList = (List<UserInfo>)ViewBag.UserList;
                                if (customerList.Any())
                                {
                                    foreach (var cust in customerList)
                                    {

#line default
#line hidden
            BeginContext(3189, 47, true);
            WriteLiteral("                                        <option");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 3236, "\"", 3260, 1);
#line 85 "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\GatePermission\Index.cshtml"
WriteAttributeValue("", 3244, cust.UserName, 3244, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3261, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(3264, 13, false);
#line 85 "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\GatePermission\Index.cshtml"
                                                                     Write(cust.FullName);

#line default
#line hidden
            EndContext();
            BeginContext(3278, 11, true);
            WriteLiteral("</option>\r\n");
            EndContext();
#line 86 "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\GatePermission\Index.cshtml"
                                    }
                                }
                            

#line default
#line hidden
            BeginContext(3394, 2128, true);
            WriteLiteral(@"

                        </select>

                    </div>
                </div>
            </div>
            <div class=""modal-footer"">
                <a class=""btn btn-success"" onclick=""SavePermission()"">Phân quyền</a>
                <a class=""btn btn-danger"" onclick=""HideModal('#modal-Gate-Permisson')"">Đóng</a>

            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>

<!--Modal Thêm Gate-->
<div class=""modal fade show"" id=""modal-Create-Gate"" aria-modal=""true"" role=""dialog"">
    <div class=""modal-dialog  modal-lg "">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h4 class=""modal-title"">Thêm Cổng</h4>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">×</span>
                </button>
            </div>
            <div class=""modal-body"">
                <form class=""form-horizontal""");
            WriteLiteral(@" id=""form-Create-Gate"">
                    <div class=""row"">
                        <div class=""col-sm-4""><label class=""col-form-label"">Mã cổng *</label></div>
                        <div class=""col-sm-8"">
                            <input class=""form-control"" name=""GateCode"" id=""txtGateCodeCreate"" />

                        </div>
                    </div>
                    <div class=""row"">
                        <div class=""col-sm-4""><label class=""col-form-label"">Tên cổng *</label></div>
                        <div class=""col-sm-8"">
                            <input class=""form-control"" name=""GateName"" id=""txtGateNameCreate"" />

                        </div>
                    </div>
                </form>

            </div>
            <div class=""modal-footer"">
                <a class=""btn btn-success"" onclick=""CreateGate()"">Thêm</a>
                <a class=""btn btn-danger"" onclick=""HideModal('#modal-Create-Gate')"">Đóng</a>

            </div>
        </div>
     ");
            WriteLiteral("   <!-- /.modal-content -->\r\n    </div>\r\n    <!-- /.modal-dialog -->\r\n</div>\r\n\r\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(5539, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(5545, 63, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cb1140a525bc5bc14c89616975a3c6cc43c6ddaa16532", async() => {
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
                BeginContext(5608, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(5614, 76, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cb1140a525bc5bc14c89616975a3c6cc43c6ddaa17788", async() => {
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
                BeginContext(5690, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(5696, 87, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cb1140a525bc5bc14c89616975a3c6cc43c6ddaa19044", async() => {
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
                BeginContext(5783, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(5789, 47, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cb1140a525bc5bc14c89616975a3c6cc43c6ddaa20300", async() => {
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
                BeginContext(5836, 6023, true);
                WriteLiteral(@"

    <script>
        var tableId = ""#table-GatePermission"";
        var ajaxURL = ""/GatePermission/GetGatePermissionPaging"";
        var columnData = [
            { ""data"": ""gateCode"" },
            { ""data"": ""gateName"" },
            { ""data"": ""fullName"" },
            {
                ""data"": ""gateCode"", ""render"": function (data, type, row, meta) {
                    return RenderTableAction(data, (row.userName == null ? """" : row.userName));
                }
            },


        ];
        $(document).ready(function () {

            SearchGatePermission();
            $(""#btn-search"").click(function () {
                SearchGatePermission();
            });
        });
        function RenderTableAction(gateCode, userName) {
            var html = ""<div class='div-table-action'>"" +
                ""<i class='fa fa-key' onclick=GotoPermission('"" + gateCode + ""','"" + userName + ""')></i>&nbsp;"" +
                //""<i class='fa fa-trash' onclick=DeleteGate('"" + gateCode ");
                WriteLiteral(@"+ ""')></i>"" +
                ""</div>"";
            return html;
        }
        function GotoPermission(gateCode, userName) {
            //location.href = ""/customer/customerdetail/"" + customerId;
            $(""#modal-Gate-Permisson"").modal();
            $(""#txtGateCode"").val(gateCode)
            $(""#txtUserName"").val(userName)
        }
        function SearchGatePermission() {

            var dataSearch = {
                //CustomerType: $(""#ddl-customertype"").val(),
                //ProvinceCode: $(""#ddl-province"").val(),
                Keyword: $(""#txtkeyword"").val(),
                start: 0,
                length: 20
            };
            GenrateDataTableSearch(tableId, ajaxURL, columnData, dataSearch,20,""tuyến"");

        }

        function DeleteGate(gateCode) {
            bootbox.confirm(""Bạn có chắc muốn xóa cổng này?"", function (confi) {
                if (confi) {
                    $.ajax({
                        type: ""Get"",
                     ");
                WriteLiteral(@"   contentType: 'application/json; charset=utf-8',
                        url: ""/GatePermission/DeleteGate?gateCode="" + gateCode,

                        success: function (res) {
                            if (res.isSuccess === true) {
                                SearchGatePermission();
                            } else {
                                bootbox.alert(AlertFail(res.errorMessage));
                            }

                        }
                    });
                }
            });
        }

        function HideModal(modal) {
            $(modal).modal('hide');
            $(""#txtGateCode"").val("""")
        }

        function SavePermission() {
            var model = {
                UserName: $(""#txtUserName"").val(),
                GateCode: $(""#txtGateCode"").val()
            };
            $.ajax({
                type: ""POST"",
                contentType: 'application/json; charset=utf-8',
                url: ""/GatePermission/SaveGate");
                WriteLiteral(@"Permission"",
                data: JSON.stringify(model),
                success: function (res) {
                    if (res.isSuccess === true) {
                        $(""#modal-Gate-Permisson"").modal('hide');
                        SearchGatePermission();
                    } else {
                        bootbox.alert(AlertFail(res.errorMessage));
                    }

                }
            });
        }

        function ShowModalCreateGate() {
            $(""#txtGateNameCreate"").val("""");
            $(""#txtGateCodeCreate"").val("""");
            $(""#modal-Create-Gate"").modal();
        }

        function CreateGate() {
            var resutlValid = $(""#form-Create-Gate"").validate({
                rules: {
                    ""GateCode"": ""required"",
                    ""GateName"": ""required""
                },
                messages: {
                    ""GateCode"": ""Không được để trống !"",
                    ""GateName"": ""Không được để trống !""
           ");
                WriteLiteral(@"     }
            }).form();
            if (resutlValid == true) {

                var modelCreate = {
                    GateName: $(""#txtGateNameCreate"").val(),
                    GateCode: xoa_dau($(""#txtGateCodeCreate"").val())
                };
                $.ajax({
                    type: ""POST"",
                    contentType: 'application/json; charset=utf-8',
                    url: ""/GatePermission/CreateGate"",
                    data: JSON.stringify(modelCreate),
                    success: function (res) {
                        if (res.isSuccess === true) {
                            $(""#modal-Create-Gate"").modal(""hide"");
                            SearchGatePermission();
                        } else {
                            bootbox.alert(AlertFail(res.errorMessage));
                        }

                    }
                });
            }
        }

        //Hàm Xóa dấu
        function xoa_dau(str) {
            str = str.replace(/à");
                WriteLiteral(@"|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ/g, ""a"");
            str = str.replace(/è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ/g, ""e"");
            str = str.replace(/ì|í|ị|ỉ|ĩ/g, ""i"");
            str = str.replace(/ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ/g, ""o"");
            str = str.replace(/ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ/g, ""u"");
            str = str.replace(/ỳ|ý|ỵ|ỷ|ỹ/g, ""y"");
            str = str.replace(/đ/g, ""d"");
            str = str.replace(/À|Á|Ạ|Ả|Ã|Â|Ầ|Ấ|Ậ|Ẩ|Ẫ|Ă|Ằ|Ắ|Ặ|Ẳ|Ẵ/g, ""A"");
            str = str.replace(/È|É|Ẹ|Ẻ|Ẽ|Ê|Ề|Ế|Ệ|Ể|Ễ/g, ""E"");
            str = str.replace(/Ì|Í|Ị|Ỉ|Ĩ/g, ""I"");
            str = str.replace(/Ò|Ó|Ọ|Ỏ|Õ|Ô|Ồ|Ố|Ộ|Ổ|Ỗ|Ơ|Ờ|Ớ|Ợ|Ở|Ỡ/g, ""O"");
            str = str.replace(/Ù|Ú|Ụ|Ủ|Ũ|Ư|Ừ|Ứ|Ự|Ử|Ữ/g, ""U"");
            str = str.replace(/Ỳ|Ý|Ỵ|Ỷ|Ỹ/g, ""Y"");
            str = str.replace(/Đ/g, ""D"");
            str = str.replace("" "", ""_"");
            return str;
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
