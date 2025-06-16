import { Injectable } from '@angular/core';
import { Character } from '../models/character.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../environments/environment';


@Injectable({
  providedIn: 'root'
})
export class CharacterService {
  private apiUrl = `${environment.apiUrl}`;

  constructor(private http: HttpClient) { }

  getAllCharacters(page: number = 1): Observable<Character[]> {
    return this.http.get<Character[]>(`${this.apiUrl}?page=${page}`);
  }

  getCharacterById(id: number): Observable<Character> {
    return this.http.get<Character>(`${this.apiUrl}/${id}`);
  }

  getCharacterByName(name: string): Observable<Character[]> {
    return this.http.get<Character[]>(`${this.apiUrl}/search?name=${name}`);
  }

}
