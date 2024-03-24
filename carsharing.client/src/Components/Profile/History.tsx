import React from 'react';
import { RentalHistory } from "../../types/rentalHistory"

interface RentalHistoryTableProps {
  rentalHistory: RentalHistory | null;
}

const RentalHistoryTable: React.FC<RentalHistoryTableProps> = ({ rentalHistory }) => {
  if (!rentalHistory) {
    return <div>No rental history available</div>;
  }

  return (
    <div>
      <h2>Rental History</h2>
      <table>
        <thead>
          <tr>
            <th>Rental Start Date</th>
            <th>Rental End Date</th>
            <th>Car License Plate</th>
            <th>Car Name</th>
            <th>Price All Time</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>{rentalHistory.rentalStartDate}</td>
            <td>{rentalHistory.retntalEndDate}</td>
            <td>{rentalHistory.carLicensePlate}</td>
            <td>{rentalHistory.careName}</td>
            <td>{rentalHistory.priceAllTime}</td>
          </tr>
        </tbody>
      </table>
    </div>
  );
};

export default RentalHistoryTable;
