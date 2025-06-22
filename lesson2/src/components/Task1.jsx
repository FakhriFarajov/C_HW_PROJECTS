import React from "react";



export default function Movie(props) {
    return (
        <div className="ContainerTask1">
            <div className="TextT1">
            <h1>Name {props.name}</h1>                
            <h1>Auhtor {props.author}</h1>                
            <h1>Year {props.year}</h1>        
            </div>
            <img src="https://avatars.mds.yandex.net/get-kinopoisk-image/10671298/9d781c44-1351-4818-ad9c-065911a120c4/600x900" alt="" />
        </div>
    );
}