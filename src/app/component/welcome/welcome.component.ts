import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-welcome',
  templateUrl: './welcome.component.html',
  styleUrls: ['./welcome.component.css'],
})
export class WelcomeComponent implements OnInit {
  utente: string;
  titolo: string;
  sottotitolo: string;
  show: boolean;
  constructor(private route: ActivatedRoute) {
    this.utente = '';
    this.titolo = 'Benvenuti in alphashot';
    this.sottotitolo = 'Visualizza le offerte del giorno';
    this.show = false;
  }

  ngOnInit(): void {
    this.utente = this.route.snapshot.params['userId'];
  }
}
