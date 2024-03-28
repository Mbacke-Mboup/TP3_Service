import { Component, OnInit } from '@angular/core';
import { Score } from '../models/score';
import { FlappyService } from '../services/flappy.service';

@Component({
  selector: 'app-score',
  templateUrl: './score.component.html',
  styleUrls: ['./score.component.css']
})
export class ScoreComponent implements OnInit {

  myScores : Score[] = [];
  publicScores : Score[] = [];
  userIsConnected : boolean = false;

  constructor(public service : FlappyService) { }

  async ngOnInit() {

    this.userIsConnected = sessionStorage.getItem("token") != null;
    if(this.userIsConnected){
     this.myScores = await this.service.getMyScores()
    }

    this.publicScores = await this.service.getPublicScores()

  }

  async changeScoreVisibility(score : Score){
    score.isPublic = !score.isPublic
    await this.service.changeVisibility(score)

  }

}
