import React, { useState, useEffect } from "react";
import "react-toastify/dist/ReactToastify.css";
import {
    Button,
    Datepicker,
    Dropdown,
    Modal,
    Select,
    Textarea,
    TextInput,
} from "flowbite-react";
import FlowbiteGenericTable from "../Tables/FlowbiteGenericTable";
import "react-datepicker/dist/react-datepicker.css";
import { Api } from "../api/Api";

const Capability = () => {
    const [errors, setErrors] = useState({});
    const [openAddModal, setOpenAddModal] = useState(false);
    const [openUpdateModal, setOpenUpdateModal] = useState(false);
    const [openDeleteModal, setOpenDeleteModal] = useState(false);
    const [selectedRow, setSelectedRow] = useState(false);
    const [data, setData] = useState([]);

    useEffect(() => {
        getAllCapabilities();
    }, []);


    const onChange = (e) => {
        const { name, value } = e.target.value;
        if (selectedRow !== false) {

            selectedRow.CAPABILITYNAME = e.target.value;
            if (selectedRow.CAPABILITYNAME.length > 1 && selectedRow.CAPABILITYNAME.length < 257) {
                setErrors('');
            }
        }
        setSelectedRow({ ...selectedRow, [name]: value });
    };

    const onClose = (method) => {
            if(Object.keys(errors).length > 0){
                setErrors('');
            }
            method(false);
    };



    const validationControl = (capabilityName) => {
        let validationErrors = {};
        if (!capabilityName || capabilityName.length < 2 || capabilityName.length > 256) {
            validationErrors.CAPABILITYLENGHT =
                "The capability name must be between 2 and 256 characters long";
        }
       


        // Input değişikliklerinde hataları temizleyen fonksiyonlar
        setErrors(validationErrors);
        if (Object.keys(validationErrors).length > 0) {
            // Hata mesajlarını toastr ile göster

            return false;
        }
        return true;
    };

    const getAllCapabilities = async () => {
        try {
            await Api.handleRequestGetAsync(
                "https://localhost:7052/api/Capability/GetAll"
            ).then((response) => {
                if (response.status === 200) {
                    // ToastService.toastSuccess("Veriler başarıyla getirildi.");

                    let updatedData = null;
                    updatedData = response.data.data.map((e) => ({
                        ...e,
                    }));



                    setData(updatedData);
                } else {
                    // ToastService.toastError("An error occurred while fetching the data");
                }
            });
        } catch (error) {
            // ToastService.toastError("An error occurred while fetching the data");
            console.error("An error occurred:", error);
        }
    };

    const handleCreateSubmit = async (e) => {
        e.preventDefault();
        const capabilityName = e.target[0].value;
        const data = {
            capabilityName: capabilityName
        };

        const validationResult = validationControl(capabilityName);
        if (!validationResult) return;
        try {
            await Api.handleRequestPostAsync(
                "https://localhost:7052/api/Capability/Create",
                data,
                false
            ).then(async () => {
                await getAllCapabilities();
            });
            // ToastService.toastSuccess("Capability created");
            setOpenAddModal(false);
        } catch (error) {
            // ToastService.toastError("Capability create failed");

            console.error("An error occurred:", error);
        }
    };

    const handleUpdateSubmit = async (e) => {
        e.preventDefault();
        const capabilityName = e.target[0].value;
        const data = {
            id: selectedRow.ID,
            capabilityName: capabilityName
        };
        const validationResult = validationControl(capabilityName);
        if (!validationResult) return;
        try {
            const { name, value } = e.target;
            setSelectedRow({ ...selectedRow, [name]: value });
            await Api.handleRequestPutAsync(
                "https://localhost:7052/api/Capability/Update",
                data
            ).then(async () => {
                await getAllCapabilities();
            });
            // ToastService.toastSuccess("Capability successfully updated");
            setOpenUpdateModal(false);
        } catch (error) {
            // ToastService.toastError("An error occurred while deleting the capability");
            console.error("An error occurred:", error);
        }
    };

    const handleDeleteSubmit = async (e) => {
        e.preventDefault();
        try {

            await Api.handleRequestDeleteAsync(
                "https://localhost:7052/api/Capability/Delete", selectedRow.ID
            ).then(async () => {
                await getAllCapabilities();
            });
            // ToastService.toastSuccess("Capability successfully deleted");
            setOpenDeleteModal(false);
        } catch (error) {
            // ToastService.toastError("An error occurred while deleting the capability")
            console.error("An error occurred:", error);
        }
    };



    return (
        <>
            <FlowbiteGenericTable
                data={data}
                colSize={2}
                setOpenAddModal={setOpenAddModal}
                setOpenUpdateModal={setOpenUpdateModal}
                setOpenDeleteModal={setOpenDeleteModal}
                setSelectedRow={setSelectedRow}
            />

            <Modal
                show={openAddModal}
                size="md"
                popup
                onClose={() => onClose(setOpenAddModal)}
            >
                <Modal.Header>
                    <div className="text-lg font-semibold text-gray-900 dark:text-white pl-2">
                        Create New Capability
                    </div>
                </Modal.Header>
                <Modal.Body>
                    <form onSubmit={handleCreateSubmit} className="p-4 md:p-5">
                        <div className="grid gap-4 mb-4 grid-cols-2">
                            <div className="col-span-2">
                                <label
                                    htmlFor="capability"
                                    className="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
                                >
                                    Capability Name
                                </label>
                                <TextInput
                                    label="capability"
                                    id="CAPABILITY"
                                    name="CAPABILITY"
                                    type="text"
                                    placeholder="Capability"
                                    onChange={onChange}
                                    required
                                />
                                {errors.CAPABILITYLENGHT && (
                                    <div style={{ color: "red" }} id="capabilityLenghtError">{errors.CAPABILITYLENGHT}</div>

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
                onClose={() => onClose(setOpenUpdateModal)}
            >
                <Modal.Header>
                    <div className="text-lg font-semibold text-gray-900 dark:text-white pl-2">
                        Update Capability
                    </div>
                </Modal.Header>
                <Modal.Body>
                    <form onSubmit={handleUpdateSubmit} className="p-4 md:p-5">
                        <div className="grid gap-4 mb-4 grid-cols-2">
                            <div className="col-span-2">
                                <label
                                    htmlFor="capability"
                                    className="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
                                >
                                    Capability Name
                                </label>
                                <TextInput
                                    label="capability"
                                    id="CAPABILITY"
                                    name="CAPABILITY"
                                    type="text"
                                    value={selectedRow.CAPABILITYNAME}
                                    placeholder="Capability"
                                    onChange={onChange}
                                />
                                {errors.CAPABILITYLENGHT && (
                                    <div style={{ color: "red" }} id="capabilityLenghtError">{errors.CAPABILITYLENGHT}</div>

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

export default Capability;
