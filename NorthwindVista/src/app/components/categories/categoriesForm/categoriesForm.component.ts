import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router  } from '@angular/router';
import { catchError } from 'rxjs/operators';
import { MatSnackBar } from '@angular/material/snack-bar';

import { CategoriesService } from '../../../shared/service/northwind/categories/categories.service';
import { CategoriesModel } from '../../../shared/models/northwind/categories/categories.model';

@Component({
  selector: 'app-categories-form',
  templateUrl: './categoriesForm.component.html',
  styleUrls: ['./categoriesForm.component.scss']
})
export class CategoriesFormComponent implements OnInit {

  categoriesForm: FormGroup;
  isSubmitted = false;
  categoryId?: number;
  errorMessage: string = '';

  constructor(private fb: FormBuilder,
    private route: ActivatedRoute,
    private categoriesService: CategoriesService,
    private router: Router,
    private snackBar: MatSnackBar) {
      this.categoriesForm = this.fb.group({
        categoryName: new FormControl(),
        categoryDescription: new FormControl()
      })
    }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.categoryId = id ? +id : 0;
    this.initForm();
    if (this.categoryId){
      this.getCategory(this.categoryId);
    }
  }

  onSubmit(): void {
    this.isSubmitted = true;
    if (this.categoriesForm.invalid){
      return;
    }
    let categoryDescription: string | null = this.categoriesForm.controls['categoryDescription'].value;
    if(categoryDescription){
      categoryDescription = this.categoriesForm.controls['categoryDescription'].value;
    } else {
      categoryDescription = null;
    }

    const category: CategoriesModel = {
      CategoryID: null,
      CategoryName: this.categoriesForm.controls['categoryName'].value,
      CategoryDescription: categoryDescription
    }

    if (this.categoryId) {
      category['CategoryID'] = this.categoryId;
      this.categoriesService.updateCategory(this.categoryId, category)
        .pipe(
          catchError(() => {
            this.errorMessage = 'No se pudo actualizar la categoria. Por favor, inténtalo de nuevo más tarde.';
            this.snackBar.open(this.errorMessage, undefined, {duration: 3000});
            return (this.errorMessage);
          })
        )
        .subscribe(() => {
          this.router.navigate(['/categories'])
        });
    } else {
      this.categoriesService.addCategory(category)
        .pipe(
          catchError(() => {
            this.errorMessage = 'No se pdo agregar la categoria. Por favor, inténtalo de nuevo más tarde.';
            this.snackBar.open(this.errorMessage, undefined, {duration: 3000});
            return (this.errorMessage);
          })
        )
        .subscribe(() => {
          this.router.navigate(['/categories'])
        });
    }
  }

  initForm(): void {
    this.categoriesForm = this.fb.group({
      categoryName: ['', [Validators.required, Validators.pattern('^[a-zA-ZñÑ\\s]+$'), Validators.maxLength(15)]],
      categoryDescription: ['',[Validators.pattern('^[a-zA-ZñÑ\\s]+$'), Validators.maxLength(25)]],
    });
  }

  getCategory(id: number): void {
    this.categoriesService.getCategoriesById(id).subscribe(category => {
      this.categoriesForm.patchValue({
        categoryName: category.CategoryName,
        categoryDescription: category.CategoryDescription
      });
    });
  }
}
