import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ContactService } from 'src/app/service/contact.service';
import { SharedService } from 'src/app/service/shared.service';

@Component({
  selector: 'app-contact-us',
  templateUrl: './contact-us.component.html',
  styleUrls: ['./contact-us.component.css']
})
export class ContactUsComponent implements OnInit {
myForm:FormGroup
  constructor(private fb: FormBuilder, private conService:ContactService, private shared:SharedService){}
  ngOnInit(): void {
    this.initForm();
  }



  initForm(){
    this.myForm = this.fb.group({
      userId:[this.shared.getUserId()],
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      phone: [''],
      message: ['', Validators.required],
    })
  }


  SendMessage() {
    if (this.myForm.valid) {
      this.conService.SendContactUsMessage(this.myForm.value);
    }
  }





}


