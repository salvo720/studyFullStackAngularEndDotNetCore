import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup , Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginform:FormGroup
  constructor(private fb:FormBuilder) {
    this.loginform = this.fb.group({
      email : ['', [ Validators.maxLength(255), Validators.minLength(6), Validators.required]],
      password : ['', [ Validators.maxLength(255), Validators.minLength(6), Validators.required]],
      remberMe : ['', Validators.requiredTrue]
    });
  }

  ngOnInit(): void {
  }

  invioLogin(){
  }


}
