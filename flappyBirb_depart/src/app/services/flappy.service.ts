import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { lastValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FlappyService {
domain :string = "http://localhost:7059/"
constructor(public http:HttpClient) { }

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
  console.log(x);
  
  }
}
