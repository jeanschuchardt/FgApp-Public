$(function () {
    /* ChartJS
     * -------
     * Data and config for chartjs
     */
    'use strict';
    var data = {
        labels: ["2015", "2016", "2017", "2018"],
        datasets: [{
            label: 'Ocupantes-FG',
            data: [6253, 6441, 6452, 5913],
            backgroundColor: 'rgba(255, 99, 132, 0.4)',
            borderColor: 'rgba(255,99,132,1)',
            borderWidth: 1,
            fill: false
        },
        {
            label: 'Ocupantes-FGR',
            data: [4258, 4173, 3905, 3426],
            backgroundColor: 'rgba(54, 162, 235, 0.4)',
            borderColor: 'rgba(54, 162, 235, 1)',
            borderWidth: 1,
            fill: false
        },
        {
            label: 'Ocupantes-DAS',
            data: [5083, 4634, 2791, 2347],
            backgroundColor: 'rgba(255, 206, 86, 0.4)',
            borderColor: 'rgba(255, 206, 86, 1)',
            borderWidth: 1,
            fill: false
        },
        {
            label: 'Ocupantes-FPE',
            data: [0, 218, 1657, 2177],
            backgroundColor: 'rgba(75, 192, 192, 0.4)',
            borderColor: 'rgba(75, 192, 192, 1)',
            borderWidth: 1,
            fill: false
        },
        {
            label: 'Ocupantes-FUC',
            data: [1766, 1906, 2005, 1933],
            backgroundColor: 'rgba(153, 102, 255, 0.4)',
            borderColor: 'rgba(153, 102, 255, 1)',
            borderWidth: 1,
            fill: false
        }]
    };
    var multiLineData = {
        labels: ["Red", "Blue", "Yellow", "Green", "Purple", "Orange"],
        datasets: [{
            label: 'Dataset 1',
            data: [12, 19, 3, 5, 2, 3],
            borderColor: [
                '#587ce4'
            ],
            borderWidth: 2,
            fill: false
        },
        {
            label: 'Dataset 2',
            data: [5, 23, 7, 12, 42, 23],
            borderColor: [
                '#ede190'
            ],
            borderWidth: 2,
            fill: false
        },
        {
            label: 'Dataset 3',
            data: [15, 10, 21, 32, 12, 33],
            borderColor: [
                '#f44252'
            ],
            borderWidth: 2,
            fill: false
        }
        ]
    };
    var options = {
        scales: {
            yAxes: [{
                ticks: {
                    beginAtZero: true
                }
            }]
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
    var doughnutPieData = {
        datasets: [{
            data: [3224, 2811, 2055, 1678, 1408],
            backgroundColor: [
                'rgba(255, 99, 132, 0.5)',
                'rgba(54, 162, 235, 0.5)',
                'rgba(255, 206, 86, 0.5)',
                'rgba(75, 192, 192, 0.5)',
                'rgba(153, 102, 255, 0.5)'
            ],
            borderColor: [
                'rgba(255,99,132,1)',
                'rgba(54, 162, 235, 1)',
                'rgba(255, 206, 86, 1)',
                'rgba(75, 192, 192, 1)',
                'rgba(153, 102, 255, 1)'
            ],
        }],

        // These labels appear in the legend and in the tooltips when hovering different arcs
        labels: [
            'PT',
            'PSDB',
            'PMDB',
            'PDT',
            'PP'
        ]
    };
    var doughnutPieOptions = {
        responsive: true,
        animation: {
            animateScale: true,
            animateRotate: true
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
                backgroundColor: '#fe709677',
                borderColor: '#fe7096',
                borderWidth: 1,
                fill: true,
                pointRadius: 5,
                pointHoverRadius: 7,
                pointHitRadius: 25,
                pointBackgroundColor: '#fe7096CC',
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
        maintainAspectRatio: false
    }

    var multiAreaData = {
        labels: ["Jan", "Fev", "Mar", "Abr", "Mai", "Jun", "Jul", "Ago", "Set", "Out", "Nov", "Dez"],
        datasets: [{
            label: 'Facebook',
            data: [8, 11, 13, 15, 12, 13, 16, 15, 13, 19, 11, 14],
            borderColor: ['rgba(255, 99, 132, 0.5)'],
            backgroundColor: ['rgba(255, 99, 132, 0.5)'],
            borderWidth: 1,
            fill: true
        },
        {
            label: 'Twitter',
            data: [7, 17, 12, 16, 14, 18, 16, 12, 15, 11, 13, 9],
            borderColor: ['rgba(54, 162, 235, 0.5)'],
            backgroundColor: ['rgba(54, 162, 235, 0.5)'],
            borderWidth: 1,
            fill: true
        },
        {
            label: 'Linkedin',
            data: [6, 14, 16, 20, 12, 18, 15, 12, 17, 19, 15, 11],
            borderColor: ['rgba(255, 206, 86, 0.5)'],
            backgroundColor: ['rgba(255, 206, 86, 0.5)'],
            borderWidth: 1,
            fill: true
        }
        ]
    };

    var multiAreaOptions = {
        plugins: {
            filler: {
                propagate: true
            }
        },
        elements: {
            point: {
                radius: 0
            }
        },
        scales: {
            xAxes: [{
                gridLines: {
                    display: false
                }
            }],
            yAxes: [{
                gridLines: {
                    display: false
                }
            }]
        },
        maintainAspectRatio: false
    }

    var scatterChartData = {
        datasets: [{
            label: 'First Dataset',
            data: [{
                x: -10,
                y: 0
            },
            {
                x: 0,
                y: 3
            },
            {
                x: -25,
                y: 5
            },
            {
                x: 40,
                y: 5
            }
            ],
            backgroundColor: [
                'rgba(255, 99, 132, 0.2)'
            ],
            borderColor: [
                'rgba(255,99,132,1)'
            ],
            borderWidth: 1
        },
        {
            label: 'Second Dataset',
            data: [{
                x: 10,
                y: 5
            },
            {
                x: 20,
                y: -30
            },
            {
                x: -25,
                y: 15
            },
            {
                x: -10,
                y: 5
            }
            ],
            backgroundColor: [
                'rgba(54, 162, 235, 0.2)',
            ],
            borderColor: [
                'rgba(54, 162, 235, 1)',
            ],
            borderWidth: 1
        }
        ]
    }

    var scatterChartOptions = {
        scales: {
            xAxes: [{
                type: 'linear',
                position: 'bottom'
            }]
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

    if ($("#lineChart").length) {
        var lineChartCanvas = $("#lineChart").get(0).getContext("2d");
        var lineChart = new Chart(lineChartCanvas, {
            type: 'line',
            data: data,
            options: options
        });
    }

    if ($("#linechart-multi").length) {
        var multiLineCanvas = $("#linechart-multi").get(0).getContext("2d");
        var lineChart = new Chart(multiLineCanvas, {
            type: 'line',
            data: multiLineData,
            options: options
        });
    }

    if ($("#areachart-multi").length) {
        var multiAreaCanvas = $("#areachart-multi").get(0).getContext("2d");
        var multiAreaChart = new Chart(multiAreaCanvas, {
            type: 'line',
            data: multiAreaData,
            options: multiAreaOptions
        });
    }

    if ($("#doughnutChart").length) {
        var doughnutChartCanvas = $("#doughnutChart").get(0).getContext("2d");
        var doughnutChart = new Chart(doughnutChartCanvas, {
            type: 'doughnut',
            data: doughnutPieData,
            options: doughnutPieOptions
        });
    }

    if ($("#pieChart").length) {
        var pieChartCanvas = $("#pieChart").get(0).getContext("2d");
        var pieChart = new Chart(pieChartCanvas, {
            type: 'pie',
            data: doughnutPieData,
            options: doughnutPieOptions
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

    if ($("#scatterChart").length) {
        var scatterChartCanvas = $("#scatterChart").get(0).getContext("2d");
        var scatterChart = new Chart(scatterChartCanvas, {
            type: 'scatter',
            data: scatterChartData,
            options: scatterChartOptions
        });
    }

    if ($("#browserTrafficChart").length) {
        var doughnutChartCanvas = $("#browserTrafficChart").get(0).getContext("2d");
        var doughnutChart = new Chart(doughnutChartCanvas, {
            type: 'doughnut',
            data: browserTrafficData,
            options: doughnutPieOptions
        });
    }
});