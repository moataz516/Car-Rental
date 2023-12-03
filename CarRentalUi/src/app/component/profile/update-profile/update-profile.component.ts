import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AccountService } from 'src/app/service/account.service';

@Component({
  selector: 'app-update-profile',
  templateUrl: './update-profile.component.html',
  styleUrls: ['./update-profile.component.css']
})
export class UpdateProfileComponent implements OnInit {
  UpdateForm:FormGroup;
  constructor(@Inject(MAT_DIALOG_DATA) public data, private fb:FormBuilder,private account:AccountService){}
  ngOnInit(): void {
    this.initForm()
  }

  updateUserProfile(){
    this.account.UpdateUserProfile(this.UpdateForm.value)
  }
  initForm(){
    this.UpdateForm = this.fb.group({
        Id:[this.data.id],
        firstName:[this.data?.firstName || ''],
        lastName:[this.data?.lastName || ''],
        email:[this.data?.email || ''],
        username:[this.data?.username || ''],
        userDetails: this.fb.group({
          country:[this.data.userDetails?.country || ''],
          city:[this.data.userDetails?.city || ''],
          street:[this.data.userDetails?.street || ''],
          address:[this.data.userDetails?.address || ''],
          phoneNumber:[this.data.userDetails?.phoneNumber || ''],
          gender:[this.data.userDetails?.gender || ''],
          
        })

    })
  }
}
