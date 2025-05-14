let button = document.getElementById("Next");
let green = document.getElementById("green");
let yellow = document.getElementById("yellow");
let red = document.getElementById("red");

button.onclick = function() {
    if (green.style.backgroundColor === "gray" &&
        yellow.style.backgroundColor === "gray" &&
        red.style.backgroundColor === "red") {
        green.style.backgroundColor = "green";
        red.style.backgroundColor = "gray";

    }
    else if(
        green.style.backgroundColor === "green" &&
        yellow.style.backgroundColor === "gray" &&
        red.style.backgroundColor === "gray"
    ){
        green.style.backgroundColor = "gray";
        yellow.style.backgroundColor = "yellow";
    }
    else if(
        green.style.backgroundColor === "gray" &&
        yellow.style.backgroundColor === "yellow" &&
        red.style.backgroundColor === "gray"
    ){

        yellow.style.backgroundColor = "gray";
        red.style.backgroundColor = "red";
    }
};