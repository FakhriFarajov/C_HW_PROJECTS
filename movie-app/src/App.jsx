import './App.css'
import UseContextSearch from './pages/UseContext';
import Log from './pages/LogReg';
import Reg from './pages/Reg';
import Nav from './components/Nav'; // Importing the Nav component
import {Routes, Route} from 'react-router-dom'; // Assuming you have a Routes component for routing


function App() {

  if (window.location.pathname === '/') {
    window.location.pathname = '/log'; // Redirect to /log if the path is root
  }

  return (
    <>
        
      <Routes >
        <Route path="/log" element={<Log />} />
        <Route path="/reg" element={<Reg />} />
        <Route path="/main" element={<UseContextSearch />} />
      </Routes>

    </>
  )
}

export default App;

