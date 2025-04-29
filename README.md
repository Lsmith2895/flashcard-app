# Flashcard App

The Flashcard App is a simple full-stack application built to practice full-stack software engineering skills using modern technologies. It demonstrates setting up a .NET 9 Web API backend and an Angular 17 Standalone frontend. The goal is to create an interactive flashcard experience where users can flip cards, mark them as correct or incorrect, and complete a learning session.

---

## 🛠 Requirements

To run this application, ensure the following are installed:

| Tool | Version | Purpose |
|:---|:---|:---|
| .NET SDK | 9.0+ | Backend API server |
| Node.js | 20+ | JavaScript runtime for Angular |
| Angular CLI | 17+ | Development and serving of Angular frontend (`npm install -g @angular/cli`) |
| Git | Latest | To clone the repository |

You can verify installations with:

```bash
dotnet --version
node --version
ng version
git --version
```

---

## 🚀 How to Run the App

After cloning the repository:

```bash
git clone https://github.com/your-username/flashcard-app.git
cd flashcard-app
```

### Running the Backend

Navigate to the backend project directory and start the .NET Web API server:

```bash
cd FlashCardApi
dotnet run
```

This will start the backend on:

- `http://localhost:5000`
- `https://localhost:5001`

You should leave this backend server running while working with the frontend.

---

### Updating the Frontend API URL

Before running the frontend, you need to configure the frontend service to point to your backend server.

Open:

```
flashcard-ui/src/app/flash-deck.service.ts
```

Locate the `apiUrl` definition:

```typescript
private apiUrl = 'http://localhost:5000/flashcard';
```

Ensure this URL matches the backend server address.  
If your backend port or address changes, update this URL accordingly.

---

### Running the Frontend

Navigate to the frontend Angular project and install dependencies:

```bash
cd ../flashcard-ui
npm install
```

Then start the Angular development server:

```bash
ng serve --open
```

This will launch the app automatically in your browser at:

```
http://localhost:4200
```

You can now interact with the Flashcard App: flipping cards, submitting answers, and completing your flashcard session.

---

## 📦 Tech Stack Overview

| Layer | Technology | Purpose |
|:---|:---|:---|
| Backend | C# .NET 9 Web API | Flashcard management and session logic |
| Frontend | Angular 17 Standalone Components | UI and user interaction |
| Communication | RESTful APIs | JSON exchange between frontend and backend |

---

## 🎯 About This Project

This application was created as a learning project to practice full-stack software engineering principles: building APIs, designing interactive UIs, handling client-server communication, and managing simple state across user sessions. It serves as a foundation for further improvements, such as authentication, session tracking, advanced animations, and cloud deployment.