import { Component, OnInit } from "@angular/core";
import { FormControl, NgForm } from "@angular/forms";
import { Router } from "@angular/router";
import { Store } from "../services/store.service";
import { Brand, Category, NewProduct } from "../shared/Product";

@Component({
    selector: "create-view",
    templateUrl: "createView.component.html"
})

export default class CreateView implements OnInit  {
    title = "Create Product"
    constructor(public product: Store, private router: Router) {
        
    }
    
    public newProduct: NewProduct = {
        description:"",
        price: "" as unknown as number,
        name: "",
        brandId: "" ,
        categoryId: ""
    }


    ngOnInit(): void {
        console.log("debugging");
        this.product
            .getCategories()
            .subscribe(
                data => {
                    for (let c of this.product.categories) {
                        console.log(c.categoryId)
                    }
                }
            );
        
        
    }

    onChangeCategory($event: any, categoryId: string) {
        var catId = Number(categoryId);
        this.product
            .getBrands(catId)
            .subscribe();
    }

    onCreate(myForm: NgForm) {
        if (myForm.valid) {
        this.product
            .Create(this.newProduct)
            .subscribe(() => {
                //this.router.navigate([""]);
                myForm.reset();
            });
        }
    }


}

