import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import UsersPage from "./pages/UsersPage.jsx";
import './App.css'

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<UsersPage />} />
      </Routes>
    </Router>
  );
}

export default App
