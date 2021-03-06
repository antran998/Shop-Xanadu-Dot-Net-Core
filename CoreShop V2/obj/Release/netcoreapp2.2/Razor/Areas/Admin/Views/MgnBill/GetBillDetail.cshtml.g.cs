#pragma checksum "C:\Users\Admin\source\repos\CoreShop V2\CoreShop V2\Areas\Admin\Views\MgnBill\GetBillDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1f48bc54c54f744ce10d9093f9b57197f3987713"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_MgnBill_GetBillDetail), @"mvc.1.0.view", @"/Areas/Admin/Views/MgnBill/GetBillDetail.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/MgnBill/GetBillDetail.cshtml", typeof(AspNetCore.Areas_Admin_Views_MgnBill_GetBillDetail))]
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
#line 1 "C:\Users\Admin\source\repos\CoreShop V2\CoreShop V2\Areas\Admin\Views\_ViewImports.cshtml"
using CoreShop_V2;

#line default
#line hidden
#line 2 "C:\Users\Admin\source\repos\CoreShop V2\CoreShop V2\Areas\Admin\Views\_ViewImports.cshtml"
using CoreShop_V2.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1f48bc54c54f744ce10d9093f9b57197f3987713", @"/Areas/Admin/Views/MgnBill/GetBillDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"be368f68ea0450b0cf0fa72b1c4abedb6d412583", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_MgnBill_GetBillDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CoreShop_V2.Areas.Admin.ViewModel.BillMgnViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(59, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Admin\source\repos\CoreShop V2\CoreShop V2\Areas\Admin\Views\MgnBill\GetBillDetail.cshtml"
  
    ViewData["Title"] = "GetBillDetail";

#line default
#line hidden
            BeginContext(110, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(124, 251, true);
            WriteLiteral("<div id=\"invoice-POS\">\r\n    <center id=\"top\">\r\n        <div class=\"logo\"></div>\r\n    </center><!--End InvoiceTop-->\r\n\r\n    <div id=\"mid\">\r\n        <div class=\"info\">\r\n            <h2>Receipt Info</h2>\r\n            <p>\r\n                Purchase Time : ");
            EndContext();
            BeginContext(376, 16, false);
#line 17 "C:\Users\Admin\source\repos\CoreShop V2\CoreShop V2\Areas\Admin\Views\MgnBill\GetBillDetail.cshtml"
                           Write(Model.CreateDate);

#line default
#line hidden
            EndContext();
            BeginContext(392, 79, true);
            WriteLiteral("<br>\r\n                Purchase By : Paypal<br>\r\n                CustomerEmail: ");
            EndContext();
            BeginContext(472, 19, false);
#line 19 "C:\Users\Admin\source\repos\CoreShop V2\CoreShop V2\Areas\Admin\Views\MgnBill\GetBillDetail.cshtml"
                          Write(Model.CustomerEmail);

#line default
#line hidden
            EndContext();
            BeginContext(491, 390, true);
            WriteLiteral(@"
            </p>
        </div>
    </div><!--End Invoice Mid-->

    <div id=""bot"">

        <div id=""table"">
            <table>

                <tr class=""tabletitle"">
                    <td class=""item""><h2>Item</h2></td>
                    <td class=""Hours""><h2>Quantity</h2></td>
                    <td class=""Rate""><h2>Sub Total</h2></td>
                </tr>

");
            EndContext();
#line 35 "C:\Users\Admin\source\repos\CoreShop V2\CoreShop V2\Areas\Admin\Views\MgnBill\GetBillDetail.cshtml"
                 foreach (var item in Model.BillDetails)
                {
                    var subTotal = item.TotalPrice;

#line default
#line hidden
            BeginContext(1011, 108, true);
            WriteLiteral("                    <tr class=\"service\">\r\n                        <td class=\"tableitem\"><p class=\"itemtext\">");
            EndContext();
            BeginContext(1120, 16, false);
#line 39 "C:\Users\Admin\source\repos\CoreShop V2\CoreShop V2\Areas\Admin\Views\MgnBill\GetBillDetail.cshtml"
                                                             Write(item.ProductName);

#line default
#line hidden
            EndContext();
            BeginContext(1136, 77, true);
            WriteLiteral("</p></td>\r\n                        <td class=\"tableitem\"><p class=\"itemtext\">");
            EndContext();
            BeginContext(1214, 13, false);
#line 40 "C:\Users\Admin\source\repos\CoreShop V2\CoreShop V2\Areas\Admin\Views\MgnBill\GetBillDetail.cshtml"
                                                             Write(item.Quantity);

#line default
#line hidden
            EndContext();
            BeginContext(1227, 77, true);
            WriteLiteral("</p></td>\r\n                        <td class=\"tableitem\"><p class=\"itemtext\">");
            EndContext();
            BeginContext(1305, 8, false);
#line 41 "C:\Users\Admin\source\repos\CoreShop V2\CoreShop V2\Areas\Admin\Views\MgnBill\GetBillDetail.cshtml"
                                                             Write(subTotal);

#line default
#line hidden
            EndContext();
            BeginContext(1313, 40, true);
            WriteLiteral(" $</p></td>\r\n                    </tr>\r\n");
            EndContext();
#line 43 "C:\Users\Admin\source\repos\CoreShop V2\CoreShop V2\Areas\Admin\Views\MgnBill\GetBillDetail.cshtml"
                }

#line default
#line hidden
            BeginContext(1372, 392, true);
            WriteLiteral(@"
                <tr class=""tabletitle"">
                    <td class=""Rate""><h2>Shipping</h2></td>
                    <td></td>
                    <td class=""payment""><h2>2$</h2></td>
                </tr>

                <tr class=""tabletitle"">
                    <td class=""Rate""><h2>Total</h2></td>
                    <td></td>
                    <td class=""payment""><h2>");
            EndContext();
            BeginContext(1765, 44, false);
#line 54 "C:\Users\Admin\source\repos\CoreShop V2\CoreShop V2\Areas\Admin\Views\MgnBill\GetBillDetail.cshtml"
                                       Write(Model.BillDetails.Sum(x => x.TotalPrice + 2));

#line default
#line hidden
            EndContext();
            BeginContext(1809, 151, true);
            WriteLiteral("$</h2></td>\r\n                </tr>\r\n\r\n            </table>\r\n        </div><!--End Table-->\r\n    </div><!--End InvoiceBot-->\r\n</div><!--End Invoice-->\r\n");
            EndContext();
            BeginContext(1972, 2, true);
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CoreShop_V2.Areas.Admin.ViewModel.BillMgnViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
