import axios from "axios";
import IUser from "../types/IUser";

const API_URL = "https://localhost:7228/";

class AuthService {
  register(Name: string, Email: string, password: string, confirmPassword: string) {
    return axios.post(API_URL + "api/SignUp", {
      Name,
      Email,
      password,
      confirmPassword
    });
  }

  login(email: string, password: string) {
    return axios
      .post(API_URL + "login", {
        email,
        password,
      })
      .then((response) => {
        if (response.data) {
          // Сохраняем токен в куках или в localStorage
          document.cookie = `email = ${email}`;
          document.cookie = `AuthToken=${response.data}`;
  
          // Исключаем токен из сохраненных данных
          const userData = { ...response.data };
          delete userData.accessToken;
  
        
        }
  
        return response.data;
      });
  }
  
  
  logout() {
    document.cookie = "email=;expires=Thu, 01 Jan 1970 00:00:00 GMT";
    document.cookie = "AuthToken=;expires=Thu, 01 Jan 1970 00:00:00 GMT";
    localStorage.clear();
  }

  async getCurrentUser(): Promise<IUser | null> {
    const authToken = this.getAuthTokenFromCookies();
    
    try {
      const response = await axios.get(API_URL + `Profile/get`, {
        withCredentials: true,
        headers: {
          Authorization: `Bearer ${authToken}`
        }
      });
  
      const user = response.data;
      // Сохраняем другие данные в localStorage, если нужно
      localStorage.setItem("UserEntity", JSON.stringify(user["UserEntity"]));
      localStorage.setItem("RentalHistoryEntity", JSON.stringify(user["RentalHistoryEntity"]));
  
      return user; // Возвращаем полный объект пользователя
    } catch (error) {
      console.error(error);
      return null;
    }
  };
  


  getAuthTokenFromCookies() {
    const cookies = document.cookie.split(';');
    let authToken = null;
  
    cookies.forEach((cookie) => {
      const [name, value] = cookie.trim().split('=');
  
      if (name === 'AuthToken') {
        authToken = value;
      }
    });
  
    return authToken;
  }
}

export default new AuthService();
