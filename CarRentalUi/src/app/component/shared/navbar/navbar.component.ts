import { Component } from '@angular/core';
import { AuthenticationService } from 'src/app/service/authentication.service';
import { SharedService } from 'src/app/service/shared.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {
  isSubMenuOpen = false;

  constructor(private auth:AuthenticationService ,private shared:SharedService){}
  LogoutUser(){
    this.auth.Logout();
  }

  isAuthenticated(){
    if(this.shared.isLoggedIn())
      return true;
    return false
  }

  isAuthorized(){
    return this.shared.CheckAuth()
  }
    isOwnerAuthorized(){
      return this.shared.CheckAuth() == "Owner"
  }
  UserName(){
    return this.shared.getUserName()
  }

  getUserId(){
    return this.shared.getUserId()
  }


  toggleMenu(){
    var subMenu = document.getElementById("subMenu");
    subMenu.classList.toggle("open-menu")
  }

  toggleSubMenu() {
    this.isSubMenuOpen = !this.isSubMenuOpen;
  }
  
}
