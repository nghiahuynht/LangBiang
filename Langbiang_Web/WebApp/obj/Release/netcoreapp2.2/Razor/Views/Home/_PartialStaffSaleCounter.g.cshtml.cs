#pragma checksum "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\Home\_PartialStaffSaleCounter.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "189cd41969fdbe7d4ceb7980c1d62caf78cdf9f2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home__PartialStaffSaleCounter), @"mvc.1.0.view", @"/Views/Home/_PartialStaffSaleCounter.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/_PartialStaffSaleCounter.cshtml", typeof(AspNetCore.Views_Home__PartialStaffSaleCounter))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"189cd41969fdbe7d4ceb7980c1d62caf78cdf9f2", @"/Views/Home/_PartialStaffSaleCounter.cshtml")]
    public class Views_Home__PartialStaffSaleCounter : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<DAL.Models.Report.StaffSaleCounterModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(54, 43, true);
            WriteLiteral("<table style=\"width:100%;\" class=\"table\">\r\n");
            EndContext();
#line 3 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\Home\_PartialStaffSaleCounter.cshtml"
      
        if (Model.Any())
        {
            foreach (var item in Model)
            {


#line default
#line hidden
            BeginContext(200, 84, true);
            WriteLiteral("                <tr>\r\n                    <td><i class=\"fa fa-user\"></i>&nbsp;&nbsp;");
            EndContext();
            BeginContext(286, 13, false);
#line 10 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\Home\_PartialStaffSaleCounter.cshtml"
                                                          Write(item.FullName);

#line default
#line hidden
            EndContext();
            BeginContext(300, 108, true);
            WriteLiteral("</td>\r\n                    <td style=\"text-align:right;font-size:11pt;\"><label class=\"badge badge-success \">");
            EndContext();
            BeginContext(410, 35, false);
#line 11 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\Home\_PartialStaffSaleCounter.cshtml"
                                                                                                 Write(item.TotalSale.Value.ToString("N0"));

#line default
#line hidden
            EndContext();
            BeginContext(446, 38, true);
            WriteLiteral("</label></td>\r\n                </tr>\r\n");
            EndContext();
#line 13 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\Home\_PartialStaffSaleCounter.cshtml"


            }
        }
        else
        {

#line default
#line hidden
            BeginContext(539, 58, true);
            WriteLiteral("            <tr><td colspan=\"3\">Không tìm thấy</td></tr>\r\n");
            EndContext();
#line 20 "F:\Projects\OnSVN\Lanbiang\Langbiang_Web\WebApp\Views\Home\_PartialStaffSaleCounter.cshtml"
        }
    

#line default
#line hidden
            BeginContext(615, 14, true);
            WriteLiteral("\r\n</table>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<DAL.Models.Report.StaffSaleCounterModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591