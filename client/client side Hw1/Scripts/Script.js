function getCurrentUser() {
  const savedUser = sessionStorage.getItem("currentUser");
  if (savedUser) {
    return JSON.parse(savedUser);
  }
  return null;
}

function deleteCurrentUser() {
  sessionStorage.removeItem("currentUser");
}
