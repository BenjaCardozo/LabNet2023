import { Component, OnInit, Output, EventEmitter, ChangeDetectionStrategy } from '@angular/core';
import { FormControl } from '@angular/forms';
import { debounceTime } from 'rxjs/operators';

import { ShippersModel } from '../../../shared/models/northwind/shippers/shippers.model';
import { ShippersService } from '../../../shared/service/northwind/shippers/shippers.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SearchComponent implements OnInit {

  public search: FormControl;
  public shippers: ShippersModel [];

  @Output('search') searchEmiiter = new EventEmitter<string>();

  constructor(private shippersService: ShippersService) {
    this.shippers = [];
    this.search = new FormControl('');
   }

   ngOnInit(): void {
    this.search.valueChanges
    .pipe(
      debounceTime(300)
    ).subscribe(value => this.searchEmiiter.emit(value))
  }
}
