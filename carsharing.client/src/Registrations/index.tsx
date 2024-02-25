import { Component } from 'react';
import { Formik, Field, Form, ErrorMessage } from 'formik';
import * as Yup from 'yup';
import authServices from '../Services/auth.services';

interface Props { }
interface State {
    userEmail: string;
    username: string;
    password: string;
    confirmPassword: string;
    successful: boolean;
    message: string;
}

export default class Register extends Component<Props, State> {
    constructor(props: Props) {
        super(props);
        this.handleRegister = this.handleRegister.bind(this);
        this.state = {
            userEmail: "",
            username: "",
            password: "",
            confirmPassword: "",
            successful: false,
            message: ""
        };
    }

    validationSchema() {
        return Yup.object().shape({
            username: Yup.string().required("This field is required"),
            userEmail: Yup.string()
                .email("This is not a valid email")
                .required("This field is required"),
            password: Yup.string().min(6, 'Password must be at least 6 characters').required('Password is required'),
            confirmPassword: Yup.string().oneOf([Yup.ref('password'), undefined], 'Passwords must match').required('Confirm Password is required')
        });
    }

    handleRegister(formValue: { username: string, userEmail: string, password: string, confirmPassword: string }) {
        const { username, userEmail, password, confirmPassword } = formValue;
        this.setState({
            message: "",
            successful: false
        });

        authServices.registration(
            userEmail,
            username,
            password,
            confirmPassword
        ).then(
            response => {
                this.setState({
                    message: response.data.message,
                    successful: true
                });
            },
            error => {
                const resMessage =
                    (error.response &&
                        error.response.data &&
                        error.response.data.message) ||
                    error.message ||
                    error.toString();

                this.setState(
                    {
                        successful: false,
                        message: resMessage
                    });
            }
        );
    }

    render() {
        const { successful, message } = this.state;

        const initialValues = {
            userEmail: "",
            username: "",
            password: "",
            confirmPassword: ""
        };

        return (
            <Formik
                initialValues={initialValues}
                validationSchema={this.validationSchema}
                onSubmit={(values) => this.handleRegister(values)}>
                <Form>
                    {!successful && (
                        <section className='vh-100 gradient-custom'>
                            <div className='container py-1 h-100'>
                                <div className='row d-flex justify-content-center align-items-center h-100'>
                                    <div className='col-12 col-md-8 col-lg-6 col-xl-5'>
                                        <div className='card bg-dark text-white' style={{ borderRadius: '1rem' }}>
                                            <div className='card-body p-3 text-center'>
                                                <div className='mb-md-5 mt-md-4 pb-5'>
                                                    <h2 className='fw-bold mb-2 text-uppercase'>Registration</h2>
                                                    <p className='text-white-50 mb-5'>Registration Info</p>
                                                    <div className="form-outline form-white mb-4">
                                                        <label htmlFor="username">Username</label>
                                                        <Field type="text" id="username" name="username" className="form-control" />
                                                        <ErrorMessage name="username" component="div" className="error" />
                                                    </div>
                                                    <div className="form-outline form-white mb-4">
                                                        <label htmlFor="userEmail">Email</label>
                                                        <Field type="email" id="userEmail" name="userEmail" className="form-control" />
                                                        <ErrorMessage name="userEmail" component="div" className="error" />
                                                    </div>
                                                    <div className="form-outline form-white mb-4">
                                                        <label htmlFor="password">Password</label>
                                                        <Field type="password" id="password" name="password" className="form-control" />
                                                        <ErrorMessage name="password" component="div" className="error" />
                                                    </div>
                                                    <div className="form-outline form-white mb-4">
                                                        <label htmlFor="confirmPassword">Confirm Password</label>
                                                        <Field type="password" id="confirmPassword" name="confirmPassword" className="form-control" />
                                                        <ErrorMessage name="confirmPassword" component="div" className="error" />
                                                    </div>
                                                    <button className='btn btn-outline-light btn-lg px-5' type="submit">Sign up</button>
                                                    <div>
                                                        <p className='mb-0 p-4 px-5 '>
                                                            If you have an account! <a href="/Login" className='text-white-50 fw-bold'>Sign In</a>
                                                        </p>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </section>
                    )}
                </Form>
            </Formik>
        );
    }
}