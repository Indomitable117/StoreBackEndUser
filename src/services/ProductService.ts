import type { Product } from "../types/responses/Product";
import { config } from "../config";

const API_URL = `${config.api.url}/api/products`;

export async function getProducts(): Promise<Product[]> {
  const response = await fetch(API_URL);

  if (!response.ok) {
    throw new Error("Error al obtener productos");
  }

  return await response.json();
}