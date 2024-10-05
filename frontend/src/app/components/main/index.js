'use client';
import { useState, useEffect } from "react";
import Swal from 'sweetalert2'
import Loader from "../loader"
import NewPerson from "../newPerson";
import List from "../listPeople";

const API_URL = 'http://localhost:5000/api/v1/person/';

export default function Main() {
    const getTodayDate = () => {
        const today = new Date();
        const year = today.getFullYear();
        const month = String(today.getMonth() + 1).padStart(2, "0");
        const day = String(today.getDate()).padStart(2, "0");
        return `${year}-${month}-${day}`;
    };

    const [loading, setLoading] = useState(true);
    const [refresh, setRefresh] = useState(true);
    const [people, setPeople] = useState([]);
    const [editing, setEditing] = useState(false);
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [formData, setFormData] = useState({
        firstName: "",
        lastName: "",
        userName: "",
        email: "",
        birthday: getTodayDate(),
        phoneNumber: ""
    });

    useEffect(() => {
        const getPeople = async () => {
            try {
                const response = await fetch(`${API_URL}get-all`);
                if (!response.ok) throw new Error('Error en la petición');
                const bodyRes = await response.json();
                setPeople(bodyRes.data);
            } catch (err) {
                console.error('Error al obtener datos', err)
            } finally {
                setLoading(false);
            }
        };
        getPeople();
    }, [refresh]);

    const handleChange = (e) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
    };

    const cleanPersonData = () => {
        setFormData({
            firstName: "",
            lastName: "",
            userName: "",
            email: "",
            birthday: getTodayDate(),
            phoneNumber: ""
        });
    }
    const handleAddPerson = async (e) => {
        e.preventDefault();
        if (Object.values(formData).some(field => !field)) return;

        const url = editing ? `${API_URL}update` : `${API_URL}create`;
        try {
            const response = await fetch(url, {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(formData)
            });

            if (!response.ok) throw new Error(`Error: ${response.status} ${response.statusText}`);

            Swal.fire({
                icon: "success",
                title: `Registro ${editing ? 'actualizado' : 'creado'} con éxito`,
                showConfirmButton: true,
                customClass: {
                    popup: 'dark:bg-gray-800 dark:text-white',
                    confirmButton: 'bg-blue-500 hover:bg-blue-700 text-white',
                },
            });

            if (editing) {
                setEditing(false);
            }
        } catch (error) {
            console.error(`Error al ${editing ? 'actualizar' : 'crear'} el registro:`, error);
        }

        cleanPersonData();
        setIsModalOpen(false);
        setRefresh(!refresh)
    };

    const handleDelete = async (id) => {

        Swal.fire({
            title: "Eliminar registro?",
            text: "No podras revertir esto!",
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Eliminar",
            cancelButtonText: "Cancelar",
            customClass: {
                popup: 'dark:bg-gray-800 dark:text-white',
                confirmButton: 'bg-blue-500 hover:bg-blue-700 text-white',
            },
        }).then(async (result) => {
            if (result.isConfirmed) {
                try {
                    const response = await fetch(`${API_URL}delete/${id}`, {
                        method: "DELETE",
                        headers: {
                            "Content-Type": "application/json",
                        }
                    });

                    if (!response.ok) throw new Error(`Error: ${response.status} ${response.statusText}`);

                    Swal.fire({
                        icon: "success",
                        title: "Registro eliminado con éxito",
                        showConfirmButton: true,
                        customClass: {
                            popup: 'dark:bg-gray-800 dark:text-white',
                            confirmButton: 'bg-blue-500 hover:bg-blue-700 text-white',
                        },
                    });
                } catch (error) {
                    console.error(`Error al ${editing ? 'actualizar' : 'crear'} el registro:`, error);
                }
            }
        });

        setPeople(people.filter((person) => person.id !== id));
    };

    const handleEdit = (person) => {
        setFormData({
            ...person,
            birthday: person.birthday.split("T")[0]
        });
        setEditing(true);
        setIsModalOpen(true);
    };

    const closeModal = () => {
        setIsModalOpen(false);
        cleanPersonData();
        setEditing(false);
    };
    return (
        <div className="min-h-screen bg-gray-900 text-white p-6">
            <div className="max-w-6xl mx-auto bg-gray-800 p-8 rounded-lg shadow-md">
                <h1 className="text-3xl font-bold text-center mb-6">Registro de Personas</h1>
                {loading ? (
                    <Loader />
                ) : (
                    <>
                        <div className="flex justify-end mb-4">
                            <button
                                onClick={() => setIsModalOpen(true)}
                                className="bg-green-500 hover:bg-green-600 text-white font-bold py-2 px-4 rounded transition-all duration-300 ease-in-out transform hover:scale-105"
                            >
                                Añadir Persona
                            </button>
                        </div>
                        <List
                            people={people}
                            handleEdit={handleEdit}
                            handleDelete={handleDelete}
                        >
                        </List>
                    </>
                )}
            </div>
            {isModalOpen && (
                <NewPerson
                    handleAddPerson={handleAddPerson}
                    formData={formData}
                    editing={editing}
                    handleChange={handleChange}
                    closeModal={closeModal}
                >
                </NewPerson>
            )}
        </div>
    )
}
