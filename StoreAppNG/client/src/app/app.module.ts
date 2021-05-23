import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http'


import { AppComponent } from './app.component';
import { Store } from './services/store.service';
import ProductListView from './views/productListView.component';
import router from './router';
import { ProductPage } from './pages/productsPage.component';
import { CreateProduct } from './pages/create.component';
import CreateView from './views/createView.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
        AppComponent,
        ProductListView,
        ProductPage,
        CreateProduct,
        CreateView
  ],
  imports: [
      BrowserModule,
      HttpClientModule,
      router,
      FormsModule,
      ReactiveFormsModule
  ],
    providers: [
        Store
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }
