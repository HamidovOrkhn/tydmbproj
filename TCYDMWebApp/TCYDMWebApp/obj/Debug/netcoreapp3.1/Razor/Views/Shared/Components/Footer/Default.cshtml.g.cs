#pragma checksum "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Shared\Components\Footer\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1878644c75d5d8a35709ddb5a585bd17493e9dc0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Footer_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Footer/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1878644c75d5d8a35709ddb5a585bd17493e9dc0", @"/Views/Shared/Components/Footer/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b6a4fda3b3cc13f3694c06c6c145161e13168af", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Footer_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<TCYDMWebApp.DTO.OurServicesDTO>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 7 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Shared\Components\Footer\Default.cshtml"
 if (Model == null)
{
    return;
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"col-lg-4 col-md-12 services-center\">\r\n");
#nullable restore
#line 14 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Shared\Components\Footer\Default.cshtml"
          var count = Model.Count / 3; 

#line default
#line hidden
#nullable disable
            WriteLiteral("        <ul class=\"info-ul\">\r\n");
#nullable restore
#line 16 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Shared\Components\Footer\Default.cshtml"
             for (int i = 0; i < count + 1; i++)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li><a");
            BeginWriteAttribute("href", " href=\"", 437, "\"", 479, 2);
            WriteAttributeValue("", 444, "/home/services/", 444, 15, true);
#nullable restore
#line 18 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Shared\Components\Footer\Default.cshtml"
WriteAttributeValue("", 459, Model?[i].ServiceId, 459, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">* ");
#nullable restore
#line 18 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Shared\Components\Footer\Default.cshtml"
                                                               Write(Model?[i].Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 19 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Shared\Components\Footer\Default.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </ul>\r\n    </div>\r\n    <div class=\"col-lg-4 col-md-12 services-center \">\r\n        <ul class=\"info-ul\">\r\n");
#nullable restore
#line 25 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Shared\Components\Footer\Default.cshtml"
             for (int i = count + 1; i < (count + 1) * 2; i++)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li><a");
            BeginWriteAttribute("href", " href=\"", 739, "\"", 781, 2);
            WriteAttributeValue("", 746, "/home/services/", 746, 15, true);
#nullable restore
#line 27 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Shared\Components\Footer\Default.cshtml"
WriteAttributeValue("", 761, Model?[i].ServiceId, 761, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">* ");
#nullable restore
#line 27 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Shared\Components\Footer\Default.cshtml"
                                                               Write(Model?[i].Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 28 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Shared\Components\Footer\Default.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </ul>\r\n    </div>\r\n    <div class=\"col-lg-4 col-md-12 services-center\">\r\n        <ul class=\"info-ul\">\r\n");
#nullable restore
#line 33 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Shared\Components\Footer\Default.cshtml"
             for (int i = (count + 1) * 2; i <= count * 3; i++)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li><a");
            BeginWriteAttribute("href", " href=\"", 1039, "\"", 1081, 2);
            WriteAttributeValue("", 1046, "/home/services/", 1046, 15, true);
#nullable restore
#line 35 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Shared\Components\Footer\Default.cshtml"
WriteAttributeValue("", 1061, Model?[i].ServiceId, 1061, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">* ");
#nullable restore
#line 35 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Shared\Components\Footer\Default.cshtml"
                                                               Write(Model?[i].Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 36 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Shared\Components\Footer\Default.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </ul>\r\n    </div>\r\n");
#nullable restore
#line 39 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Shared\Components\Footer\Default.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<TCYDMWebApp.DTO.OurServicesDTO>> Html { get; private set; }
    }
}
#pragma warning restore 1591
