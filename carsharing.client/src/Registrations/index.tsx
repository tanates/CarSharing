import React, { useState } from 'react';
 
interface RegistrationsProps {
    name: string;
    email: string;
    password: string;
    confirmPassword: string;
}

const Registrations: React.FC<RegistrationsProps> = () => {
    const [email, setEmail] = useState('');
    const [name, setName] = useState('');
    const [password, setPassword] = useState('');
    const [confirmPassword, setConfirm] = useState('');

    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        try {
            const response = await fetch('http://localhost:5033/api/SignUp', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({ name, email, password , confirmPassword})
            });
        
            if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }
        
            const data = await response.json();
            console.log(data); // Вывод ответа от сервера
        
        } catch (error) {
            console.error('Ошибка при выполнении запроса:', error);
        }
        
    };
      return (
            <section className='vh-100 gradient-custom'>
             <div className='container  py-1 h-100'>
                <div className='row d-flex justify-content-center align-items-center h-100'>
                    <div className='col-12 col-md-8 col-lg-6 col-xl-5'>
                        <div className='card bg-dark text-white' style={{borderRadius :'1rem'}} >
                            <div className='card-body  p-3 text-center'>
                                <div className='mb-md-5 mt-md-4 pb-5'>
                                    <form onSubmit={handleSubmit}>
                                     <h2 className='fw-bold mb-2 text-uppercase'>Registratiom</h2>
                                     <p className='text-white-50 mb-5'>Registratiom Info</p>
                                     <div className="form-outline form-white mb-4">
                                            <label htmlFor="name">Name</label>
                                            <input type="text" id="name" value={name} onChange={(e) => setName(e.target.value)} className="form-control" />
                                        </div>
                                        <div className="form-outline form-white mb-4">
                                            <label htmlFor="email">Email</label>
                                            <input type="email" id="email" value={email} onChange={(e) => setEmail(e.target.value)} className="form-control" />
                                        </div>
                                        <div className="form-outline form-white mb-4">
                                            <label htmlFor="password">Password</label>
                                            <input type="password" id="password" value={password} onChange={(e) => setPassword(e.target.value)} className="form-control" />
                                        </div>
                                        <div className="form-outline form-white mb-4">
                                            <label htmlFor="confirmPassword">Confirm Password</label>
                                            <input type="password" id="confirmPassword" value={confirmPassword} onChange={(e) => setConfirm(e.target.value)} className="form-control" />
                                        </div>
                                          <button className='btn btn-outline-light btn-lg px-5' type="submit">Sign up</button>
                                        <div>
                                            <p className='mb-0 p-4 px-5 '>
                                               If you have an account! <a href="/Login" className='text-white-50 fw-bold'>Sign In</a>
                                            </p>
                                        </div>
                                     </form>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
             </div>
            </section>
      );

 };
 export default Registrations;