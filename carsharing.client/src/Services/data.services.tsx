export default function authHeader(){
    const userStr = localStorage.getItem("User")
    let user = null
     if(userStr)
        user = JSON.parse(userStr)

   if (user && user.acessToken)
   {
    return {'x-acces-token':user.acessToken};
   }
   else
     return {'x-acces-token' : null};
}