import { Routes } from '@angular/router';
import { HomeComponent } from './views/home/home.component';
import { LayoutComponent } from './views/shared/layout/layout.component';

export const routes: Routes = [
    {
        path: '', title: 'PokedexV1', component: LayoutComponent,
        children: [
            { path: '', title: 'PokedexV1', component: HomeComponent }
        ]
    }
];
