const userStr = localStorage.getItem("user");
if (userStr) {
  const user = JSON.parse(userStr);
  alert("Welcome", user.username);
}