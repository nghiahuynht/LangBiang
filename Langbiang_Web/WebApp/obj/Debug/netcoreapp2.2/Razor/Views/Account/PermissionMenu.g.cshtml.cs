#pragma checksum "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\Account\PermissionMenu.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1520ec9f0a5e12f24dfefe06dfb8d9a9d4593ff7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_PermissionMenu), @"mvc.1.0.view", @"/Views/Account/PermissionMenu.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Account/PermissionMenu.cshtml", typeof(AspNetCore.Views_Account_PermissionMenu))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1520ec9f0a5e12f24dfefe06dfb8d9a9d4593ff7", @"/Views/Account/PermissionMenu.cshtml")]
    public class Views_Account_PermissionMenu : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<DAL.Models.ComboBoxModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\Account\PermissionMenu.cshtml"
  
    ViewData["Title"] = "Vai trò quyền hạn";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(141, 157, true);
            WriteLiteral("<section class=\"content-header\">\r\n    <div class=\"container-fluid\">\r\n        <div class=\"row mb-2\">\r\n            <div class=\"col-sm-6\">\r\n                <h1>");
            EndContext();
            BeginContext(300, 17, false);
#line 11 "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\Account\PermissionMenu.cshtml"
                Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(318, 622, true);
            WriteLiteral(@"</h1>
            </div>
            <div class=""col-sm-6"">
                <ol class=""breadcrumb float-sm-right"">
                    <li class=""breadcrumb-item""> <input type=""button"" value=""Lưu"" class=""btn bg-primary"" id=""btn-save"" /></li>
                </ol>
            </div>
        </div>
    </div><!-- /.container-fluid -->
</section>
<section class=""content"">
    <div class=""card"">
        <div class=""card-header"">
            <div class=""row"">
                <div class=""col-sm-2"">
                    <label>Vai trò</label>
                    <select class=""form-control"" id=""ddl-role"">
");
            EndContext();
#line 28 "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\Account\PermissionMenu.cshtml"
                          
                            foreach (var opt in Model)
                            {

#line default
#line hidden
            BeginContext(1055, 39, true);
            WriteLiteral("                                <option");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1094, "\"", 1112, 1);
#line 31 "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\Account\PermissionMenu.cshtml"
WriteAttributeValue("", 1102, opt.Value, 1102, 10, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1113, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1115, 8, false);
#line 31 "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\Account\PermissionMenu.cshtml"
                                                      Write(opt.Text);

#line default
#line hidden
            EndContext();
            BeginContext(1123, 11, true);
            WriteLiteral("</option>\r\n");
            EndContext();
#line 32 "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\Account\PermissionMenu.cshtml"
                            }
                        

#line default
#line hidden
            BeginContext(1192, 198, true);
            WriteLiteral("                    </select>\r\n                </div>\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"card-body\" id=\"div-load-permissiontable\">\r\n\r\n        </div>\r\n    </div>\r\n</section>\r\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(1407, 2118, true);
                WriteLiteral(@"

    <script>
        var arrMenuRole = [];
        $(document).ready(function () {
            LoadPermissionTable();
            $(""#ddl-role"").change(function () {
                LoadPermissionTable();
            });

        });
        function LoadPermissionTable() {
            var roleCode = $(""#ddl-role"").val();
            $(""#div-load-permissiontable"").load(""/account/_PartialLstPermissionMenu?roleCode="" + roleCode);


        }
        //function CheckMenu(thatCheckBox, menuId) {
        //    var roleCode = $(""#ddl-role"").val();
        //    var checkedParent = $(thatCheckBox).is("":checked"");
        //    var objIndex = arrMenuRole.findIndex(x => x.RoleCode === roleCode && x.MenuId === menuId);
        //    if (objIndex === -1)
        //    {
        //        if (checkedParent == true)
        //        {
        //            var objRole = { RoleCode: roleCode, MenuId: menuId };
        //            arrMenuRole.push(objRole);
        //        } 

        // ");
                WriteLiteral(@"   } else {
        //        arrMenuRole = arrMenuRole.filter(x => x.RoleCode === roleCode && x.MenuId !== menuId);
        //    }
        //}
        function UpdatePermissionMenu(menuId) {
            var model = {
                RoleCode: $(""#ddl-role"").val(),
                MenuId: menuId
            };
            $.ajax({
                type: ""POST"",
                contentType: 'application/json; charset=utf-8',
                url: ""/Account/UpdatePermissionMenu"",
                dataType: 'json',
                data: JSON.stringify(model),
                beforeSend: function () {

                },
                success: function (res) {
                    if (res.isSuccess === false)
                    {
                        bootbox.alert(AlertFail(res.errorMessage));
                        //bootbox.alert(AlertSuccess(""Lưu dữ liệu thành công""), function () {
                        //    LoadPermissionTable();
                        //});
                  ");
                WriteLiteral("  } \r\n\r\n                }\r\n            });\r\n        }\r\n    </script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<DAL.Models.ComboBoxModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
