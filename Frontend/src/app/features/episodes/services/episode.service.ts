import { Injectable } from '@angular/core';
import { Episode } from '../models/episode.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EpisodeService {

   private apiUrl = `${environment.apiEpisodesUrl}`;

    constructor(private http: HttpClient) { }

    getAllEpisodes(page: number = 1): Observable<Episode[]> {
      return this.http.get<Episode[]>(`${this.apiUrl}?page=${page}`);
    }
}
