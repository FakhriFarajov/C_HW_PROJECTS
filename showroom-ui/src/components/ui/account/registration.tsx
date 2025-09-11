import React, { useState } from "react";
import styles from "./styles/Registration.module.css";
import Sidebar from "../navigation/SideBar";

export default function Registration() {
    const [showPassword, setShowPassword] = useState(false);

    const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        alert("Registration submitted!");
    };

    return (
        <div className={styles["registration-container"]}>
            <Sidebar />
            <h2 className={styles["registration-title"]}>Create Account</h2>
            <form className={styles["registration-form"]} onSubmit={handleSubmit} autoComplete="off">
                <label>Name
                    <input
                        type="text"
                        name="name"
                        required
                        placeholder="Your full name"
                    />
                </label>
                <label>Email
                    <input
                        type="email"
                        name="email"
                        required
                        placeholder="you@email.com"
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
                <label>Confirm Password
                    <input
                        type={showPassword ? "text" : "password"}
                        name="confirmPassword"
                        required
                        minLength={6}
                        placeholder="Confirm Password"
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
                <button type="submit">Register</button>
            </form>
            <p className={styles["registration-login"]}>
                Already have an account?{' '}
                <a href="/account/login">Login</a>
            </p>
        </div>
    );
}
