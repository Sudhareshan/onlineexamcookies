function startCountdown() {
    var countdownElement = document.getElementById("countdown");
    var countdown = 30; // Initial countdown time in seconds

    function updateCountdown() {
        countdown--;
        countdownElement.textContent = countdown;

        if (countdown <= 0) {
            // Time's up! Submit the answer
            document.querySelector("form").submit();
        }
    }

    // Start the countdown timer
    var timerInterval = setInterval(updateCountdown, 1000);
}

