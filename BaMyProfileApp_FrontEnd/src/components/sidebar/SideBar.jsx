import React from "react";
import { NavLink } from "react-router-dom";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
    faHouse,
    faAddressCard,
    faThumbtack,
    faChevronLeft,
    faBars,
    faUsersLine,
    faCalendarDays,
    faCertificate,
    faContactCard,
    faCalendarCheck,
    faGift
} from "@fortawesome/free-solid-svg-icons";
import "../../assets/styles/sidebar.scss";

const SideBar = ({ isWrap, handleWrap }) => {
  return (
    <aside className={`sidebar ${isWrap ? "wrap" : ""}`}>
      <div className="logo-sidebar">
        {isWrap ? (
          <FontAwesomeIcon onClick={handleWrap} icon={faBars} />
        ) : (
          <FontAwesomeIcon onClick={handleWrap} icon={faChevronLeft} />
        )}
      </div>
      <ul>
        <li>
          <NavLink to={"/home"}>
            <FontAwesomeIcon icon={faHouse} /> <span>Home</span>
          </NavLink>
        </li>
        <li>
          <NavLink to={"/benefit"}>
            <FontAwesomeIcon icon={faGift} /> <span>Benefit</span>
          </NavLink>
        </li>
        <li>
          <NavLink to={"/traningprogram"}>
            <FontAwesomeIcon icon={faCalendarCheck} /> <span>Training Program</span>
          </NavLink>
        </li>
        <li>
          <NavLink to={"/event"}>
            <FontAwesomeIcon icon={faCalendarDays} /> <span>Event</span>
          </NavLink>
        </li>
        <li>
          <NavLink to={"/certificatelist"}>
            <FontAwesomeIcon icon={faCertificate} /> <span>Certificate List</span>
          </NavLink>
        </li>
        <li>
          <NavLink to={"/reference"}>
            <FontAwesomeIcon icon={faContactCard} /> <span>Reference</span>
          </NavLink>
        </li>
        <li>
          <NavLink to={"/usercardlist"}>
            <FontAwesomeIcon icon={faUsersLine} /> <span>Users</span>
          </NavLink>
        </li>
        <li>
          <FontAwesomeIcon icon={faAddressCard} /> <span>Info</span>
        </li>
        <li>
          <FontAwesomeIcon icon={faThumbtack} /> <span>Add</span>
        </li>
        <li>
          <NavLink to={"/capability"}>
            <FontAwesomeIcon icon={faUsersLine} /> <span>Capability</span>
          </NavLink>
        </li>
      </ul>
    </aside>
  );
};

export default SideBar;
