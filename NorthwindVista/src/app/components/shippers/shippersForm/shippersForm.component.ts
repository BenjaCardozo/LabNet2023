import { Component, OnInit, OnChanges } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router  } from '@angular/router';
import { ShippersService } from '../../../shared/service/northwind/shippers/shippers.service';
import { ShippersModel } from 'src/app/shared/models/northwind/shippers/shippersModel';


@Component({
  selector: 'app-shippers-form',
  templateUrl: './shippersForm.component.html',
  styleUrls: ['./shippersForm.component.scss']
})
export class ShippersFormComponent implements OnInit, OnChanges {

  shippersForm: FormGroup;
  isSubmitted = false;
  shipperId?: number;


  constructor(private fb: FormBuilder,
    private route: ActivatedRoute,
    private shippersService: ShippersService,
    private router: Router,
    )
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

    const shipper: ShippersModel = {
      ShipperId: null,
      CompanyName: this.shippersForm.controls['companyName'].value,
      Phone: this.shippersForm.controls['phone'].value
    }

    if (this.shipperId) {
      shipper['ShipperId'] = this.shipperId;
        this.shippersService.updateShipper(this.shipperId, shipper).subscribe(() => {
        this.router.navigate(['/shippers']);
      });
    } else {
        this.shippersService.addShipper(shipper).subscribe(() => {
        this.router.navigate(['/shippers']);
      });
    }
  }

  ngOnChanges(): void{
    console.log('aaa');
  }

  initForm(): void{
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
