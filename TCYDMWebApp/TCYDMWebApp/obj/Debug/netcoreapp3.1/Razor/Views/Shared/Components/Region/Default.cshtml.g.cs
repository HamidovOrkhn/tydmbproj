#pragma checksum "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Shared\Components\Region\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9e4e7a1d4b0f48a4edf16e732d1121b1ec49f4f9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Region_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Region/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9e4e7a1d4b0f48a4edf16e732d1121b1ec49f4f9", @"/Views/Shared/Components/Region/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b6a4fda3b3cc13f3694c06c6c145161e13168af", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Region_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<TCYDMWebApp.DTO.RegionDTO>>
    {
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 7 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Shared\Components\Region\Default.cshtml"
 if (Model == null)
{
    return;
}
else
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Shared\Components\Region\Default.cshtml"
     foreach (var item in Model)
    {
        if (Convert.ToInt32(Context.Request.Cookies["rId"]) == item?.Id)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9e4e7a1d4b0f48a4edf16e732d1121b1ec49f4f93985", async() => {
#nullable restore
#line 17 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Shared\Components\Region\Default.cshtml"
                                                          Write(item?.Name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 17 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Shared\Components\Region\Default.cshtml"
                       WriteLiteral(Convert.ToUInt32(item?.Id));

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 18 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Shared\Components\Region\Default.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9e4e7a1d4b0f48a4edf16e732d1121b1ec49f4f96445", async() => {
#nullable restore
#line 21 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Shared\Components\Region\Default.cshtml"
                                                 Write(item?.Name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 21 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Shared\Components\Region\Default.cshtml"
              WriteLiteral(Convert.ToUInt32(item?.Id));

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 22 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Shared\Components\Region\Default.cshtml"
        }

    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Shared\Components\Region\Default.cshtml"
     
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<TCYDMWebApp.DTO.RegionDTO>> Html { get; private set; }
    }
}
#pragma warning restore 1591
