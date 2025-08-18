import './App.css'
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import LoginForm from "@/pages/login"
import AdminSidebar from './pages/mainPage';


function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path='/login' element={<LoginForm />} />
        <Route path='/main' element={<AdminSidebar />} />
      </Routes>
    </BrowserRouter>
  )
}

export default App