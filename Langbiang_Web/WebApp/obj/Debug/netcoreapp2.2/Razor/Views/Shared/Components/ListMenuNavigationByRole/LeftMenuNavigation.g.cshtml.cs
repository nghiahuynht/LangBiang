#pragma checksum "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\Shared\Components\ListMenuNavigationByRole\LeftMenuNavigation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f31eecf046a4353d7ae7985f9dfb5356182031fc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_ListMenuNavigationByRole_LeftMenuNavigation), @"mvc.1.0.view", @"/Views/Shared/Components/ListMenuNavigationByRole/LeftMenuNavigation.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/ListMenuNavigationByRole/LeftMenuNavigation.cshtml", typeof(AspNetCore.Views_Shared_Components_ListMenuNavigationByRole_LeftMenuNavigation))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f31eecf046a4353d7ae7985f9dfb5356182031fc", @"/Views/Shared/Components/ListMenuNavigationByRole/LeftMenuNavigation.cshtml")]
    public class Views_Shared_Components_ListMenuNavigationByRole_LeftMenuNavigation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<DAL.Entities.Menu>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(32, 238, true);
            WriteLiteral("\r\n<ul class=\"nav nav-pills nav-sidebar flex-column\" data-widget=\"treeview\" role=\"menu\" data-accordion=\"false\">\r\n    <!-- Add icons to the links using the .nav-icon class\r\n         with font-awesome or any other icon font library -->\r\n\r\n\r\n");
            EndContext();
#line 8 "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\Shared\Components\ListMenuNavigationByRole\LeftMenuNavigation.cshtml"
      
        if (Model.Any())
        {
            foreach (var menuParent in Model.Where(x => x.Parent == 0).OrderBy(x => x.Priority))
            {
                var lstChild = Model.Where(x => x.Parent == menuParent.Id).OrderBy(x => x.Priority);


#line default
#line hidden
            BeginContext(532, 87, true);
            WriteLiteral("                <li class=\"nav-item menu-is-opening menu-open\">\r\n                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 619, "\"", 643, 1);
#line 16 "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\Shared\Components\ListMenuNavigationByRole\LeftMenuNavigation.cshtml"
WriteAttributeValue("", 626, menuParent.URL, 626, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(644, 46, true);
            WriteLiteral(" class=\"nav-link\">\r\n                        <i");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 690, "\"", 729, 2);
            WriteAttributeValue("", 698, "nav-icon", 698, 8, true);
#line 17 "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\Shared\Components\ListMenuNavigationByRole\LeftMenuNavigation.cshtml"
WriteAttributeValue(" ", 706, menuParent.MenuIcon, 707, 22, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(730, 65, true);
            WriteLiteral("></i> \r\n                        <p>\r\n                            ");
            EndContext();
            BeginContext(797, 15, false);
#line 19 "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\Shared\Components\ListMenuNavigationByRole\LeftMenuNavigation.cshtml"
                        Write(menuParent.Name);

#line default
#line hidden
            EndContext();
            BeginContext(813, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 20 "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\Shared\Components\ListMenuNavigationByRole\LeftMenuNavigation.cshtml"
                              
                                if (lstChild.Any())
                                {

#line default
#line hidden
            BeginContext(935, 77, true);
            WriteLiteral("                                    <i class=\"right fas fa-angle-left\"></i>\r\n");
            EndContext();
#line 24 "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\Shared\Components\ListMenuNavigationByRole\LeftMenuNavigation.cshtml"
                                }
                            

#line default
#line hidden
            BeginContext(1078, 56, true);
            WriteLiteral("                        </p>\r\n                    </a>\r\n");
            EndContext();
#line 28 "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\Shared\Components\ListMenuNavigationByRole\LeftMenuNavigation.cshtml"
                      
                        
                        if (lstChild.Any())
                        {

#line default
#line hidden
            BeginContext(1256, 78, true);
            WriteLiteral("                    <ul class=\"nav nav-treeview \" style=\"display: block;\">\r\n\r\n");
            EndContext();
#line 34 "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\Shared\Components\ListMenuNavigationByRole\LeftMenuNavigation.cshtml"
                          
                            foreach (var menuChild in lstChild)
                            {

#line default
#line hidden
            BeginContext(1458, 55, true);
            WriteLiteral("                                <li class=\"nav-item\"><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1513, "\"", 1536, 1);
#line 37 "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\Shared\Components\ListMenuNavigationByRole\LeftMenuNavigation.cshtml"
WriteAttributeValue("", 1520, menuChild.URL, 1520, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1537, 70, true);
            WriteLiteral(" class=\"nav-link\"><i class=\"far fa-circle nav-icon child-icon\"></i><p>");
            EndContext();
            BeginContext(1609, 14, false);
#line 37 "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\Shared\Components\ListMenuNavigationByRole\LeftMenuNavigation.cshtml"
                                                                                                                                                 Write(menuChild.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1624, 15, true);
            WriteLiteral("</p></a></li>\r\n");
            EndContext();
#line 38 "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\Shared\Components\ListMenuNavigationByRole\LeftMenuNavigation.cshtml"
                            }
                        

#line default
#line hidden
            BeginContext(1697, 29, true);
            WriteLiteral("\r\n                    </ul>\r\n");
            EndContext();
#line 42 "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\Shared\Components\ListMenuNavigationByRole\LeftMenuNavigation.cshtml"
                         }



                    

#line default
#line hidden
            BeginContext(1783, 24, true);
            WriteLiteral("                 </li>\r\n");
            EndContext();
#line 48 "D:\Projects\OnGit\LangBianSytem\Langbiang_Web\WebApp\Views\Shared\Components\ListMenuNavigationByRole\LeftMenuNavigation.cshtml"
            }
         }
    

#line default
#line hidden
            BeginContext(1841, 23, true);
            WriteLiteral("\r\n\r\n\r\n    \r\n\r\n</ul>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<DAL.Entities.Menu>> Html { get; private set; }
    }
}
#pragma warning restore 1591
