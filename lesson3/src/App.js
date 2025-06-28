import './App.css';
import NavBar from './components/Nav'; // ✅ Correct casing
import SignIn from './components/SignIn';
import SignUp from './components/SignUp';
import {Routes, Route} from 'react-router-dom'; // Assuming you have a Routes component for routing

function App() {
  return (
    <div className="App">
      <NavBar />
      <div className="content">
        <Routes > 
          <Route path="/signin" element={<SignIn />} />
          <Route path="/signup" element={<SignUp />} />
        </Routes>
      </div>
    </div>
  );
}

export default App;
