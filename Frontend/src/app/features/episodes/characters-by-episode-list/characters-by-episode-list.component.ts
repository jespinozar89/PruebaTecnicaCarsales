import { CommonModule, Location } from '@angular/common';
import { Component } from '@angular/core';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { CharacterService } from '../../characters/services/character.service';
import { Observable } from 'rxjs';
import { Character } from '../../characters/models/character.model';

@Component({
  selector: 'app-characters-by-episode-list',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './characters-by-episode-list.component.html',
  styleUrl: './characters-by-episode-list.component.css'
})
export class CharactersByEpisodeListComponent {

  characterIds: number[] = [];
  episodeName: string = '';
  characters: Character[] = [];
  isReady = false;

  constructor(
    private characterService: CharacterService,
    private route: ActivatedRoute,
    private location: Location
  ) { }

  ngOnInit(): void {
    const characterIds = this.route.snapshot.queryParamMap.get('characterIds');
    const episodeName = this.route.snapshot.queryParamMap.get('episodeName');
    this.characterIds = characterIds ? characterIds.split(',').map(n => +n) : [];
    this.episodeName = episodeName ? episodeName : '';

    let loaded = 0;
    const total = this.characterIds.length;

    if (total === 0) {
      this.isReady = true;
      return;
    }

    this.characterIds.forEach(id => {
      this.getCharacterById(id).subscribe({
        next: (character) => {
          this.characters.push(character);
          loaded++;
          if (loaded === total) {
            this.isReady = true;
          }
        },
        error: (error) => {
          console.error('Error al obtener el personaje con ID:', id, error);
        }
      });
    });


  }

  getCharacterById(id: number): Observable<Character> {
    return this.characterService.getCharacterById(id);
  }

  goBack(): void {
    this.location.back();
  }
}
