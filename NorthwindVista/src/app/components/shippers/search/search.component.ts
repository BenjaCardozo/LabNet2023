import { Component, OnInit, Output, EventEmitter, OnChanges, ChangeDetectionStrategy } from '@angular/core';
import { FormControl } from '@angular/forms';
import { debounceTime } from 'rxjs/operators';
import { ShippersModel } from '../../../shared/models/northwind/shippers/shippersModel';
import { ShippersService } from '../../../shared/service/northwind/shippers/shippers.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SearchComponent implements OnInit {

  public search: FormControl = new FormControl('');
  public shippers: ShippersModel [];

  @Output('search') searchEmiiter = new EventEmitter<string>();

  constructor(private shippersService: ShippersService) {
    this.shippers = [];
   }

   ngOnInit(): void {
    this.search.valueChanges
    .pipe(
      debounceTime(300)
    ).subscribe(value => this.searchEmiiter.emit(value))
  }
}
