import React, { useEffect, useState } from "react";
import { Routes, Route, Navigate } from "react-router-dom";
import LoginForm from "./components/forms/Login/LoginForm";
import Home from "./components/Home/Home";
import TrainingProgram from "./components/TrainingProgram/TrainingProgram";
import Event from "./components/Event/Event";
import CertificateList from "./components/CertificateList/CertificateList";
import Reference from "./components/Reference/Reference";
import UserCardList from "./components/UserCardList/UserCardList";
import Capability from "./components/Capability/Capability";
import Benefit from "./components/Benefit/Benefit";

function App() {
  const [isAuthenticated, setIsAuthenticated] = useState(false);

  useEffect(() => {
    const token =
      localStorage.getItem("Token") || sessionStorage.getItem("Token");
    setIsAuthenticated(token !== null);
  }, []);

  return (
    <Routes>
      <Route
        path="/login"
        element={<LoginForm setIsAuthenticated={setIsAuthenticated} />}
      />
      <Route path="/" element={isAuthenticated ? (<LoginForm setIsAuthenticated={setIsAuthenticated} />
      ) : (<Navigate to="/login" />)
      }
      />
      <Route path="/home" element={isAuthenticated ? (<Home setIsAuthenticated={setIsAuthenticated} />
      ) : (<Navigate to="/login" />)
      }
      />
      <Route path="/usercardlist" element={isAuthenticated ? (<Home setIsAuthenticated={setIsAuthenticated} page={<UserCardList />} />
      ) : (<Navigate to="/login" />)
      }
      />
      <Route path="/traningprogram" element={isAuthenticated ?
        (<Home setIsAuthenticated={setIsAuthenticated} page={<TrainingProgram />} />
        ) : (<Navigate to="/login" />)
      }
      />
      <Route path="/event" element={isAuthenticated ?
        (<Home setIsAuthenticated={setIsAuthenticated} page={<Event />} />
        ) : (<Navigate to="/login" />)
      }
      />
      <Route path="/certificatelist" element={isAuthenticated ?
        (<Home setIsAuthenticated={setIsAuthenticated} page={<CertificateList />} />
        ) : (<Navigate to="/login" />)
      }
      />
      <Route path="/reference" element={isAuthenticated ?
        (<Home setIsAuthenticated={setIsAuthenticated} page={<Reference />} />
        ) : (<Navigate to="/login" />)
      }
      />

      <Route path="/capability" element={isAuthenticated ?
        (<Home setIsAuthenticated={setIsAuthenticated} page={<Capability />} />
        ) : (<Navigate to="/login" />)
      }
      />
      <Route path="/benefit" element={isAuthenticated ? 
                                                 (<Home setIsAuthenticated={setIsAuthenticated} page={<Benefit/>}/>
                                             ) : (<Navigate to="/login" />)
        }
      />
    </Routes>
  );
}

export default App;