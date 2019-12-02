$(function () {

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
        labels: ["2014", "2015", "2016", "2017", "2018"],
        datasets: [
            {
                label: 'Total em R$',
                data: arrayGastosPorAno,
                backgroundColor: 'rgba(255, 213, 0, 0.5)',
                borderColor: 'rgba(255, 213, 0, 1)',
                borderWidth: 1,
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


    var gastoFuncaoData = {
        labels: ["Jan", "Fev", "Mar", "Abr", "Mai", "Jun", "Jul", "Ago", "Set", "Out", "Nov", "Dez"],
        datasets: [
            {
                type: 'bar',
                label: 'FG',
                backgroundColor: "rgba(255, 99, 132, 0.6)",
                data: [270946978, 265270477, 259593976, 256742847, 259584956, 316381087, 258843915, 262296307, 261617943, 258703222, 494129128, 360796812]
            }, {
                type: 'bar',
                label: 'FGR',
                backgroundColor: "rgba(54, 162, 235, 0.6)",
                data: [217595955, 205906630, 194217306, 193678954, 193456714, 223170396, 195257368, 195111004, 197300146, 193754003, 369077940, 261119501]
            }, {
                type: 'bar',
                label: 'DAS',
                backgroundColor: "rgba(255, 206, 86, 0.6)",
                data: [165821951, 161413654, 157005358, 156602871, 157233422, 196020591, 158591939, 159408100, 158890981, 157506191, 297741730, 190817801]
            },
            {
                type: 'bar',
                label: 'FPE',
                backgroundColor: "rgba(75, 192, 192, 0.6)",
                data: [214702540, 208528240, 202353940, 200779779, 201552278, 242259718, 202069238, 200935927, 202003550, 200684823, 387089472, 263394350]
            },
            {
                type: 'bar',
                label: 'FUC',
                backgroundColor: "rgba(153, 102, 255, 0.6)",
                data: [166209958, 163381419, 160552880, 160582200, 163134653, 207167840, 162951731, 167395152, 168056385, 166571367, 325078790, 256789559]
            }, {
                type: 'bar',
                label: 'OUTROS',
                backgroundColor: "rgba(45, 45, 255, 0.6)",
                data: [379429945, 366178996, 352928047, 358232906, 349238889, 419684998, 351556554, 349844227, 340299158, 343789195, 639976522, 465225655]
            }
        ]
    };

    var gastoFuncaoOptions = {
        scales: {
            yAxes: [{
                ticks: {
                    beginAtZero: true,
                    userCallback: function (value, index, values) {
                        return 'R$' + NumeroFormatado(value);
                    }
                },
                stacked: true
            }],
            xAxes: [{
                stacked: true
            }]
        },
        tooltips: {
            callbacks: {
                label: function (tooltipItem, chart) {
                    var label = tooltipItem.yLabel;
                    return chart.datasets[tooltipItem.datasetIndex].label + ': R$' + NumeroFormatado(label);
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


    var PieData = {
        datasets: [{
            data: arrayNumTopPartidos,
            backgroundColor: [
                'rgba(170, 68, 255, 0.8)',
                'rgba(153, 102, 255, 0.8)',
                'rgba(136, 149, 255, 0.8)',
                'rgba(169, 183, 255, 0.8)',
                'rgba(180, 223, 255, 0.8)'
            ],
        }],
        labels: arrayPartidos
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
        labels: datasNumerosAnalises,
        datasets: [
            {
                label: 'Relações',
                data: totalResultadosAnalisados,
                backgroundColor: 'rgba(148, 194, 255, 0.5)',
                borderColor: 'rgba(148, 194, 255, 1)',
                borderWidth: 1,
                fill: true,
                pointRadius: 5,
                pointHoverRadius: 7,
                pointHitRadius: 25,
                pointBackgroundColor: 'rgba(148, 194, 255, 0.8)',
            },
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
                label: "2015",
                data: totalResAnalisados2015,
                backgroundColor: 'rgba(254, 112, 150, 0.4)',
                borderColor: 'rgba(254, 112, 150, 1)',
                borderWidth: 2,
                fill: false,
                pointRadius: 5,
                pointHoverRadius: 7,
                pointHitRadius: 25,
                pointBackgroundColor: 'rgba(254, 112, 150, 0.8)',
            },
            {
                label: "2016",
                data: totalResAnalisados2016,
                backgroundColor: 'rgba(4, 126, 223, 0.4)',
                borderColor: 'rgba(4, 126, 223, 1)',
                borderWidth: 2,
                fill: false,
                pointRadius: 5,
                pointHoverRadius: 7,
                pointHitRadius: 25,
                pointBackgroundColor: 'rgba(4, 126, 223, 0.8)',
            },
            {
                label: "2017",
                data: totalResAnalisados2017,
                backgroundColor: 'rgba(7, 205, 174, 0.4)',
                borderColor: 'rgba(7, 205, 174, 1)',
                borderWidth: 2,
                fill: false,
                pointRadius: 5,
                pointHoverRadius: 7,
                pointHitRadius: 25,
                pointBackgroundColor: 'rgba(7, 205, 174, 0.8)',
            },
            {

                label: "2018",
                data: totalResAnalisados2018,
                backgroundColor: 'rgba(154, 85, 255, 0.4)',
                borderColor: 'rgba(154, 85, 255, 1)',
                borderWidth: 2,
                fill: true,
                pointRadius: 5,
                pointHoverRadius: 7,
                pointHitRadius: 25,
                pointBackgroundColor: 'rgba(154, 85, 255, 0.8)',
            },



        ]
    };

    var transpostoOptions = {
        plugins: {
            filler: {
                propagate: true
            }
        },
        legend: {
            display: true,
            position: 'bottom'
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
        tooltips: {
            callbacks: {
                label: function (tooltipItem, chart) {
                    var label = tooltipItem.yLabel;
                    return NumeroFormatado(label);
                }
            }
        },
        maintainAspectRatio: false
    };


    // Verifica a existancia dos canvas e aplica a API nos canvas selecionados
    if ($("#barChart").length) {
        var barChartCanvas = $("#barChart").get(0).getContext("2d");

        new Chart(barChartCanvas, {
            type: 'bar',
            data: data,
            options: options
        });
    }

    if ($("#gastoChart").length) {
        var lineChartCanvas = $("#gastoChart").get(0).getContext("2d");

        new Chart(lineChartCanvas, {
            type: 'bar',
            data: gastoData,
            options: gastoOptions
        });
    }

    if ($("#gastoFuncaoChart").length) {
        var lineChartCanvas = $("#gastoFuncaoChart").get(0).getContext("2d");

        new Chart(lineChartCanvas, {
            type: 'bar',
            data: gastoFuncaoData,
            options: gastoFuncaoOptions
        });
    }

    if ($("#pieChart").length) {
        var pieChartCanvas = $("#pieChart").get(0).getContext("2d");

        new Chart(pieChartCanvas, {
            type: 'pie',
            data: PieData,
            options: PieOptions
        });
    }

    if ($("#areaChart").length) {
        var areaChartCanvas = $("#areaChart").get(0).getContext("2d");

        new Chart(areaChartCanvas, {
            type: 'line',
            data: areaData,
            options: areaOptions
        });
    }

    if ($("#transpostoChart").length) {
        var areaChartCanvas = $("#transpostoChart").get(0).getContext("2d");

        new Chart(areaChartCanvas, {
            type: 'line',
            data: transpostoData,
            options: transpostoOptions
        });
    }

});