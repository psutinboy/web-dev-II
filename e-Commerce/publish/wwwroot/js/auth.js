// Authentication helper functions

// Check if user is authenticated
function isAuthenticated() {
    return localStorage.getItem('authToken') !== null;
}

// Get current user role
function getUserRole() {
    return localStorage.getItem('userRole');
}

// Add authorization header to AJAX requests
function addAuthHeader(xhr) {
    const token = localStorage.getItem('authToken');
    if (token) {
        xhr.setRequestHeader('Authorization', `Bearer ${token}`);
    }
}

// Logout function
function logout() {
    localStorage.removeItem('authToken');
    localStorage.removeItem('userRole');
    window.location.href = '/AuthView/Login';
}

// Protect routes that require authentication
document.addEventListener('DOMContentLoaded', function() {
    // Get the current path
    const path = window.location.pathname.toLowerCase();
    
    // Skip authentication check for login and register pages
    if (path.includes('/authview/login') || path.includes('/authview/register')) {
        return;
    }
    
    // For all other pages, check if user is authenticated
    if (!isAuthenticated()) {
        window.location.href = '/AuthView/Login';
    }
    
    // Setup logout button if it exists
    const logoutBtn = document.getElementById('logoutBtn');
    if (logoutBtn) {
        logoutBtn.addEventListener('click', logout);
    }
    
    // Setup AJAX default settings to include auth token
    $.ajaxSetup({
        beforeSend: function(xhr) {
            addAuthHeader(xhr);
        }
    });
    
    // Display user info if the element exists
    const userInfo = document.getElementById('userInfo');
    if (userInfo) {
        // Fetch current user info
        $.ajax({
            url: '/api/Auth/me',
            type: 'GET',
            success: function(data) {
                userInfo.innerHTML = `Welcome, ${data.name} (${data.role})`;
            },
            error: function() {
                // If error occurs, user might be logged out
                logout();
            }
        });
    }
}); 