import { Component, inject } from '@angular/core';
import { IProducto } from '../../../interfaces/IProducto';
import { ProductoService } from '../../../services/producto.service';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-listado-producto',
  standalone: true,
  imports: [MatTableModule, MatButtonModule, RouterLink],
  templateUrl: './listado-producto.component.html',
  styleUrl: './listado-producto.component.css'
})
export class ListadoProductoComponent {
  ruta = inject(Router);
  listado: IProducto[] = [];
  servicio = inject(ProductoService);
  displayedColumns: string[] = [
    'idproducto',
    'nombre',
    'descripcion',
    'cantidad',
    'precio'
  ];

  ngOnInit(){
    this.getProducto();
  }

  getProducto() {
    this.servicio.ObterTodo().subscribe((result) => {
      this.listado = result;
      console.log(this.listado);
    });
  }

}
