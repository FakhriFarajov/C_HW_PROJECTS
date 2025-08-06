import { BrowserRouter, Routes, Route } from 'react-router-dom'
import  Login  from './pages/auth/login'
import  Reg  from './pages/auth/register'
import './App.css'
import LandingPage from './pages/landingPage'

function App() {

  return (
    <div className="App">
      <BrowserRouter>
        <Routes>
          <Route path='/main' element={<LandingPage />} />
          <Route path='/login' element={<Login />} />
          <Route path='/reg' element={<Reg />} />
          <Route path='/' element={<LandingPage />} />
        </Routes>
      </BrowserRouter>
    </div>
  )
}

export default App
