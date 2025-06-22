export default function CityInfoTask1() {
const city = {
    name: 'Baku',
    country: 'Azerbaijan',
    establishmentYear: "Undefined",
};

return (
    <div className="CityInfoContainerT1">
        <div className="CityInfoTextT1">
            <h1>City:{city.name}</h1>
            <h1>County:{city.country}</h1>
            <h1>Est Year:{city.establishmentYear}</h1>

        </div>
    <h2>Landmarks</h2>
    <div className="landmarksT1">
        <img src="https://www.azal.az/_next/static/media/Background_d3887632a5.6ae79313.png" alt="" />
        <img src="https://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Maiden_tower_IMG_8521.jpg/500px-Maiden_tower_IMG_8521.jpg" alt="" />
    </div>
    </div>
);
}
