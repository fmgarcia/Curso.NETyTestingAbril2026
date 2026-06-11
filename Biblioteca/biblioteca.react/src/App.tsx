import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Layout from './components/Layout';
import Home from './pages/Home';
import AutoresList from './pages/AutoresList';
import LibrosList from './pages/LibrosList';

function App() {
    return (
        <Router>
            <Layout>
                <Routes>
                    <Route path="/" element={<Home />} />
                    <Route path="/autores" element={<AutoresList />} />
                    <Route path="/libros" element={<LibrosList />} />
                </Routes>
            </Layout>
        </Router>
    );
}

export default App;
