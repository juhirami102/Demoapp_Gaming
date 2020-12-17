if (!Highcharts.theme) {
    Highcharts.setOptions({
        colors: ['#08cefb', '#02adf5 ', '#999999'],
        title: {
            style: {
                color: 'silver'
            }
        },
        tooltip: {
            style: {
                color: 'silver'
            }
        }
    });
}

/**
* In the chart render event, add icons on top of the circular shapes
*/
Highcharts.chart('outcomation-score', {

    chart: {
        backgroundColor: 'none',
        type: 'solidgauge',
        height: '70%'
    },

    title: {
        text: '',
        style: {
            fontSize: '10px'
        }
    },

    tooltip: {
        enabled: true,
    },

    pane: {
        startAngle: 0,
        endAngle: 360,
        pointFormat: '{series.name}<br><span style="font-size:1em; color: #777777; font-weight: normal">{point.y}%</span>',
        background: [{ // Track for Move
            outerRadius: '110%',
            innerRadius: '100%',
            backgroundColor: Highcharts.Color(Highcharts.getOptions().colors[2])
                .setOpacity(0.3)
                .get(),
            borderWidth: 0
        }]
    },

    yAxis: {
        min: 0,
        max: 100,
        lineWidth: 0,
        tickPositions: []
    },

    plotOptions: {
        solidgauge: {
            dataLabels: {
                enabled: true
            },
            linecap: 'round',
            stickyTracking: false,
            rounded: true
        }
    },
    credits: {
        enabled: false
    },

    series: [{
        name: '<div style="label-graph"><span style="font-size:10px;color:#999;font-weight: normal; text-anchor:middle' + '">Reach Out</span><br/>' + '<span style="font-size:10px;color:#999;font-weight: normal;text-anchor:middle">Weekly Progress</span>' +
                   '</div>',
        data: [{
            color: Highcharts.getOptions().colors[0],
            radius: '110%',
            innerRadius: '100%',
            y: 80
        }],
        dataLabels: {
            enabled: true,
            pointFormat: '{series.name}<br><span style="font-size:1.2em; color: #999999; font-weight: bold;text-anchor:middle;">{point.y}%</span>',
            positioner: function (labelWidth) {
                return {
                    x: (this.chart.chartWidth - labelWidth) / 2,
                    y: (this.chart.plotHeight / 2) + 50,
                };
            },
            style: {
                fontSize: '10px'
            },
            borderWidth: 0,
            backgroundColor: 'none',
            shadow: false,
        }
    }]
});