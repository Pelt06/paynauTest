import React, { useState, useEffect } from "react";

export default function NewPerson({
  handleAddPerson, formData, editing, handleChange, closeModal
}) {


  return (
    <div className="fixed inset-0 flex items-center justify-center z-50 bg-black bg-opacity-50 animate-fade-in">
      <div className="bg-gray-800 p-8 rounded-lg shadow-lg max-w-lg w-full transform transition-transform duration-300 ease-out scale-95 animate-zoom-in">
        <h2 className="text-2xl font-bold mb-4">{editing ? "Editar Persona" : "Añadir Persona"}</h2>

        <form onSubmit={handleAddPerson} className="space-y-4">
          <div>
            <label className="block text-gray-400 text-sm font-bold mb-2" htmlFor="firstName">Nombre</label>
            <input
              id="firstName"
              name="firstName"
              type="text"
              value={formData.firstName}
              onChange={handleChange}
              className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-900 leading-tight focus:outline-none focus:shadow-outline"
              placeholder="Introduce el nombre"
            />
          </div>

          <div>
            <label className="block text-gray-400 text-sm font-bold mb-2" htmlFor="lastName">Apellido</label>
            <input
              id="lastName"
              name="lastName"
              type="text"
              value={formData.lastName}
              onChange={handleChange}
              className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-900 leading-tight focus:outline-none focus:shadow-outline"
              placeholder="Introduce el apellido"
            />
          </div>

          <div>
            <label className="block text-gray-400 text-sm font-bold mb-2" htmlFor="userName">Usuario</label>
            <input
              id="userName"
              name="userName"
              type="text"
              value={formData.userName}
              onChange={handleChange}
              className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-900 leading-tight focus:outline-none focus:shadow-outline"
              placeholder="Introduce el correo"
            />
          </div>

          <div>
            <label className="block text-gray-400 text-sm font-bold mb-2" htmlFor="email">Correo Electrónico</label>
            <input
              id="email"
              name="email"
              type="text"
              value={formData.email}
              onChange={handleChange}
              className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-900 leading-tight focus:outline-none focus:shadow-outline"
              placeholder="Introduce el correo"
            />
          </div>

          <div>
            <label className="block text-gray-400 text-sm font-bold mb-2" htmlFor="birthday">Fecha de nacimiento</label>
            <input
              id="birthday"
              name="birthday"
              type="date"
              value={formData.birthday}
              onChange={handleChange}
              className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-900 leading-tight focus:outline-none focus:shadow-outline"
              placeholder="Introduce la fecha de nacimiento"
            />
          </div>

          <div>
            <label className="block text-gray-400 text-sm font-bold mb-2" htmlFor="phoneNumber">Teléfono</label>
            <input
              id="phoneNumber"
              name="phoneNumber"
              type="text"
              value={formData.phoneNumber}
              onChange={handleChange}
              className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-900 leading-tight focus:outline-none focus:shadow-outline"
              placeholder="Introduce el teléfono"
            />
          </div>

          <div className="flex justify-between">
            <button
              type="submit"
              className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline"
            >
              {editing ? "Actualizar" : "Añadir"}
            </button>
            <button
              type="button"
              onClick={closeModal}
              className="bg-gray-500 hover:bg-gray-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline"
            >
              Cancelar
            </button>
          </div>
        </form>
      </div>
    </div>
  )
}
