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

    constructor(private pokemonService: PokemonService)
    {
        this.pokemonService.getPokemons().subscribe((response) => {
            this.pokemons = response.data;
        });
    }

    onPokemonSearch()
    {
        if (!!this.pokemonSearch) {
            this.pokemonService.getPokemonSearch(this.pokemonSearch).subscribe((response) => {
                this.pokemons = response.data
            });
        }
        else {
            console.log('inserir dados de busca')
        }
    }

}
