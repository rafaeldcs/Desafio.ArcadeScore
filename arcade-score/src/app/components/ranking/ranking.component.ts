import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterModule } from '@angular/router';
import { ScoreService } from '../../services/score.service';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-ranking',
  standalone: true,
  templateUrl: './ranking.component.html',
  styleUrls: ['./ranking.component.scss'],
  imports: [CommonModule, RouterModule, HttpClientModule],
})
export class RankingComponent implements OnInit {
  scores: any[] = [];

  constructor(private scoreService: ScoreService, private router: Router) {}

  ngOnInit(): void {
    this.scoreService.getRanking().subscribe(data => {
      this.scores = data;
    });
  }

  goToStats(player: string) {
    this.router.navigate(['/stats', player]);
  }
}