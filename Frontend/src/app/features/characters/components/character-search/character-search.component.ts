import { Component, EventEmitter, Output } from '@angular/core';
import { Character } from '../../models/character.model';
import { Observable } from 'rxjs';
import { CharacterService } from '../../services/character.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-character-search',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './character-search.component.html',
  styleUrl: './character-search.component.css'
})
export class CharacterSearchComponent {
  character$!: Observable<Character[]>;
  @Output() resultados = new EventEmitter<Character[]>();
  nombre: string = '';

  constructor(
    private characterService: CharacterService,
  ) { }

  searchCharacters(): void {
    console.log('Buscando personajes con el nombre:', this.nombre);
    this.characterService.getCharacterByName(this.nombre)
      .subscribe({
      next: (data) => {
        this.resultados.emit(data);
      },
      error: (error) => {
        console.error('Error al buscar personajes:', error);
      }
    });
  }

  clearSearch(): void {
    this.nombre = '';
    this.resultados.emit([]);
  }

}
