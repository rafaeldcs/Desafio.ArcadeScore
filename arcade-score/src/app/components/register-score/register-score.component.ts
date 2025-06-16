import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-register-score',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, FormsModule],
  templateUrl: './register-score.component.html',
  styleUrls: ['./register-score.component.scss']
})
export class RegisterScoreComponent implements OnInit {
  form: FormGroup;
  scores: any[] = [];

  private fb = inject(FormBuilder);
  private http = inject(HttpClient);

  constructor() {
    this.form = this.fb.group({
      playerName: ['', Validators.required],
      value: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    this.loadScores();
  }

  loadScores() {
    this.http.get<any[]>('https://localhost:7101/api/scores').subscribe({
      next: data => (this.scores = data),
      error: err => console.error('Error loading scores:', err)
    });
  }

  onSubmit() {
    if (this.form.valid) {
      const scorePayload = {
        player: this.form.value.playerName,
        points: this.form.value.value,
        date: new Date(),
      };
    
      this.http.post('https://localhost:7101/api/scores', scorePayload).subscribe({
        next: () => {
          this.form.reset();
          this.loadScores();
        },
        error: err => console.error('Erro ao salvar pontuação:', err)
      });
    }
  }
}
