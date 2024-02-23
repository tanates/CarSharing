import React from 'react'
import ReactDOM from 'react-dom/client'
import './index.css'
import 'bootstrap/dist/css/bootstrap.css';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Login from './Login/index.tsx';
import Registrations from './Registrations/index.tsx';


ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
   <BrowserRouter>
            <Routes>
                <Route path="Login" element={<Login email={"email"} password={"password"}/>}/>
                <Route path="Registrations" element={<Registrations email={"email"} password={"password"} name={"name"} confirmPassword={"confirmPassword"}/>}/>
            </Routes>
    </BrowserRouter>
  </React.StrictMode>
)
