import './style.css';
import { Component } from 'react'
import { RouteComponentProps } from 'react-router-dom';
import { Formik , Field , Form , ErrorMessage} from "formik";
import * as Yup from 'yup';
import authServices from '../Services/auth.services';
interface RouterProps {
     history:string
}
type Props = RouteComponentProps<RouterProps>
interface State {
    redirect :string | null , 
    userEmail :string ,
    password :string , 
    loading :boolean , 
    message :string 
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
            message:"",
        }
    }
    componentDidMount(){
        const currentUser = authServices.getCurentUser();
        if (currentUser){
            this.setState({redirect: "/profile"});
        };   
    }
    validationSchema() {
        return Yup.object().shape({
            userEmail: Yup.string().required("This is field is required!"),
            password:  Yup.string().required("This is field is required!"),
        });
    }
    
    handleLogin(formValue: { userEmail: string; password: string }) {
        const { userEmail, password } = formValue;

        this.setState ({
            message : "", 
            loading :true
        });

     authServices.login (userEmail , password).then(
            ()=>{
                this.props.history.push("/profile");
                window.location.reload();
            }, 
            error => {
                const resMessage= (
                    error.response &&
                    error.response.date&&
                    error.response.data.message)||
                    error.message||
                    error.toString();

                    this.setState({
                        loading:false , 
                        message : resMessage
                    });
                }
             );
     }
    
    render() {               
        const {loading , message} = this.state;
       
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