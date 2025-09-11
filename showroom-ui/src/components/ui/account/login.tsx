import React, { useState } from "react";
import styles from "./styles/Login.module.css";
import Sidebar from "../navigation/SideBar";

export default function Login() {
    const [showPassword, setShowPassword] = useState(false);

    const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        alert("Login submitted!");
    };

    return (
        <div className={styles["login-container"]}>
            <Sidebar />
            <h2 className={styles["login-title"]}>Login</h2>
            <form className={styles["login-form"]} onSubmit={handleSubmit} autoComplete="off">
                <label>Email
                    <input
                        type="text"
                        name="email"
                        required
                        placeholder="Your email"
                    />
                </label>
                <label>Password
                    <input
                        type={showPassword ? "text" : "password"}
                        name="password"
                        required
                        minLength={6}
                        placeholder="Password"
                    />
                </label>
                <div className={styles["show-password"]}>
                    <input
                        type="checkbox"
                        checked={showPassword}
                        onChange={() => setShowPassword((v) => !v)}
                        id="showPassword"
                        style={{ marginRight: 8 }}
                    />
                    <label htmlFor="showPassword">Show Passwords</label>
                </div>
                <button type="submit">Login</button>
            </form>
            <p className={styles["login-register"]}>
                Don't have an account?{' '}
                <a href="/account/registration">Register</a>
            </p>
        </div>
    );
}
