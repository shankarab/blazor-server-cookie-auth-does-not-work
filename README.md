# Blazor Server Cookie Authentication App

I created a simple Blazor Server-side interactive web application to understand cookie-based authentication. 

## Conclusion: It does not work.
It throws the error: An error occurred: Headers are read-only, response has already started. Essentially HttpContext is not available in Blazor Server.

Feel free to modify. If you get it to work, please checkin and let the world know. Thank you.

## Features

- ✅ Cookie-based authentication
- ✅ Login/Logout functionality
- ✅ Protected pages requiring authentication

## Demo Credentials

Use these credentials to log in:

| Username | Password   | Role  |
|----------|------------|-------|
| admin    | admin123   | Admin |
| user     | user123    | User  |
| demo     | demo123    | User  |

## Getting Started

### Prerequisites

- .NET 10.0 SDK or later
- Visual Studio 2026

## Authentication Implementation

This application uses ASP.NET Core Cookie Authentication:

- **Authentication Scheme**: Cookie-based
- **Protected Routes**: Using `[Authorize]` attribute
- **User Validation**: In-memory user store (for demo purposes)

### Security Notes

⚠️ **This is a demo application**. For production use:
- Use a database for user storage
- Hash passwords (e.g., using BCrypt or ASP.NET Core Identity)
- Implement HTTPS
- Add CSRF protection
- Implement rate limiting for login attempts
- Add multi-factor authentication
- Use secure cookie settings

## License

MIT License