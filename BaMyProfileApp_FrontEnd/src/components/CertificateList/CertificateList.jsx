import React, { useState, useEffect } from "react";
import axios from "axios";
import "react-toastify/dist/ReactToastify.css";
import ToastService from "../services/ToastService";
import {
    Button,
    Checkbox,
    Datepicker,
    Dropdown,
    Label,
    Modal,
    Select,
    Textarea,
    TextInput,
} from "flowbite-react";
import FlowbiteGenericTable from "../Tables/FlowbiteGenericTable";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import { format } from "date-fns";
import { Api } from "../api/Api";
import { CertificateService } from "../services/CertificateService";

const Event = () => {
    const [errors, setErrors] = useState({});
    const [openAddModal, setOpenAddModal] = useState(false);
    const [openUpdateModal, setOpenUpdateModal] = useState(false);
    const [openDeleteModal, setOpenDeleteModal] = useState(false);
    const [selectedRow, setSelectedRow] = useState(false);
    const [date, setDate] = useState(new Date());
    const [data, setData] = useState([]);

    const formatDateToDateFns = (date) => {
        return format(date, "yyyy-MM-dd'T'HH:mm:ss");
    };

    const handleDateChange = (date) => {
        selectedRow.CERTIFICATEDATE = date;
        const { name, value } = date;
        setSelectedRow({ ...selectedRow, [name]: value });
    };
    useEffect(() => {
        getAllCertificates();
    }, []);


    const onChange = (e) => {
        const { name, value } = e.target;
        setSelectedRow({ ...selectedRow, [name]: value });
    };

    

    // const validationControl = (title, date, file) => {
    //     let validationErrors = {};
    //     if (!title || title.length < 2 || title.length > 50) {
    //         validationErrors.TITLELENGHT =
    //             "The event title must be between 2 and 50 characters long";
    //     }
    //     if (!/^([a-zA-ZğüşöçıİĞÜŞÖÇı0-9\s]+)$/.test(title))
    //         validationErrors.TITLECHARS =
    //             "Title must consist of only numbers and letters";
    //     if (date < formatDateToDateFns(new Date())) {
    //         validationErrors.DATE = "The date must be later than the current date";
    //     }

    //     if (file.length > 400) {
    //         validationErrors.FILE = "The file name cannot exceed 400 characters";
    //     }
    //     // Input değişikliklerinde hataları temizleyen fonksiyonlar
    //     setErrors(validationErrors);
    //     if (Object.keys(validationErrors).length > 0) {
    //         // Hata mesajlarını toastr ile göster
    //         Object.values(validationErrors).forEach((error) => {
    //             ToastService.toastError(error);
    //         });
    //         return false;
    //     }
    //     return true;
    // };

    const getAllCertificates = async () => {
        try {
            var response = await Api.handleRequestGetAsync("https://localhost:7052/api/Certificate/GetAll").then((res)=>{
                console.log(res);
                setData(res.data);
                if (res.status === 200) {
                    // ToastService.toastSuccess("Veriler başarıyla getirildi.");
    
                    let updatedData = null;
                    updatedData = res.data.data.map((e) => ({
                        ...e,
                        CERTIFICATEDATE: new Date(e.CERTIFICATEDATE),
                    }));
    
                    setData(updatedData);
                } else {
                    // ToastService.toastError("An error occurred while fetching the data");
                }
            })
            console.log(response);
            
                   
                
        } catch (error) {
            // ToastService.toastError("An error occurred while fetching the data");
            console.error("An error occurred:", error);
        }
    };

    const handleCreateSubmit = async (e) => {
        e.preventDefault();
        const name = e.target[0].value;
        const certificateDate = e.target[1].value;
        const description = e.target[2].value;
        const achievementStatus = e.target[3].checked;
        const data = {
            name: name,
            certificateDate: formatDateToDateFns(certificateDate),
            description: description,
            achievementStatus: achievementStatus,
        };

        // const validationResult = validationControl(title, date, file);
        // if (!validationResult) return;
        try {

            await CertificateService.create(data)            
                await getAllCertificates();
            setOpenAddModal(false);
        } catch (error) {
            // ToastService.toastError("Event create failed");

            console.error("An error occurred:", error);
        }
    };

    const handleUpdateSubmit = async (e) => {
        e.preventDefault();
        const name = e.target[0].value;
        const certificateDate = e.target[1].value;
        const description = e.target[2].value;
        const achievementStatus = e.target[3].checked;
        const data = {
            id:selectedRow.ID,
            name: name,
            certificateDate: formatDateToDateFns(certificateDate),
            description: description,
            achievementStatus: achievementStatus,
        };

        // const validationResult = validationControl(title, date, file);
    //     if (!validationResult) return;
        try {
            const { name, value } = e.target;
            setSelectedRow({ ...selectedRow, [name]: value });
                await CertificateService.update(data)
                await getAllCertificates();
            // ToastService.toastSuccess("Event successfully updated");
            setOpenUpdateModal(false);
        } catch (error) {
            // ToastService.toastError("An error occurred while deleting the event");
            console.error("An error occurred:", error);
        }
    };

    const handleDeleteSubmit = async (e) => {
        e.preventDefault();
        try {
            console.log(selectedRow)
            console.log(selectedRow.ID)

            await CertificateService.delete(selectedRow.ID)
            
                await getAllCertificates();
            // ToastService.toastSuccess("Event successfully deleted");
            setOpenDeleteModal(false);
        } catch (error) {
            // ToastService.toastError("An error occurred while deleting the program")
            console.error("An error occurred:", error);
        }
    };



    return (
        <>
            <FlowbiteGenericTable
                data={data}
                colSize={3}
                setOpenAddModal={setOpenAddModal}
                setOpenUpdateModal={setOpenUpdateModal}
                setOpenDeleteModal={setOpenDeleteModal}
                setSelectedRow={setSelectedRow}
            />

            <Modal
                show={openAddModal}
                size="md"
                popup
                onClose={() => setOpenAddModal(false)}
            >
                <Modal.Header>
                    <div className="text-lg font-semibold text-gray-900 dark:text-white pl-2">
                        Create New Certificate
                    </div>
                </Modal.Header>
                <Modal.Body>
                    <form onSubmit={handleCreateSubmit} className="p-4 md:p-5">
                        <div className="grid gap-4 mb-4 grid-cols-2">
                            <div className="col-span-2">
                                <label
                                    htmlFor="title"
                                    className="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
                                >
                                    Title
                                </label>
                                <TextInput
                                    label="name"
                                    id="NAME"
                                    name="NAME"
                                    type="text"
                                    placeholder="Certificate Name"
                                    onChange={onChange}
                                    required
                                />
                                {/* {errors.TITLELENGHT && (
                                    <div style={{ color: "red" }}>{errors.TITLELENGHT}</div>
                                    
                                )}
                                {errors.TITLECHARS && (
                                    <div style={{ color: "red" }}>{errors.TITLECHARS}</div>
                                    
                                )} */}
                            </div>
                            <div className="col-span-2">
                                <label
                                    htmlFor="datePicker"
                                    className="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
                                >
                                    Date
                                </label>

                                <DatePicker
                                    name="CERTIFICATEDATE"
                                    selected={date}
                                    onChange={(date) => setDate(date)}
                                    showTimeSelect
                                    dateFormat="yyyy-MM-dd HH:mm"
                                    timeFormat="HH:mm"
                                    className="p-2 border rounded-md shadow-sm focus:ring-2 focus:ring-blue-500"
                                    required
                                />

                                {/* {errors.DATE && (
                                    <div style={{ color: "red" }}>{errors.DATE}</div>
                                )} */}
                            </div>
                            <div className="col-span-2">
                                <label
                                    htmlFor="content"
                                    className="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
                                >
                                    File
                                </label>
                                <Textarea
                                    className="pl-2 pt-2"
                                    label="descripton"
                                    id="DESCRIPTION"
                                    name="DESCRIPTION"
                                    rows="4"
                                    placeholder="Descripton"
                                    onChange={onChange}
                                />
                                {/* {errors.FILE && (
                                    <div style={{ color: "red" }}>{errors.FILE}</div>
                                )} */}
                            </div>                            
                        </div>
                        <div className="col-span-4">
                        <Checkbox id="ACHIEVEMENTSTATUS" />
                                    <Label htmlFor="achievementStatus">Achievement status of the certificate</Label>
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
                                Create
                            </Button>
                        </div>
                    </form>
                </Modal.Body>
            </Modal>

            {/* UPDATEMODALL */}
            <Modal
                show={openUpdateModal}
                size="md"
                popup
                onClose={() => setOpenUpdateModal(false)}
            >
                <Modal.Header>
                    <div className="text-lg font-semibold text-gray-900 dark:text-white pl-2">
                        Update Certificate
                    </div>
                </Modal.Header>
                <Modal.Body>
                    <form onSubmit={handleUpdateSubmit} className="p-4 md:p-5">
                        <div className="grid gap-4 mb-4 grid-cols-2">
                        <div className="col-span-2">
                                <label
                                    htmlFor="title"
                                    className="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
                                >
                                    Title
                                </label>
                                <TextInput
                                    label="name"
                                    id="NAME"
                                    name="NAME"
                                    type="text"
                                    placeholder="Certificate Name"
                                    onChange={onChange}
                                    value={selectedRow.NAME}
                                    required
                                />
                                {/* {errors.TITLELENGHT && (
                                    <div style={{ color: "red" }}>{errors.TITLELENGHT}</div>
                                    
                                )}
                                {errors.TITLECHARS && (
                                    <div style={{ color: "red" }}>{errors.TITLECHARS}</div>
                                    
                                )} */}
                            </div>
                            <div className="col-span-2">
                                <label
                                    htmlFor="datePicker"
                                    className="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
                                >
                                    Date
                                </label>

                                <DatePicker
                                    name="CERTIFICATEDATE"
                                    selected={new Date(selectedRow.CERTIFICATEDATE)}
                                    onChange={(date) => handleDateChange(date)}
                                    showTimeSelect
                                    dateFormat="yyyy-MM-dd HH:mm"
                                    timeFormat="HH:mm"
                                    className="p-2 border rounded-md shadow-sm focus:ring-2 focus:ring-blue-500"
                                    required
                                />

                                {/* {errors.DATE && (
                                    <div style={{ color: "red" }}>{errors.DATE}</div>
                                )} */}
                            </div>
                            <div className="col-span-2">
                                <Textarea
                                    className="pl-2 pt-2"
                                    label="descripton"
                                    id="DESCRIPTION"
                                    name="DESCRIPTION"
                                    rows="4"
                                    placeholder="Descripton"
                                    value={selectedRow.DESCRIPTION}
                                    onChange={onChange}
                                />
                                {/* {errors.FILE && (
                                    <div style={{ color: "red" }}>{errors.FILE}</div>
                                )} */}
                            </div>                            
                        </div>
                        <div className="col-span-4">
                                    <Checkbox id="ACHIEVEMENTSTATUS"
                                     />
                                    <Label htmlFor="achievementStatus">Achievement status of the certificate</Label>
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
                                Update
                            </Button>
                        </div>
                    </form>
                </Modal.Body>
            </Modal>

            <Modal
                show={openDeleteModal}
                size="md"
                popup
                onClose={() => setOpenDeleteModal(false)}
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

export default Event;
