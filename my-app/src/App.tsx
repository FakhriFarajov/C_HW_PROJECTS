import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import HomePage from './components/custom/Home'

function App() {
  const [count, setCount] = useState(0)

  return (
    <>
    <h1 className="text-2xl font-bold mb-4">Weather App</h1>
    <HomePage />
    
    </>
  )
}

export default App
