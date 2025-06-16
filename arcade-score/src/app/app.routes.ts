// app.routes.ts
import { Routes } from '@angular/router';
import { RegisterScoreComponent } from './components/register-score/register-score.component';
import { RankingComponent } from './components/ranking/ranking.component';
import { PlayerStatsComponent } from './components/player-stats/player-stats.component';

export const routes: Routes = [
  { path: '', component: RankingComponent },
  { path: 'register', component: RegisterScoreComponent },
  { path: 'ranking', component: RankingComponent },
  { path: 'stats/:player', component: PlayerStatsComponent }
];
