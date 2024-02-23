import React, { useState } from 'react';
import './style.css'
interface LoginProps {
    email: string;
    password: string;
}

const Login: React.FC<LoginProps> = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        
        // Отправка данных на сервер
        const response = await fetch('/Login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ email, password })
        });

        if (response.ok) {
            // Перенаправление пользователя после успешного входа
            window.location.href = '/dashboard';
        } else {
            // Обработка ошибок
            console.error('Ошибка входа');
        }
    };

    return (
     <body className='gradient-custom'>
        <section className="vh-100 gradient-custom">
            <div className="container py-1 h-100">
                <div className="row d-flex justify-content-center align-items-center h-100">
                    <div className="col-12 col-md-8 col-lg-6 col-xl-5">
                        <div className="card bg-dark text-white" style={{ borderRadius: '1rem' }}>
                            <div className="card-body p-3 text-center">
                                <form onSubmit={handleSubmit}>
                                    <div className="mb-md-5 mt-md-4 pb-5">
                                        <h2 className="fw-bold mb-2 text-uppercase">Login</h2>
                                        <p className="text-white-50 mb-5">Please enter your login and password!</p>
                                        <div className="form-outline form-white mb-4">
                                            <label htmlFor="email">Email</label>
                                            <input type="email" id="email" value={email} onChange={(e) => setEmail(e.target.value)} className="form-control" />
                                        </div>
                                        <div className="form-outline form-white mb-4">
                                            <label htmlFor="password">Password</label>
                                            <input type="password" id="password" value={password} onChange={(e) => setPassword(e.target.value)} className="form-control" />
                                        </div>
                                        <input type="submit" value="Sign up" className="btn btn-outline-light btn-lg px-5" />
                                        <div>
                                            <p className='mb-0 p-4 px-5'>
                                                Don't have an account? <a href="/Registrations" className='text-white-50 fw-bold '>Sign Up</a>
                                            </p>
                                        </div>
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
     </body>
    );
};

export default Login;
