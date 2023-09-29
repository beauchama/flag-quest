function rotateArrow(code, guessedCoordinate, coordinate) {
    const arrow = document.getElementById(code).getElementsByClassName('arrow')[0];

    console.log(code);
    console.log(guessedCoordinate);
    console.log(coordinate);

    const angle = calculateAngle();
    console.log(angle);
    arrow.style.transform = `rotate(${angle - 90}deg)`;

    function calculateAngle() {
        const latitude = coordinate.latitude - guessedCoordinate.latitude
        const longitude = coordinate.longitude - guessedCoordinate.longitude

        console.log(latitude);
        console.log(longitude);

        return Math.atan2(longitude, latitude) * 180 / Math.PI;
    }
}
