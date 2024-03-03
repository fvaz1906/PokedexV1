import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { LayoutComponent } from './/components/shared/layout/layout.component';

export const routes: Routes = [
    {
        path: '', title: 'Layout', component: LayoutComponent,
        children: [
            { path: '', title: 'Home', component: HomeComponent },
        ]
    }
    //{ path: '', redirectTo: '/home', pathMatch: 'full' },
];
