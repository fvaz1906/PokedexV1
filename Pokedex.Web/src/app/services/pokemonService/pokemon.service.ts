import { Injectable } from '@angular/core';

import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable, map, tap } from 'rxjs';
import { IPokemon } from '../../interfaces/IPokemon';

@Injectable({
    providedIn: 'root'
})
export class PokemonService
{

    private API_URL = environment.API_URL;

    constructor(private http: HttpClient, private router: Router) { }

    getPokemons(): Observable<IPokemon> {
        return this.http.get<IPokemon>(
            `${this.API_URL}/api/v1/pokemon/?page=1&pageSize=48`,
        ).pipe(map(response => response));
    }

    getPokemonSearch(search: string): Observable<IPokemon> {
        return this.http.get<IPokemon>(
            `${this.API_URL}/api/v1/pokemon/?page=1&pageSize=48&name=${search}`,
        ).pipe(map(response => response));
    }

}
