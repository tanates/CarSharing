import axios from  'axios'

const API = 'https://localhost:7228/api/';



class AuthServices  {


    login (email:string  , password : string ){

         return axios
             .post('https://localhost:7228/Login', {
                email, 
                password, 
             }).then(response =>{
                if(response.data.acessToken){
                  localStorage.setItem("User", JSON.stringify(response.data))
                }
                  return response.data
             });
    }
    registration(email:string , name:string , password :string , confirmPassword:string){
        return axios.post(API +'signup' , {
            email, 
            name, 
            password, 
            confirmPassword
        });

    }

    logout(){
        localStorage.removeItem("user");
    }

    getCurentUser(){
        const usetStr = localStorage.getItem("User");
        if(usetStr)
                return JSON.parse(usetStr)
     
        return null;
    }
}
export default new AuthServices