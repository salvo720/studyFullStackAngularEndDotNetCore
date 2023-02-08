import { GridArticoliComponent } from './component/grid-articoli/grid-articoli.component';
import { RouterGuardService } from './service/routerGuard/router-guard.service';
import { ArticoliComponent } from './component/articoli/articoli.component';
import { LoginComponent } from './component/login/login.component';
import { WelcomeComponent } from './component/welcome/welcome.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LogoutComponent } from './component/logout/logout.component';

const routes: Routes = [
  {
    path: 'welcome',
    component: WelcomeComponent,
  },
  {
    path: 'welcome/:userId',
    component: WelcomeComponent,
    canActivate:[RouterGuardService]
  },

  {
    path: 'user/auth',
    component: LoginComponent,
  },
  {
    // pagina di errore o redirect alla pagina di default , le altre rotte non hanna matchato
    path: 'Login',
    redirectTo: 'user/auth',
    pathMatch:'full'
  },
  {
    path: 'logout',
    component: LogoutComponent,
  },
  {
    path: 'articoli',
    component: ArticoliComponent,
    canActivate:[RouterGuardService]
  },
  {
    path: 'articoli/grid',
    component: GridArticoliComponent,
    canActivate:[RouterGuardService]
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
