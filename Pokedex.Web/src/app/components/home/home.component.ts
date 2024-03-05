import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { PokemonService } from '../../services/pokemonService/pokemon.service';
import { formatarData } from '../shared/helpers/utils'
import { FormsModule } from '@angular/forms';

@Component({
    selector: 'app-home',
    standalone: true,
    imports: [CommonModule, FormsModule],
    templateUrl: './home.component.html',
    styleUrl: './home.component.css'
})
export class HomeComponent {

    public pokemonSearch!: string;
    public pokemons: any;
    public currentPage: number = 1;
    public totalPages!: number;
    public pageSize: number = 9;

    constructor(private pokemonService: PokemonService)
    {
        this.onGetPokemons();
    }

    onGetPokemons()
    {
        this.pokemonService.getPokemons(this.currentPage, this.pageSize).subscribe((response) => {
            this.pokemons = response.data;
            this.totalPages = response.totalPages;
        });
    }

    onPokemonSearch()
    {
        if (!!this.pokemonSearch) {
            this.pokemonService.getPokemonSearch(this.currentPage, this.pageSize, this.pokemonSearch).subscribe((response) => {
                this.pokemons = response.data
                this.totalPages = response.totalPages;
            });
        }
        else {
            console.log('inserir dados de busca')
        }
    }

    getRange(total: number): number[] {
        return Array.from({ length: total }, (_, index) => index + 1);
    }

    get visiblePages(): number[] {
        const inicio = Math.max(1, this.currentPage - 2);
        const fim = Math.min(this.totalPages, inicio + 4);
        return Array.from({ length: fim - inicio + 1 }, (_, index) => inicio + index);
    }

    goToPage(pagina: number): void {
        if (pagina >= 1 && pagina <= this.totalPages) {
            this.currentPage = pagina;
            if (!!this.pokemonSearch) {
                this.onPokemonSearch();
            }
            else {
                this.onGetPokemons();
            }
        }
    }

}
