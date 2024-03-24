export type UserProfileToken ={
 userEmail :string ;
 password :string ;
 token:string;
}
export type UserProfile =  {
     name ? :string ;
     roleName?:string; 
     userBalance ?:string;
     email ?:string;
     surname ? :string; 
     driversLicense? :string;
     passportNumber ?:string;
     phoneNumber ? :string;
  }
export type UpdateUserProfile = {
   email? :string;
   surname? :string; 
   driversLicense? :string;
   passportNumber ?:string;
   phoneNumber ?:string;
}