import React, { Component } from "react";
import { Link } from "react-router-dom";

export default class NavBar extends React.Component {
    render() {
        return (
            <div className="NavBar">
                <Link to="/signin" className="NavBarButton">
                    Sign In
                </Link>
                <Link to="/signup" className="NavBarButton">
                    Sign Up
                </Link>
            </div>
        );
    }
}