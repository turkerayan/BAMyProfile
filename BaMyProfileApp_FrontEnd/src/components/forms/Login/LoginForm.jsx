import React, { useState } from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faEye,
  faEyeSlash,
  faUser,
  faLock,
} from "@fortawesome/free-solid-svg-icons";
import LoginService from "../../services/LoginService";
import { useNavigate } from "react-router-dom";
import "../../../assets/styles/LoginFormm.scss"; // Stil dosyasını buradan içe aktar

const LoginForm = ({ setIsAuthenticated }) => {
  const [togglePassword, setTogglePassword] = useState(false);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState("");
  const [rememberMe, setRememberMe] = useState(false);
  const navigate = useNavigate();

  const handleLogin = async (event) => {
    event.preventDefault();
    setLoading(true);
    setError("");

    const data = {
      email: event.target.email.value,
      password: event.target.password.value,
    };

    try {
      const response = await LoginService.LoginServiceAsync(data);
      if (response.status === 200 && response.data.isSuccess) {
        const token = response.data.data;
        if (rememberMe) {
          localStorage.setItem("Token", token);
        } else {
          sessionStorage.setItem("Token", token);
        }
        setIsAuthenticated(true);
        navigate("/home");
      } else {
        setError(
          "Giriş Bilgilerinizi Kontrol Ediniz. Lütfen Tekrar Deneyiniz."
        );
      }
    } catch (error) {
      setError("Bir hata oluştu. Lütfen tekrar deneyin.");
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="login-container">
      <div className="cont">
        <div className="demo">
          <div className="login">
            <div className="login__check"></div>
            <div className="login__form">
              <form onSubmit={handleLogin} className="form-login">
                <div className="login__row">
                  <FontAwesomeIcon icon={faUser} className="login__icon" />
                  <input
                    type="text"
                    className="login__input name"
                    name="email"
                    placeholder="Email"
                    required
                  />
                </div>
                <div className="login__row">
                  <FontAwesomeIcon icon={faLock} className="login__icon" />
                  <div className="input-password">
                    <input
                      type={togglePassword ? "text" : "password"}
                      className="login__input pass"
                      name="password"
                      placeholder="Password"
                      required
                    />
                    <FontAwesomeIcon
                      onClick={() => setTogglePassword(!togglePassword)}
                      icon={!togglePassword ? faEye : faEyeSlash}
                      className="password-icons"
                    />
                  </div>
                </div>
                <div className="login_checkbox">
                  <input
                    type="checkbox"
                    id="rememberMe"
                    className="remember-me-checkbox"
                    checked={rememberMe}
                    onChange={() => setRememberMe(!rememberMe)}
                  />
                  <label className="rememberr">Beni Hatırla</label>
                </div>

                {error && <p className="error-message">{error}</p>}
                <button
                  type="submit"
                  className="login__submit"
                  disabled={loading}
                >
                  {loading ? "Yükleniyor..." : "Giriş Yap"}
                </button>
                <p className="login__signup">
                  &nbsp;<a href="#">Şifremi Unuttum</a>
                </p>
              </form>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default LoginForm;
