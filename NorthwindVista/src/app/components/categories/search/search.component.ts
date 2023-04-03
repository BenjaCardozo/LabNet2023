import { Component, OnInit, Output, EventEmitter, ChangeDetectionStrategy } from '@angular/core';
import { FormControl } from '@angular/forms';
import { debounceTime } from 'rxjs/operators';

import { CategoriesModel } from '../../../shared/models/northwind/categories/categories.model';
import { CategoriesService } from '../../../shared/service/northwind/categories/categories.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SearchComponent implements OnInit {

  public search: FormControl;
  public category: CategoriesModel [];

  @Output('search') searchEmiiter = new EventEmitter<string>();

  constructor(private categoriesService: CategoriesService) {
    this.category = [];
    this.search = new FormControl('');
   }

  ngOnInit(): void {
    this.search.valueChanges
    .pipe(
      debounceTime(300)
    ).subscribe(value => this.searchEmiiter.emit(value))
  }

}
