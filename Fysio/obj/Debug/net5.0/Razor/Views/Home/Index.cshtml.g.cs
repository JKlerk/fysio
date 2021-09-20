#pragma checksum "/Users/jklerk/projects/Fysio/Fysio/Views/Home/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "195b25bcb8be0ed957b5d7475e4f33bf50ad6bd1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "/Users/jklerk/projects/Fysio/Fysio/Views/_ViewImports.cshtml"
using Fysio;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/jklerk/projects/Fysio/Fysio/Views/_ViewImports.cshtml"
using Fysio.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"195b25bcb8be0ed957b5d7475e4f33bf50ad6bd1", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1c5d4e97c5a09b01bf7514933bf6609e0a9e9e54", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "/Users/jklerk/projects/Fysio/Fysio/Views/Home/Index.cshtml"
  
ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""flex"">
    <h1 class=""text-4xl font-semibold"">Patients
    </h1>
    <div class=""flex flex-1 justify-end"">
        <div class=""flex"">
            <p class=""my-auto mr-4 uppercase text-sm text-gray-600"">Username</p>
            <img src=""https://images.unsplash.com/photo-1570295999919-56ceb5ecca61?ixlib=rb-1.2.1&amp;ixid=eyJhcHBfaWQiOjEyMDd9&amp;auto=format&amp;fit=facearea&amp;facepad=4&amp;w=256&amp;h=256&amp;q=60""
                class=""h-10 w-10 rounded-full"">
        </div>
    </div>
</div>
<div class=""z-20"">
    <transition name=""fade"" appear leave>
        <div v-if=""visible""
            class=""fixed top-0 right-0 bottom-0 left-0 w-full h-full bg-black transition-opacity duration-300 opacity-30 z-10"">
        </div>
    </transition>
    <transition name=""fade"" appear leave>
        <div v-if=""visible"" class=""fixed transition-transform p-0 left-0 top-0 font-inter w-full z-10"">
            <div class=""mt-2 flex justify-center"">
                <div v-if=""visible"" class=""bg-white shadow overf");
            WriteLiteral(@"low-hidden sm:rounded-lg w-2/3"">
                    <div class=""px-4 py-5 sm:px-6 flex"">
                        <div>
                            <h3 class=""text-lg leading-6 font-medium text-gray-900"">
                                Patient Information
                            </h3>
                            <p class=""mt-1 max-w-2xl text-sm text-gray-500"">
                                Patients details and information.
                            </p>
                        </div>
                        <div class=""flex flex-1 justify-end my-auto"" v-on:click=""visible = false"">
                            <svg xmlns=""http://www.w3.org/2000/svg"" class=""h-6 w-6 cursor-pointer hover:w-12 hover:h-12""
                                fill=""none"" viewBox=""0 0 24 24"" stroke=""currentColor"">
                                <path stroke-linecap=""round"" stroke-linejoin=""round"" stroke-width=""2""
                                    d=""M6 18L18 6M6 6l12 12"" />
                            </svg>
                  ");
            WriteLiteral(@"      </div>
                    </div>
                    <div class=""border-t border-gray-200"">
                        <dl>
                            <div class=""bg-gray-50 px-4 py-5 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-6"">
                                <dt class=""text-sm font-medium text-gray-500"">
                                    Patient name
                                </dt>
                                <dd class=""mt-1 text-sm text-gray-900 sm:mt-0 sm:col-span-2"">
                                    Margot Foster
                                </dd>
                            </div>
                            <div class=""bg-white px-4 py-5 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-6"">
                                <dt class=""text-sm font-medium text-gray-500"">
                                    Gender
                                </dt>
                                <dd class=""mt-1 text-sm text-gray-900 sm:mt-0 sm:col-span-2"">
                                    Female
            ");
            WriteLiteral(@"                    </dd>
                            </div>
                            <div class=""bg-gray-50 px-4 py-5 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-6"">
                                <dt class=""text-sm font-medium text-gray-500"">
                                    Email address
                                </dt>
                                <dd class=""mt-1 text-sm text-gray-900 sm:mt-0 sm:col-span-2"">
                                    margotfoster@example.com
                                </dd>
                            </div>
                            <div class=""bg-white px-4 py-5 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-6"">
                                <dt class=""text-sm font-medium text-gray-500"">
                                    Birthdate
                                </dt>
                                <dd class=""mt-1 text-sm text-gray-900 sm:mt-0 sm:col-span-2"">
                                    06-06-1999
                                </dd>
                      ");
            WriteLiteral(@"      </div>
                            <div class=""bg-gray-50 px-4 py-5 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-6"">
                                <dt class=""text-sm font-medium text-gray-500"">
                                    Notes
                                </dt>
                                <dd class=""mt-1 text-sm text-gray-900 sm:mt-0 sm:col-span-2"">
                                    Fugiat ipsum ipsum deserunt culpa aute sint do nostrud anim incididunt cillum culpa
                                    consequat. Excepteur qui ipsum aliquip consequat sint. Sit id mollit nulla mollit
                                    nostrud in
                                    ea officia proident. Irure nostrud pariatur mollit ad adipisicing reprehenderit
                                    deserunt qui
                                    eu.
                                </dd>
                            </div>
                            <div class=""bg-white px-4 py-5 sm:grid sm:grid-cols-3 sm:gap-4 s");
            WriteLiteral(@"m:px-6"">
                                <dt class=""text-sm font-medium text-gray-500"">
                                    Profile image
                                </dt>
                                <dd class=""mt-1 text-sm text-gray-900 sm:mt-0 sm:col-span-2"">
                                    <ul role=""list"" class=""border border-gray-200 rounded-md divide-y divide-gray-200"">
                                        <li class=""pl-3 pr-4 py-3 flex items-center justify-between text-sm"">
                                            <div class=""w-0 flex-1 flex items-center"">
                                                <!-- Heroicon name: solid/paper-clip -->
                                                <svg class=""flex-shrink-0 h-5 w-5 text-gray-400""
                                                    xmlns=""http://www.w3.org/2000/svg"" viewBox=""0 0 20 20""
                                                    fill=""currentColor"" aria-hidden=""true"">
                                                    ");
            WriteLiteral(@"<path fill-rule=""evenodd""
                                                        d=""M8 4a3 3 0 00-3 3v4a5 5 0 0010 0V7a1 1 0 112 0v4a7 7 0 11-14 0V7a5 5 0 0110 0v4a3 3 0 11-6 0V7a1 1 0 012 0v4a1 1 0 102 0V7a3 3 0 00-3-3z""
                                                        clip-rule=""evenodd"" />
                                                </svg>
                                                <span class=""ml-2 flex-1 w-0 truncate"">
                                                    user_profile_image.png
                                                </span>
                                            </div>
                                            <div class=""ml-4 flex-shrink-0"">
                                                <a href=""#"" class=""font-medium text-indigo-600 hover:text-indigo-500"">
                                                    Upload
                                                </a>
                                            </div>
                                      ");
            WriteLiteral(@"  </li>
                                    </ul>
                                </dd>
                            </div>
                        </dl>
                    </div>
                    <div class=""flex flex-1 justify-end mt-5 pb-6 px-6"">
                        <button v-on:click=""addPatient()""
                            class=""bg-blue-500 rounded-lg text-white py-2 w-1/6 text-center font-bold"">Add
                            patient</button>
                    </div>
                </div>
            </div>
        </div>
    </transition>
</div>
<section class=""mx-auto mt-10"">
    <div class=""flex flex-col"">
        <div class=""-my-2 overflow-x-auto sm:-mx-6 lg:-mx-8"">
            <div class=""py-2 align-middle inline-block min-w-full sm:px-6 lg:px-8"">
                <div class=""shadow overflow-hidden border-b border-gray-200 sm:rounded-lg"">
                    <table class=""min-w-full divide-y divide-gray-200"">
                        <thead class=""bg-gray-50"">
                           ");
            WriteLiteral(@" <tr>
                                <th scope=""col""
                                    class=""px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider"">
                                    Name
                                </th>
                                <th scope=""col""
                                    class=""px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider"">
                                    Data
                                </th>
                                <th scope=""col""
                                    class=""px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider"">
                                    Gender
                                </th>
                                <th scope=""col""
                                    class=""px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider"">
                                    Birthdate
                                </th>
       ");
            WriteLiteral(@"                         <th scope=""col"" class=""relative px-6 py-3"">
                                    <span class=""sr-only"">Edit</span>
                                </th>
                            </tr>
                        </thead>
                        <tbody class=""bg-white divide-y divide-gray-200"">
                            <tr>
                                <td class=""px-6 py-4 whitespace-nowrap"">
                                    <div class=""flex items-center"">
                                        <div class=""flex-shrink-0 h-10 w-10"">
                                            <img class=""h-10 w-10 rounded-full""
                                                src=""https://images.unsplash.com/photo-1494790108377-be9c29b29330?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=4&w=256&h=256&q=60""");
            BeginWriteAttribute("alt", "\n                                                alt=\"", 10111, "\"", 10165, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                                        </div>
                                        <div class=""ml-4"">
                                            <div class=""text-sm font-medium text-gray-900"">
                                                Jane Cooper
                                            </div>
                                            <div class=""text-sm text-gray-500"">
                                                jane.cooper@example.com
                                            </div>
                                        </div>
                                    </div>
                                </td>
                                <td class=""px-6 py-4 whitespace-nowrap"">
                                    <div class=""text-sm text-gray-900"">06 12121212</div>
                                    <div class=""text-sm text-gray-500"">7dcf62d6-1134-410c-b7d3-eff040c97835</div>
                                </td>
                                <td class=""px-6 py-4 whitespace-nowr");
            WriteLiteral(@"ap"">
                                    <span
                                        class=""px-2 inline-flex text-xs leading-5 font-semibold rounded-full bg-green-100 text-green-800"">
                                        Female
                                    </span>
                                </td>
                                <td class=""px-6 py-4 whitespace-nowrap text-sm text-gray-500"">
                                    06-06-1999
                                </td>
                                <td class=""px-6 pt-6 whitespace-nowrap text-right text-sm font-medium flex"">
                                    <a href=""#"" class=""text-indigo-600 hover:text-indigo-900""> <svg
                                            xmlns=""http://www.w3.org/2000/svg"" width=""24"" height=""24""
                                            viewBox=""0 0 24 24"" fill=""none"" stroke=""currentColor"" stroke-width=""2""
                                            stroke-linecap=""round"" stroke-linejoin=""round"" class=""feath");
            WriteLiteral(@"er feather-edit"">
                                            <path d=""M11 4H4a2 2 0 0 0-2 2v14a2 2 0 0 0 2 2h14a2 2 0 0 0 2-2v-7"" />
                                            <path d=""M18.5 2.5a2.121 2.121 0 0 1 3 3L12 15l-4 1 1-4 9.5-9.5z"" />
                                        </svg>
                                        <a href=""#"" class=""text-red-600 hover:text-red-900""> <svg
                                                xmlns=""http://www.w3.org/2000/svg"" width=""24"" height=""24""
                                                viewBox=""0 0 24 24"" fill=""none"" stroke=""currentColor"" stroke-width=""2""
                                                stroke-linecap=""round"" stroke-linejoin=""round""
                                                class=""feather feather-x"">
                                                <line x1=""18"" y1=""6"" x2=""6"" y2=""18"" />
                                                <line x1=""6"" y1=""6"" x2=""18"" y2=""18"" />
                                            </svg>
            ");
            WriteLiteral(@"                            </a>
                                </td>
                            </tr>

                            <tr>
                                <td class=""px-6 py-4 whitespace-nowrap"">
                                    <div class=""flex items-center"">
                                        <div class=""flex-shrink-0 h-10 w-10"">
                                            <img class=""h-10 w-10 rounded-full""
                                                src=""https://source.unsplash.com/256x256/?face""");
            BeginWriteAttribute("alt", " alt=\"", 13771, "\"", 13777, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                                        </div>
                                        <div class=""ml-4"">
                                            <div class=""text-sm font-medium text-gray-900"">
                                                Jane Cooper
                                            </div>
                                            <div class=""text-sm text-gray-500"">
                                                jane.cooper@example.com
                                            </div>
                                        </div>
                                    </div>
                                </td>
                                <td class=""px-6 py-4 whitespace-nowrap"">
                                    <div class=""text-sm text-gray-900"">06 12121212</div>
                                    <div class=""text-sm text-gray-500"">7dcf62d6-1134-410c-b7d3-eff040c97835</div>
                                </td>
                                <td class=""px-6 py-4 whitespace-nowr");
            WriteLiteral(@"ap"">
                                    <span
                                        class=""px-2 inline-flex text-xs leading-5 font-semibold rounded-full bg-green-100 text-green-800"">
                                        Male
                                    </span>
                                </td>
                                <td class=""px-6 py-4 whitespace-nowrap text-sm text-gray-500"">
                                    06-06-1999
                                </td>
                                <td class=""px-6 pt-6 whitespace-nowrap text-right text-sm font-medium flex"">
                                    <a href=""#"" class=""text-indigo-600 hover:text-indigo-900""> <svg
                                            xmlns=""http://www.w3.org/2000/svg"" width=""24"" height=""24""
                                            viewBox=""0 0 24 24"" fill=""none"" stroke=""currentColor"" stroke-width=""2""
                                            stroke-linecap=""round"" stroke-linejoin=""round"" class=""feather");
            WriteLiteral(@" feather-edit"">
                                            <path d=""M11 4H4a2 2 0 0 0-2 2v14a2 2 0 0 0 2 2h14a2 2 0 0 0 2-2v-7"" />
                                            <path d=""M18.5 2.5a2.121 2.121 0 0 1 3 3L12 15l-4 1 1-4 9.5-9.5z"" />
                                        </svg>
                                        <a href=""#"" class=""text-red-600 hover:text-red-900""> <svg
                                                xmlns=""http://www.w3.org/2000/svg"" width=""24"" height=""24""
                                                viewBox=""0 0 24 24"" fill=""none"" stroke=""currentColor"" stroke-width=""2""
                                                stroke-linecap=""round"" stroke-linejoin=""round""
                                                class=""feather feather-x"">
                                                <line x1=""18"" y1=""6"" x2=""6"" y2=""18"" />
                                                <line x1=""6"" y1=""6"" x2=""18"" y2=""18"" />
                                            </svg>
              ");
            WriteLiteral(@"                          </a>
                                </td>
                            </tr>

                            <!-- More people... -->
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        <div class=""flex flex-1 justify-end mt-5"">
            <button v-on:click=""visible = true""
                class=""bg-blue-500 rounded-lg text-white py-2 w-1/6 text-center font-bold"">Add
                patient</button>
        </div>
    </div>
</section>
<script type=""application/javascript"">
    const app = new Vue({
        el: '#app',
        data: {
            visible: false,
        },
        created() {
            console.log(""Vue running"")
        },
        methods: {
            addPatient() {
                console.log(""Called"")
            }
        }
    })
</script>");
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
