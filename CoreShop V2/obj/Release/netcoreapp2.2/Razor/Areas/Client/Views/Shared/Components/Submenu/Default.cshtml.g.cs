#pragma checksum "C:\Users\Admin\source\repos\CoreShop V2\CoreShop V2\Areas\Client\Views\Shared\Components\Submenu\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d7ab09b768471415b83ce065df24750f89047724"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Client_Views_Shared_Components_Submenu_Default), @"mvc.1.0.view", @"/Areas/Client/Views/Shared/Components/Submenu/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Client/Views/Shared/Components/Submenu/Default.cshtml", typeof(AspNetCore.Areas_Client_Views_Shared_Components_Submenu_Default))]
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
#line 1 "C:\Users\Admin\source\repos\CoreShop V2\CoreShop V2\Areas\Client\Views\_ViewImports.cshtml"
using CoreShop_V2;

#line default
#line hidden
#line 2 "C:\Users\Admin\source\repos\CoreShop V2\CoreShop V2\Areas\Client\Views\_ViewImports.cshtml"
using CoreShop_V2.Models;

#line default
#line hidden
#line 3 "C:\Users\Admin\source\repos\CoreShop V2\CoreShop V2\Areas\Client\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 4 "C:\Users\Admin\source\repos\CoreShop V2\CoreShop V2\Areas\Client\Views\_ViewImports.cshtml"
using CoreShop_V2.Areas.Admin.Models;

#line default
#line hidden
#line 5 "C:\Users\Admin\source\repos\CoreShop V2\CoreShop V2\Areas\Client\Views\_ViewImports.cshtml"
using FinalProjectASPDotnet.Areas.Admin.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d7ab09b768471415b83ce065df24750f89047724", @"/Areas/Client/Views/Shared/Components/Submenu/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ebd3fa5b4346cb47b380285bd6cc8d9cf21950cc", @"/Areas/Client/Views/_ViewImports.cshtml")]
    public class Areas_Client_Views_Shared_Components_Submenu_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Category>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "products", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Products", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Products"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(30, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Admin\source\repos\CoreShop V2\CoreShop V2\Areas\Client\Views\Shared\Components\Submenu\Default.cshtml"
  
    ViewData["Title"] = "SubMenu";

#line default
#line hidden
            BeginContext(75, 50, true);
            WriteLiteral("\r\n<li class=\"level1 dropdown hassub images\">\r\n    ");
            EndContext();
            BeginContext(125, 80, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d7ab09b768471415b83ce065df24750f890477245458", async() => {
                BeginContext(193, 8, true);
                WriteLiteral("Products");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(205, 183, true);
            WriteLiteral("\r\n    <i class=\"fa fa-plus\"></i>\r\n    <div class=\"sub-menu sub-menu-v2 dropdown-menu\" style=\"display: none;\">\r\n        <ul class=\"menu-level-1 dropdown-menu\" style=\"display: none;\">\r\n");
            EndContext();
#line 12 "C:\Users\Admin\source\repos\CoreShop V2\CoreShop V2\Areas\Client\Views\Shared\Components\Submenu\Default.cshtml"
             foreach (var type in Model)
            {
                int i =0;

#line default
#line hidden
            BeginContext(472, 64, true);
            WriteLiteral("                <li class=\"level2 hassub\">\r\n                    ");
            EndContext();
            BeginContext(536, 72, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d7ab09b768471415b83ce065df24750f890477247724", async() => {
                BeginContext(587, 17, false);
#line 16 "C:\Users\Admin\source\repos\CoreShop V2\CoreShop V2\Areas\Client\Views\Shared\Components\Submenu\Default.cshtml"
                                                                 Write(type.CategoryName);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 545, "~/products?sortOrder=", 545, 21, true);
#line 16 "C:\Users\Admin\source\repos\CoreShop V2\CoreShop V2\Areas\Client\Views\Shared\Components\Submenu\Default.cshtml"
AddHtmlAttributeValue("", 566, type.CategoryName, 566, 18, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(608, 75, true);
            WriteLiteral("<i class=\"fa fa-plus\"></i>\r\n                    <ul class=\"menu-level-2\">\r\n");
            EndContext();
#line 18 "C:\Users\Admin\source\repos\CoreShop V2\CoreShop V2\Areas\Client\Views\Shared\Components\Submenu\Default.cshtml"
                         foreach (var item in type.product)
                        {                            

#line default
#line hidden
            BeginContext(799, 47, true);
            WriteLiteral("                            <li class=\"level3\">");
            EndContext();
            BeginContext(846, 110, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d7ab09b768471415b83ce065df24750f8904772410182", async() => {
                BeginContext(936, 16, false);
#line 20 "C:\Users\Admin\source\repos\CoreShop V2\CoreShop V2\Areas\Client\Views\Shared\Components\Submenu\Default.cshtml"
                                                                                                                                   Write(item.ProductName);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 4, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 855, "~/product/", 855, 10, true);
#line 20 "C:\Users\Admin\source\repos\CoreShop V2\CoreShop V2\Areas\Client\Views\Shared\Components\Submenu\Default.cshtml"
AddHtmlAttributeValue("", 865, item.CategoryNameSeo, 865, 21, false);

#line default
#line hidden
            AddHtmlAttributeValue("", 886, "/", 886, 1, true);
#line 20 "C:\Users\Admin\source\repos\CoreShop V2\CoreShop V2\Areas\Client\Views\Shared\Components\Submenu\Default.cshtml"
AddHtmlAttributeValue("", 887, item.ProductNameSeo, 887, 20, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "title", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 20 "C:\Users\Admin\source\repos\CoreShop V2\CoreShop V2\Areas\Client\Views\Shared\Components\Submenu\Default.cshtml"
AddHtmlAttributeValue("", 916, item.ProductName, 916, 17, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(956, 33, true);
            WriteLiteral("<i class=\"fa fa-plus\"></i></li>\r\n");
            EndContext();
#line 21 "C:\Users\Admin\source\repos\CoreShop V2\CoreShop V2\Areas\Client\Views\Shared\Components\Submenu\Default.cshtml"
                            i++;
                            if (i == 4) { break; }
                        }                        

#line default
#line hidden
            BeginContext(1126, 50, true);
            WriteLiteral("                    </ul>\r\n                </li>\r\n");
            EndContext();
#line 26 "C:\Users\Admin\source\repos\CoreShop V2\CoreShop V2\Areas\Client\Views\Shared\Components\Submenu\Default.cshtml"
            }            

#line default
#line hidden
            BeginContext(1203, 322, true);
            WriteLiteral(@"        </ul>
        <div class=""right-submenu"">
            <a href=""#"" title=""images"" class=""images""><img class=""img-responsive"" src=""assets/images/right-submenu.jpg"" alt=""Sub-Menu""></a><i class=""fa fa-plus""></i>
        </div>
        <!-- End RightSubMenu -->
    </div>
    <!-- End Dropdow Menu -->
</li>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Category>> Html { get; private set; }
    }
}
#pragma warning restore 1591
