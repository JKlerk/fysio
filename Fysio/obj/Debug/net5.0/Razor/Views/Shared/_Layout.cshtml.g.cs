#pragma checksum "C:\Users\joeyd\projects\fysio\Fysio\Views\Shared\_Layout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2c95345886ce483fd1a73e49539e6a7feba28f17"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Layout), @"mvc.1.0.view", @"/Views/Shared/_Layout.cshtml")]
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
#line 1 "C:\Users\joeyd\projects\fysio\Fysio\Views\_ViewImports.cshtml"
using Fysio;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\joeyd\projects\fysio\Fysio\Views\_ViewImports.cshtml"
using Fysio.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2c95345886ce483fd1a73e49539e6a7feba28f17", @"/Views/Shared/_Layout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"623b2ca378ab5dc583dc64f5d5b503299eca9f1b", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Layout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/site.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/output.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/joey.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("h-12"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Sample Photo"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("bg-white min-h-screen flex"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2c95345886ce483fd1a73e49539e6a7feba28f175832", async() => {
                WriteLiteral("\r\n        <meta charset=\"utf-8\" />\r\n        <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" />\r\n        <title>");
#nullable restore
#line 6 "C:\Users\joeyd\projects\fysio\Fysio\Views\Shared\_Layout.cshtml"
          Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(" - Fysio</title>\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "2c95345886ce483fd1a73e49539e6a7feba28f176475", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "2c95345886ce483fd1a73e49539e6a7feba28f177657", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
        <link href=""https://cdn.jsdelivr.net/npm/select2@4.1.0-rc.0/dist/css/select2.min.css"" rel=""stylesheet"" />
        <script src=""https://cdnjs.cloudflare.com/ajax/libs/jquery/3.6.0/jquery.min.js"" integrity=""sha512-894YE6QWD5I59HgZOGReFYm4dnWc1Qt5NtvYSaNcOP+u1T9qYdvdihz0PPSiiqn/+/3e7Jo4EaG7TubfWGUrMQ=="" crossorigin=""anonymous"" referrerpolicy=""no-referrer""></script>
        <script src=""https://cdn.jsdelivr.net/npm/select2@4.1.0-rc.0/dist/js/select2.min.js""></script>
        <script src=""https://cdn.jsdelivr.net/npm/vue@2.6.14/dist/vue.js""></script>
    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2c95345886ce483fd1a73e49539e6a7feba28f1710130", async() => {
                WriteLiteral("\r\n        <div class=\"bg-gray-100 w-2/12 p-5\">\r\n            <div class=\"flex justify-center\">\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "2c95345886ce483fd1a73e49539e6a7feba28f1710506", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                <h1 class=""text-3xl mb-10 uppercase text-fysio-header"">Fysio</h1>
            </div>
            <div class=""mx-auto"">
                <ul class=""text-gray-600 font-source"">
                    <a href=""/"" class=""flex my-3 rounded-lg p-2 bg-fysio-light"">
                        <svg
                            xmlns=""http://www.w3.org/2000/svg""
                            width=""24""
                            height=""24""
                            viewBox=""0 0 24 24""
                            fill=""none""
                            stroke=""currentColor""
                            stroke-width=""2""
                            stroke-linecap=""round""
                            stroke-linejoin=""round""
                            class=""feather feather-activity""
                        >
                            <polyline points=""22 12 18 12 15 21 9 3 6 12 2 12""></polyline>
                        </svg>
                        <li class=""my-auto ml-3"">Dashboard</li>
 ");
                WriteLiteral("                   </a>\r\n");
#nullable restore
#line 40 "C:\Users\joeyd\projects\fysio\Fysio\Views\Shared\_Layout.cshtml"
                     if (User.IsInRole("Therapist") || User.IsInRole("Student"))
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                        <a href=""/patients"" class=""flex my-3 rounded-lg p-2 hover:bg-fysio-light select-none"">
                            <svg
                                xmlns=""http://www.w3.org/2000/svg""
                                width=""24""
                                height=""24""
                                viewBox=""0 0 24 24""
                                fill=""none""
                                stroke=""currentColor""
                                stroke-width=""2""
                                stroke-linecap=""round""
                                stroke-linejoin=""round""
                                class=""feather feather-users"">
                                <path d=""M17 21v-2a4 4 0 0 0-4-4H5a4 4 0 0 0-4 4v2""/>
                                <circle cx=""9"" cy=""7"" r=""4""/>
                                <path d=""M23 21v-2a4 4 0 0 0-3-3.87""/>
                                <path d=""M16 3.13a4 4 0 0 1 0 7.75""/>
                            </svg>
            ");
                WriteLiteral("                <li class=\"my-auto ml-3\">Patients</li>\r\n                        </a>\r\n");
#nullable restore
#line 61 "C:\Users\joeyd\projects\fysio\Fysio\Views\Shared\_Layout.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                    <a href=""/appointment"" class=""flex my-5 rounded-lg p-2 hover:bg-fysio-light select-none"">
                        <svg
                            xmlns=""http://www.w3.org/2000/svg""
                            width=""24""
                            height=""24""
                            viewBox=""0 0 24 24""
                            fill=""none""
                            stroke=""currentColor""
                            stroke-width=""2""
                            stroke-linecap=""round""
                            stroke-linejoin=""round""
                            class=""feather feather-users"">
                            <path d=""M17 21v-2a4 4 0 0 0-4-4H5a4 4 0 0 0-4 4v2""/>
                            <circle cx=""9"" cy=""7"" r=""4""/>
                            <path d=""M23 21v-2a4 4 0 0 0-3-3.87""/>
                            <path d=""M16 3.13a4 4 0 0 1 0 7.75""/>
                        </svg>
                        <li class=""my-auto ml-3"">Appointments</li>
         ");
                WriteLiteral(@"           </a>
                    
                    <a href=""/patients/profile"" class=""flex my-5 p-2 hover:bg-fysio-light select-none"">
                        <svg
                            xmlns=""http://www.w3.org/2000/svg""
                            width=""24""
                            height=""24""
                            viewBox=""0 0 24 24""
                            fill=""none""
                            stroke=""currentColor""
                            stroke-width=""2""
                            stroke-linecap=""round""
                            stroke-linejoin=""round""
                            class=""feather feather-database""
                        >
                            <ellipse cx=""12"" cy=""5"" rx=""9"" ry=""3"" />
                            <path d=""M21 12c0 1.66-4 3-9 3s-9-1.34-9-3"" />
                            <path d=""M3 5v14c0 1.66 4 3 9 3s9-1.34 9-3V5"" />
                        </svg>
                        <li class=""my-auto ml-3"">Profile</li>
     ");
                WriteLiteral(@"               </a>
                    <a href=""/user/logout"" class=""flex my-5 p-2 hover:bg-fysio-light select-none"">
                        <svg
                            xmlns=""http://www.w3.org/2000/svg""
                            width=""24""
                            height=""24""
                            viewBox=""0 0 24 24""
                            fill=""none""
                            stroke=""currentColor""
                            stroke-width=""2""
                            stroke-linecap=""round""
                            stroke-linejoin=""round""
                            class=""feather feather-settings""
                        >
                            <circle cx=""12"" cy=""12"" r=""3"" />
                            <path
                                d=""M19.4 15a1.65 1.65 0 0 0 .33 1.82l.06.06a2 2 0 0 1 0 2.83 2 2 0 0 1-2.83 0l-.06-.06a1.65 1.65 0 0 0-1.82-.33 1.65 1.65 0 0 0-1 1.51V21a2 2 0 0 1-2 2 2 2 0 0 1-2-2v-.09A1.65 1.65 0 0 0 9 19.4a1.65 1.65 0 0 0-1.82.33l");
                WriteLiteral(@"-.06.06a2 2 0 0 1-2.83 0 2 2 0 0 1 0-2.83l.06-.06a1.65 1.65 0 0 0 .33-1.82 1.65 1.65 0 0 0-1.51-1H3a2 2 0 0 1-2-2 2 2 0 0 1 2-2h.09A1.65 1.65 0 0 0 4.6 9a1.65 1.65 0 0 0-.33-1.82l-.06-.06a2 2 0 0 1 0-2.83 2 2 0 0 1 2.83 0l.06.06a1.65 1.65 0 0 0 1.82.33H9a1.65 1.65 0 0 0 1-1.51V3a2 2 0 0 1 2-2 2 2 0 0 1 2 2v.09a1.65 1.65 0 0 0 1 1.51 1.65 1.65 0 0 0 1.82-.33l.06-.06a2 2 0 0 1 2.83 0 2 2 0 0 1 0 2.83l-.06.06a1.65 1.65 0 0 0-.33 1.82V9a1.65 1.65 0 0 0 1.51 1H21a2 2 0 0 1 2 2 2 2 0 0 1-2 2h-.09a1.65 1.65 0 0 0-1.51 1z""
                            />
                        </svg>
                        <li class=""my-auto ml-3"">Logout</li>
                    </a>
                </ul>
            </div>
        </div>
        <p class=""hidden"" id=""route"">");
#nullable restore
#line 124 "C:\Users\joeyd\projects\fysio\Fysio\Views\Shared\_Layout.cshtml"
                                Write(Context.Request.Path);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</p>
        <div id=""app"" class=""w-full container mx-auto"">
            <div class=""py-6 w-full border-b"">
                <div class=""flex flex-1 justify-end"">
                    <a href=""/patients/profile"" class=""flex hover:bg-gray-100 transition-colors duration-100 px-2 rounded-lg"">
                        <p class=""mr-4 my-auto"">");
#nullable restore
#line 129 "C:\Users\joeyd\projects\fysio\Fysio\Views\Shared\_Layout.cshtml"
                                           Write(Context.User.Identity.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</p>
                        <div class=""bg-gray-100 p-1 rounded-lg"">
                            <svg xmlns=""http://www.w3.org/2000/svg"" class=""h-6 w-6 text-fysio-header my-auto"" fill=""none"" viewBox=""0 0 24 24"" stroke=""currentColor"">
                                <path stroke-linecap=""round"" stroke-linejoin=""round"" stroke-width=""2"" d=""M16 7a4 4 0 11-8 0 4 4 0 018 0zM12 14a7 7 0 00-7 7h14a7 7 0 00-7-7z""/>
                            </svg>
                        </div>
                    </a>
                </div>
            </div>
            <div class=""py-6"">");
#nullable restore
#line 138 "C:\Users\joeyd\projects\fysio\Fysio\Views\Shared\_Layout.cshtml"
                         Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n        </div>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n<script>\r\n\r\nnew Vue({\r\n    el: \"#app\",\r\n    data: {\r\n        visible: false,\r\n        curModalId: null,\r\n        options: [],\r\n    },\r\n    created() {\r\n        console.log(\"Vue running\");\r\n    },\r\n});\r\n</script>");
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
