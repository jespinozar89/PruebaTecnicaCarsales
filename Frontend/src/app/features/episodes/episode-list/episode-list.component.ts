import { Component } from '@angular/core';
import { Episode } from '../models/episode.model';
import { EpisodeService } from '../services/episode.service';
import { Observable, of } from 'rxjs';
import { CommonModule } from '@angular/common';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-episode-list',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './episode-list.component.html',
  styleUrl: './episode-list.component.css'
})
export class EpisodeListComponent {

  episodes$!: Observable<Episode[]>;
  currentPage: number = 1;

  constructor(
    private episodeService: EpisodeService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.loadEpisodes();
  }

  private loadEpisodes(): void {

    this.episodeService.getAllEpisodes(this.currentPage)
    .subscribe({
      next: (data) => {
        this.episodes$ = of(data);
      },
      error: () => {
        this.currentPage--
      }
    });
  }

  showCharacters(characterIds: number[], episodeName: string): void {
    const paramsCharacterIds = characterIds.join(',');
    const paramsEpisodeName = episodeName;
    this.router.navigate(
      ['episodes/detail'],
      {
        queryParams: {
          characterIds: paramsCharacterIds,
          episodeName: paramsEpisodeName
        }
      });
  }

  nextPage() {
    this.currentPage++;
    this.loadEpisodes();
  }

  previousPage() {
    if (this.currentPage > 1) {
      this.currentPage--;
      this.loadEpisodes();
    }
  }
}
