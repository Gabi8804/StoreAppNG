import { HttpClient } from "@angular/common/http";
import { error } from "@angular/compiler/src/util";
import { Injectable } from "@angular/core";
import { map } from "rxjs/operators";
import { CreateProduct } from "../pages/create.component";
import { Brand, Category, NewProduct, Product } from "../shared/Product";

@Injectable()
export class Store {
    constructor(private http: HttpClient) {

    }
    public product: Product = new Product();
    public products: Product[] = [];
    public categories: Category[] = [];
    public brands: Brand[] = [];
    
    getProducts() {
        return this.http.get<[]>("/api/Products")
            .pipe(map(data => {
                this.products = data;
                return;
            }));
    }

    getCategories() {
        return this.http.get<[]>("/api/Categories")
            .pipe(map(data => {
                this.categories = data;
                return;
            }));
    }


    getBrands(id: number) {
        return this.http.get<[]>(`/api/Categories/${id}`)
            .pipe(map(data => {
                this.brands = data;
                return;
            }));
    }

    Create(newProduct: NewProduct) {
        return this.http.post<NewProduct>("api/Products", newProduct)
            .pipe(map(data => {
            }));

    }

    
}

