import { SalutiService } from './../../service/saluti/saluti.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';

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
  risposta: string
  error: string;
  constructor(private route: ActivatedRoute, private salutiService: SalutiService) {
    this.utente = '';
    this.titolo = 'Benvenuti in alphashot';
    this.sottotitolo = 'Visualizza le offerte del giorno';
    this.show = false;
    this.risposta = '';
    this.error = '';
  }

  ngOnInit(): void {
    this.utente = this.route.snapshot.params['userId'];
  }

  getSaluti(): Subscription {
    console.log("Tasto saluti premuto")
    return this.salutiService.getSalutiObservable(this.utente).subscribe(
      (risposta: string) => this.risposta = risposta ,
      (error: any) => this.error = error
    );
  }
}
