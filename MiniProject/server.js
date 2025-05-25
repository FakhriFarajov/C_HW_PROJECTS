const express = require('express');
const fs = require('fs');
const path = require('path');
const bodyParser = require('body-parser');
const cors = require('cors');

const app = express();
const USERS_FILE = path.join(__dirname, 'users.json');

app.use(cors());
app.use(bodyParser.json());

// Helper to read users
function readUsers() {
    if (!fs.existsSync(USERS_FILE)) return [];
    const data = fs.readFileSync(USERS_FILE, 'utf-8');
    return data ? JSON.parse(data) : [];
}

// Helper to write users
function writeUsers(users) {
    fs.writeFileSync(USERS_FILE, JSON.stringify(users, null, 2));
}

// Register endpoint
app.post('/api/register', (req, res) => {
    let { username, email, password } = req.body;
    let users = readUsers();
    if (users.find(u => u.email === email)) {
        return res.status(400).json({ message: 'Email already exists' });
    }
    let lat = 0; // Default to 0 if not provided
    let long = 0; // Default to 0 if not provided
    const newUser = { username, email, password, lat, long };
    users.push(newUser);
    writeUsers(users);
    res.json({ message: 'Registration successful',  newUser }); // <-- Return user here
});

// Login endpoint
app.post('/api/login', (req, res) => {
    const { username, password } = req.body;
    let users = readUsers();
    const user = users.find(u => u.username === username && u.password === password);
    if (user) {
        res.json({ message: 'Login successful', user });
    } else {
        res.status(401).json({ message: 'Invalid username or password' });
    }
});

const PORT = 3000;
app.listen(PORT, () => console.log(`Server running on http://localhost:${PORT}`));