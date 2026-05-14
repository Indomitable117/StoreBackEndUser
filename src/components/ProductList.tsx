import { useEffect, useState } from "react";
import type { Product } from "../types/responses/Product";
import { getProducts } from "../services/ProductService";

export function ProductList() {
  const [products, setProducts] = useState<Product[]>([]);

  useEffect(() => {
    getProducts()
      .then((data) => {
        setProducts(data);
      })
      .catch((error) => {
        console.error("Error al obtener productos:", error);
      });
  }, []);

  return (
    <div>
      <h1>Lista de productos</h1>

      {products.map((product) => (
        <div key={product.productResourceId}>
          <p>{product.name}</p>
        </div>
      ))}
    </div>
  );
}