import { useEffect, useState } from 'react';
import type { Libro, Autor } from '../types';
import { LibrosService, AutoresService } from '../services/api';

export default function LibrosList() {
  const [libros, setLibros] = useState<Libro[]>([]);
  const [autores, setAutores] = useState<Autor[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const [editingId, setEditingId] = useState<number | null>(null);
  const [form, setForm] = useState<{ titulo: string; isbn: string; anio: number; autorIds: number[] }>({ 
    titulo: '', isbn: '', anio: new Date().getFullYear(), autorIds: []
  });

  const fetchData = async () => {
    try {
      const [librosData, autoresData] = await Promise.all([
        LibrosService.getAll(),
        AutoresService.getAll()
      ]);
      setLibros(librosData);
      setAutores(autoresData);
    } catch (err) {
      setError('Error al cargar la lista de libros y autores');
      console.error(err);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchData();
  }, []);

  const handleEdit = (libro: Libro) => {
    setEditingId(libro.id);
    setForm({ 
      titulo: libro.titulo, 
      isbn: libro.isbn, 
      anio: libro.anio,
      autorIds: libro.autores ? libro.autores.map(a => a.id) : []
    });
  };

  const handleDelete = async (id: number) => {
    if (window.confirm('¿Seguro que deseas eliminar el libro?')) {
      try {
        await LibrosService.delete(id);
        fetchData();
      } catch (err) {
        alert('Ocurrió un error al eliminar');
      }
    }
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      if (editingId) {
        await LibrosService.update(editingId, form);
      } else {
        await LibrosService.create(form);
      }
      setEditingId(null);
      setForm({ titulo: '', isbn: '', anio: new Date().getFullYear(), autorIds: [] });
      fetchData();
    } catch (error) {
      alert('Error al guardar el libro');
    }
  };

  const handleAutorToggle = (autorId: number) => {
    setForm(prev => {
      const currentIds = prev.autorIds;
      if (currentIds.includes(autorId)) {
        return { ...prev, autorIds: currentIds.filter(id => id !== autorId) };
      } else {
        return { ...prev, autorIds: [...currentIds, autorId] };
      }
    });
  };

  if (loading) return <div>Cargando...</div>;
  if (error) return <div className="text-red-600">{error}</div>;

  return (
    <div className="space-y-8">
      {/* Formulario */}
      <div className="bg-white shadow px-4 py-5 sm:rounded-lg sm:p-6">
        <h3 className="text-base font-semibold leading-6 text-gray-900">
          {editingId ? 'Editar Libro' : 'Nuevo Libro'}
        </h3>
        <form onSubmit={handleSubmit} className="mt-5 space-y-4">
          <div className="sm:flex sm:items-center sm:space-y-0 sm:space-x-4">
            <div className="w-full sm:max-w-xs">
              <input
                type="text"
                name="titulo"
                value={form.titulo}
                onChange={(e) => setForm({ ...form, titulo: e.target.value })}
                className="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm px-3"
                placeholder="Título"
                required
              />
            </div>
            <div className="w-full sm:max-w-xs">
              <input
                type="text"
                name="isbn"
                value={form.isbn}
                onChange={(e) => setForm({ ...form, isbn: e.target.value })}
                className="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm px-3"
                placeholder="ISBN"
                required
              />
            </div>
            <div className="w-full sm:max-w-[100px]">
              <input
                type="number"
                name="anio"
                value={form.anio}
                onChange={(e) => setForm({ ...form, anio: parseInt(e.target.value) || 0 })}
                className="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm px-3"
                placeholder="Año"
                required
              />
            </div>
          </div>

          <div className="mt-4">
            <label className="text-sm font-medium text-gray-700">Autores:</label>
            <div className="mt-2 flex flex-wrap gap-3">
              {autores.map(autor => (
                <label key={autor.id} className="inline-flex items-center">
                  <input
                    type="checkbox"
                    checked={form.autorIds.includes(autor.id)}
                    onChange={() => handleAutorToggle(autor.id)}
                    className="h-4 w-4 rounded border-gray-300 text-indigo-600 focus:ring-indigo-600"
                  />
                  <span className="ml-2 text-sm text-gray-700">{autor.nombre}</span>
                </label>
              ))}
              {autores.length === 0 && <span className="text-sm text-gray-500">No hay autores registrados. Da de alta autores primero.</span>}
            </div>
          </div>

          <div className="pt-4">
            <button
              type="submit"
              className="inline-flex items-center justify-center rounded-md bg-indigo-600 px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-indigo-500 focus-visible:outline sm:w-auto"
            >
              {editingId ? 'Actualizar' : 'Guardar'}
            </button>
            {editingId && (
              <button
                type="button"
                onClick={() => { setEditingId(null); setForm({ titulo: '', isbn: '', anio: new Date().getFullYear(), autorIds: [] }); }}
                className="ml-3 inline-flex items-center justify-center rounded-md bg-white px-3 py-2 text-sm font-semibold text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 hover:bg-gray-50 sm:w-auto"
              >
                Cancelar
              </button>
            )}
          </div>
        </form>
      </div>

      {/* Listado */}
      <div className="bg-white shadow sm:rounded-lg">
        <ul role="list" className="divide-y divide-gray-200">
          {libros.map((libro) => (
            <li key={libro.id} className="flex items-center justify-between gap-x-6 py-5 px-4 sm:px-6">
              <div className="min-w-0">
                <p className="text-sm font-semibold leading-6 text-gray-900">
                  {libro.titulo} <span className="text-xs text-gray-500 font-normal">({libro.anio})</span>
                </p>
                <div className="mt-1 flex items-center gap-x-2 text-xs leading-5 text-gray-500">
                  <p>ISBN: {libro.isbn}</p>
                </div>
                {/* Listar autores asociados si hay */}
                {libro.autores && libro.autores.length > 0 && (
                  <div className="mt-1 text-xs text-gray-500">
                    Autores: {libro.autores.map(a => a.nombre).join(', ')}
                  </div>
                )}
              </div>
              <div className="flex flex-none items-center gap-x-4">
                <button
                  onClick={() => handleEdit(libro)}
                  className="hidden rounded-md bg-white px-2.5 py-1.5 text-sm font-semibold text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 hover:bg-gray-50 sm:block"
                >
                  Editar
                </button>
                <button
                  onClick={() => handleDelete(libro.id)}
                  className="hidden rounded-md bg-red-50 text-red-600 px-2.5 py-1.5 text-sm font-semibold shadow-sm ring-1 ring-inset ring-red-200 hover:bg-red-100 sm:block"
                >
                  Eliminar
                </button>
              </div>
            </li>
          ))}
          {libros.length === 0 && (
            <li className="py-5 px-4 text-center text-sm text-gray-500">
              No hay libros registrados.
            </li>
          )}
        </ul>
      </div>
    </div>
  );
}