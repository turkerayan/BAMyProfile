import React from "react";


const SideBarContent = ({ setIsWrap }) => {
  let width = window.innerWidth;
  return (
    <div
      className="side-content"
      onClick={width <= 770? () => {setIsWrap(true);}: null}
    >
    </div>
  );
};

export default SideBarContent;
