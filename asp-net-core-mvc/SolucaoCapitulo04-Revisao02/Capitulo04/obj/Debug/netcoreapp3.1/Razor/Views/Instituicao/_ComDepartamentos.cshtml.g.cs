#pragma checksum "C:\Users\Everton\Documents\GitHub\implementacoes-de-livros\asp-net-core-mvc\SolucaoCapitulo04-Revisao02\Capitulo04\Views\Instituicao\_ComDepartamentos.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b4ba1cfb81d1ff000cff0c1d01321e2bc1695611"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Instituicao__ComDepartamentos), @"mvc.1.0.view", @"/Views/Instituicao/_ComDepartamentos.cshtml")]
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
#line 1 "C:\Users\Everton\Documents\GitHub\implementacoes-de-livros\asp-net-core-mvc\SolucaoCapitulo04-Revisao02\Capitulo04\Views\_ViewImports.cshtml"
using Capitulo04;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Everton\Documents\GitHub\implementacoes-de-livros\asp-net-core-mvc\SolucaoCapitulo04-Revisao02\Capitulo04\Views\_ViewImports.cshtml"
using Capitulo04.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b4ba1cfb81d1ff000cff0c1d01321e2bc1695611", @"/Views/Instituicao/_ComDepartamentos.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"685d96449dedf86b57bed34797f0d25593b46b19", @"/Views/_ViewImports.cshtml")]
    public class Views_Instituicao__ComDepartamentos : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Capitulo04.Models.Departamento>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""panel panel-primary"">
    <div class=""card-header text-white bg-warning text-center"">
        Relação de DEPARTAMENTOS registrados para a instituição
    </div>
    <div class=""panel-body"">
        <table class=""table table-striped table-hover"">
            <thead>
                <tr>
                    <th>
                        ");
#nullable restore
#line 12 "C:\Users\Everton\Documents\GitHub\implementacoes-de-livros\asp-net-core-mvc\SolucaoCapitulo04-Revisao02\Capitulo04\Views\Instituicao\_ComDepartamentos.cshtml"
                   Write(Html.DisplayNameFor(model => model.Nome));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 17 "C:\Users\Everton\Documents\GitHub\implementacoes-de-livros\asp-net-core-mvc\SolucaoCapitulo04-Revisao02\Capitulo04\Views\Instituicao\_ComDepartamentos.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 21 "C:\Users\Everton\Documents\GitHub\implementacoes-de-livros\asp-net-core-mvc\SolucaoCapitulo04-Revisao02\Capitulo04\Views\Instituicao\_ComDepartamentos.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Nome));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 24 "C:\Users\Everton\Documents\GitHub\implementacoes-de-livros\asp-net-core-mvc\SolucaoCapitulo04-Revisao02\Capitulo04\Views\Instituicao\_ComDepartamentos.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n    <div class=\"panel-footer panel-info\">\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Capitulo04.Models.Departamento>> Html { get; private set; }
    }
}
#pragma warning restore 1591