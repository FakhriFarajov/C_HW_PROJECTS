import React from "react";

export default class SignIn extends React.Component {
    render() {
        return (
            <div className="SignForm">
                <h1>Sign In</h1>
                <input type="text" placeholder="Username" />
                <input type="password" placeholder="Password" />
                <button>Sign In</button>
            </div>
        );
    }
}