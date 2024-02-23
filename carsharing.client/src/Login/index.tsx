import './style.css';
import { Component, ErrorInfo } from 'react'
import { Formik , Field , Form , ErrorMessage} from "formik";
import * as Yup from 'yup';
import authServices from '../Services/auth.services';
interface Props {

}
interface State {
    redirect :string | null , 
    userEmail :string ,
    password :string , 
    loading :boolean , 
    messange :string 
}

export default class Login extends Component<Props , State> {
    
    constructor (props:Props ){
        super(props);
        this.handleLogin = this.handleLogin.bind(this); 
        this.state = {
            redirect : null,
            userEmail : "",
            password :"" ,
            loading:false,
            messange:"",
        }
    }
    componentDidMount(){
        const currentUser = authServices.getCurentUser();
        if (currentUser){
            this.setState({redirect "/profile"});
        };   
    }
    validationSchema() {
        return Yup.object().shape({
            userEmail: [Yup Schema],
            password: [Yup Schema],
        });
    }
    
    handleLogin(formValue: { userEmail: string; password: string }) {
        const { username, password } = formValue;
        
    }
    
    render() {
        const initialValues = {
        userEmail: "",
        password: "",
        };
    
        return (
             <Formik
                    initialValues={initialValues}
                    validationSchema={this.validationSchema}
                    onSubmit={this.handleLogin}
                    >
                <Form>
                    <section className="vh-100 gradient-custom">
                        <div className="container py-1 h-100">
                            <div className="row d-flex justify-content-center align-items-center h-100">
                                <div className="col-12 col-md-8 col-lg-6 col-xl-5">
                                    <div className="card bg-dark text-white" style={{ borderRadius: '1rem' }}>
                                        <div className="card-body p-3 text-center">
                                                <div className="mb-md-5 mt-md-4 pb-5">
                                                    <h2 className="fw-bold mb-2 text-uppercase">Login</h2>
                                                    <p className="text-white-50 mb-5">Please enter your login and password!</p>
                                                    <div className="form-outline form-white mb-4">
                                                        <label htmlFor="email">Email</label>
                                                        <Field name="userEmail" type="text"  />
                                                        <ErrorMessage name='userEmail'  component="div"/>
                                                    </div>
                                                    <div className="form-outline form-white mb-4">
                                                        <label htmlFor="password">Password</label>
                                                        <Field name="password" type="password"  />
                                                        <ErrorMessage name='password'  component="div"/>
                                                    <button type="submit" disabled={loading} value="Sign up" className="btn btn-outline-light btn-lg px-5" />
                                                    <div>
                                                        <p className='mb-0 p-4 px-5'>
                                                            Don't have an account? <a href="/Registrations" className='text-white-50 fw-bold '>Sign Up</a>
                                                        </p>
                                                    </div>
                                                </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>
              </Form>
            </Formik>
        );
    }
}