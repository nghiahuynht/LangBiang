#pragma checksum "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\Shared\_Layout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3a85b1515ca9692a2c386a0ea7a32d49d7834a6a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Layout), @"mvc.1.0.view", @"/Views/Shared/_Layout.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_Layout.cshtml", typeof(AspNetCore.Views_Shared__Layout))]
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
#line 1 "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\Shared\_Layout.cshtml"
using System.Security.Claims;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3a85b1515ca9692a2c386a0ea7a32d49d7834a6a", @"/Views/Shared/_Layout.cshtml")]
    public class Views_Shared__Layout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/fontawesome-free/css/all.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/bootstrap.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/adminlte.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/jquery/jquery.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/bootstrap/js/bootstrap.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/adminlte.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/bootbox/bootbox.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/bootstrap3-typehead/bootstrap3-typeahead.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/app-script/helper.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("hold-transition sidebar-mini text-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(31, 25, true);
            WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n");
            EndContext();
            BeginContext(56, 1364, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3a85b1515ca9692a2c386a0ea7a32d49d7834a6a7257", async() => {
                BeginContext(62, 223, true);
                WriteLiteral("\r\n    <meta name=\"zalo-platform-site-verification\" content=\"K8Ey6vAkQI1kdCm7dxLCMLI5cr-uyqa3CZap\" />\r\n    <meta charset=\"utf-8\" />\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" />\r\n\r\n    <title>");
                EndContext();
                BeginContext(286, 17, false);
#line 9 "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\Shared\_Layout.cshtml"
      Write(ViewData["Title"]);

#line default
#line hidden
                EndContext();
                BeginContext(303, 171, true);
                WriteLiteral("</title>\r\n\r\n    <link rel=\"stylesheet\" href=\"https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback\">\r\n    <!-- Font Awesome -->\r\n\r\n    ");
                EndContext();
                BeginContext(474, 71, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3a85b1515ca9692a2c386a0ea7a32d49d7834a6a8410", async() => {
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
                BeginContext(545, 137, true);
                WriteLiteral("\r\n    <!-- Ionicons -->\r\n    <link rel=\"stylesheet\" href=\"https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css\">\r\n\r\n\r\n    ");
                EndContext();
                BeginContext(682, 52, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3a85b1515ca9692a2c386a0ea7a32d49d7834a6a9887", async() => {
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
                BeginContext(734, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(740, 51, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3a85b1515ca9692a2c386a0ea7a32d49d7834a6a11219", async() => {
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
                BeginContext(791, 577, true);
                WriteLiteral(@"
    <style>
        .child-icon {
            font-size: 10pt !important;
            margin-left: 10px;
        }
        #popup-overlay {
            position: fixed;
            background-color: rgba(0, 0, 0, 0.685);
            width: 100%;
            height: 95vh;
            top: 0;
            left: 0;
            z-index: 9998;
            display: block;
            overflow-y: hidden;
            overflow-x: hidden;
            display: none;
        }

        #content-wating {
            margin-top: 20%;
        }
    </style>
    ");
                EndContext();
                BeginContext(1369, 40, false);
#line 44 "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\Shared\_Layout.cshtml"
Write(RenderSection("styles", required: false));

#line default
#line hidden
                EndContext();
                BeginContext(1409, 4, true);
                WriteLiteral("\r\n\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1420, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(1422, 5245, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3a85b1515ca9692a2c386a0ea7a32d49d7834a6a14300", async() => {
                BeginContext(1473, 684, true);
                WriteLiteral(@"
    <div class=""wrapper"">
        <!-- Navbar -->
        <nav class=""main-header navbar navbar-expand navbar-dark navbar-lightblue"">
            <!-- Left navbar links -->
            <ul class=""navbar-nav"">
                <li class=""nav-item"">
                    <a class=""nav-link"" data-widget=""pushmenu"" href=""#"" role=""button""><i class=""fas fa-bars""></i></a>
                </li>
                <li class=""nav-item d-none d-sm-inline-block"">
                    <a href=""#"" class=""nav-link"">HỆ THỐNG BÁN VÉ KHU DU LỊCH LANG BIANG</a>
                </li>
            </ul>

            <!-- Right navbar links -->
            <ul class=""navbar-nav ml-auto"">
");
                EndContext();
#line 63 "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\Shared\_Layout.cshtml"
                  
                    string userName = string.Empty;
                    string fullName = string.Empty;
                    string role = string.Empty;
                    if (User.Identity.IsAuthenticated)
                    {
                        userName = User.Identity.Name;
                        fullName = User.Claims.FirstOrDefault(x => x.Type == "FullName").Value;
                        role = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value;
                    }
                

#line default
#line hidden
                BeginContext(2704, 239, true);
                WriteLiteral("                <!-- Notifications Dropdown Menu -->\r\n                <li class=\"nav-item dropdown\">\r\n                    <a class=\"nav-link\" data-toggle=\"dropdown\" href=\"#\">\r\n                        <i class=\"far fa-user\"></i>&nbsp;<span>");
                EndContext();
                BeginContext(2945, 8, false);
#line 77 "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\Shared\_Layout.cshtml"
                                                           Write(userName);

#line default
#line hidden
                EndContext();
                BeginContext(2954, 306, true);
                WriteLiteral(@"</span>
                    </a>
                    <div class=""dropdown-menu dropdown-menu-lg dropdown-menu-right"">

                        <div class=""dropdown-divider""></div>
                        <a href=""#"" class=""dropdown-item"">
                            <i class=""fas fa-user mr-2""></i> ");
                EndContext();
                BeginContext(3262, 8, false);
#line 83 "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\Shared\_Layout.cshtml"
                                                         Write(fullName);

#line default
#line hidden
                EndContext();
                BeginContext(3271, 215, true);
                WriteLiteral("\r\n                        </a>\r\n                        <div class=\"dropdown-divider\"></div>\r\n                        <a href=\"#\" class=\"dropdown-item\">\r\n                            <i class=\"fas fa-bolt mr-2\"></i> ");
                EndContext();
                BeginContext(3488, 4, false);
#line 87 "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\Shared\_Layout.cshtml"
                                                         Write(role);

#line default
#line hidden
                EndContext();
                BeginContext(3493, 832, true);
                WriteLiteral(@"
                        </a>
                        <div class=""dropdown-divider""></div>
                        <a href=""/Account/Logout"" class=""dropdown-item"">
                            <i class=""fas fa-power-off mr-2""></i> Thoát hệ thống
                        </a>

                    </div>
                </li>


            </ul>
        </nav>
        <!-- /.navbar -->
        <!-- Main Sidebar Container -->
        <aside class=""main-sidebar sidebar-dark-primary elevation-4"">
            <!-- Brand Logo -->
            <a href=""/"" class=""brand-link navbar-lightblue"">
                <span style=""font-weight:bold;"">Lang Biang</span>
            </a>
            <!-- Sidebar -->
            <div class=""sidebar "">
                <!-- Sidebar Menu -->
                <nav class=""mt-2"">
");
                EndContext();
#line 111 "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\Shared\_Layout.cshtml"
                      
                        if (User.Identity.IsAuthenticated)
                        {
                            string roleCode = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value;
                            

#line default
#line hidden
                BeginContext(4579, 84, false);
#line 115 "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\Shared\_Layout.cshtml"
                        Write(await Component.InvokeAsync("ListMenuNavigationByRole", new { roleCode = roleCode }));

#line default
#line hidden
                EndContext();
#line 115 "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\Shared\_Layout.cshtml"
                                                                                                                   
                        }
                    

#line default
#line hidden
                BeginContext(4716, 245, true);
                WriteLiteral("\r\n                </nav>\r\n                <!-- /.sidebar-menu -->\r\n            </div>\r\n            <!-- /.sidebar -->\r\n        </aside>\r\n        <!-- Content Wrapper. Contains page content -->\r\n        <div class=\"content-wrapper\">\r\n            ");
                EndContext();
                BeginContext(4962, 12, false);
#line 126 "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\Shared\_Layout.cshtml"
       Write(RenderBody());

#line default
#line hidden
                EndContext();
                BeginContext(4974, 1180, true);
                WriteLiteral(@"
            <!-- Content Header (Page header) -->
            <!-- /.content -->
        </div>
        <!-- /.content-wrapper -->
        <!-- /.control-sidebar -->
    </div>
    <!-- ./wrapper -->

    <footer class=""main-footer"" style=""padding:0px"">
        <div class=""float-right d-none d-sm-block"" style=""padding:5px"">

            <a style=""color:black"" href=""https://gamansoftware.com"">Hotline: 0977 209 040-Email: info@gamanjsc.com</a>
        </div>
        <div class=""float-left d-none d-sm-block"" style=""padding:5px"">
            <a style=""color:black"" href=""https://gamansoftware.com"">Hệ thống được phát triển và vận hành bởi: Công ty cổ phần GAMAN</a><br />

        </div>

    </footer>
    <!-- Control Sidebar -->
    <aside class=""control-sidebar control-sidebar-dark"">
        <!-- Control sidebar content goes here -->
    </aside>
    <div id=""popup-overlay"">
        <div class=""text-center"" id=""content-wating"">
            <div class=""spinner-border text-warning"" role=""");
                WriteLiteral("status\" style=\"width: 3rem; height: 3rem;\">\r\n                <span class=\"sr-only\">Loading...</span>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n    ");
                EndContext();
                BeginContext(6154, 50, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3a85b1515ca9692a2c386a0ea7a32d49d7834a6a21985", async() => {
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
                BeginContext(6204, 100, true);
                WriteLiteral("\r\n    <script src=\"https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.0.4/popper.js\"></script>\r\n    ");
                EndContext();
                BeginContext(6304, 59, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3a85b1515ca9692a2c386a0ea7a32d49d7834a6a23341", async() => {
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
                BeginContext(6363, 8, true);
                WriteLiteral("\r\n\r\n    ");
                EndContext();
                BeginContext(6371, 40, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3a85b1515ca9692a2c386a0ea7a32d49d7834a6a24601", async() => {
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
                BeginContext(6411, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(6417, 56, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3a85b1515ca9692a2c386a0ea7a32d49d7834a6a25857", async() => {
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
                BeginContext(6473, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(6479, 77, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3a85b1515ca9692a2c386a0ea7a32d49d7834a6a27113", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(6556, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(6562, 46, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3a85b1515ca9692a2c386a0ea7a32d49d7834a6a28369", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(6608, 8, true);
                WriteLiteral("\r\n\r\n    ");
                EndContext();
                BeginContext(6617, 41, false);
#line 167 "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\Shared\_Layout.cshtml"
Write(RenderSection("scripts", required: false));

#line default
#line hidden
                EndContext();
                BeginContext(6658, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(6667, 11, true);
            WriteLiteral("\r\n</html>\r\n");
            EndContext();
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
