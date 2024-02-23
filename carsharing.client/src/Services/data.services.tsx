export default function authHeader(){
    const userStr = localStorage.getItem("User")
    let user = null
     if(userStr)
        user = JSON.parse(userStr)

   if (user && user.acessToken)
   {
    return {Authorization:'Bearer' +user.acessToken}
   }
   else {Authorization :''}
}