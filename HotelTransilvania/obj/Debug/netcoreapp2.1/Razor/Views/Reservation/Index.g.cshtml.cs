#pragma checksum "C:\Users\denise.garcia\source\repos\DB_DeniseProject\HotelTransilvania\HotelTransilvania\Views\Reservation\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f152d536904caed2aebf9a51a1cabb3c5a347ddf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Reservation_Index), @"mvc.1.0.view", @"/Views/Reservation/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Reservation/Index.cshtml", typeof(AspNetCore.Views_Reservation_Index))]
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
#line 1 "C:\Users\denise.garcia\source\repos\DB_DeniseProject\HotelTransilvania\HotelTransilvania\Views\_ViewImports.cshtml"
using HotelTransilvania;

#line default
#line hidden
#line 2 "C:\Users\denise.garcia\source\repos\DB_DeniseProject\HotelTransilvania\HotelTransilvania\Views\_ViewImports.cshtml"
using HotelTransilvania.ViewModels;

#line default
#line hidden
#line 1 "C:\Users\denise.garcia\source\repos\DB_DeniseProject\HotelTransilvania\HotelTransilvania\Views\Reservation\Index.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f152d536904caed2aebf9a51a1cabb3c5a347ddf", @"/Views/Reservation/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c29cb8e4b13ab60431d5a530cc42b8c471e5076b", @"/Views/_ViewImports.cshtml")]
    public class Views_Reservation_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<X.PagedList.PagedList<Commom.DTOs.ReservationDTO>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("submit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("margin:auto;width:auto;padding:1em;border:1px solid #CCC;border-radius:1em;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Reservation", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("border:0px;padding:0px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Cancel", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onclick", new global::Microsoft.AspNetCore.Html.HtmlString("return confirm(\'Você tem certeza que deseja cancelar esta reserva?\');"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/views/reservation/index.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(88, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "C:\Users\denise.garcia\source\repos\DB_DeniseProject\HotelTransilvania\HotelTransilvania\Views\Reservation\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(131, 23, true);
            WriteLiteral("\r\n<h2>Reservas</h2>\r\n\r\n");
            EndContext();
            BeginContext(154, 105, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "08ae443ed6e34b7bafc9c846b4295211", async() => {
                BeginContext(160, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(166, 84, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bc42b8a536624fd2986d2362a71163ae", async() => {
                    BeginContext(229, 12, true);
                    WriteLiteral("Nova Reserva");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(250, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(259, 10, true);
            WriteLiteral("\r\n<br>\r\n\r\n");
            EndContext();
            BeginContext(269, 874, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8b4f131ead494542afa350da7523e537", async() => {
                BeginContext(359, 777, true);
                WriteLiteral(@"
    <label class=""control-label"">Procurar:</label>
    <div class=""form-actions no-color"">
        <br>
        <label class=""control-label"">De</label>
        <input type=""date"" id=""arrivalSearch"" class=""form-control-lg"" data-dependent-validation='{""from"": ""departureSearch"", ""prop"": ""max""}' />
        <span id=""arrivalSearch"" class=""text-danger""></span>

        <label class=""control-label"">até</label>
        <input type=""date"" id=""departureSearch"" class=""form-control-lg"" data-dependent-validation='{(""from"": ""arrivalSearch"", ""prop"": ""min""), (""from"": ""departureSearch"", ""prop"": ""max"")}' />
        <span id=""departureSearch"" class=""text-danger""></span>

        <button class=""btn btn-group-lg"" onclick=""personalizedSearch()"">Procurar</button>
    </div>
");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1143, 10, true);
            WriteLiteral("\r\n<br>\r\n\r\n");
            EndContext();
            BeginContext(1153, 2685, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ec696d35746c4fa7807905f91e7f6760", async() => {
                BeginContext(1173, 734, true);
                WriteLiteral(@"
    <table class=""table"">
        <thead>
            <tr>
                <th>
                    Entrada
                </th>
                <th>
                    Saída
                </th>
                <th>
                    Hóspede
                </th>
                <th>
                    Categoria
                </th>
                <th>
                    Apartamento
                </th>
                <th>
                    Situação
                </th>
                <th>
                    Contato da Reserva
                </th>
                <th>
                    Data de Criação
                </th>
            </tr>
        </thead>
        <tbody>
");
                EndContext();
#line 63 "C:\Users\denise.garcia\source\repos\DB_DeniseProject\HotelTransilvania\HotelTransilvania\Views\Reservation\Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
                BeginContext(1964, 103, true);
                WriteLiteral("                <tr style=\"vertical-align:middle;\">\r\n                    <td>\r\n                        ");
                EndContext();
                BeginContext(2068, 32, false);
#line 67 "C:\Users\denise.garcia\source\repos\DB_DeniseProject\HotelTransilvania\HotelTransilvania\Views\Reservation\Index.cshtml"
                   Write(item.Arrival.ToShortDateString());

#line default
#line hidden
                EndContext();
                BeginContext(2100, 79, true);
                WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
                EndContext();
                BeginContext(2180, 34, false);
#line 70 "C:\Users\denise.garcia\source\repos\DB_DeniseProject\HotelTransilvania\HotelTransilvania\Views\Reservation\Index.cshtml"
                   Write(item.Departure.ToShortDateString());

#line default
#line hidden
                EndContext();
                BeginContext(2214, 79, true);
                WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
                EndContext();
                BeginContext(2294, 52, false);
#line 73 "C:\Users\denise.garcia\source\repos\DB_DeniseProject\HotelTransilvania\HotelTransilvania\Views\Reservation\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.MainGuestFullName));

#line default
#line hidden
                EndContext();
                BeginContext(2346, 79, true);
                WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
                EndContext();
                BeginContext(2426, 47, false);
#line 76 "C:\Users\denise.garcia\source\repos\DB_DeniseProject\HotelTransilvania\HotelTransilvania\Views\Reservation\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.RoomCategory));

#line default
#line hidden
                EndContext();
                BeginContext(2473, 79, true);
                WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
                EndContext();
                BeginContext(2553, 43, false);
#line 79 "C:\Users\denise.garcia\source\repos\DB_DeniseProject\HotelTransilvania\HotelTransilvania\Views\Reservation\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.RoomCode));

#line default
#line hidden
                EndContext();
                BeginContext(2596, 79, true);
                WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
                EndContext();
                BeginContext(2676, 41, false);
#line 82 "C:\Users\denise.garcia\source\repos\DB_DeniseProject\HotelTransilvania\HotelTransilvania\Views\Reservation\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Status));

#line default
#line hidden
                EndContext();
                BeginContext(2717, 79, true);
                WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
                EndContext();
                BeginContext(2797, 56, false);
#line 85 "C:\Users\denise.garcia\source\repos\DB_DeniseProject\HotelTransilvania\HotelTransilvania\Views\Reservation\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ContactPersonFullName));

#line default
#line hidden
                EndContext();
                BeginContext(2853, 79, true);
                WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
                EndContext();
                BeginContext(2933, 47, false);
#line 88 "C:\Users\denise.garcia\source\repos\DB_DeniseProject\HotelTransilvania\HotelTransilvania\Views\Reservation\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.CreationDate));

#line default
#line hidden
                EndContext();
                BeginContext(2980, 31, true);
                WriteLiteral("\r\n                    </td>\r\n\r\n");
                EndContext();
#line 91 "C:\Users\denise.garcia\source\repos\DB_DeniseProject\HotelTransilvania\HotelTransilvania\Views\Reservation\Index.cshtml"
                     if (item.Status == Commom.Enums.ReservationStatusEnum.Reserved)
                    {

#line default
#line hidden
                BeginContext(3120, 58, true);
                WriteLiteral("                        <td>\r\n                            ");
                EndContext();
                BeginContext(3178, 77, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c8aae411c71a4552991bc39724486e99", async() => {
                    BeginContext(3245, 6, true);
                    WriteLiteral("Editar");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-reservationId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#line 94 "C:\Users\denise.garcia\source\repos\DB_DeniseProject\HotelTransilvania\HotelTransilvania\Views\Reservation\Index.cshtml"
                                                              WriteLiteral(item.ReservationId);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["reservationId"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-reservationId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["reservationId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3255, 93, true);
                WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n\r\n                            ");
                EndContext();
                BeginContext(3348, 357, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d93d133c6aa4f50b89f0f29a81f36e9", async() => {
                    BeginContext(3624, 72, true);
                    WriteLiteral("\r\n                                Cancelar\r\n                            ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Controller = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_8.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#line 99 "C:\Users\denise.garcia\source\repos\DB_DeniseProject\HotelTransilvania\HotelTransilvania\Views\Reservation\Index.cshtml"
                                                          WriteLiteral(item.ReservationId);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3705, 33, true);
                WriteLiteral("\r\n                        </td>\r\n");
                EndContext();
#line 103 "C:\Users\denise.garcia\source\repos\DB_DeniseProject\HotelTransilvania\HotelTransilvania\Views\Reservation\Index.cshtml"
                    }

#line default
#line hidden
                BeginContext(3761, 23, true);
                WriteLiteral("                </tr>\r\n");
                EndContext();
#line 105 "C:\Users\denise.garcia\source\repos\DB_DeniseProject\HotelTransilvania\HotelTransilvania\Views\Reservation\Index.cshtml"
            }

#line default
#line hidden
                BeginContext(3799, 32, true);
                WriteLiteral("        </tbody>\r\n    </table>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_10.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_10);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3838, 141, true);
            WriteLiteral("\r\n\r\n\r\n<br>\r\n<div class=\"form-group\">\r\n    <select type=\"number\" id=\"pageSize\" onchange=\"personalizedSearch()\" class=\"form-control\">\r\n        ");
            EndContext();
            BeginContext(3979, 33, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "89647bda70fd4d928dafb3e2baea4cca", async() => {
                BeginContext(3996, 7, true);
                WriteLiteral("Mostrar");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_11.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_11);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4012, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 115 "C:\Users\denise.garcia\source\repos\DB_DeniseProject\HotelTransilvania\HotelTransilvania\Views\Reservation\Index.cshtml"
         foreach (var item in ViewBag.RecordNumber)
        {
            

#line default
#line hidden
#line 117 "C:\Users\denise.garcia\source\repos\DB_DeniseProject\HotelTransilvania\HotelTransilvania\Views\Reservation\Index.cshtml"
             if (ViewBag.PageSize == @item)
            {

#line default
#line hidden
            BeginContext(4138, 16, true);
            WriteLiteral("                ");
            EndContext();
            BeginContext(4154, 54, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ac80b8c34036430fbedcd0aff5827965", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            BeginWriteTagHelperAttribute();
#line 119 "C:\Users\denise.garcia\source\repos\DB_DeniseProject\HotelTransilvania\HotelTransilvania\Views\Reservation\Index.cshtml"
                            WriteLiteral(item);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "label", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 119 "C:\Users\denise.garcia\source\repos\DB_DeniseProject\HotelTransilvania\HotelTransilvania\Views\Reservation\Index.cshtml"
AddHtmlAttributeValue("", 4192, item, 4192, 5, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4208, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 120 "C:\Users\denise.garcia\source\repos\DB_DeniseProject\HotelTransilvania\HotelTransilvania\Views\Reservation\Index.cshtml"
            }
            else
            {

#line default
#line hidden
            BeginContext(4258, 16, true);
            WriteLiteral("                ");
            EndContext();
            BeginContext(4274, 45, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5bbe4121c17b4570ad87dac8aa3c9c99", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#line 123 "C:\Users\denise.garcia\source\repos\DB_DeniseProject\HotelTransilvania\HotelTransilvania\Views\Reservation\Index.cshtml"
                   WriteLiteral(item);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "label", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 123 "C:\Users\denise.garcia\source\repos\DB_DeniseProject\HotelTransilvania\HotelTransilvania\Views\Reservation\Index.cshtml"
AddHtmlAttributeValue("", 4303, item, 4303, 5, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4319, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 124 "C:\Users\denise.garcia\source\repos\DB_DeniseProject\HotelTransilvania\HotelTransilvania\Views\Reservation\Index.cshtml"
            }

#line default
#line hidden
#line 124 "C:\Users\denise.garcia\source\repos\DB_DeniseProject\HotelTransilvania\HotelTransilvania\Views\Reservation\Index.cshtml"
             
        }

#line default
#line hidden
            BeginContext(4347, 121, true);
            WriteLiteral("    </select>\r\n    <span class=\"text-danger\"></span>\r\n</div>\r\n\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-md-8\">\r\n        ");
            EndContext();
            BeginContext(4469, 98, false);
#line 133 "C:\Users\denise.garcia\source\repos\DB_DeniseProject\HotelTransilvania\HotelTransilvania\Views\Reservation\Index.cshtml"
   Write(Html.PagedListPager(Model, page => Url.Action("Index", new { page, pageSize = ViewBag.PageSize })));

#line default
#line hidden
            EndContext();
            BeginContext(4567, 24, true);
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(4609, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 138 "C:\Users\denise.garcia\source\repos\DB_DeniseProject\HotelTransilvania\HotelTransilvania\Views\Reservation\Index.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
                BeginContext(4679, 4, true);
                WriteLiteral("    ");
                EndContext();
                BeginContext(4683, 55, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5f3a7f3a60434ed49b69b2f16ee7a2d0", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_12);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(4738, 1077, true);
                WriteLiteral(@"

    <script type=""text/javascript"" src=""https://cdn.jsdelivr.net/jquery/latest/jquery.min.js""></script>
    <script type=""text/javascript"" src=""https://cdn.jsdelivr.net/momentjs/latest/moment.min.js""></script>
    <script type=""text/javascript"" src=""https://cdn.jsdelivr.net/npm/daterangepicker/daterangepicker.min.js""></script>
    <link rel=""stylesheet"" type=""text/css"" href=""https://cdn.jsdelivr.net/npm/daterangepicker/daterangepicker.css"" />

    <script src=""http://code.jquery.com/jquery-1.9.1.js""></script>
    <script type=""text/javascript"" src=""https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.4.1/js/bootstrap-datepicker.min.js""></script>
    <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.4.1/css/bootstrap-datepicker3.css"" />

    <script src=""https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js""></script>
    <script src=""http://code.jquery.com/ui/1.11.0/jquery-ui.js""></script>
    <link rel=""stylesheet"" href=""http://co");
                WriteLiteral("de.jquery.com/ui/1.12.1/themes/base/jquery-ui.css\">\r\n");
                EndContext();
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<X.PagedList.PagedList<Commom.DTOs.ReservationDTO>> Html { get; private set; }
    }
}
#pragma warning restore 1591
