#pragma checksum "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Shared\Components\UserInfo\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d94d3cab221a00a50caaec64fec45e97ad704022"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_UserInfo_Default), @"mvc.1.0.view", @"/Views/Shared/Components/UserInfo/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d94d3cab221a00a50caaec64fec45e97ad704022", @"/Views/Shared/Components/UserInfo/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b6a4fda3b3cc13f3694c06c6c145161e13168af", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_UserInfo_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TCYDMWebApp.DTO.UserDataDTO>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"form-group\">\r\n    <input type=\"text\" readonly");
            BeginWriteAttribute("value", " value=\"", 223, "\"", 244, 1);
#nullable restore
#line 8 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Shared\Components\UserInfo\Default.cshtml"
WriteAttributeValue("", 231, Model.Region, 231, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"form-control\" id=\"exampleFormControlInput1\" placeholder=\"Data\">\r\n</div>\r\n<div class=\"form-group\">\r\n    <input type=\"text\" readonly");
            BeginWriteAttribute("value", " value=\"", 383, "\"", 405, 1);
#nullable restore
#line 11 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Shared\Components\UserInfo\Default.cshtml"
WriteAttributeValue("", 391, Model.Country, 391, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"form-control\" id=\"exampleFormControlInput1\" placeholder=\"Data\">\r\n</div>\r\n<div class=\"form-group\">\r\n    <input type=\"text\" readonly");
            BeginWriteAttribute("value", " value=\"", 544, "\"", 563, 1);
#nullable restore
#line 14 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Shared\Components\UserInfo\Default.cshtml"
WriteAttributeValue("", 552, Model.Name, 552, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"form-control\" id=\"exampleFormControlInput1\" placeholder=\"Data\">\r\n</div>\r\n<div class=\"form-group\">\r\n    <input type=\"text\" readonly");
            BeginWriteAttribute("value", " value=\"", 702, "\"", 724, 1);
#nullable restore
#line 17 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Shared\Components\UserInfo\Default.cshtml"
WriteAttributeValue("", 710, Model.Surname, 710, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"form-control\" id=\"exampleFormControlInput1\" placeholder=\"Data\">\r\n</div>\r\n\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-6\">\r\n        <div class=\"form-group\">\r\n            <input type=\"text\" readonly");
            BeginWriteAttribute("value", " value=\"", 927, "\"", 973, 1);
#nullable restore
#line 24 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Shared\Components\UserInfo\Default.cshtml"
WriteAttributeValue("", 935, Model.BornYear.ToString("yyyy-mm-dd"), 935, 38, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"form-control\" id=\"exampleFormControlInput1\" placeholder=\"Data\">\r\n        </div>\r\n    </div>\r\n    <div class=\"col-6\">\r\n        <div class=\"form-group\">\r\n            <input type=\"text\" readonly");
            BeginWriteAttribute("value", " value=\"", 1173, "\"", 1191, 1);
#nullable restore
#line 29 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Shared\Components\UserInfo\Default.cshtml"
WriteAttributeValue("", 1181, Model.Sex, 1181, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"form-control\" id=\"exampleFormControlInput1\" placeholder=\"Data\">\r\n        </div>\r\n    </div>\r\n\r\n</div>\r\n<div class=\"form-group\">\r\n    <input type=\"text\" readonly");
            BeginWriteAttribute("value", " value=\"", 1360, "\"", 1379, 1);
#nullable restore
#line 35 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Shared\Components\UserInfo\Default.cshtml"
WriteAttributeValue("", 1368, Model.TcNo, 1368, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"form-control\" id=\"exampleFormControlInput1\" placeholder=\"Data\">\r\n</div>\r\n<div class=\"form-group\">\r\n    <input type=\"text\" readonly");
            BeginWriteAttribute("value", " value=\"", 1518, "\"", 1538, 1);
#nullable restore
#line 38 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Shared\Components\UserInfo\Default.cshtml"
WriteAttributeValue("", 1526, Model.Email, 1526, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"form-control\" id=\"exampleFormControlInput1\" placeholder=\"Data\">\r\n</div>\r\n<div class=\"form-group\">\r\n    <input type=\"text\" readonly");
            BeginWriteAttribute("value", " value=\"", 1677, "\"", 1697, 1);
#nullable restore
#line 41 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Shared\Components\UserInfo\Default.cshtml"
WriteAttributeValue("", 1685, Model.Phone, 1685, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"form-control\" id=\"exampleFormControlInput1\" placeholder=\"Data\">\r\n\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TCYDMWebApp.DTO.UserDataDTO> Html { get; private set; }
    }
}
#pragma warning restore 1591