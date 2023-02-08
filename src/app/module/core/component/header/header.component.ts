import { Ilogin } from './../../../../model/interface/ilogin';
import { FormControl, FormGroup } from '@angular/forms';
import { LoginService } from './../../../../service/login/login.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  utente:Ilogin
  constructor( public login:LoginService) {
    this.utente = JSON.parse(sessionStorage.getItem('utente')!)
  }

  ngOnInit(): void {
  }



}
