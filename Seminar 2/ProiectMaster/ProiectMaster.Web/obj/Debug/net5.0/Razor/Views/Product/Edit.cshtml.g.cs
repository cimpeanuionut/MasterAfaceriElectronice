#pragma checksum "D:\ProiectMaster\ProiectMaster.Web\Views\Product\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1335ada904e1788985c7a092bad8df0f10e5670a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_Edit), @"mvc.1.0.view", @"/Views/Product/Edit.cshtml")]
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
#line 1 "D:\ProiectMaster\ProiectMaster.Web\Views\_ViewImports.cshtml"
using ProiectMaster.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\ProiectMaster\ProiectMaster.Web\Views\_ViewImports.cshtml"
using ProiectMaster.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\ProiectMaster\ProiectMaster.Web\Views\_ViewImports.cshtml"
using ProiectMaster.Models.DTOs.VM;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1335ada904e1788985c7a092bad8df0f10e5670a", @"/Views/Product/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1e0f90aa2bc31c32be44b04d713c11a4956ab7b6", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProductVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\ProiectMaster\ProiectMaster.Web\Views\Product\Edit.cshtml"
  
    ViewData["Title"] = "Edit a product";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "D:\ProiectMaster\ProiectMaster.Web\Views\Product\Edit.cshtml"
   ViewBag.IsNew = false;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 9 "D:\ProiectMaster\ProiectMaster.Web\Views\Product\Edit.cshtml"
Write(await Html.PartialAsync(@"../Shared/Components/_Product.cshtml"));

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProductVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
