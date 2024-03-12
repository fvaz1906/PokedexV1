import { Component, Input, OnInit } from '@angular/core';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { faHeart } from '@fortawesome/free-solid-svg-icons';
import { PokemonService } from '../../services/pokemon/pokemon.service';
import { CommonModule } from '@angular/common';
import { LoadingSpinnerComponent } from '../../components/loading-spinner/loading-spinner.component';
import { FormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatIconModule } from '@angular/material/icon';
import { MatDividerModule } from '@angular/material/divider';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';

@Component({
  selector: 'app-home',
  standalone: true,
    imports: [
        CommonModule,
        FontAwesomeModule,
        LoadingSpinnerComponent,
        FormsModule,
        MatCardModule,
        MatGridListModule,
        MatIconModule,
        MatDividerModule,
        MatButtonModule,
        MatInputModule,
        MatFormFieldModule
    ],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent implements OnInit {

    faHeart = faHeart
    pokemons: any[] = [];
    pageSize: number = 12;
    pageSizeMore: number = 6;
    pokemonSearch!: string;

    constructor(private pokemonService: PokemonService) { }

    ngOnInit(): void {
        this.obterDados();
    }

    obterDados(): void {
        this.pageSize = 12;
        this.pokemonService.getPokemons(this.pageSize, this.pokemonSearch).subscribe((response) => {
            this.pokemons = response.data;
        },
        (error) => {
            console.error('Erro ao obter dados:', error);
        });
    }

    mostrarMais(): void {
        this.pageSize = this.pageSize + this.pageSizeMore;
        this.pokemonService.getPokemons(this.pageSize, this.pokemonSearch).subscribe((response) => {
            this.pokemons = response.data;
        },
        (error) => {
            console.error('Erro ao obter dados:', error);
        });
    }


}
