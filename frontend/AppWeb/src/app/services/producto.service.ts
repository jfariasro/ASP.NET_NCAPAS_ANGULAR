import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { IProducto } from '../interfaces/IProducto';

@Injectable({
  providedIn: 'root'
})
export class ProductoService {

  http = inject(HttpClient);

  constructor() {}

  ObterTodo(){
    return this.http.get<IProducto[]>('https://localhost:7180/api/Producto/Obtener');
  }

}
