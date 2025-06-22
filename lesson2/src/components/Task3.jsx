import React from "react";


             

function updateTime() {
    const now = new Date();
    const currentTime = now.toLocaleTimeString();
    document.getElementById('timeDisplay').innerText = currentTime;
}

setInterval(updateTime, 1000); 

export default function Time(props) {
    
    return (
        <div className="ContainerTask1">
            <div className="TextT1">
                <span id="timeDisplay"></span>
            </div>
        </div>
    );
}