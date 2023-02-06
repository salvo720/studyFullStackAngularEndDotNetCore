import { ArticoliComponent } from './component/articoli/articoli.component';
import { LoginComponent } from './component/login/login.component';
import { WelcomeComponent } from './component/welcome/welcome.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'welcome/:userId',
    component: WelcomeComponent,
  },
  {
    path: 'user/auth',
    component: LoginComponent,
  },
  {
    path: 'articoli',
    component: ArticoliComponent,
  },
  {
    // pagina di errore o redirect alla pagina di default , le altre rotte non hanna matchato
    path: '**',
    redirectTo: 'welcome',
    pathMatch:'full'
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {

}

// 5:00 video 15
