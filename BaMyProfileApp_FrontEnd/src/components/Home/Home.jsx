import React, { useState } from "react";
import { Routes, Route, Navigate } from "react-router-dom";
import "../../assets/styles/Home.scss";
// import SideBar from "../sidebar/SideBar";
import Navbar from "../Navbar/Navbar";
import Footer from "../Footer/Footer";
import TrainingProgram from "../TrainingProgram/TrainingProgram.jsx";
import UserCardList from "../UserCardList/UserCardList";
import "react-toastify/dist/ReactToastify.css";
import { ToastContainer } from "react-toastify";
import SideBarComponent from "../sidebar/SideBarComponent.jsx";

const Home = ({ setIsAuthenticated , page}) => {
  const [isWrap, setIsWrap] = useState(false);
  let width = window.innerWidth;

  const handleWrap = () => {
    setIsWrap(!isWrap);
  };
  return (
    <div className="home-container">
      <Navbar setIsAuthenticated={setIsAuthenticated} />
        <SideBarComponent />
      <div className="main-layout">
        <div className="content-container">
          {page}
        </div>
      </div>
      <Footer />
      <ToastContainer
        position="bottom-right"
        limit={5}
        hideProgressBar={false}
        newestOnTop={false}
        rtl={false}
        theme="light"
      />
    </div>
  );
};

export default Home;
