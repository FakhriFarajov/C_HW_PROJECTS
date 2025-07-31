import React, { useState } from 'react';
import useWeather from '@/components/custom/useWeather';
import { Search } from 'lucide-react';
import { Input } from '../ui/input';
import { Button } from '../ui/button';
import { Card } from '../ui/card';

export default function HomePage() {
    const [city, setCity] = useState('London');
    const [search, setSearch] = useState('London');
    const { weather, isLoading, isError } = useWeather(city);

    // Debug: log weather object
    console.log('Weather response:', weather);

    const isWeatherValid = weather && weather.name && weather.main && weather.weather && Array.isArray(weather.weather) && weather.weather.length > 0 && weather.sys;

    const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        if (search.trim() !== '') {
            setCity(search.trim());
        }
    };

    return (
        <>
            <h1 className="text-2xl font-bold mb-4">Current Weather</h1>
            <form onSubmit={handleSubmit} className="mb-6 flex gap-2">
                <Input
                    type="text"
                    value={search}
                    onChange={e => setSearch(e.target.value)}
                    placeholder="Enter city name"
                    autoFocus
                />
                <Button type="submit" className="flex items-center gap-2 bg-blue-500 text-white px-4 py-1 rounded">
                    <Search size={18} /> Search
                </Button>
            </form>
            {isLoading && <div>Loading...</div>}
            {isError && <div className="text-red-500">{typeof isError === 'string' ? isError : 'Error loading weather data'}</div>}
            {!isWeatherValid && !isLoading && !isError && (
                <div>No valid weather data available. Please check the city name or API response.</div>
            )}
            {isWeatherValid && (
                <Card className="max-w-sm mx-auto bg-white shadow-lg rounded-lg overflow-hidden p-6">
                    <h2 className="text-xl font-semibold mb-2">{weather.name}, {weather.sys.country}</h2>
                    <div className="flex items-center gap-4">
                        <img src={`https://openweathermap.org/img/wn/${weather.weather[0].icon}@2x.png`} alt={weather.weather[0].description} />
                        <div>
                            <p className="text-lg">{(weather.main.temp - 273.15).toFixed(1)} °C</p>
                            <p className="text-gray-600">{weather.weather[0].description}</p>
                        </div>
                    </div>
                </Card>
            )}
        </>
    );
}