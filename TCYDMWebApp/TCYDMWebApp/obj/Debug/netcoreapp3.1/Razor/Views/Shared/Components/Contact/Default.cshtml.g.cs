#pragma checksum "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Shared\Components\Contact\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "400222a65c4452ed40aaaeab1784f622a839ce00"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Contact_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Contact/Default.cshtml")]
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
#line 1 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\_ViewImports.cshtml"
using TCYDMWebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\_ViewImports.cshtml"
using TCYDMWebApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\_ViewImports.cshtml"
using TCYDMWebApp.Resources;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Shared\Components\Contact\Default.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Shared\Components\Contact\Default.cshtml"
using TCYDMWebApp.Repositories.Lang;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"400222a65c4452ed40aaaeab1784f622a839ce00", @"/Views/Shared/Components/Contact/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b6a4fda3b3cc13f3694c06c6c145161e13168af", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Contact_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TCYDMWebApp.DTO.ContactUsDTO>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/homelayout/logo/640px-Google_Play_Store_badge_EN.svg.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/homelayout/logo/download-on-app-store-png-click-the-qr-code-to-show-the-download-link-800-1.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n\r\n");
            WriteLiteral("\r\n\r\n");
            WriteLiteral("\r\n<a href=\"#\" style=\"text-transform:uppercase\">");
#nullable restore
#line 11 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Shared\Components\Contact\Default.cshtml"
                                        Write(SharedLocalizer["WHO WE ARE"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n<a href=\"#\" style=\"text-transform:uppercase\">");
#nullable restore
#line 12 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Shared\Components\Contact\Default.cshtml"
                                        Write(SharedLocalizer["What We Do"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n<a href=\"#\" style=\"text-transform:uppercase\">");
#nullable restore
#line 13 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Shared\Components\Contact\Default.cshtml"
                                        Write(SharedLocalizer["Contact us"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n<address class=\"address\">\r\n    <span>");
#nullable restore
#line 15 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Shared\Components\Contact\Default.cshtml"
     Write(SharedLocalizer["Email"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(": </span><a");
            BeginWriteAttribute("href", " href=\"", 505, "\"", 532, 2);
            WriteAttributeValue("", 512, "mailto:", 512, 7, true);
#nullable restore
#line 15 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Shared\Components\Contact\Default.cshtml"
WriteAttributeValue("", 519, Model?.Email, 519, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 15 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Shared\Components\Contact\Default.cshtml"
                                                                      Write(Model?.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a> <br>\r\n    <span>");
#nullable restore
#line 16 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Shared\Components\Contact\Default.cshtml"
     Write(SharedLocalizer["Mobile"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(":</span><a");
            BeginWriteAttribute("href", " href=\"", 604, "\"", 628, 2);
            WriteAttributeValue("", 611, "tel:", 611, 4, true);
#nullable restore
#line 16 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Shared\Components\Contact\Default.cshtml"
WriteAttributeValue("", 615, Model?.Phone, 615, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 16 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Shared\Components\Contact\Default.cshtml"
                                                                   Write(Model?.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a><br>\r\n    <span>");
#nullable restore
#line 17 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Shared\Components\Contact\Default.cshtml"
     Write(SharedLocalizer["Adress"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(":</span><a");
            BeginWriteAttribute("href", " href=\"", 699, "\"", 746, 2);
            WriteAttributeValue("", 706, "http://maps.google.com/?q=", 706, 26, true);
#nullable restore
#line 17 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Shared\Components\Contact\Default.cshtml"
WriteAttributeValue("", 732, Model?.Adress, 732, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n        ");
#nullable restore
#line 18 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Shared\Components\Contact\Default.cshtml"
   Write(Model?.Adress);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </a>\r\n</address>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "400222a65c4452ed40aaaeab1784f622a839ce009096", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "400222a65c4452ed40aaaeab1784f622a839ce0010127", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IHtmlLocalizer<SharedResource> SharedLocalizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TCYDMWebApp.DTO.ContactUsDTO> Html { get; private set; }
    }
}
#pragma warning restore 1591