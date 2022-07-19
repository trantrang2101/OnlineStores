#pragma checksum "D:\.Net Project\OnlineShop\Project\Views\User\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f752d7ee3d4457fe483822272f089ae71cfd7919"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_List), @"mvc.1.0.view", @"/Views/User/List.cshtml")]
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
#line 1 "D:\.Net Project\OnlineShop\Project\Views\User\List.cshtml"
using Project.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\.Net Project\OnlineShop\Project\Views\User\List.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\.Net Project\OnlineShop\Project\Views\User\List.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f752d7ee3d4457fe483822272f089ae71cfd7919", @"/Views/User/List.cshtml")]
    public class Views_User_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 5 "D:\.Net Project\OnlineShop\Project\Views\User\List.cshtml"
  
Layout = "_LayoutLogin";
ViewBag.Title = "Danh sách người dùng";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""card-body table-responsive"">
    <table class=""table table-striped table-hover table-bordered padding-0"">
        <thead class=""table-primary"">
            <tr>
                <th>Full Name</th>
                <th>Email</th>
                <th>Status</th>
                <th colspan=""2"" class=""text-center"">Action</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 20 "D:\.Net Project\OnlineShop\Project\Views\User\List.cshtml"
             foreach(User user in Model.List)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    <div class=\"d-flex align-items-center\">\r\n                        <div class=\"avatar me-2\"><img class=\"avatar-img img-fluid\"");
            BeginWriteAttribute("src", " src=\"", 815, "\"", 833, 1);
#nullable restore
#line 25 "D:\.Net Project\OnlineShop\Project\Views\User\List.cshtml"
WriteAttributeValue("", 821, user.Avatar, 821, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                        </div>\r\n                        ");
#nullable restore
#line 27 "D:\.Net Project\OnlineShop\Project\Views\User\List.cshtml"
                   Write(user.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </td>\r\n                <td>");
#nullable restore
#line 30 "D:\.Net Project\OnlineShop\Project\Views\User\List.cshtml"
               Write(user.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 31 "D:\.Net Project\OnlineShop\Project\Views\User\List.cshtml"
                Write(user.Gender==true?"Male":"Female");

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td class=\"text-center form-switch\">\r\n                    <a data-bs-toggle=\"modal\"");
            BeginWriteAttribute("href", " href=\"", 1162, "\"", 1191, 2);
            WriteAttributeValue("", 1169, "#updateStatus_", 1169, 14, true);
#nullable restore
#line 33 "D:\.Net Project\OnlineShop\Project\Views\User\List.cshtml"
WriteAttributeValue("", 1183, user.Id, 1183, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <input class=\"form-check-input\" style=\"margin-left:5px;\" name=\"status\" type=\"checkbox\"\r\n                            ");
#nullable restore
#line 35 "D:\.Net Project\OnlineShop\Project\Views\User\List.cshtml"
                        Write(user.IsActive==true?"checked":"");

#line default
#line hidden
#nullable disable
            WriteLiteral(" />\r\n                    </a>\r\n                </td>\r\n                <td class=\"text-center\">\r\n                    <a class=\"btn btn-outline-primary me-2\"");
            BeginWriteAttribute("href", " href=\"", 1525, "\"", 1552, 2);
            WriteAttributeValue("", 1532, "user/detail/", 1532, 12, true);
#nullable restore
#line 39 "D:\.Net Project\OnlineShop\Project\Views\User\List.cshtml"
WriteAttributeValue("", 1544, user.Id, 1544, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i data-feather=\"edit\"></i></a>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 42 "D:\.Net Project\OnlineShop\Project\Views\User\List.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
#nullable restore
#line 45 "D:\.Net Project\OnlineShop\Project\Views\User\List.cshtml"
     foreach(User user in Model.List)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"modal fade\"");
            BeginWriteAttribute("id", " id=\"", 1765, "\"", 1791, 2);
            WriteAttributeValue("", 1770, "updateStatus_", 1770, 13, true);
#nullable restore
#line 47 "D:\.Net Project\OnlineShop\Project\Views\User\List.cshtml"
WriteAttributeValue("", 1783, user.Id, 1783, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" tabindex=\"-1\"");
            BeginWriteAttribute("aria-labelledby", " aria-labelledby=\"", 1806, "\"", 1845, 2);
            WriteAttributeValue("", 1824, "updateStatus_", 1824, 13, true);
#nullable restore
#line 47 "D:\.Net Project\OnlineShop\Project\Views\User\List.cshtml"
WriteAttributeValue("", 1837, user.Id, 1837, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@"
                aria-hidden=""true"">
                <div class=""modal-dialog"">
                    <div class=""modal-content"">
                        <div class=""modal-header"">
                            <h5 class=""modal-title"" id=""exampleModalLabel"">
                                ");
#nullable restore
#line 53 "D:\.Net Project\OnlineShop\Project\Views\User\List.cshtml"
                            Write(user.IsActive==true?"Deactive":"Active");

#line default
#line hidden
#nullable disable
            WriteLiteral(" user\r\n                                ");
#nullable restore
#line 54 "D:\.Net Project\OnlineShop\Project\Views\User\List.cshtml"
                           Write(user.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h5>
                            <button type=""button"" class=""btn-close"" data-bs-dismiss=""modal"" aria-label=""Close""></button>
                        </div>
                        <div class=""modal-body"">
                            Select ""Change"" below if you are ready to
                            ");
#nullable restore
#line 59 "D:\.Net Project\OnlineShop\Project\Views\User\List.cshtml"
                        Write(user.IsActive==true?"deactive":"active");

#line default
#line hidden
#nullable disable
            WriteLiteral(" this user\r\n                            ");
#nullable restore
#line 60 "D:\.Net Project\OnlineShop\Project\Views\User\List.cshtml"
                       Write(user.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@".
                        </div>
                        <div class=""modal-footer"">
                            <button type=""button"" class=""btn btn-light"" data-bs-dismiss=""modal"">Close</button>
                            <a href=""user?service=changeStatus&id=${userChoose.getUser_id()}&status=${userChoose.isStatus()}""
                                class=""btn btn-primary"">Change</a>
                        </div>
                    </div>
                </div>
            </div>
");
#nullable restore
#line 70 "D:\.Net Project\OnlineShop\Project\Views\User\List.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
