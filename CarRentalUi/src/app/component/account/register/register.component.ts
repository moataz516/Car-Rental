import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthenticationService } from 'src/app/service/authentication.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm:FormGroup
  showPassword  = false;

  constructor(private fb:FormBuilder, private auth:AuthenticationService){}

  ngOnInit(): void {
    this.registerForm =  this.fb.group({
      firstName:['',Validators.required],
      lastName:[''],
      email:['',Validators.required],
      password:['',Validators.required]
    })
  }

  RegisterUser(){
    this.auth.RegisterUser(this.registerForm.value)
  }


  toggleShow(){
    this.showPassword = !this.showPassword 

  }
}
