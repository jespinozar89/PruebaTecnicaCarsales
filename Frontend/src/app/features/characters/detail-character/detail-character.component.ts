import { CommonModule, Location } from '@angular/common';
import { Component } from '@angular/core';
import { Character } from '../models/character.model';
import { Observable, switchMap } from 'rxjs';
import { CharacterService } from '../services/character.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-detail-character',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './detail-character.component.html',
  styleUrl: './detail-character.component.css'
})
export class DetailCharacterComponent {
  character$!: Observable<Character>;

  constructor(
    private route: ActivatedRoute,
    private characterService: CharacterService,
    private location: Location
  ) {}

  ngOnInit(): void {
    this.character$ = this.route.paramMap.pipe(
      switchMap(params => {
        const id = Number(params.get('id'));
        return this.characterService.getCharacterById(id);
      })
    );
  }

  goBack(): void {
    this.location.back();
  }
}
