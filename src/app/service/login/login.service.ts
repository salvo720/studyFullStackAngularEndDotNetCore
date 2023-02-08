import { FormGroup, FormControl } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class LoginService {
  constructor(private http: HttpClient) {}

  login(loginForm: FormGroup) {
    console.log('loginForm :  ', loginForm);
    sessionStorage.setItem('utente', JSON.stringify(loginForm));
  }

  logout(): string | null {
    let userLogged = sessionStorage.getItem('utente') ? sessionStorage.getItem('utente'): null;
    return userLogged;
  }

  isLogged(): boolean {
    return (sessionStorage.getItem('utente')) ? true : false;
  }

  clearUtente ():void {
    sessionStorage.removeItem('utente');
  }

  clearAll = ():void => sessionStorage.clear()

}
