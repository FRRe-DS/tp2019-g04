<<<<<<< HEAD
#pragma checksum "C:\Users\fedez\Desktop\tp2019-g04\AppWeb\Pages\Error.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1f02565c188bc0cf60de1bc120acef71a3608055"
=======
#pragma checksum "C:\Users\carli\source\repos\tp2019-g04\AppWeb\Pages\Error.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1f02565c188bc0cf60de1bc120acef71a3608055"
>>>>>>> 4fb7ca1d3db7dfe2a74ee129fe8c91f7ce9c7b90
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AppWeb.Pages.Pages_Error), @"mvc.1.0.razor-page", @"/Pages/Error.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Error.cshtml", typeof(AppWeb.Pages.Pages_Error), null)]
namespace AppWeb.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
<<<<<<< HEAD
#line 1 "C:\Users\fedez\Desktop\tp2019-g04\AppWeb\Pages\_ViewImports.cshtml"
=======
#line 1 "C:\Users\carli\source\repos\tp2019-g04\AppWeb\Pages\_ViewImports.cshtml"
>>>>>>> 4fb7ca1d3db7dfe2a74ee129fe8c91f7ce9c7b90
using AppWeb;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1f02565c188bc0cf60de1bc120acef71a3608055", @"/Pages/Error.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"58b4fd5ee4eb22073dbadc5e4ebfc0b14acd6770", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Error : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
<<<<<<< HEAD
#line 3 "C:\Users\fedez\Desktop\tp2019-g04\AppWeb\Pages\Error.cshtml"
=======
#line 3 "C:\Users\carli\source\repos\tp2019-g04\AppWeb\Pages\Error.cshtml"
>>>>>>> 4fb7ca1d3db7dfe2a74ee129fe8c91f7ce9c7b90
  
    ViewData["Title"] = "Error";

#line default
#line hidden
            BeginContext(67, 120, true);
            WriteLiteral("\r\n<h1 class=\"text-danger\">Error.</h1>\r\n<h2 class=\"text-danger\">An error occurred while processing your request.</h2>\r\n\r\n");
            EndContext();
<<<<<<< HEAD
#line 10 "C:\Users\fedez\Desktop\tp2019-g04\AppWeb\Pages\Error.cshtml"
=======
#line 10 "C:\Users\carli\source\repos\tp2019-g04\AppWeb\Pages\Error.cshtml"
>>>>>>> 4fb7ca1d3db7dfe2a74ee129fe8c91f7ce9c7b90
 if (Model.ShowRequestId)
{

#line default
#line hidden
            BeginContext(217, 52, true);
            WriteLiteral("    <p>\r\n        <strong>Request ID:</strong> <code>");
            EndContext();
            BeginContext(270, 15, false);
<<<<<<< HEAD
#line 13 "C:\Users\fedez\Desktop\tp2019-g04\AppWeb\Pages\Error.cshtml"
=======
#line 13 "C:\Users\carli\source\repos\tp2019-g04\AppWeb\Pages\Error.cshtml"
>>>>>>> 4fb7ca1d3db7dfe2a74ee129fe8c91f7ce9c7b90
                                      Write(Model.RequestId);

#line default
#line hidden
            EndContext();
            BeginContext(285, 19, true);
            WriteLiteral("</code>\r\n    </p>\r\n");
            EndContext();
<<<<<<< HEAD
#line 15 "C:\Users\fedez\Desktop\tp2019-g04\AppWeb\Pages\Error.cshtml"
=======
#line 15 "C:\Users\carli\source\repos\tp2019-g04\AppWeb\Pages\Error.cshtml"
>>>>>>> 4fb7ca1d3db7dfe2a74ee129fe8c91f7ce9c7b90
}

#line default
#line hidden
            BeginContext(307, 572, true);
            WriteLiteral(@"
<h3>Development Mode</h3>
<p>
    Swapping to the <strong>Development</strong> environment displays detailed information about the error that occurred.
</p>
<p>
    <strong>The Development environment shouldn't be enabled for deployed applications.</strong>
    It can result in displaying sensitive information from exceptions to end users.
    For local debugging, enable the <strong>Development</strong> environment by setting the <strong>ASPNETCORE_ENVIRONMENT</strong> environment variable to <strong>Development</strong>
    and restarting the app.
</p>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ErrorModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ErrorModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ErrorModel>)PageContext?.ViewData;
        public ErrorModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591