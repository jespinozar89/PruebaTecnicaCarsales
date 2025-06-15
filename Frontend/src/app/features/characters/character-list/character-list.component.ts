import { Component, OnInit } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Character } from '../models/character.model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-character-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './character-list.component.html',
  styleUrl: './character-list.component.css'
})
export class CharacterListComponent implements OnInit {
  // Usamos un observable para aprovechar el async pipe en la plantilla
  characters$!: Observable<Character[]>;

  constructor() {}

  ngOnInit(): void {
    // Creamos datos falsos de acuerdo al modelo Character
    const fakeCharacters: Character[] = [
      {
        id: 1,
        name: 'Rick Sanchez',
        status: 'Alive',
        species: 'Human',
        type: '',
        gender: 'Male',
        originName: 'Earth (C-137)',
        locationName: 'Earth (Replacement Dimension)',
        image: 'https://rickandmortyapi.com/api/character/avatar/1.jpeg',
        episode: ['https://rickandmortyapi.com/api/episode/1', 'https://rickandmortyapi.com/api/episode/2'],
        url: 'https://rickandmortyapi.com/api/character/1',
        created: '2017-11-04T18:48:46.250Z'
      },
      {
        id: 2,
        name: 'Morty Smith',
        status: 'Alive',
        species: 'Human',
        type: '',
        gender: 'Male',
        originName: 'Earth (C-137)',
        locationName: 'Earth (Replacement Dimension)',
        image: 'https://rickandmortyapi.com/api/character/avatar/2.jpeg',
        episode: ['https://rickandmortyapi.com/api/episode/1', 'https://rickandmortyapi.com/api/episode/2'],
        url: 'https://rickandmortyapi.com/api/character/2',
        created: '2017-11-04T18:50:21.651Z'
      },
      {
        id: 3,
        name: 'Summer Smith',
        status: 'Alive',
        species: 'Human',
        type: '',
        gender: 'Female',
        originName: 'Earth (Replacement Dimension)',
        locationName: 'Earth (Replacement Dimension)',
        image: 'https://rickandmortyapi.com/api/character/avatar/3.jpeg',
        episode: ['https://rickandmortyapi.com/api/episode/6', 'https://rickandmortyapi.com/api/episode/7'],
        url: 'https://rickandmortyapi.com/api/character/3',
        created: '2017-11-04T19:09:56.428Z'
      }
    ];

    // Asignamos el observable con los datos falsos usando of()
    this.characters$ = of(fakeCharacters);
  }

}
