import { Injectable } from '@angular/core';

import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable, map, tap } from 'rxjs';
import { Pagination } from '../../interfaces/Pagination';

@Injectable({
    providedIn: 'root'
})
export class PokemonService
{

    private API_URL = environment.API_URL;

    constructor(private http: HttpClient, private router: Router) { }

    getPokemons(page: number, pageSize: number): Observable<Pagination> {
        return this.http.get<Pagination>(
            `${this.API_URL}/api/v1/pokemon/?page=${page}&pageSize=${pageSize}`,
        ).pipe(map(response => response));
    }

    getPokemonType(): Observable<Pagination> {
        return this.http.get<Pagination>(
            `${this.API_URL}/api/v1/pokemonType/?page=1&pageSize=20`,
        ).pipe(map(response => response));
    }

    getPokemonTypeSearch(type: string): Observable<Pagination> {
        return this.http.get<Pagination>(
            `${this.API_URL}/api/v1/pokemonType/?page=1&pageSize=20&type=${type}`,
        ).pipe(map(response => response));
    }

    getPokemonSearch(page: number, pageSize: number, search: string): Observable<Pagination> {
        return this.http.get<Pagination>(
            `${this.API_URL}/api/v1/pokemon/?page=${page}&pageSize=${pageSize}&name=${search}`,
        ).pipe(map(response => response));
    }

}
