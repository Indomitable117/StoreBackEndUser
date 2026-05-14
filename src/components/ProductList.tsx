import { useEffect, useState } from "react";
import type { Product } from "../types/responses/Product";
import { getProducts } from "../services/ProductService";

export function ProductList() {
  const [products, setProducts] = useState<Product[]>([]);
  const [error, setError] = useState("");
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    getProducts()
      .then((data) => {
        console.log("Productos recibidos:", data);
        setProducts(data);
      })
      .catch((error) => {
        console.error("Error al obtener productos:", error);
        setError(String(error));
      })
      .finally(() => {
        setLoading(false);
      });
  }, []);

  return (
    <div>
      <h1>Lista de productos</h1>

      {loading && <p>Cargando productos...</p>}

      {error && <p style={{ color: "red" }}>Error: {error}</p>}

      {products.length === 0 && !loading && !error && (
        <p>No hay productos para mostrar.</p>
      )}

      {products.map((product) => (
        <div key={product.productResourceId}>
          <p>{product.name}</p>
        </div>
      ))}
    </div>
  );
}