import { LoginService } from './../../service/login/login.service';
import { LoginComponent } from './../login/login.component';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.css']
})
export class LogoutComponent implements OnInit {

  constructor( private login:LoginService) { }

  ngOnInit(): void {
    this.login.clearAll();
  }

}
