import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FlappyService } from '../services/flappy.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  hide = true;

  registerUsername : string = "";
  registerEmail : string = "";
  registerPassword : string = "";
  registerPasswordConfirm : string = "";

  loginUsername : string = "";
  loginPassword : string = "";

  constructor(public route : Router, public service: FlappyService) { }

  ngOnInit() {
  }

  login(){
    this.service.login(this.loginUsername, this.loginPassword)

    // Redirection si la connexion a réussi :
    this.route.navigate(["/play"]);
  }

  register(){
    this.service.register(this.registerUsername,this.registerEmail,this.registerPassword,this.registerPasswordConfirm)
  }

}
