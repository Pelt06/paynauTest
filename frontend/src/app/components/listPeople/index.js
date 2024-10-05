import React, { useState, useEffect } from "react";


export default function List({ people, handleEdit, handleDelete }) {


  return (
    <div>
      <table className="min-w-full table-auto text-white">
        <thead>
          <tr className="bg-gray-700">
            <th className="px-4 py-2">Nombre</th>
            <th className="px-4 py-2">Apelido</th>
            <th className="px-4 py-2">Usuario</th>
            <th className="px-4 py-2">Correo Electrónico</th>
            <th className="px-4 py-2">Fecha de nacimiento</th>
            <th className="px-4 py-2">Teléfono</th>
            <th className="px-4 py-2">Acciones</th>
          </tr>
        </thead>
        <tbody>
          {people.length === 0 ? (
            <tr>
              <td colSpan="7" className="text-center text-gray-400">No hay personas registradas.</td>
            </tr>
          ) : (
            people.map((person) => (
              <tr key={person.id} className="border-b border-gray-600">
                <td className="px-4 py-2">{person.firstName}</td>
                <td className="px-4 py-2">{person.lastName}</td>
                <td className="px-4 py-2">{person.userName}</td>
                <td className="px-4 py-2">{person.email}</td>
                <td className="px-4 py-2">
                {new Date(person.birthday).toLocaleDateString("es-ES", {
                  year: "numeric",
                  month: "long",
                  day: "numeric",
                })}</td>
                <td className="px-4 py-2">{person.phoneNumber}</td>
                <td className="px-4 py-2 flex space-x-2">
                  <button
                    onClick={() => handleEdit(person)}
                    className="bg-yellow-500 hover:bg-yellow-600 text-white font-bold py-1 px-2 rounded transition-all duration-300 ease-in-out transform hover:scale-105"
                  >
                    Editar
                  </button>
                  <button
                    onClick={() => handleDelete(person.id)}
                    className="bg-red-500 hover:bg-red-600 text-white font-bold py-1 px-2 rounded transition-all duration-300 ease-in-out transform hover:scale-105"
                  >
                    Eliminar
                  </button>
                </td>
              </tr>
            ))
          )}
        </tbody>
      </table>
    </div>
  )
}
