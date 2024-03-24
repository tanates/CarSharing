import { useState, useEffect } from 'react';
import AuthService from "../../Services/auth.services";
import { useNavigate } from "react-router-dom";
import { UpdateUserProfile, UserProfile } from '../../types/userProfile';
import { RentalHistory } from '../../types/rentalHistory';
import AddDataModal from './AddDataModel';
import RentalHistoryTable from './History';

const Profile: React.FC = () => {
  const navigate = useNavigate();
  const currentUser = AuthService.getCurrentUser();
  const [data, setData] = useState<UserProfile | null>(null);
  const [updateData , setUpdateData] = useState<UpdateUserProfile| null>(null);
  const [loading, setLoading] = useState(true);
  const [rentalHistory, setRentalHistory] = useState<RentalHistory | null>(null);
  useEffect(() => {
    const fetchUserData = async () => {
      const storedData = localStorage.getItem("UserEntity");
    
      if (storedData) {
        const parsedData = JSON.parse(storedData);
        setData(parsedData);
      }

      const savedRentalHistory = localStorage.getItem('rentalHistory');
      if (savedRentalHistory) {
        setRentalHistory(JSON.parse(savedRentalHistory));
      }
      
      setLoading(false); // Устанавливаем loading в false после загрузки данных
    };

    fetchUserData();
  }, []);

  if (!currentUser) {
    // Пользователь не авторизован, перенаправить его на страницу входа
    navigate("/login");
    return (
      <div className="container">
        <header className="jumbotron">
          <h3>
            <strong>Неавторизован</strong>
          </h3>
        </header>
      </div>
    );
  }

  if (loading ||!data) {
    return <div>Loading...</div>;
  }

  const handleAddData = (updatedData: UpdateUserProfile): void => {
    // Обновить данные в локальном хранилище
    const storedData = JSON.stringify({ userEntity: updatedData });
    localStorage.setItem('Update-profile', storedData);

    // Обновить состояние компонента
    setUpdateData(updatedData);
  };

  return (
    <div className="row">
      <div className=" col-lg-4">
          {data && (
            <div className="card-body  bg-light text-center  ">
              <img src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-chat/ava3.webp" alt="avatar"
                className="rounded-circle img-fluid" style={{ width: '150px' }}></img>
              <h5>{data?.name}</h5>
              <h5>Email : {data.email}</h5>
              </div>
          )}
   
      </div>
      <div className='col-lg-8'>
        <div className="card mb-4">
          <div className="card-body">
            <h1>Information</h1>
            <div className="row">
              <div className="col-sm-3">
                <p className="mb-0">Name</p>
              </div>
              <div className="col-sm-9">
                {data && (<p className="text-muted mb-0">{data?.name}</p>)}
              </div>
            </div>
            <hr/>
            <div className="row">
              <div className="col-sm-3">
                <p className="mb-0">Surname</p>
              </div>
              <div className="col-sm-9">
                {data && (<p className="text-muted mb-0">{data?.surname}</p>)}
              </div>
            </div>
            <hr/>
            <div className="row">
              <div className="col-sm-3">
                <p className="mb-0">Phone</p>
              </div>
              <div className="col-sm-9">
                {data && (<p className="text-muted mb-0">{data?.phoneNumber}</p>)}
              </div>
            </div>
            <hr/>
            <div className="row">
              <div className="col-sm-3">
                <p className="mb-0">Drive License</p>
              </div>
              <div className="col-sm-9">
                {data && (<p className="text-muted mb-0">{data?.driversLicense}</p>)}
              </div>
            </div>
            <hr/>
            <div className="row">
              <div className="col-sm-3">
                <p className="mb-0">Passport</p>
              </div>
              <div className="col-sm-9">
                {data && (<p className="text-muted mb-0">{data?.passportNumber}</p>)}
              </div>
            </div>
            <hr/>
            <div className='d-flex mt-3 justify-content-centr'>
              <AddDataModal onSubmit={handleAddData} />
            </div>
          </div>
           

        </div>
        <div className="card mb-4">
        <div className="card-body">
          <h1>History</h1>
          <RentalHistoryTable rentalHistory={rentalHistory} />
        </div>
        </div>
      </div>
    </div>
  );
};

export default Profile;
