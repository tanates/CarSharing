import React, { useState } from 'react';
import { Button, Modal, ModalHeader, ModalBody, Form, FormGroup, Label, Input } from 'reactstrap';
import { UpdateUserProfile } from '../../types/userProfile';
import { submitForm } from '../../Services/update.data.services';

interface AddDataModalProps {
  onSubmit: (data: UpdateUserProfile) => void; // Явно укажите тип для пропса onSubmit
}

const AddDataModal: React.FC<AddDataModalProps> = ({ onSubmit }) => {
  // Состояние модального окна
  const [modal, setModal] = useState(false);

  // Состояние для хранения введённых данных
  const [newData, setNewData] = useState<UpdateUserProfile>({
    surname: '',
    email: '',
    phoneNumber: '',
    driversLicense: '',
    passportNumber: '',
  });
  // Функция для открытия/закрытия модального окна
  const toggle = () => setModal(!modal);

  // Функция для обработки изменения полей ввода
  const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setNewData({
      ...newData,
      [e.target.name]: e.target.value,
    });
  };

  // Функция для отправки данных на сервер
  const handleFormSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    try {
      await submitForm(newData);

      alert('Form submitted successfully!');
      onSubmit(newData); // Вызвать функцию handleAddData из компонента Profile
      toggle(); // Закрыть модальное окно
    } catch (error) {
      alert('Error submitting form. Please try again.');
    }
  };

  return (
    <div>
      <Button color="primary" onClick={toggle}>Update info</Button>
      <Modal isOpen={modal} toggle={toggle}>
        <ModalHeader toggle={toggle}>Update info</ModalHeader>
        <ModalBody>
          <Form onSubmit={handleFormSubmit}>
            <FormGroup>
              <Label for="surname">Surname</Label>
              <Input type="text" name="surname" id="surname" value={newData.surname} onChange={handleInputChange} required />
            </FormGroup>
            <FormGroup>
              <Label for="phoneNumber">Phone</Label>
              <Input type="text" name="phoneNumber" id="phoneNumber" value={newData.phoneNumber} onChange={handleInputChange} required />
            </FormGroup>
            <FormGroup>
              <Label for="driversLicense">Driver License</Label>
              <Input type="text" name="driversLicense" id="driversLicense" value={newData.driversLicense} onChange={handleInputChange} required />
            </FormGroup>
            <FormGroup>
              <Label for="passportNumber">Passport</Label>
              <Input type="text" name="passportNumber" id="passportNumber" value={newData.passportNumber} onChange={handleInputChange} required />
            </FormGroup>
            <Button color="primary" type="submit">Send</Button>
            <Button color="secondary" onClick={toggle}>Cancel</Button>
          </Form>
        </ModalBody>
      </Modal>
    </div>
  );
};

export default AddDataModal;
