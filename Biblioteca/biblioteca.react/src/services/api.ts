import axios from 'axios';
import type { Autor, Libro } from '../types';

// API base URL configurada al puerto por defecto que levanta .NET para webapi
const API_URL = 'https://localhost:7041/api';

const api = axios.create({
  baseURL: API_URL,
  headers: {
    'Content-Type': 'application/json',
  },
});

export const AutoresService = {
  getAll: async () => {
    const response = await api.get<Autor[]>('/autores');
    return response.data;
  },
  getById: async (id: number) => {
    const response = await api.get<Autor>(`/autores/${id}`);
    return response.data;
  },
  create: async (autor: Omit<Autor, 'id' | 'libros'>) => {
    const response = await api.post<Autor>('/autores', autor);
    return response.data;
  },
  update: async (id: number, autor: Omit<Autor, 'id' | 'libros'>) => {
    await api.put(`/autores/${id}`, autor);
  },
  delete: async (id: number) => {
    await api.delete(`/autores/${id}`);
  },
};

export const LibrosService = {
  getAll: async () => {
    const response = await api.get<Libro[]>('/libros');
    return response.data;
  },
  getById: async (id: number) => {
    const response = await api.get<Libro>(`/libros/${id}`);
    return response.data;
  },
  create: async (libro: { titulo: string; isbn: string; anio: number; autorIds: number[] }) => {
    const response = await api.post<Libro>('/libros', libro);
    return response.data;
  },
  update: async (id: number, libro: { titulo: string; isbn: string; anio: number; autorIds: number[] }) => {
    await api.put(`/libros/${id}`, libro);
  },
  delete: async (id: number) => {
    await api.delete(`/libros/${id}`);
  },
};
