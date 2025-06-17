import { Component, OnInit } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Character } from '../models/character.model';
import { CommonModule } from '@angular/common';
import { CharacterService } from '../services/character.service';
import { RouterModule } from '@angular/router';
import { CharacterSearchComponent } from "../components/character-search/character-search.component";

@Component({
  selector: 'app-character-list',
  standalone: true,
  imports: [CommonModule, RouterModule, CharacterSearchComponent],
  templateUrl: './character-list.component.html',
  styleUrl: './character-list.component.css'
})
export class CharacterListComponent implements OnInit {

  characters$!: Observable<Character[]>;
  currentPage: number = 1;

  constructor(private characterService: CharacterService) { }

  ngOnInit(): void {
    this.loadCharacters();
  }

  actualizarTabla(lista: Character[]) {
    console.log('Actualizando tabla con la lista de personajes:', lista);

    if (!lista || lista.length === 0) this.loadCharacters();
    else this.characters$ = of(lista);

  }

  private loadCharacters(): void {

    this.characterService.getAllCharacters(this.currentPage)
    .subscribe({
      next: (data) => {
        this.characters$ = of(data);
      },
      error: () => {
        this.currentPage--;
      }
    });
  }

  nextPage() {
    this.currentPage++;
    this.loadCharacters();
  }

  previousPage() {
    if (this.currentPage > 1) {
      this.currentPage--;
      this.loadCharacters();
    }
  }
}
