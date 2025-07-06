import React from "react";
import { Link, useNavigate } from "react-router-dom";


export default function Log() {

    const navigate = useNavigate();
    const handleLogin = (e) => {
        e.preventDefault();
        // Here you would typically handle the login logic, e.g., API call
        // For now, we'll just navigate to the home page
        navigate("/main");
    };

    return (
        <div className="flex items-center justify-center flex-col">
            <h1 className="text-2xl font-bold mb-4">Login</h1>
            <form className="flex flex-col space-y-4">
                <input type="text" placeholder="Username" className="border p-2 rounded" />
                <input type="password" placeholder="Password" className="border p-2 rounded" />
                <button type="submit" className="bg-blue-500 text-white p-2 rounded" onClick={handleLogin}> 
                    Submit</button>
                <Link to="/reg" className="NavBarButton">
                    Don't have an account? Register Now
                </Link>
            </form>
        </div>
    );
}