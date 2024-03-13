import { CommonModule } from '@angular/common';
import { Component, ElementRef, HostListener } from '@angular/core';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatDrawerMode, MatSidenavModule } from '@angular/material/sidenav';
import { FormControl, ReactiveFormsModule } from '@angular/forms';

import { MatSelectModule } from '@angular/material/select';
import { MatListModule } from '@angular/material/list';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { faCoffee, faBars } from '@fortawesome/free-solid-svg-icons';

@Component({
    selector: 'app-layout',
    standalone: true,
    imports: [
        CommonModule,
        RouterOutlet,
        RouterLink,
        RouterLinkActive,
        MatIconModule,
        MatGridListModule,
        MatButtonModule,
        MatToolbarModule,
        MatSidenavModule,
        ReactiveFormsModule,
        MatSelectModule,
        MatFormFieldModule,
        MatListModule,
        FontAwesomeModule
    ],
    templateUrl: './layout.component.html',
    styleUrl: './layout.component.scss'
})
export class LayoutComponent {

    isNavbarFixed: boolean = false;
    faBars = faBars;

    constructor(private el: ElementRef) { }

    //@HostListener('window:scroll', ['$event'])
    //onWindowScroll() {
    //    const navbarOffset = this.el.nativeElement.querySelector('.navbar').offsetTop;
    //    this.isNavbarFixed = window.pageYOffset > navbarOffset;
    //}
}
