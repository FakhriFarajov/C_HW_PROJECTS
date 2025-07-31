import useSWR from 'swr';
export default function useWeather(city:string) {
  const fetcher = async (url: string) => {
    const res = await fetch(url);
    if (!res.ok) {
      throw new Error('Network response was not ok');
    }
    return res.json();
  };

  const apiKey = import.meta.env.VITE_API_KEY;
  console.log(`Fetching weather data for city: ${city} with API key: ${apiKey}`);
  // Check for missing API key or city
  const shouldFetch = apiKey && city && city.trim() !== '';
  const swrKey = shouldFetch
    ? `https://api.openweathermap.org/data/2.5/weather?q=${city}&appid=${apiKey}`
    : null;

  const { data, error, isLoading } = useSWR(swrKey, fetcher);

  return {
    weather: data,
    isLoading: isLoading,
    isError: !shouldFetch ? 'Missing API key or city' : error
  };
}