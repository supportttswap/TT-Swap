var HomeController = function () {
    this.initialize = function () {
        tradingviewWidget();
        registerEvents();
    }

    function registerEvents() {
        google.charts.load("current", { packages: ["corechart"] });
        google.charts.setOnLoadCallback(drawChart);
    };

    function drawChart() {
        debugger;
        var seedRoundTotal = parseFloat($("#SeedRoundTotal").val());
        var seedRoundDistributedToken = parseFloat($("#SeedRoundDistributedToken").val());
        var seedRoundRemaining = seedRoundTotal - seedRoundDistributedToken;
        if (seedRoundDistributedToken > seedRoundTotal) {
            seedRoundDistributedToken = seedRoundTotal;
            seedRoundRemaining = 0;
        }
        var data1 = google.visualization.arrayToDataTable([
            ['Task', 'Hours per Day'],
            ['Distributed', seedRoundDistributedToken],
            ['Remaining', seedRoundRemaining]
        ]);

        var privateSaleTotal = parseFloat($("#PrivateSaleTotal").val());
        var privateSaleDistributedToken = parseFloat($("#PrivateSaleDistributedToken").val());
        var privateSaleRemaining = privateSaleTotal - privateSaleDistributedToken;
        if (privateSaleDistributedToken > privateSaleTotal) {
            privateSaleDistributedToken = privateSaleTotal;
            privateSaleRemaining = 0;
        }
        var data2 = google.visualization.arrayToDataTable([
            ['Task', 'Hours per Day'],
            ['Distributed', privateSaleDistributedToken],
            ['Remaining', privateSaleRemaining]
        ]);

        var preSaleTotal = parseFloat($("#PreSaleTotal").val());
        var preSaleDistributedToken = parseFloat($("#PreSaleDistributedToken").val());
        var preSaleSaleRemaining = preSaleTotal - preSaleDistributedToken;
        if (preSaleDistributedToken > preSaleTotal) {
            preSaleDistributedToken = preSaleTotal;
            preSaleSaleRemaining = 0;
        }
        var data3 = google.visualization.arrayToDataTable([
            ['Task', 'Hours per Day'],
            ['Distributed', preSaleDistributedToken],
            ['Remaining', preSaleSaleRemaining]
        ]);

        var options = {
            legend: {
                position: 'bottom',
                textStyle: {
                    color: 'white'
                }
            },
            title: '',
            titleTextStyle: {
                color: 'white',
                fontSize: 12,
                bold: true
            },
            slices: { 0: { color: '#11941b' }, 1: { color: '#8a0b0b' } },
            pieSliceBorderColor: '#1e1e2d',
            pieHole: 0.5,
            backgroundColor: '#151521'
        };

        options.title = 'Seed Round 2500000TTS';
        var chart = new google.visualization.PieChart(document.getElementById('donutchart1'));
        chart.draw(data1, options);

        options.title = 'Private Sale 2500000TTS';
        var chart2 = new google.visualization.PieChart(document.getElementById('donutchart2'));
        chart2.draw(data2, options);

        options.title = 'PreSale 2500000TTS';
        var chart3 = new google.visualization.PieChart(document.getElementById('donutchart3'));
        chart3.draw(data3, options);
    }

    function tradingviewWidget() {
        var data = {
            'symbols': [
                {
                    'description': 'BTC/USDT',
                    'proName': 'BINANCE:BTCUSDT'
                },
                {
                    'description': 'ETH/USDT',
                    'proName': 'BINANCE:ETHUSDT'
                },
                {
                    'description': 'BNB/USDT',
                    'proName': 'BINANCE:BNBUSDT'
                },
                {
                    'description': 'TRX/USDT',
                    'proName': 'BINANCE:TRXUSDT'
                },
                {
                    'description': 'DOGE/USDT',
                    'proName': 'DOGE'
                }
            ],
            'showSymbolLogo': true,
            'colorTheme': 'dark',
            'isTransparent': true,
            'displayMode': 'regular',
            'locale': 'en',
            'container_id': 'tradingview_0d214'
        };
        const script = document.createElement('script');
        script.src = 'https://s3.tradingview.com/external-embedding/embed-widget-ticker-tape.js'
        script.async = true;
        script.innerHTML = JSON.stringify(data);

        document.getElementById("ticker-tape").appendChild(script);
    }
}
