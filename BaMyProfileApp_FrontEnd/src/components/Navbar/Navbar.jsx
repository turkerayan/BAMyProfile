import React from "react";
import { Link, useNavigate } from "react-router-dom";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faUser, faSignOutAlt } from "@fortawesome/free-solid-svg-icons";
import "../../assets/styles/navbar.scss";

const Navbar = ({ setIsAuthenticated }) => {
  const navigate = useNavigate();

  const handleLogout = () => {
    localStorage.removeItem("Token");
    sessionStorage.removeItem("Token");
    setIsAuthenticated(false);
    navigate("/login");
  };

  return (
    <nav className="navbar">
      <div className="navbar-left">
        <Link to="/" className="navbar-logo">
          My Profile
        </Link>
      </div>
      <div className="navbar-right">
        <FontAwesomeIcon icon={faUser} className="icon-profile" />
        <button onClick={handleLogout} className="logout-button">
          <FontAwesomeIcon icon={faSignOutAlt} />
        </button>
      </div>
    </nav>
  );
};

export default Navbar;
