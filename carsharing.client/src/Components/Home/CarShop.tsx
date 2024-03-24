import React, { useState, useEffect } from 'react';
import { CarModelEntity } from '../../types/ICart'; // Предположим, что у вас есть файл с типами
import { getAllCars } from '../../Services/cart.services';

interface CarListProps {
  cars: CarModelEntity[];
}

const CarList: React.FC<CarListProps> = ({ cars }) => {
  const [loggedIn, setLoggedIn] = useState(false); // Предположим, что здесь будет логика для проверки авторизации пользователя
  const [carList, setCarList] = useState<CarModelEntity[]>([]);
  useEffect(() => {
    const fetchCars = async () => {
      const allCars = await getAllCars(); // Вызов функции для получения всех машин
      setCarList(allCars);
    };

    fetchCars();
  }, []);
  const handleRentClick = (car: CarModelEntity) => {
    if (!loggedIn) {
      // Редирект на страницу авторизации
      // Например, с использованием React Router: history.push('/login');
      return;
    }
    const hoursToRent = prompt('Enter the number of hours for rental:', '1');
    if (hoursToRent && !isNaN(parseInt(hoursToRent))) {
      const hours = parseInt(hoursToRent);
      const totalPrice = car.price * hours;
      // Логика для отправки запроса на сервер API для аренды автомобиля
      handleRentCar(car, hours, totalPrice);
    } else {
      alert('Please enter a valid number of hours for rental.');
    }
  };

  const handleRentCar = (car: CarModelEntity, hours: number, totalPrice: number) => {
   
    fetch('your-api-endpoint', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
        // Добавьте заголовок авторизации, если требуется
      },
      body: JSON.stringify({
        carId: car.id,
        hours: hours,
        totalPrice: totalPrice
      })
    })
    .then(response => {
      // Обработка ответа от сервера
    })
    .catch(error => {
      // Обработка ошибки
    });
   
  };

  return (
    <div>
      <h2>Available Cars</h2>
      {carList.map((car) => (
        <div key={car.id}>
          <h3>{car.name}</h3>
          <img src={car.imgCar} alt={car.name} />
          <p>Description: {car.carDescription}</p>
          <p>License Plate: {car.carLicensePlate}</p>
          <p>Brand: {car.carBrandsName}</p>
          <p>Price: ${car.price}</p>
          <button onClick={() => handleRentClick(car)}>Rent</button>
        </div>
      ))}
    </div>
  );
};

export default CarList;
