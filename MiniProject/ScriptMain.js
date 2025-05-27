const userStr = localStorage.getItem("user");
const user = JSON.parse(userStr);
console.log(user);

document.addEventListener("DOMContentLoaded", () => {
  let initialText = document.getElementById("Username").textContent;
  document.getElementById("Username").textContent =  initialText + " " + user.username;
  getNearbyCityWeather(user.lat, user.long);
})


document.getElementById("ChooseTheLocationButton").addEventListener("click", () => {
  document.getElementById("Maps").style.display = "block";
  document.getElementById ("weather-container").style.display = "none";
});



let map;
let marker = null; 

function initMap() {
  map = new google.maps.Map(document.getElementById("map"), {
    center: { lat: 40.4093, lng: 49.8671 },
    zoom: 13,
  });

  map.addListener("click", function (event) {
    const lat = event.latLng.lat();
    const lng = event.latLng.lng();

    document.getElementById("latitude").value = lat;
    document.getElementById("longitude").value = lng;

    if (marker) {
      marker.setMap(null);
    }

    marker = new google.maps.Marker({
      position: { lat, lng },
      map: map,
    });
  });
}

window.initMap = initMap;

async function updateUserByEmail(email, updates) {
    const response = await fetch(`http://localhost:3000/api/users/${email}`, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(updates)
    });
    if (response.ok) {
        const data = await response.json();
        return data.user;
    } else {
        const error = await response.json();
        alert(error.message);
        return null;
    }
}

document.getElementById("SaveButton").addEventListener("click", () => {
  const latitude = document.getElementById("latitude").value;
  const longitude = document.getElementById("longitude").value;

  if (latitude&& longitude) {
    user.lat = latitude;
    user.long = longitude;
    
    localStorage.setItem("user", JSON.stringify(user));
    updateUserByEmail(user.email, { lat: latitude, long: longitude })
      .then(updatedUser => {
        if (updatedUser) {
          alert("Location saved successfully!");
          document.getElementById("Maps").style.display = "none";
          document.getElementById("auth-container").style.display = "block";
        } else {
          alert("Failed to save location.");
        }
      })
      .catch(error => {
        alert("An error occurred while saving your location.");
      });
  }
  else{
    alert("Please select a location on the map.");
  }

  getNearbyCityWeather(latitude, longitude);
}
);


document.getElementById("LogOut").addEventListener("click", () => {
  localStorage.removeItem("user");
  window.location.href = "index.html";
});





const apiKey = 'c15ba3b71f8f57914a6a3c8e61ed5547';

let citiesWithinRange;

function getNearbyCityWeather(lat, lon) {
    const url = `https://api.openweathermap.org/data/2.5/find?lat=${lat}&lon=${lon}&cnt=50&units=metric&appid=${apiKey}`;

    fetch(url)
        .then(response => response.json())
        .then(data => {
            if (data && data.list) {
                citiesWithinRange = data.list.filter(city => {
                    const distance = haversineDistance(lat, lon, city.coord.lat, city.coord.lon);
                    return distance <= 100;
                });
                currentPage = 1; // Reset to first page
                renderUsers();
            }
        })
        .catch(error => console.error("Weather fetch error:", error));
}


function haversineDistance(lat1, lon1, lat2, lon2) {
    const R = 6371; // Earth radius in km
    const dLat = toRad(lat2 - lat1);
    const dLon = toRad(lon2 - lon1);
    const a = Math.sin(dLat / 2) ** 2 +
              Math.cos(toRad(lat1)) * Math.cos(toRad(lat2)) *
              Math.sin(dLon / 2) ** 2;
    const c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
    return R * c;
}

function toRad(deg) {
    return deg * Math.PI / 180;
}


let currentPage = 1;
const itemsPerPage = 5;

const weatherInfoList = document.getElementById("weatherInfoList");
const pageInfo = document.getElementById("pageInfo");
const prevBtn = document.getElementById("prevBtn");
const nextBtn = document.getElementById("nextBtn");

function renderUsers() {
  weatherInfoList.innerHTML = "";
  const start = (currentPage - 1) * itemsPerPage;
  const end = start + itemsPerPage;
  const forecastPage = citiesWithinRange.slice(start, end);

  forecastPage.forEach(city => {
          let a = document.createElement("div");
          a.textContent = `${city.name}, ${city.sys.country} - ${city.main.temp}°C, ${city.weather[0].description}`;
          a.className = "WeatherEntity";
          document.getElementById("weatherInfoList").appendChild(a);
  });

  pageInfo.textContent = `Page ${currentPage} of ${Math.ceil(citiesWithinRange.length / itemsPerPage)}`;
}

prevBtn.addEventListener("click", () => {
  if (currentPage > 1) {
    currentPage--;
    renderUsers();
  }
});

nextBtn.addEventListener("click", () => {
  if (currentPage * itemsPerPage < citiesWithinRange.length) {
    currentPage++;
    renderUsers();
  }
});

renderUsers();
