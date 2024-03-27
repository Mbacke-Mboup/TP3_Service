import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { Score } from '../models/score';

@Injectable({
  providedIn: 'root'
})
export class FlappyService {
domain :string = "http://localhost:7059/"
activeUser: string =""

constructor(public http:HttpClient) {
 }

async register(Username:string, Email:string,Password:string,PasswordConfirm:string) : Promise<void>{
let registerDTO = {
  username: Username,
  email:Email,
  password: Password,
  passwordConfirm: PasswordConfirm
}

let x = await lastValueFrom(this.http.post<any>(this.domain+"api/Users/Register", registerDTO))
console.log(x);

}

async login(Username:string, Password:string) : Promise<void>{
  let loginDTO = {
    username: Username,
    password: Password,
  }
  
  let x = await lastValueFrom(this.http.post<any>(this.domain+"api/Users/Login", loginDTO))
  console.log(x.token);
  sessionStorage.setItem("token", x.token)
  if(sessionStorage.getItem("token")){
    this.activeUser = Username;

  }

  
  }

  async postScore(score:Score):Promise<void>{
    let token = sessionStorage.getItem("token")
    let httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':'application/json',
        'Authorization':'Bearer '+ token
      })
    }

    let x = await lastValueFrom(this.http.post<Score>(this.domain+"api/Scores/PostScore", score, httpOptions))
    console.log(x);
    
    
    
  }

  async getMyScores():Promise<Score[]>{
    let token = sessionStorage.getItem("token")
    let httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':'application/json',
        'Authorization':'Bearer '+ token
      })
    }

    let x = await lastValueFrom(this.http.get<Score[]>(this.domain+"api/Scores/GetMyScores",  httpOptions))
    return x;
  }
}


