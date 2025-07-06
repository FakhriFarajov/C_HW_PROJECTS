import React from "react";
import {Link} from "react-router-dom";
import { useNavigate } from "react-router-dom";



export default function Reg() {
    
    const navigate = useNavigate();
    const handleLogin = (e) => {
        e.preventDefault();
        // Here you would typically handle the login logic, e.g., API call
        // For now, we'll just navigate to the home page
        navigate("/main");
    };

    return (
        <div className="flex items-center justify-center flex-col">
            <h1 className="text-2xl font-bold mb-4">Register</h1>
            <form className="flex flex-col space-y-4">
                <input type="text" placeholder="Username" className="border p-2 rounded" />
                <input type="password" placeholder="Password" className="border p-2 rounded" />
                <button type="submit" className="bg-blue-500 text-white p-2 rounded" onClick={handleLogin}>Submit</button>
                <Link to="/log" className="NavBarButton">
                    Already have an account? Sign in
                </Link>
            </form>
        </div >
    );
}