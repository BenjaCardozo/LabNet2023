import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router  } from '@angular/router';
import { catchError } from 'rxjs/operators';
import { MatSnackBar } from '@angular/material/snack-bar';

import { ShippersService } from '../../../shared/service/shippers/shippers.service';
import { ShippersModel } from '../../../shared/models/shippers/shippers.model';



@Component({
  selector: 'app-shippers-form',
  templateUrl: './shippersForm.component.html',
  styleUrls: ['./shippersForm.component.scss']
})
export class ShippersFormComponent implements OnInit {

  shippersForm: FormGroup;
  isSubmitted = false;
  shipperId?: number;
  errorMessage: string = '';

  constructor(private fb: FormBuilder,
    private route: ActivatedRoute,
    private shippersService: ShippersService,
    private router: Router,
    private snackBar: MatSnackBar)
    {
      this.shippersForm = this.fb.group({
        companyName: new FormControl(),
        phone: new FormControl()
      })
    }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.shipperId = id ? +id : 0;
    this.initForm();
    if (this.shipperId) {
      this.getShipper(this.shipperId);
    }
  }

  onSubmit(): void {
    this.isSubmitted = true;
    if (this.shippersForm.invalid) {
      return;
    }

    let phone: string | null = this.shippersForm.controls['phone'].value;
    if(phone){
      phone = this.shippersForm.controls['phone'].value;
    } else {
      phone = null;
    }

    const shipper: ShippersModel = {
      ShipperId: null,
      CompanyName: this.shippersForm.controls['companyName'].value,
      Phone: phone
    }

    if (this.shipperId) {
      shipper['ShipperId'] = this.shipperId;
      this.shippersService.updateShipper(this.shipperId, shipper)
        .pipe(
          catchError(() => {
            this.errorMessage = 'No se pudo actualizar el expedidor. Por favor, inténtalo de nuevo más tarde.';
            this.snackBar.open(this.errorMessage, undefined, {duration: 3000});
            return (this.errorMessage);
          })
        )
        .subscribe(() => {
          this.router.navigate(['/shippers']);
        });
    } else {
      this.shippersService.addShipper(shipper)
        .pipe(
          catchError(() => {
            this.errorMessage = 'No se pudo agregar el expedidor. Por favor, inténtalo de nuevo más tarde.';
            this.snackBar.open(this.errorMessage, undefined, {duration: 3000});
            return (this.errorMessage);
          })
        )
        .subscribe(() => {
          this.router.navigate(['/shippers']);
        });
    }
  }

  initForm(): void {
    this.shippersForm = this.fb.group({
      companyName:['', [Validators.required, Validators.pattern('^[a-zA-ZñÑ\\s]+$'), Validators.maxLength(40)]],
      phone: ['', [Validators.pattern(/^\(\d{3}\) \d{3}\-\d{4}$/)]]
    });
  }

  getShipper(id: number): void {
    this.shippersService.getShipperById(id).subscribe(shipper => {
      this.shippersForm.patchValue({
        companyName: shipper.CompanyName,
        phone: shipper.Phone
      });
    });
  }

}
