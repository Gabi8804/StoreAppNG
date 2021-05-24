import { Component, Input, OnInit } from "@angular/core";
import { FormControl, NgForm } from "@angular/forms";
import { Router } from "@angular/router";
import { Store } from "../services/store.service";

@Component({
    selector: "create-view",
    templateUrl: "createView.component.html"
})

export default class CreateView implements OnInit  {

    title = "Create Product"
    showBrandSelect = false;

    constructor(public product: Store, private router: Router) {
       
    }

    ngOnInit(): void {
        console.log("debugging");
        this.product
            .getCategories()
            .subscribe();
        if (this.product.product.brand.brandId != null && this.product.product.brand.brandId != undefined) {
            this.showBrandSelect = true;
        }else
        this.showBrandSelect = false;
    }

    onChangeCategory(categoryId: any) {
        if (categoryId != null && categoryId != undefined) {
            this.product
                .getBrands(categoryId)
                .subscribe();
            this.showBrandSelect = true;
        }
    }

    onCreate(myForm: NgForm) {
        if (myForm.valid) {
            this.product
                .Create(this.product.product)
            .subscribe(() => {
                this.router.navigate([""]);
                myForm.reset();
                this.showBrandSelect = false;
            });
        }
    }


}

