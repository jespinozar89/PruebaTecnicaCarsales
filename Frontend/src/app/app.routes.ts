import { Routes } from '@angular/router';
import { HomeComponent } from './features/home/home.component';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full'
  },
  {
    path: 'home',
    component: HomeComponent
  },
  {
    path: 'characters',
    children: [
      {
        path: '',
        loadComponent: () =>
          import('./features/characters/character-list/character-list.component').then(
            m => m.CharacterListComponent
          )
      },
      {
        path: ':id',
        loadComponent: () =>
          import('./features/characters/detail-character/detail-character.component').then(
            m => m.DetailCharacterComponent
          )
      }
    ]
  },
  {
    path: 'episodes',
    children: [
      {
        path: '',
        loadComponent: () =>
          import('./features/episodes/episode-list/episode-list.component').then(
            m => m.EpisodeListComponent
          )
      },
      {
        path: 'detail',
        loadComponent: () =>
          import('./features/episodes/characters-by-episode-list/characters-by-episode-list.component').then(
            m => m.CharactersByEpisodeListComponent
          )
      }
    ]
  },
  {
    path: '**',
    redirectTo: 'home'
  }
];
