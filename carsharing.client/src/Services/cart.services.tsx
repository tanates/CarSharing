import axios from 'axios';
import {CarModelEntity} from '../types/ICart';
import {CartCarsRequistModel }from '../types/ICart';

const getAllCars = async (): Promise<CarModelEntity[]> => {
  const response = await axios.get<CarModelEntity[]>('http://localhost:7228/AllCars/get');
  return response.data;
};

const searchCars = async (brand: string): Promise<CarModelEntity[]> => {
  const response = await axios.get<CarModelEntity[]>(`http://yourapiurl/AllCars/${brand}`);
  return response.data;
};

const addCar = async (carData: CartCarsRequistModel): Promise<void> => {
  await axios.post('http://localhost:7228/AllCars/add', carData);
};

export { getAllCars, searchCars, addCar , };
