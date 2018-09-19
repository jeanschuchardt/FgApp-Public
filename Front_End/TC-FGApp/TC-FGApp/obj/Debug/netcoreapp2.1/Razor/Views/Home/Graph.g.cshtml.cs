#pragma checksum "C:\Users\João\Documents\GitHub\FGApp\Front_End\TC-FGApp\TC-FGApp\Views\Home\Graph.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "220741fc326948d822d586f23d38bd0616ac7919"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Graph), @"mvc.1.0.view", @"/Views/Home/Graph.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Graph.cshtml", typeof(AspNetCore.Views_Home_Graph))]
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
#line 1 "C:\Users\João\Documents\GitHub\FGApp\Front_End\TC-FGApp\TC-FGApp\Views\_ViewImports.cshtml"
using TC_FGApp;

#line default
#line hidden
#line 2 "C:\Users\João\Documents\GitHub\FGApp\Front_End\TC-FGApp\TC-FGApp\Views\_ViewImports.cshtml"
using TC_FGApp.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"220741fc326948d822d586f23d38bd0616ac7919", @"/Views/Home/Graph.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4202f3bcc647d81bd077b12858b6b8e016a4c41d", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Graph : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\João\Documents\GitHub\FGApp\Front_End\TC-FGApp\TC-FGApp\Views\Home\Graph.cshtml"
  
    ViewData["Title"] = "Graph";

#line default
#line hidden
            BeginContext(43, 2767, true);
            WriteLiteral(@"
<script type=""text/javascript"">
    google.charts.load('current', { packages: ['corechart', 'bar'] });
    google.charts.setOnLoadCallback(drawChart);
    google.charts.setOnLoadCallback(drawMultSeries);

    function drawChart() {
        var data = new google.visualization.DataTable();
        data.addColumn('string', 'Element');
        data.addColumn('number', 'Percentage');
        data.addRows([
            ['PSDB', 0.56],
            ['PT', 0.24],
            ['MDB', 0.15],
            ['PV', 0.05]
        ]);

        var chart = new google.visualization.PieChart(document.getElementById('partidosPizza'));
        chart.draw(data, null);
    }

    function drawMultSeries() {
        var data = new google.visualization.DataTable();
        data.addColumn('date', 'Ano');
        data.addColumn('number', 'PSDB');
        data.addColumn('number', 'PT');

        data.addRows([
            [new Date(2009, 0), 12, 15.5],
            [new Date(2010, 0), 15.3, 12.9],
           ");
            WriteLiteral(@" [new Date(2011, 0), 12.6, 16.3],
            [new Date(2012, 0), 10.9, 19],
            [new Date(2013, 0), 9.8, 15.6],
            [new Date(2014, 0), 13.6, 14.3],
            [new Date(2015, 0), 14.3, 8.4],
            [new Date(2016, 0), 17.9, 4.4],
            [new Date(2017, 0), 19.6, 7.1],
            [new Date(2018, 0), 18.5, 10.2]
        ]);

        var options = {
            title: 'PT x PSDB',
            hAxis: {
                title: 'Ano',
                format: 'yyyy'
            },
            vAxis: {
                title: '%'
            }
        };

        var chart = new google.visualization.ColumnChart(
            document.getElementById('comparaPartido'));

        chart.draw(data, options);
    }

</script>



<div class=""row"">
    <div class=""col-lg-8"">
        <div class=""card mb-3"">
            <div class=""card-header"">
                <i class=""fas fa-chart-bar""></i>
                Mulheres em Cargos Públicos
            </div>
       ");
            WriteLiteral(@"     <div class=""card-body"">
                <div id=""comparaPartido""style=""height:230px; width:100%;""></div>
            </div>
            <div class=""card-footer small text-muted"">Atualizado 07/09/2018 às 10:20 AM</div>
        </div>
    </div>
    <div class=""col-lg-4"">
        <div class=""card mb-3"">
            <div class=""card-header"">
                <i class=""fas fa-chart-pie""></i>
                Partidos
            </div>
            <div class=""card-body"">
                <div id=""partidosPizza"" style=""height:230px; width:100%;""></div>
            </div>
            <div class=""card-footer small text-muted"">Atualizado 07/09/2018 às 10:20 AM</div>
        </div>
    </div>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
