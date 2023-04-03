import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RickandmortyComponent } from 'src/app/components/rickandmorty/rickandmorty.component';

const routes: Routes = [
  { path: 'personajes', component: RickandmortyComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RickandMortyRoutingModule { }
