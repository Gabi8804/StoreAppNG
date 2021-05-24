export class Product {
    productId: number;
    name: string;
    description: string;
    price: number;
    brandCategoryId: number;
    quantity: number;
    category: Category = new Category();
    brand: Brand = new Brand();
}

export class Category{
    categoryId: number;
    name: string;
}
export class Brand {
    brandId: number;
    name: string;
}

