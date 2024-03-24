import axios from "axios";
import authHeader  from "./data.services";


const API_URL  = "https://localhost:7228/"
export const getPublicContent = () => {
    return axios.get(API_URL + `AllCars`);
  };
  
  export const getUserBoard = () => {
    return axios.get(API_URL + "Profile/get", { headers: authHeader() });
  };
  
  export const getModeratorBoard = () => {
    return axios.get(API_URL + "mod", { headers: authHeader() });
  };
  
  export const getAdminBoard = () => {
    return axios.get(API_URL + "admin", { headers: authHeader() });
  };

  // src/services/userProfileService.ts


  
