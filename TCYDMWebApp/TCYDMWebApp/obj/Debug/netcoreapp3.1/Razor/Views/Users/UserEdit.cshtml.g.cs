#pragma checksum "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Users\UserEdit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "36204bb3b37561865b8340270fb372d3922eeb91"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Users_UserEdit), @"mvc.1.0.view", @"/Views/Users/UserEdit.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"36204bb3b37561865b8340270fb372d3922eeb91", @"/Views/Users/UserEdit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b6a4fda3b3cc13f3694c06c6c145161e13168af", @"/Views/_ViewImports.cshtml")]
    public class Views_Users_UserEdit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 6 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Users\UserEdit.cshtml"
 if (TempData["ServerResponseError"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"p-red-box servererror\" style=\"position:absolute;left:5%;top:40%;z-index:2;display:none;\">\r\n        <p style=\"color:white\">");
#nullable restore
#line 9 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Users\UserEdit.cshtml"
                          Write(TempData["ServerResponseError"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n    </div>\r\n");
#nullable restore
#line 12 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Users\UserEdit.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Users\UserEdit.cshtml"
Write(await Component.InvokeAsync("UserEdit"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 16 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Users\UserEdit.cshtml"
     if (TempData["ServerResponseError"] != null)
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        <script>\r\n            $(\".servererror\").fadeIn(function () {\r\n                setTimeout(function () {\r\n                    $(\".servererror\").fadeOut();\r\n                }, 2000);\r\n            })\r\n        </script>\r\n");
#nullable restore
#line 25 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Users\UserEdit.cshtml"
    }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"    <script>
        $(document).ready(function () {
            const togglePassword = document.querySelector('.toggle-password');
            const password = document.querySelector('#password-field');
            togglePassword.addEventListener('click', function (e) {
                // toggle the type attribute
                const type = password.getAttribute('type') === 'password' ? 'text' : 'password';
                password.setAttribute('type', type);
                // toggle the eye slash icon
                this.classList.toggle('fa-eye-slash');
            });


        })
    </script>
");
#nullable restore
#line 41 "C:\Users\Orxan\source\repos\tydmbproj\TCYDMWebApp\TCYDMWebApp\Views\Users\UserEdit.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            }
            );
            WriteLiteral("\r\n");
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
