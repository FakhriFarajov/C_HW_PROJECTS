import React from "react";

export default class SignUp extends React.Component {
    render() {
        return (
            <div className="SignForm">
                <h1>Sign Up</h1>
                <input type="text" placeholder="Username" />
                <input type="password" placeholder="Password" />
                <button>Sign Up</button>
            </div>
        );
    }
}
