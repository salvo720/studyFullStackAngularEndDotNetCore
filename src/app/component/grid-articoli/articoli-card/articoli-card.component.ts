import { Iarticoli } from './../../../model/interface/iarticoli';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-articoli-card',
  templateUrl: './articoli-card.component.html',
  styleUrls: ['./articoli-card.component.css']
})
export class ArticoliCardComponent implements OnInit {
  @Input() articolo: Iarticoli

  constructor() {
    this.articolo = {
      codart: '', 
      descrizione: '', 
      um: '', 
      pzcart: 0, 
      peso: 0, 
      prezzo: 0, 
      active: true, 
      data: new Date(), 
      imageUrl: ''
    }
  }

  ngOnInit(): void {
  }

}
