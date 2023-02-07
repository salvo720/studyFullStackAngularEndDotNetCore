import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './component/header/header.component';
import { FooterComponent } from './component/footer/footer.component';
import { JumbotronComponent } from './component/jumbotron/jumbotron.component';



@NgModule({
  declarations: [
    HeaderComponent,
    FooterComponent,
    JumbotronComponent
  ],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [
    HeaderComponent,
    FooterComponent,
    JumbotronComponent
  ]
})
export class CoreModule { }
