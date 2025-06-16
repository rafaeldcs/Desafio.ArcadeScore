import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ScoreService {
  private baseUrl = 'https://localhost:7101/api/Scores';

  constructor(private http: HttpClient) {}

  register(score: any) {
    return this.http.post(this.baseUrl, score);
  }

  getRanking() {
    return this.http.get<any[]>(`${this.baseUrl}/ranking`);
  }

  getStats(player: string) {
    return this.http.get<any>(`${this.baseUrl}/${player}`);
  }
}
