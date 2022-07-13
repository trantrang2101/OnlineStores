#pragma checksum "D:\FPT_SE\PRN211\OnlineStores\Project\Views\Bill\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "05bac71140923397ecb369c0e01a167d143099a1"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"05bac71140923397ecb369c0e01a167d143099a1", @"/Views/Bill/List.cshtml")]
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
            WriteLiteral("<div class=\"accordion\" id=\"accordionExample\">\r\n");
#nullable restore
#line 10 "D:\FPT_SE\PRN211\OnlineStores\Project\Views\Bill\List.cshtml"
     foreach (Bill bill in Model.List)
    {
        double price = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"accordion-item\">\r\n            <div class=\"accordion-header\"");
            BeginWriteAttribute("id", " id=\"", 370, "\"", 391, 2);
            WriteAttributeValue("", 375, "heading_", 375, 8, true);
#nullable restore
#line 14 "D:\FPT_SE\PRN211\OnlineStores\Project\Views\Bill\List.cshtml"
WriteAttributeValue("", 383, bill.Id, 383, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                <button class=\"accordion-button\" type=\"button\" data-bs-toggle=\"collapse\" data-bs-target=\"#collapse_");
#nullable restore
#line 15 "D:\FPT_SE\PRN211\OnlineStores\Project\Views\Bill\List.cshtml"
                                                                                                              Write(bill.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" aria-expanded=\"true\"");
            BeginWriteAttribute("aria-controls", " aria-controls=\"", 540, "\"", 573, 2);
            WriteAttributeValue("", 556, "collapse_", 556, 9, true);
#nullable restore
#line 15 "D:\FPT_SE\PRN211\OnlineStores\Project\Views\Bill\List.cshtml"
WriteAttributeValue("", 565, bill.Id, 565, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <div class=\"d-flex flex-column\">\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 657, "\"", 686, 2);
            WriteAttributeValue("", 664, "/Bill/Invoice/", 664, 14, true);
#nullable restore
#line 17 "D:\FPT_SE\PRN211\OnlineStores\Project\Views\Bill\List.cshtml"
WriteAttributeValue("", 678, bill.Id, 678, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><h5>Invoice #");
#nullable restore
#line 17 "D:\FPT_SE\PRN211\OnlineStores\Project\Views\Bill\List.cshtml"
                                                                 Write(bill.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5></a>\r\n                        <span class=\"text-muted\">");
#nullable restore
#line 18 "D:\FPT_SE\PRN211\OnlineStores\Project\Views\Bill\List.cshtml"
                                            Write(bill.Restaurant().Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 18 "D:\FPT_SE\PRN211\OnlineStores\Project\Views\Bill\List.cshtml"
                                                                       Write(bill.IsTakeAway==true?"Take Away":"Ship");

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                    </div>\r\n                </button>\r\n            </div>\r\n            <div");
            BeginWriteAttribute("id", " id=\"", 938, "\"", 960, 2);
            WriteAttributeValue("", 943, "collapse_", 943, 9, true);
#nullable restore
#line 22 "D:\FPT_SE\PRN211\OnlineStores\Project\Views\Bill\List.cshtml"
WriteAttributeValue("", 952, bill.Id, 952, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"accordion-collapse collapse show\"");
            BeginWriteAttribute("aria-labelledby", " aria-labelledby=\"", 1002, "\"", 1036, 2);
            WriteAttributeValue("", 1020, "heading_", 1020, 8, true);
#nullable restore
#line 22 "D:\FPT_SE\PRN211\OnlineStores\Project\Views\Bill\List.cshtml"
WriteAttributeValue("", 1028, bill.Id, 1028, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-bs-parent=\"#accordionExample\">\r\n                <div class=\"accordion-body\">\r\n");
#nullable restore
#line 24 "D:\FPT_SE\PRN211\OnlineStores\Project\Views\Bill\List.cshtml"
                     foreach (BillDetail billDetail in bill.BillDetails())
                    {
                        price += billDetail.Price * billDetail.Quantity;

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <hr>\r\n                        <div class=\"row\">\r\n                            <div class=\"col-xl-6\">\r\n                                <p>");
#nullable restore
#line 30 "D:\FPT_SE\PRN211\OnlineStores\Project\Views\Bill\List.cshtml"
                              Write(billDetail.Product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n                            <div class=\"col-xl-2\">\r\n                              <p class=\"float-end\">x ");
#nullable restore
#line 33 "D:\FPT_SE\PRN211\OnlineStores\Project\Views\Bill\List.cshtml"
                                                Write(billDetail.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n                            <div class=\"col-xl-2\">\r\n                              <p class=\"float-end price\">");
#nullable restore
#line 36 "D:\FPT_SE\PRN211\OnlineStores\Project\Views\Bill\List.cshtml"
                                                    Write(billDetail.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n                            <div class=\"col-xl-2\">\r\n                              <p class=\"float-end price\">");
#nullable restore
#line 39 "D:\FPT_SE\PRN211\OnlineStores\Project\Views\Bill\List.cshtml"
                                                     Write(billDetail.Price*billDetail.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n                        </div>\r\n");
#nullable restore
#line 42 "D:\FPT_SE\PRN211\OnlineStores\Project\Views\Bill\List.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <hr style=\"border: 2px solid black;\">\r\n                    <div class=\"row text-black\">\r\n                        <div class=\"col-xl-12\">\r\n                            <p class=\"float-end fw-bold\">Total: <span class=\"price\">");
#nullable restore
#line 46 "D:\FPT_SE\PRN211\OnlineStores\Project\Views\Bill\List.cshtml"
                                                                               Write(price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></p>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 52 "D:\FPT_SE\PRN211\OnlineStores\Project\Views\Bill\List.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>");
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
