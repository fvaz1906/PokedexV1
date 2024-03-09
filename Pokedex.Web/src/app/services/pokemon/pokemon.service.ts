import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PokemonService {

    private API_URL = environment.apiUrl;
    constructor(private http: HttpClient, private router: Router) { }

    getPokemons(pageSize: number, name: string = ''): Observable<any> {
        return this.http.get<any>(`${this.API_URL}/api/v1/pokemon/?page=1&pageSize=${pageSize}&name=${name}`);
    }
}
