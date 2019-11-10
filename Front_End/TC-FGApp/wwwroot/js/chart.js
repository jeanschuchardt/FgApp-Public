$(function () {
    /* ChartJS
     * -------
     * Data and config for chartjs
     */
    'use strict';
    var data = {
        labels: ["2015", "2016", "2017", "2018"],
        datasets: [{
            label: 'FG',
            data: [6253, 6441, 6452, 5913],
            backgroundColor: 'rgba(255, 99, 132, 0.4)',
            borderColor: 'rgba(255,99,132,1)',
            borderWidth: 1,
            fill: false
        },
        {
            label: 'FGR',
            data: [4258, 4173, 3905, 3426],
            backgroundColor: 'rgba(54, 162, 235, 0.4)',
            borderColor: 'rgba(54, 162, 235, 1)',
            borderWidth: 1,
            fill: false
        },
        {
            label: 'DAS',
            data: [5083, 4634, 2791, 2347],
            backgroundColor: 'rgba(255, 206, 86, 0.4)',
            borderColor: 'rgba(255, 206, 86, 1)',
            borderWidth: 1,
            fill: false
        },
        {
            label: 'FPE',
            data: [0, 218, 1657, 2177],
            backgroundColor: 'rgba(75, 192, 192, 0.4)',
            borderColor: 'rgba(75, 192, 192, 1)',
            borderWidth: 1,
            fill: false
        },
        {
            label: 'FUC',
            data: [1766, 1906, 2005, 1933],
            backgroundColor: 'rgba(153, 102, 255, 0.4)',
            borderColor: 'rgba(153, 102, 255, 1)',
            borderWidth: 1,
            fill: false
        }]
    };
    var options = {
        scales: {
            yAxes: [{
                ticks: {
                    beginAtZero: true,
                    userCallback: function (value, index, values) {
                        return NumeroFormatado(value);
                    }
                }
            }]
        },
        tooltips: {
            callbacks: {
                label: function (tooltipItem, chart) {
                    var label = tooltipItem.yLabel;
                    return NumeroFormatado(label);
                }
            }
        },
        legend: {
            display: true,
            position: 'right'
        },
        elements: {
            point: {
                radius: 0
            }
        },
        maintainAspectRatio: false
    };

    var gastoData = {
        labels: ["2015", "2016", "2017", "2018", "2019"],
        datasets: [
            {
                label: 'Total em R$',
                data: [15132703247, 15945470761, 17486948219, 16621539654, 4188528584],
                backgroundColor: '#ffd50088',
                borderColor: '#ffd500',
                borderWidth: 1,
                fill: true,
                pointRadius: 5,
                pointHoverRadius: 7,
                pointHitRadius: 25,
                pointBackgroundColor: '#94c2ffCC',
            },
        ]
    };
    var gastoOptions = {
        scales: {
            yAxes: [{
                ticks: {
                    beginAtZero: true,
                    userCallback: function (value, index, values) {
                        return 'R$ ' + NumeroFormatado(value);
                    }
                }
            }]
        },
        tooltips: {
            callbacks: {
                label: function (tooltipItem, chart) {
                    var label = tooltipItem.yLabel;
                    return 'R$ ' + NumeroFormatado(label);
                }
            }
        },
        legend: {
            display: false
        },
        elements: {
            point: {
                radius: 0
            }
        },
        maintainAspectRatio: false
    };

    var PieData = {
        datasets: [{
            data: [3224, 2811, 2055, 1678, 1408],
            backgroundColor: [
                '#9A55FFAA',
                '#887dffAA',
                '#829cffAA',
                '#8bb7ffAA',
                '#a4cfffAA'
            ],
        }],
        labels: [
            'PT',
            'PSDB',
            'PMDB',
            'PDT',
            'PP'
        ]
    };
    var PieOptions = {
        responsive: true,
        animation: {
            animateScale: true,
            animateRotate: true
        },
        legend: {
            display: true,
            position: 'right'
        },
        maintainAspectRatio: false
    };

    var areaData = {
        labels: ["Jan/15", "Fev/15", "Mar/15", "Abr/15", "Mai/15", "Jun/15", "Jul/15", "Ago/15", "Set/15", "Out/15", "Nov/15", "Dez/15",
            "Jan/16", "Fev/16", "Mar/16", "Abr/16", "Mai/16", "Jun/16", "Jul/16", "Ago/16", "Set/16", "Out/16", "Nov/16", "Dez/16",
            "Jan/17", "Fev/17", "Mar/17", "Abr/17", "Mai/17", "Jun/17", "Jul/17", "Ago/17", "Set/17", "Out/17", "Nov/17", "Dez/17",
            "Jan/18", "Fev/18", "Mar/18", "Abr/18", "Mai/18", "Jun/18", "Jul/18", "Ago/18", "Set/18", "Out/18", "Nov/18", "Dez/18"],
        datasets: [
            {
                label: 'Relações',
                data: [23823, 23745, 23814, 23810, 23699, 23495, 23348, 23168, 23144, 23024, 22930, 22874,
                    22898, 22812, 22897, 22658, 22560, 22534, 22548, 22502, 22477, 22422, 22367, 22422,
                    22909, 23566, 23430, 22948, 23772, 23436, 23479, 23511, 23430, 23439, 23371, 23491,
                    22676, 22610, 22569, 22549, 22598, 22339, 22547, 22583, 22426, 22158, 22177, 22272],
                backgroundColor: '#94c2ff77',
                borderColor: '#94c2ff',
                borderWidth: 1,
                fill: true,
                pointRadius: 5,
                pointHoverRadius: 7,
                pointHitRadius: 25,
                pointBackgroundColor: '#94c2ffCC',
            },
            //{
            //    label: 'Servidores',
            //    data: [100161, 0, 99574, 99405, 99940, 98874, 100155, 100353, 99751, 98973, 98999, 99488],
            //    backgroundColor: '#90caf977',
            //    borderColor: '#90caf9',
            //    borderWidth: 1,
            //    fill: true,
            //    pointRadius: 5,
            //    pointHoverRadius: 7,
            //    pointHitRadius: 25,
            //    pointBackgroundColor: '#90caf9CC',
            //}
        ]
    };

    var areaOptions = {
        plugins: {
            filler: {
                propagate: true
            }
        },
        scales: {
            yAxes: [{
                ticks: {
                    userCallback: function (value, index, values) {
                        return NumeroFormatado(value);
                    }
                }
            }]
        },
        legend: {
            display: false
        },
        tooltips: {
            callbacks: {
                label: function (tooltipItem, chart) {
                    var label = tooltipItem.yLabel;
                    return NumeroFormatado(label);
                }
            }
        },
        maintainAspectRatio: false
    }

    var transpostoData = {
        labels: ["Jan", "Fev", "Mar", "Abr", "Mai", "Jun", "Jul", "Ago", "Set", "Out", "Nov", "Dez"],
        datasets: [
            {
                label: "2018",
                data: [22676, 22610, 22569, 22549, 22598, 22339, 22547, 22583, 22426, 22158, 22177, 22272],
                backgroundColor: '#9a55ff55',
                borderColor: '#9a55ff',
                borderWidth: 2,
                fill: false,
                pointRadius: 5,
                pointHoverRadius: 7,
                pointHitRadius: 25,
                pointBackgroundColor: '#9a55ffCC',
            },
            {
                label: "2017",
                data: [22909, 23566, 23430, 22948, 23772, 23436, 23479, 23511, 23430, 23439, 23371, 23491],
                backgroundColor: '#07cdae55',
                borderColor: '#07cdae',
                borderWidth: 2,
                fill: false,
                pointRadius: 5,
                pointHoverRadius: 7,
                pointHitRadius: 25,
                pointBackgroundColor: '#07cdaeCC',
            },
            {
                label: "2016",
                data: [22898, 22812, 22897, 22658, 22560, 22534, 22548, 22502, 22477, 22422, 22367, 22422,],
                backgroundColor: '#047edf55',
                borderColor: '#047edf',
                borderWidth: 2,
                fill: false,
                pointRadius: 5,
                pointHoverRadius: 7,
                pointHitRadius: 25,
                pointBackgroundColor: '#047edfCC',
            },
            {
                label: "2015",
                data: [23823, 23745, 23814, 23810, 23699, 23495, 23348, 23168, 23144, 23024, 22930, 22874],
                backgroundColor: '#fe709655',
                borderColor: '#fe7096',
                borderWidth: 2,
                fill: false,
                pointRadius: 5,
                pointHoverRadius: 7,
                pointHitRadius: 25,
                pointBackgroundColor: '#fe7096CC',
            }
        ]
    };

    var transpostoOptions = {
        plugins: {
            filler: {
                propagate: true
            }
        },
        legend: {
            display: false
        },
        tooltips: {
            callbacks: {
                label: function (tooltipItem, chart) {
                    var label = tooltipItem.yLabel;
                    return NumeroFormatado(label);
                }
            }
        },
        maintainAspectRatio: false
    }

    // Get context with jQuery - using jQuery's .get() method.
    if ($("#barChart").length) {
        var barChartCanvas = $("#barChart").get(0).getContext("2d");
        // This will get the first returned node in the jQuery collection.
        var barChart = new Chart(barChartCanvas, {
            type: 'bar',
            data: data,
            options: options
        });
    }

    if ($("#gastoChart").length) {
        var lineChartCanvas = $("#gastoChart").get(0).getContext("2d");
        var lineChart = new Chart(lineChartCanvas, {
            type: 'bar',
            data: gastoData,
            options: gastoOptions
        });
    }

    if ($("#pieChart").length) {
        var pieChartCanvas = $("#pieChart").get(0).getContext("2d");
        var pieChart = new Chart(pieChartCanvas, {
            type: 'pie',
            data: PieData,
            options: PieOptions
        });
    }

    if ($("#areaChart").length) {
        var areaChartCanvas = $("#areaChart").get(0).getContext("2d");
        var areaChart = new Chart(areaChartCanvas, {
            type: 'line',
            data: areaData,
            options: areaOptions
        });
    }

    if ($("#transpostoChart").length) {
        var areaChartCanvas = $("#transpostoChart").get(0).getContext("2d");
        var areaChart = new Chart(areaChartCanvas, {
            type: 'line',
            data: transpostoData,
            options: transpostoOptions
        });
    }


    function NumeroFormatado(value) {
        value = value.toString();
        value = value.split(/(?=(?:...)*$)/);

        value = value.join('.');
        return value;
    }

});