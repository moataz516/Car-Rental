import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthenticationService } from 'src/app/service/authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

loginForm:FormGroup;
showPassword  = false;
constructor(private fb:FormBuilder, private auth:AuthenticationService){}

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      username: ['', Validators.required],
      password:['',Validators.required]
    })
  }

  SignInUser(){
    console.log(this.loginForm)
    if(this.loginForm.valid){
      this.auth.SignInUser(this.loginForm.value);
    }
  }

  toggleShow(){
    this.showPassword = !this.showPassword 
    
  }
}
