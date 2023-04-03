import { Component, OnInit } from '@angular/core';
import { Character } from '../../shared/models/rickandmorty/character.model';
import { RickAndMortyService } from '../../shared/service/rickandmorty/rickandmorty.service';


@Component({
  selector: 'app-rickandmorty',
  templateUrl: './rickandmorty.component.html',
  styleUrls: ['./rickandmorty.component.scss']
})
export class RickandmortyComponent implements OnInit {

  personajes: Character[] = [];
  error: string = '';

  constructor(private rickAndMortyService: RickAndMortyService) { }

  ngOnInit() {
    this.getCharacters();
  }

  getCharacters(): void {
    this.rickAndMortyService.getCharacters()
      .subscribe({
        next: response => {
          this.personajes = response
        },
        error: () => {
          this.error = 'No se pudo obtener la lista de personajes.'
        }
      })
  }

}
