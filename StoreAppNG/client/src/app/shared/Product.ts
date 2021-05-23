export class Product {
    productId: number;
    name: string;
    description: string;
    price: number;
    brandCategoryId: number;
    quantity: number;
    category: Category;
    brand: Brand;
}

export class Category{
    categoryId: number;
    name: string;
}
export class Brand {
    brandId: number;
    name: string;
}

export class NewProduct {
    name: string;
    description: string;
    brandId: string;
    categoryId: string;
    price: number;
}

