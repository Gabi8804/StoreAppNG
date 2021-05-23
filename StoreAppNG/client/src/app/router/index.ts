import { ProductPage } from "../pages/productsPage.component";
import { CreateProduct } from "../pages/create.component"
import { RouterModule } from "@angular/router";
import ProductListView from "../views/productListView.component";
const routes = [
    { path: "", component: ProductPage },
    {path:"create", component: CreateProduct}
]

const router = RouterModule.forRoot(routes, {
    useHash:true
});

export default router;