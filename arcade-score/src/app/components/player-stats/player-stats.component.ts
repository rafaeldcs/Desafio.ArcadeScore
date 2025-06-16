import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ScoreService } from '../../services/score.service';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-player-stats',
  standalone: true,
  templateUrl: './player-stats.component.html',
  styleUrls: ['./player-stats.component.scss'],
  imports: [CommonModule, HttpClientModule],
})
export class PlayerStatsComponent implements OnInit {
  stats: any;

  constructor(
    private route: ActivatedRoute,
    private scoreService: ScoreService
  ) {}

  ngOnInit(): void {
    const player = this.route.snapshot.paramMap.get('player');
    if (player) {
      this.scoreService.getStats(player).subscribe(data => {
        this.stats = data;
      });
    }
  }
}
