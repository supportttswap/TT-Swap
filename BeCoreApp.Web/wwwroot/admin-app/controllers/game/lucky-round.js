var LuckyRoundController = function () {
    this.initialize = function () {
        registerEvents();
        registerControl();
    }

    function registerControl() {


    }

    var registerEvents = function () {

        $("#spin_button").on('click', function (e) {
            startSpin();
        });

        $("#reset_button").on('click', function (e) {
            resetWheel();
        });
    }

    var theWheel = new Winwheel({
        'outerRadius': 156,
        'innerRadius': 58,
        'textFontSize': 14,
        'textFontWeight': 800,
        'responsive': true,
        'textMargin': 10,
        'textDirection': 'reversed',
        'textAlignment': 'inner',
        'numSegments': 10,
        'segments':
            [
                { 'fillStyle': '#3cb878', 'text': '50 TT-SWAP' },
                { 'fillStyle': '#f6989d', 'text': '500 TT-SWAP' },
                { 'fillStyle': '#00aef0', 'text': '1000 TT-SWAP' },
                { 'fillStyle': '#f26522', 'text': '3000 TT-SWAP' },
                { 'fillStyle': '#151521', 'text': 'Good Luck', 'textFillStyle': '#ffffff' },
                { 'fillStyle': '#e70697', 'text': '5000 TT-SWAP' },
                { 'fillStyle': '#fff200', 'text': '10000 TT-SWAP' },
                { 'fillStyle': '#f6989d', 'text': 'TICKET' },
                { 'fillStyle': '#ffc107', 'textFontSize': 16, 'text': '0.5 BNB' },
                { 'fillStyle': '#ffeb3b', 'textFontSize': 18, 'text': '1 BNB' }
            ],
        'animation': {
            'type': 'spinToStop',
            'duration': 10,
            'spins': 10,
            'callbackFinished': alertPrize,
            'callbackSound': playSound,
            'soundTrigger': 'pin'
        },
        'pins': {
            'number': 10,
            'fillStyle': 'hsl(54deg 100% 50%)',
            'outerRadius': 6,
            'responsive': true,
        }
    });

    var audio = new Audio('/Winwheel/examples/wheel_of_fortune/tick.mp3');

    function playSound() {
        audio.pause();
        audio.currentTime = 0;
        audio.play();
    }

    var wheelSpinning = false;

    function startSpin() {

        if (wheelSpinning == false) {

            $.ajax({
                type: "POST",
                url: '/Admin/Game/LuckyRoundResult',
                dataType: "json",
                data: {},
                beforeSend: function () {
                },
                success: function (response) {
                    if (response.Success) {

                        document.getElementById('spin_button').src = "/Winwheel/examples/wheel_of_fortune/spin_off.png";
                        document.getElementById('spin_button').className = "";

                        let stopAt = theWheel.getRandomForSegment(response.Data);

                        theWheel.animation.stopAngle = stopAt;

                        theWheel.startAnimation();

                        wheelSpinning = true;
                    }
                    else {
                        be.error('Buy TT-SWAP', response.Message);
                    }
                },
                error: function (message) {
                    be.notify(`${message.responseText}`, 'error');
                }
            });

        }
    }

    function resetWheel() {
        if (wheelSpinning == false) {
            theWheel.stopAnimation(false);
            theWheel.rotationAngle = 0;
            theWheel.draw();

            //wheelSpinning = false;

            document.getElementById('spin_button').src = "/Winwheel/examples/wheel_of_fortune/spin_on.png";
        }
    }

    // -------------------------------------------------------
    // Called when the spin animation has finished by the callback feature of the wheel because I specified callback in the parameters.
    // -------------------------------------------------------
    function alertPrize(indicatedSegment) {
        wheelSpinning = false;

        // Just alert to the user what happened.
        // In a real project probably want to do something more interesting than this with the result.
        if (indicatedSegment.text == 'LOOSE TURN') {
            alert('Sorry but you loose a turn.');
        } else if (indicatedSegment.text == 'BANKRUPT') {
            alert('Oh no, you have gone BANKRUPT!');
        } else {
            alert("You have won " + indicatedSegment.text);
        }
    }
}