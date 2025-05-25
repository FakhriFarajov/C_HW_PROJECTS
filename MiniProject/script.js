import { ValidationService } from "./ValidationService.js";

function ChangeTheForms() {
    const signInForm = document.getElementById("auth-signIn-form");
    const signUpForm = document.getElementById("auth-signUp-form");
    const authFormTitle = document.getElementById("auth-form-title");
    const switchLink = document.getElementById("switchLink");
    const signInUpText = document.getElementById("SignInUpText");

    if (signInForm.style.display === "block") {
        signInForm.style.display = "none";
        signUpForm.style.display = "block";
        authFormTitle.textContent = "Sign Up";
        switchLink.textContent = "Already have an account?";
        signInUpText.textContent = "Sign In";
    } else {
        signInForm.style.display = "block";
        signUpForm.style.display = "none";
        authFormTitle.textContent = "Sign In";
        switchLink.textContent = "Don't have an account?";
        signInUpText.textContent = "Sign Up";
    }
}

document.addEventListener("DOMContentLoaded", () => {
    document.getElementById("SignInUpText").addEventListener("click", ChangeTheForms);
    document.getElementById("auth-signIn-form").addEventListener("submit", SignIn);
    document.getElementById("auth-signUp-form").addEventListener("submit", SignUp);
});

async function SignIn(event) {
    event.preventDefault();
    const username = document.getElementById("signInUsername").value;
    const password = document.getElementById("signInPassword").value;

    const response = await fetch("http://localhost:3000/api/login", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ username, password })
    });

    if (response.ok) {
        const data = await response.json();
        localStorage.setItem("user", JSON.stringify(data.user));
        window.location.href = "MainPage.html";
    } else {
        const error = await response.json();
        alert(error.message);
    }
}

async function SignUp(event) {
    event.preventDefault();
    const username = document.getElementById("signUpUsername").value.trim();
    const email = document.getElementById("signUpEmail").value.trim();
    const password = document.getElementById("signUpPassword").value;

    if (!ValidationService.validateEmail(email)) {
        alert("Invalid email");
        return;
    }

    if (!ValidationService.validatePassword(password)) {
        alert("Password must be 8+ characters, include letters and numbers");
        return;
    }

    const response = await fetch("http://localhost:3000/api/register", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ username, email, password })
    });

    if (response.ok) {
        const data = await response.json();
        localStorage.setItem("user", JSON.stringify(data.user));
        window.location.href = "MainPage.html";
    } else {
        const error = await response.json();
        alert(error.message);
    }
}
