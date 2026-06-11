export default function Home() {
  return (
    <div className="bg-white rounded-lg shadow px-5 py-6 sm:px-6">
      <div className="border-4 border-dashed border-gray-200 rounded-lg p-10 flex flex-col items-center justify-center text-center">
        <h2 className="mt-2 text-2xl font-bold text-gray-900 leading-8">
          Bienvenido a la Biblioteca React
        </h2>
        <p className="mt-4 max-w-2xl text-lg text-gray-500">
          Usa el menú superior para navegar a las pantallas de gestión de Autores y Libros.
          Esta aplicación se conecta en tiempo real por Axios al backend .NET Minimal API.
        </p>
      </div>
    </div>
  );
}