function rotateArrow(code, guessedCoordinate, coordinate) {
    const arrow = document.getElementById(code).getElementsByClassName('arrow')[0];

    const angle = calculateAngle();

    arrow.style.transform = `rotate(${angle - 90}deg)`;

    function calculateAngle() {
        const latitude = coordinate.latitude - guessedCoordinate.latitude
        const longitude = coordinate.longitude - guessedCoordinate.longitude

        return Math.atan2(longitude, latitude) * 180 / Math.PI;
    }
}
