import { Routes } from '@angular/router';
import { HomeComponent } from './features/home/home.component';

export const routes: Routes = [
   {
    path: 'home',
    component: HomeComponent
  },
  {
    path: 'characters',
    loadComponent: () =>
      import('./features/characters/character-list/character-list.component').then(
        m => m.CharacterListComponent
      )
  },
  {
    path: 'characters/:id',
    loadComponent: () =>
      import('./features/characters/detail-character/detail-character.component').then(
        m => m.DetailCharacterComponent
      )
  }
];
