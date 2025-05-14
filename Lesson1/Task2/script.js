let openButton = document.getElementById("OpenButton")


let modal = document.getElementById("Modal-window")

openButton.onclick = function(){
    modal.style.display = "block";
}


let closeModel = document.getElementById("Close")

closeModel.onclick = function(){
    modal.style.display = "none";
}

