import { LoginService } from './../../service/login/login.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup , Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm:FormGroup
  autenticato :boolean
  errorMsg:string
  titolo:string
  sottotitolo:string
  constructor(private fb:FormBuilder , private router:Router , private loginService:LoginService) {

    this.autenticato= true;
    this.errorMsg=''
    this.titolo='Accesso & Autenticazione'
    this.sottotitolo='Procedi ad inserire la tua email e la password'

    // inizializzazione form
    this.loginForm = this.fb.group({
      email : ['', [ Validators.maxLength(255), Validators.minLength(6), Validators.required]],
      password : ['', [ Validators.maxLength(255), Validators.minLength(6), Validators.required]],
      rememberMe : ['', Validators.requiredTrue]
    });
  }

  ngOnInit(): void {
  }

  invioLogin():void{
    console.log(this.loginForm.value)
    this.loginService.login(this.loginForm.value);
    this.router.navigate(['welcome',this.email]);
  }

  // getter del for loginForm

  get email ():FormControl{
    return this.loginForm.get('email')!.value as FormControl;
  }

  get password ():FormControl{
    return this.loginForm.get('password')!.value as FormControl;
  }

  get rememberMe ():FormControl{
    return this.loginForm.get('rememberMe')!.value as FormControl;
  }


}
