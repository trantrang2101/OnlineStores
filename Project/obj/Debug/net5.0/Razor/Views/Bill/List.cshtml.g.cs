#pragma checksum "D:\FPT_SE\PRN211\OnlineStores\Project\Views\Bill\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1f7ab4804e60dd2555e93528ac3220e3126fb9c5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Bill_List), @"mvc.1.0.view", @"/Views/Bill/List.cshtml")]
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
#nullable restore
#line 1 "D:\FPT_SE\PRN211\OnlineStores\Project\Views\Bill\List.cshtml"
using Project.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\FPT_SE\PRN211\OnlineStores\Project\Views\Bill\List.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\FPT_SE\PRN211\OnlineStores\Project\Views\Bill\List.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1f7ab4804e60dd2555e93528ac3220e3126fb9c5", @"/Views/Bill/List.cshtml")]
    #nullable restore
    public class Views_Bill_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 5 "D:\FPT_SE\PRN211\OnlineStores\Project\Views\Bill\List.cshtml"
  
Layout = "_LayoutLogin";
ViewBag.Title = "Danh sách hóa đơn";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"accordion w-100\" id=\"basicAccordion\">\r\n");
#nullable restore
#line 10 "D:\FPT_SE\PRN211\OnlineStores\Project\Views\Bill\List.cshtml"
     foreach (Bill bill in Model.List)
   {

#line default
#line hidden
#nullable disable
            WriteLiteral("       <div class=\"accordion-item\">\r\n           <h2 class=\"accordion-header\"");
            BeginWriteAttribute("id", " id=\"", 341, "\"", 363, 3);
            WriteAttributeValue("", 346, "heading(", 346, 8, true);
#nullable restore
#line 13 "D:\FPT_SE\PRN211\OnlineStores\Project\Views\Bill\List.cshtml"
WriteAttributeValue("", 354, bill.Id, 354, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 362, ")", 362, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                <button class=\"accordion-button collapsed d-flex justify-content-between align-items-center\" type=\"button\" data-mdb-toggle=\"collapse\" data-mdb-target=\"#basicAccordionBill");
#nullable restore
#line 14 "D:\FPT_SE\PRN211\OnlineStores\Project\Views\Bill\List.cshtml"
                                                                                                                                                                                      Write(bill.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" aria-expanded=\"false\" aria-controls=\"collapseOne\">\r\n                    <h3>");
#nullable restore
#line 15 "D:\FPT_SE\PRN211\OnlineStores\Project\Views\Bill\List.cshtml"
                   Write(bill.Restaurant.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                    <div class=\"d-flex flex-column justify-content-between align-items-center\">\r\n                        <h6>");
#nullable restore
#line 17 "D:\FPT_SE\PRN211\OnlineStores\Project\Views\Bill\List.cshtml"
                       Write(bill.CreatedAt.ToString("MMM dd, yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n                    </div>\r\n                </button>\r\n           </h2>\r\n           <div");
            BeginWriteAttribute("id", " id=\"", 929, "\"", 962, 2);
            WriteAttributeValue("", 934, "basicAccordionBill", 934, 18, true);
#nullable restore
#line 21 "D:\FPT_SE\PRN211\OnlineStores\Project\Views\Bill\List.cshtml"
WriteAttributeValue("", 952, bill.Id, 952, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"accordion-collapse collapse\"");
            BeginWriteAttribute("aria-labelledby", " aria-labelledby=\"", 999, "\"", 1034, 3);
            WriteAttributeValue("", 1017, "heading(", 1017, 8, true);
#nullable restore
#line 21 "D:\FPT_SE\PRN211\OnlineStores\Project\Views\Bill\List.cshtml"
WriteAttributeValue("", 1025, bill.Id, 1025, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1033, ")", 1033, 1, true);
            EndWriteAttribute();
            WriteLiteral(" data-mdb-parent=\"#basicAccordion\"");
            BeginWriteAttribute("style", " style=\"", 1069, "\"", 1077, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                <div class=\"accordion-body\">\r\n\r\n                </div>\r\n           </div>\r\n       </div>\n");
#nullable restore
#line 27 "D:\FPT_SE\PRN211\OnlineStores\Project\Views\Bill\List.cshtml"
   }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591