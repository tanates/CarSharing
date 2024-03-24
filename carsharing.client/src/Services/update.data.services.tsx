import axios from "axios";
import { UpdateUserProfile } from "../types/userProfile";
import authServices from "./auth.services";

const API_URL = "https://localhost:7228/";

export const submitForm = async (data: UpdateUserProfile) => {

     const token = authServices.getAuthTokenFromCookies() ; 
    try {
        const response = await axios.post(
            API_URL + `Profile`,
            data,
            {
              withCredentials: true,
              headers: {
                Authorization: `Bearer ${token}`,
              },
            }
          );
      
      return response.data;
    } catch (error) {
      console.error('Error submitting form:', error);
      throw error;
    }
  };


