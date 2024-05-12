import { Routes } from '@angular/router';
import { ListadoProductoComponent } from './components/producto/listado-producto/listado-producto.component';

export const routes: Routes = [
    {
        path: '',
        component: ListadoProductoComponent
    },
    {
        path: 'producto-listado',
        component: ListadoProductoComponent
    }
];
