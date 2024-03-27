import { Component, OnDestroy, OnInit } from '@angular/core';
import { Game } from './gameLogic/game';
import { Score } from '../models/score';
import { FlappyService } from '../services/flappy.service';

@Component({
  selector: 'app-play',
  templateUrl: './play.component.html',
  styleUrls: ['./play.component.css']
})
export class PlayComponent implements OnInit, OnDestroy{

  game : Game | null = null;
  scoreSent : boolean = false;

  constructor(public service: FlappyService){}

  ngOnDestroy(): void {
    // Ceci est crotté mais ne le retirez pas sinon le jeu bug.
    location.reload();
  }

  ngOnInit() {
    this.game = new Game();
  }

  replay(){
    if(this.game == null) return;
    this.game.prepareGame();
    this.scoreSent = false;
  }

  async sendScore(){
    if(this.scoreSent) return;

    
    // ██ Appeler une requête pour envoyer le score du joueur ██
    // Le score est dans sessionStorage.getItem("score")
    // Le temps est dans sessionStorage.getItem("time")
    // La date sera choisie par le serveur
    let score = +sessionStorage.getItem("score")!
    let time = sessionStorage.getItem("time")!
    console.log(score + " "+ time);

    let scoreInfo = new Score(0,this.service.activeUser,"",time,score,false)

     await this.service.postScore(scoreInfo)
    this.scoreSent = true;



    



  }

}
