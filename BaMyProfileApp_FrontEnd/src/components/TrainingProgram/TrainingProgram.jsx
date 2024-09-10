import React, { useState, useEffect } from "react";
import axios from "axios";
import "react-toastify/dist/ReactToastify.css";
import ToastService from "../services/ToastService";
import { Button, Modal, Textarea, TextInput } from "flowbite-react";
import FlowbiteGenericTable from "../Tables/FlowbiteGenericTable";
import { Api } from "../api/Api";
const TrainingProgram = () => {
  const [errors, setErrors] = useState({});

  const [openAddModal, setOpenAddModal] = useState(false);
  const [openUpdateModal, setOpenUpdateModal] = useState(false);
  const [openDeleteModal, setOpenDeleteModal] = useState(false);
  const [selectedRow, setSelectedRow] = useState(false);

  const [data, setData] = useState([
    {  name: "BOOST", TimeInHours: "660", content: ".Net" },
    {  name: "BOOST", TimeInHours: "330", content: "React" },
  ]);

  useEffect(() => {
    getAllTrainingPrograms();
  }, []);

  const getAllTrainingPrograms = async () => {
    try {
      await Api.handleRequestGetAsync(
        "https://localhost:7052/api/TrainingProgram/GetAll"
      ).then((r) => {
        // ToastService.toastSuccess("Data retrieved successfully");
        setData(r.data.data);
      });
    } catch (error) {
      // ToastService.toastError("An error occurred while retrieving data.!");
      console.error("Hata oluştu:", error);
    }
  };

  const validationControl = (name, timeInHours, content) => {
    let validationErrors = {};
    const isValidNumber = (value) => {
      return /^[0-9]+$/.test(value); // Sadece sayı içeriyor mu kontrolü
    };
    if (!name || name.length < 2) {
      validationErrors.NAME = "The program name must be at least 2 characters.";
    } else if (name.length > 50) {
      validationErrors.NAME = "The program name must be at most 50 characters.";
    }
    
    if (!isValidNumber(timeInHours) || parseInt(timeInHours, 10) < 2) {
      validationErrors.TIMEINHOURS = "The program time must be at least 2 hours and contain only numbers.";
    }
    
    if (!content || content.length < 2) {
      validationErrors.CONTENT = "The program content must be at least 2 characters.";
    } else if (content.length > 500) {
      validationErrors.CONTENT = "The program content must be at most 500 characters.";
    }
    // Input değişikliklerinde hataları temizleyen fonksiyonlar
    setErrors(validationErrors);
    if (Object.keys(validationErrors).length > 0) {
      // Ekranda hata mesajları gösterilecek
      return false;
    }
    return true;
  };

  const handleCreateSubmit = async (e) => {
    e.preventDefault();
    const name = e.target[0].value;
    const timeInHours = e.target[1].value;
    const content = e.target[2].value;
    const validationResult = validationControl(name, timeInHours, content);
    if (!validationResult) return;
    try {
      await Api.handleRequestPostAsync("https://localhost:7052/api/TrainingProgram/Create",{
        name: name,
        timeInHours: timeInHours,
        content: content,
      },true).then(async () => {
          await getAllTrainingPrograms();
        });
      // Başarılı yanıt aldıktan sonra başarılı mesajı göster
      // ToastService.toastSuccess("The program has been created successfully!");
      setOpenAddModal(false);
    } catch (error) {
      // ToastService.toastError("An error occurred while retrieving data.!");

      console.error("Hata oluştu:", error);
    }
  };

  const handleUpdateSubmit = async (e) => {
    e.preventDefault();
    const name = e.target[0].value;
    const timeInHours = e.target[1].value;
    const content = e.target[2].value;
    const validationResult = validationControl(name, timeInHours, content);
    if (!validationResult) return;
    try {
      await Api.handleRequestPutAsync("https://localhost:7052/api/TrainingProgram/Update",{
        id: selectedRow.ID,
        name: name,
        timeInHours: timeInHours,
        content: content,
      },)
        .then(async () => {
          await getAllTrainingPrograms();
        });
      // Başarılı yanıt aldıktan sonra başarılı mesajı göster
      // ToastService.toastSuccess("The program has been updated successfully!");
      setOpenUpdateModal(false);
    } catch (error) {
      // ToastService.toastError("An error occurred while updating the program!");
      console.error("Hata oluştu:", error);
    }
  };

  const handleDeleteSubmit = async (e) => {
    e.preventDefault();
    try {
      await Api.handleRequestDeleteAsync("https://localhost:7052/api/TrainingProgram/Delete",selectedRow.ID)
        .then(async () => {
          await getAllTrainingPrograms();
        });
      // Başarılı yanıt aldıktan sonra başarılı mesajı göster
      // ToastService.toastSuccess("Program deleted successfully!");
      setOpenDeleteModal(false);
    } catch (error) {
      // ToastService.toastError("An error occurred while deleting the program!");
      console.error("Hata oluştu:", error);
    }
  };

  const onChange = (e) => {
    const { id, value } = e.target; // id ve value'yu e.target'dan alıyoruz

  if (id === "TIMEINHOURS") {
    // Değerin yalnızca sayılardan oluştuğunu kontrol et
    const isValidNumber = /^[0-9]*$/.test(value);

    if (!isValidNumber) {
      // Geçersiz giriş varsa, değeri temizle
      e.target.value = selectedRow[id] || ""; // Önceki geçerli değeri koru
      return;
    }
  }

  // Hata durumunda seçili alanı temizle
  if (value !== "") {
    const filtered = { ...errors };
    delete filtered[id];
    setErrors(filtered);
  }

    const newValue = { ...selectedRow };
    newValue[e.target.id] = e.target.value;
    setSelectedRow(newValue);
  };

  return (
    <>
      <FlowbiteGenericTable
        data={data}
        colSize={4}
        setOpenAddModal={setOpenAddModal}
        setOpenUpdateModal={setOpenUpdateModal}
        setOpenDeleteModal={setOpenDeleteModal}
        setSelectedRow={setSelectedRow}
      />

      <Modal
        show={openAddModal}
        size="md"
        popup
        onClose={() => {
          setOpenAddModal(false);
          setErrors({}); // Hata mesajlarını temizle
        }}
      >
        <Modal.Header>
          <div className="text-lg font-semibold text-gray-900 dark:text-white">
            Create New Training Program
          </div>
        </Modal.Header>
        <Modal.Body>
          <form onSubmit={handleCreateSubmit} className="p-4 md:p-5">
            <div className="grid gap-4 mb-4 grid-cols-2">
              <div className="col-span-2">
                <label
                  htmlFor="name"
                  className="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
                >
                  Program Name
                </label>
                <TextInput
                  label="name"
                  id="NAME"
                  name="NAME"
                  type="text"
                  placeholder="Program Name..."
                  onChange={onChange}
                />
                {errors.NAME && (
                  <div style={{ color: "red" }}>{errors.NAME}</div>
                )}
              </div>
              <div className="col-span-2">
                <label
                  htmlFor="TimeInHours"
                  className="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
                >
                  Program Duration
                </label>
                <TextInput
                  label="TimeInHours"
                  id="TIMEINHOURS"
                  name="TIMEINHOURS"
                  type="text"
                  placeholder="Program Duration..."
                  onChange={onChange}
                />
                {errors.TIMEINHOURS && (
                  <div style={{ color: "red" }}>{errors.TIMEINHOURS}</div>
                )}
              </div>
              <div className="col-span-2">
                <label
                  htmlFor="content"
                  className="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
                >
                  Program Content
                </label>
                <Textarea
                  label="content"
                  id="CONTENT"
                  name="CONTENT"
                  rows="4"
                  placeholder="Program Content..."
                  onChange={onChange}
                />
                {errors.CONTENT && (
                  <div style={{ color: "red" }}>{errors.CONTENT}</div>
                )}
              </div>
            </div>
            <div className="flex justify-end">
              <Button
                type="submit"
                size="md"
                className="text-white inline-flex items-center bg-palette-5  focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm px-2.5 py-1.5 text-center dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800"
              >
                <svg
                  className="me-1 -ms-1 w-5 h-5"
                  fill="currentColor"
                  viewBox="0 0 20 20"
                  xmlns="http://www.w3.org/2000/svg"
                >
                  <path
                    fillRule="evenodd"
                    d="M10 5a1 1 0 011 1v3h3a1 1 0 110 2h-3v3a1 1 0 11-2 0v-3H6a1 1 0 110-2h3V6a1 1 0 011-1z"
                    clipRule="evenodd"
                  ></path>
                </svg>
               ADD
              </Button>
            </div>
          </form>
        </Modal.Body>
      </Modal>
      <Modal
        show={openUpdateModal}
        size="md"
        popup
        onClose={() => {
          setOpenUpdateModal(false);
          setErrors({}); // Hata mesajlarını temizle
        }}
      >
        <Modal.Header>
          <div className="pt-3 text-lg  font-semibold text-gray-900 dark:text-white">
            UPDATE
          </div>
        </Modal.Header>
        <Modal.Body>
          <form onSubmit={handleUpdateSubmit}>
            <div className="grid gap-4 mb-4 sm:grid-cols-2">
              <div>
                <label
                  htmlFor="name"
                  className="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
                >
                  Program Name
                </label>
                <input
                  type="text"
                  name="NAME"
                  id="NAME"
                  value={selectedRow.NAME}
                  onChange={onChange}
                  className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-primary-500 dark:focus:border-primary-500"
                  placeholder="Program Name..."
                />
                {errors.NAME && (
                  <div style={{ color: "red" }}>{errors.NAME}</div>
                )}
              </div>
              <div>
                <label
                  htmlFor="brand"
                  className="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
                >
                  Program  Duration
                </label>
                <input
                  type="text"
                  name="TIMEINHOURS"
                  id="TIMEINHOURS"
                  value={selectedRow.TIMEINHOURS}
                  onChange={onChange}
                  className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-primary-500 dark:focus:border-primary-500"
                  placeholder="Program Duration..."
                />
                {errors.TIMEINHOURS && (
                  <div style={{ color: "red" }}>{errors.TIMEINHOURS}</div>
                )}
              </div>

              <div className="sm:col-span-2">
                <label
                  htmlFor="description"
                  className="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
                >
                  Program Content
                </label>
                <textarea
                  id="CONTENT"
                  name="CONTENT"
                  rows="5"
                  value={selectedRow.CONTENT}
                  onChange={onChange}
                  className="block p-2.5 w-full text-sm text-gray-900 bg-gray-50 rounded-lg border border-gray-300 focus:ring-primary-500 focus:border-primary-500 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-primary-500 dark:focus:border-primary-500"
                  placeholder="Program Açıklaması Giriniz..."
                />
                {errors.CONTENT && (
                  <div style={{ color: "red" }}>{errors.CONTENT}</div>
                )}
              </div>
            </div>
            <div className="flex items-center space-x-4">
              <Button
                type="submit"
                className="text-white bg-palette-5  focus:ring-4 focus:outline-none focus:ring-primary-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center dark:bg-primary-600 dark:hover:bg-primary-700 dark:focus:ring-primary-800"
              >
                UPDATE
              </Button>
            </div>
          </form>
        </Modal.Body>
      </Modal>

      <Modal
        show={openDeleteModal}
        size="md"
        popup
        onClose={() => {
          setOpenDeleteModal(false);
          setErrors({}); // Hata mesajlarını temizle
        }}
      >
        <Modal.Header />
        <Modal.Body>
          <div className="text-center">
            <svg
              className="text-gray-400 dark:text-gray-500 w-11 h-11 mb-3.5 mx-auto"
              aria-hidden="true"
              fill="currentColor"
              viewBox="0 0 20 20"
              xmlns="http://www.w3.org/2000/svg"
            >
              <path
                fillRule="evenodd"
                d="M9 2a1 1 0 00-.894.553L7.382 4H4a1 1 0 000 2v10a2 2 0 002 2h8a2 2 0 002-2V6a1 1 0 100-2h-3.382l-.724-1.447A1 1 0 0011 2H9zM7 8a1 1 0 012 0v6a1 1 0 11-2 0V8zm5-1a1 1 0 00-1 1v6a1 1 0 102 0V8a1 1 0 00-1-1z"
                clipRule="evenodd"
              />
            </svg>
            <p className="mb-4 text-gray-500 dark:text-gray-300">
              Are you sure you want to delete this item?
            </p>
            <div className="flex justify-center items-center space-x-4">
              <Button color="light" onClick={() => setOpenDeleteModal(false)}>
                No, cancel
              </Button>
              <Button color="failure" onClick={handleDeleteSubmit}>
                Yes, I'm sure
              </Button>
            </div>
          </div>
        </Modal.Body>
      </Modal>
    </>
  );
};

export default TrainingProgram;
