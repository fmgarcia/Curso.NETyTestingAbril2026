export interface Autor {
  id: number;
  nombre: string;
  pais: string;
  libros?: Libro[];
}

export interface Libro {
  id: number;
  titulo: string;
  isbn: string;
  anio: number;
  autores?: Autor[];
}