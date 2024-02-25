import axios  from "axios";
import authHeader  from "./data.services";


const API_URl = 'http://localhost:7228/api/SignIn'

class UserService {
    getPublicContent(){
        return axios.get(API_URl+'all')
    }

    getUserBoard (){
        return axios.get(API_URl + 'user' , {headers : authHeader ()});
    }

    getModeratorBoard (){
        return axios.get(API_URl + 'mode' , {headers :authHeader()});
    }

    getAdminBoard(){
        return axios.get (API_URl + 'admin' , {headers : authHeader()});
    }
}

export default new UserService