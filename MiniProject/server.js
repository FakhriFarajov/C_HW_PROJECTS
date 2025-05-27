const express = require('express');
const fs = require('fs');
const path = require('path');
const bodyParser = require('body-parser');
const cors = require('cors');
const bcrypt = require('bcrypt');

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
    const { username, email, password, lat = 0, long = 0 } = req.body; // Default lat and long to 0 if not provided
    const users = readUsers();

    if (users.find(user => user.email === email)) {
        return res.status(400).json({ message: 'Email already exists' });
    }

    let passwordHashed = bcrypt.hashSync(password, 12); // Hash the password

    const newUser = { username, email, passwordHashed, lat, long };

    users.push(newUser);
    writeUsers(users);

    res.status(201).json({
        message: 'Registration successful',
        user: {
            username: newUser.username,
            email: newUser.email,
            lat: newUser.lat,
            long: newUser.long
        }
    });
});

// Login endpoint
app.post('/api/login', (req, res) => {
    const { username, password } = req.body;
    let users = readUsers();
    const user = users.find(u => u.username === username && bcrypt.compare( password, u.password));
    if (user) {
        res.json({ message: 'Login successful', user });
    } else {
        res.status(401).json({ message: 'Invalid username or password' });
    }
});


// Update a user by email
app.put('/api/users/:email', (req, res) => {
    const { email } = req.params;
    const { username, password, lat, long } = req.body;
    let users = readUsers();
    // Robust email comparison
    const userIndex = users.findIndex(
        u => u.email.trim().toLowerCase() === email.trim().toLowerCase()
    );

    if (userIndex === -1) {
        return res.status(404).json({ message: 'User not found' });
    }

    // Update fields if provided
    if (username !== undefined) users[userIndex].username = username;
    if (password !== undefined) users[userIndex].password = password;
    if (lat !== undefined) users[userIndex].lat = lat;
    if (long !== undefined) users[userIndex].long = long;

    writeUsers(users);

    // Do not send password in response
    const { password: _, ...updatedUser } = users[userIndex];
    res.json({ message: 'User updated', user: updatedUser });
});


const PORT = 3000;
app.listen(PORT, () => console.log(`Server running on http://localhost:${PORT}`));