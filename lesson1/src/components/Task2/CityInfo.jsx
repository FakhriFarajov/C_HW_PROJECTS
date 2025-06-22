import React from 'react'; // Import React to use React.Component

export default class CityInfoTask1 extends React.Component {
  constructor(props) {
    super(props); 
    this.state = {
      city: {
        name: 'Baku',
        country: 'Azerbaijan',
        establishmentYear: "5th century AD",
      },
    };
  }

  render() {
    const { city } = this.state;

    return (
      <div className="CityInfoContainerT1">
        <div className="CityInfoTextT1">
          <h1>City: {city.name}</h1>
          <h1>Country: {city.country}</h1>
          <h1>Est Year: {city.establishmentYear}</h1>
        </div>
        <h2>Landmarks</h2>
        <div className="landmarksT1">
          <img src="https://www.azal.az/_next/static/media/Background_d3887632a5.6ae79313.png" alt="Flame Towers in Baku" />
          <img src="https://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Maiden_tower_IMG_8521.jpg/500px-Maiden_tower_IMG_8521.jpg" alt="Maiden Tower in Baku" />
        </div>
      </div>
    );
  }
}