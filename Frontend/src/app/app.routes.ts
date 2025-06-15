import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: 'characters',
    loadComponent: () =>
      import('./features/characters/character-list/character-list.component').then(
        m => m.CharacterListComponent
      )
  },
];
