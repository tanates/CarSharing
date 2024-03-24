export default function authHeader() {
     const userStr = localStorage.getItem("testy-login");
     let user = null;
     if (userStr)
       user = JSON.parse(userStr);
   
     if (user && user.accessToken) {
       return { Authorization: 'Bearer ' + user.accessToken };
     } else {
       return { Authorization: '' };
     }
   }