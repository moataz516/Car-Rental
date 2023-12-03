import { Component, ElementRef, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { User } from 'src/app/model/user.model';
import { AccountService } from 'src/app/service/account.service';
import { UpdateProfileComponent } from './update-profile/update-profile.component';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit,OnDestroy{
userId:string;
userProfile?:User;
profileImgFD:FormData;
subscription:Subscription
@ViewChild('fileInput') fileInput:ElementRef;
  constructor(private route:ActivatedRoute, private accountSer:AccountService,public dialog: MatDialog){}

  ngOnInit(): void {
    this.userId = this.route.snapshot.params['id']
    this.userProfile = this.route.snapshot.data.data;
    this.subscription = this.accountSer.UserProfile.subscribe(d=>{
      this.userProfile = d
    })
  }


  UpdateUserProfileImg(){
    this.accountSer.UpdateUserProfileImg(this.profileImgFD, this.userId)
  }
  
  openFileInput(){
    this.fileInput.nativeElement.click();
  }

  onFileSelected(event:any){
    const selectedFile = event.target.files[0];
    if(selectedFile){
      this.profileImgFD = new FormData();
      this.profileImgFD.append('fileImg',selectedFile)
      this.UpdateUserProfileImg()
    }
  }


  openUpdateDialog(){
    this.dialog.open(UpdateProfileComponent,{
      height:'800px',
      width:'600px',
      data:this.userProfile
    });
  }


  ngOnDestroy(): void {
    this.subscription.unsubscribe()
  }

}
