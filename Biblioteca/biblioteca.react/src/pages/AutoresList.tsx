import { useEffect, useState } from 'react';
import type { Autor } from '../types';
import { AutoresService } from '../services/api';

export default function AutoresList() {
  const [autores, setAutores] = useState<Autor[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const [editingId, setEditingId] = useState<number | null>(null);
  const [form, setForm] = useState<{ nombre: string; pais: string }>({ nombre: '', pais: '' });

  const fetchAutores = async () => {
    try {
      const data = await AutoresService.getAll();
      setAutores(data);
    } catch (err) {
      setError('Error al cargar la lista de autores');
      console.error(err);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchAutores();
  }, []);

  const handleEdit = (autor: Autor) => {
    setEditingId(autor.id);
    setForm({ nombre: autor.nombre, pais: autor.pais });
  };

  const handleDelete = async (id: number) => {
    if (window.confirm('¿Seguro que deseas eliminar el autor?')) {
      try {
        await AutoresService.delete(id);
        fetchAutores();
      } catch (err) {
        alert('Ocurrió un error al eliminar');
      }
    }
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      if (editingId) {
        await AutoresService.update(editingId, form);
      } else {
        await AutoresService.create(form);
      }
      setEditingId(null);
      setForm({ nombre: '', pais: '' });
      fetchAutores();
    } catch (error) {
      alert('Error al guardar el autor');
    }
  };

  if (loading) return <div>Cargando...</div>;
  if (error) return <div className="text-red-600">{error}</div>;

  return (
    <div className="space-y-8">
      {/* Formulario de Alta y Edición */}
      <div className="bg-white shadow px-4 py-5 sm:rounded-lg sm:p-6">
        <h3 className="text-base font-semibold leading-6 text-gray-900">
          {editingId ? 'Editar Autor' : 'Nuevo Autor'}
        </h3>
        <form onSubmit={handleSubmit} className="mt-5 sm:flex sm:items-center space-y-4 sm:space-y-0 sm:space-x-4">
          <div className="w-full sm:max-w-xs">
            <label htmlFor="nombre" className="sr-only">Nombre</label>
            <input
              type="text"
              name="nombre"
              id="nombre"
              value={form.nombre}
              onChange={(e) => setForm({ ...form, nombre: e.target.value })}
              className="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6 px-3"
              placeholder="Nombre del autor"
              required
            />
          </div>
          <div className="w-full sm:max-w-xs">
            <label htmlFor="pais" className="sr-only">País</label>
            <input
              type="text"
              name="pais"
              id="pais"
              value={form.pais}
              onChange={(e) => setForm({ ...form, pais: e.target.value })}
              className="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6 px-3"
              placeholder="País de origen"
              required
            />
          </div>
          <button
            type="submit"
            className="mt-3 inline-flex w-full items-center justify-center rounded-md bg-indigo-600 px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600 sm:mt-0 sm:ml-3 sm:w-auto"
          >
            {editingId ? 'Actualizar' : 'Guardar'}
          </button>
          {editingId && (
            <button
              type="button"
              onClick={() => { setEditingId(null); setForm({ nombre: '', pais: '' }); }}
              className="mt-3 inline-flex w-full items-center justify-center rounded-md bg-white px-3 py-2 text-sm font-semibold text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 hover:bg-gray-50 sm:mt-0 sm:ml-3 sm:w-auto"
            >
              Cancelar
            </button>
          )}
        </form>
      </div>

      {/* Listado de Autores */}
      <div className="bg-white shadow sm:rounded-lg">
        <ul role="list" className="divide-y divide-gray-200">
          {autores.map((autor) => (
            <li key={autor.id} className="flex items-center justify-between gap-x-6 py-5 px-4 sm:px-6">
              <div className="min-w-0">
                <div className="flex items-start gap-x-3">
                  <p className="text-sm font-semibold leading-6 text-gray-900">{autor.nombre}</p>
                </div>
                <div className="mt-1 flex items-center gap-x-2 text-xs leading-5 text-gray-500">
                  <p className="whitespace-nowrap">{autor.pais}</p>
                </div>
                {/* Listar libros asociados si hay */}
                {autor.libros && autor.libros.length > 0 && (
                  <div className="mt-1 text-xs text-gray-500">
                    Libros: {autor.libros.map(l => l.titulo).join(', ')}
                  </div>
                )}
              </div>
              <div className="flex flex-none items-center gap-x-4">
                <button
                  onClick={() => handleEdit(autor)}
                  className="hidden rounded-md bg-white px-2.5 py-1.5 text-sm font-semibold text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 hover:bg-gray-50 sm:block"
                >
                  Editar
                </button>
                <button
                  onClick={() => handleDelete(autor.id)}
                  className="hidden rounded-md bg-red-50 text-red-600 px-2.5 py-1.5 text-sm font-semibold shadow-sm ring-1 ring-inset ring-red-200 hover:bg-red-100 sm:block"
                >
                  Eliminar
                </button>
              </div>
            </li>
          ))}
          {autores.length === 0 && (
            <li className="py-5 px-4 text-center text-sm text-gray-500">
              No hay autores registrados.
            </li>
          )}
        </ul>
      </div>
    </div>
  );
}