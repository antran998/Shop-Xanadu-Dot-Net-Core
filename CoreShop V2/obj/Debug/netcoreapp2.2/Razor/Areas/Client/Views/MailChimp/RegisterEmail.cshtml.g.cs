#pragma checksum "C:\Users\Admin\source\repos\CoreShop V2\CoreShop V2\Areas\Client\Views\MailChimp\RegisterEmail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7c1d1f5be466e69119573a37fcc93bcba4139446"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Client_Views_MailChimp_RegisterEmail), @"mvc.1.0.view", @"/Areas/Client/Views/MailChimp/RegisterEmail.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Client/Views/MailChimp/RegisterEmail.cshtml", typeof(AspNetCore.Areas_Client_Views_MailChimp_RegisterEmail))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7c1d1f5be466e69119573a37fcc93bcba4139446", @"/Areas/Client/Views/MailChimp/RegisterEmail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ebd3fa5b4346cb47b380285bd6cc8d9cf21950cc", @"/Areas/Client/Views/_ViewImports.cshtml")]
    public class Areas_Client_Views_MailChimp_RegisterEmail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("https://facebook.us5.list-manage.com/subscribe/post?u=d165a90e8028fd239e0349abc&amp;id=206aea1391"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("mc-embedded-subscribe-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString("mc-embedded-subscribe-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("validate"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("target", new global::Microsoft.AspNetCore.Html.HtmlString("_blank"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 540, true);
            WriteLiteral(@"<!-- Begin Mailchimp Signup Form -->
<link href=""//cdn-images.mailchimp.com/embedcode/classic-10_7.css"" rel=""stylesheet"" type=""text/css"">
<style type=""text/css"">
    #mc_embed_signup {
        background: #fff;
        clear: left;
        font: 14px Helvetica,Arial,sans-serif;
    }
    /* Add your own Mailchimp form style overrides in your site stylesheet or in this style block.
            We recommend moving this block and the preceding CSS link to the HEAD of your HTML file. */
</style>
<div id=""mc_embed_signup"">
    ");
            EndContext();
            BeginContext(540, 2967, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7c1d1f5be466e69119573a37fcc93bcba41394466765", async() => {
                BeginContext(777, 2723, true);
                WriteLiteral(@"
        <div id=""mc_embed_signup_scroll"">
            <h2>Subscribe</h2>
            <div class=""indicates-required""><span class=""asterisk"">*</span> indicates required</div>
            <div class=""mc-field-group"">
                <label for=""mce-EMAIL"">
                    Email Address  <span class=""asterisk"">*</span>
                </label>
                <input type=""email"" value="""" name=""EMAIL"" class=""required email"" id=""mce-EMAIL"">
            </div>
            <div class=""mc-field-group"">
                <label for=""mce-FNAME"">First Name </label>
                <input type=""text"" value="""" name=""FNAME"" class="""" id=""mce-FNAME"">
            </div>
            <div class=""mc-field-group"">
                <label for=""mce-LNAME"">Last Name </label>
                <input type=""text"" value="""" name=""LNAME"" class="""" id=""mce-LNAME"">
            </div>
            <div class=""mc-field-group size1of2"">
                <label for=""mce-BIRTHDAY-month"">Birthday </label>
                <div cl");
                WriteLiteral(@"ass=""datefield"">
                    <span class=""subfield monthfield""><input class=""birthday "" type=""text"" pattern=""[0-9]*"" value="""" placeholder=""MM"" size=""2"" maxlength=""2"" name=""BIRTHDAY[month]"" id=""mce-BIRTHDAY-month""></span> /
                    <span class=""subfield dayfield""><input class=""birthday "" type=""text"" pattern=""[0-9]*"" value="""" placeholder=""DD"" size=""2"" maxlength=""2"" name=""BIRTHDAY[day]"" id=""mce-BIRTHDAY-day""></span>
                    <span class=""small-meta nowrap"">( mm / dd )</span>
                </div>
            </div><div class=""mc-field-group input-group"">
                <strong>Email Format </strong>
                <ul>
                    <li><input type=""radio"" value=""html"" name=""EMAILTYPE"" id=""mce-EMAILTYPE-0""><label for=""mce-EMAILTYPE-0"">html</label></li>
                    <li><input type=""radio"" value=""text"" name=""EMAILTYPE"" id=""mce-EMAILTYPE-1""><label for=""mce-EMAILTYPE-1"">text</label></li>
                </ul>
            </div>
            <div id=""mce-resp");
                WriteLiteral(@"onses"" class=""clear"">
                <div class=""response"" id=""mce-error-response"" style=""display:none""></div>
                <div class=""response"" id=""mce-success-response"" style=""display:none""></div>
            </div>    <!-- real people should not fill this in and expect good things - do not remove this or risk form bot signups-->
            <div style=""position: absolute; left: -5000px;"" aria-hidden=""true""><input type=""text"" name=""b_d165a90e8028fd239e0349abc_206aea1391"" tabindex=""-1"" value=""""></div>
            <div class=""clear""><input type=""submit"" value=""Subscribe"" name=""subscribe"" id=""mc-embedded-subscribe"" class=""button""></div>
        </div>
    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("novalidate", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3507, 570, true);
            WriteLiteral(@"
</div>
<script type='text/javascript' src='//s3.amazonaws.com/downloads.mailchimp.com/js/mc-validate.js'></script>
<script type='text/javascript'>(function ($) { window.fnames = new Array(); window.ftypes = new Array(); fnames[0] = 'EMAIL'; ftypes[0] = 'email'; fnames[1] = 'FNAME'; ftypes[1] = 'text'; fnames[2] = 'LNAME'; ftypes[2] = 'text'; fnames[3] = 'ADDRESS'; ftypes[3] = 'address'; fnames[4] = 'PHONE'; ftypes[4] = 'phone'; fnames[5] = 'BIRTHDAY'; ftypes[5] = 'birthday'; }(jQuery)); var $mcj = jQuery.noConflict(true);</script>
<!--End mc_embed_signup-->
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591