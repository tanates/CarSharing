export interface CarModelEntity {
    id: string | null | undefined;
    name: string;
    imgCar: string;
    carDescription: string;
    carLicensePlate: string;
    carBrandsName: string;
    isActiveCarRental: boolean;
    price: number;
}

export interface CartCarsRequistModel {
    name?: string;
    imgCar: string;
    carDescription?: string;
    carLicensePlate?: string;
    carBrandsName: string;
    isActiveCarRental?: boolean;
    price?: string;
}