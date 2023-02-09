import { Iarticoli } from './../../../model/interface/iarticoli';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-articoli-card',
  templateUrl: './articoli-card.component.html',
  styleUrls: ['./articoli-card.component.css']
})
export class ArticoliCardComponent implements OnInit {
  @Input() articolo: Iarticoli

  @Output() edit: EventEmitter<any>
  @Output() delete: EventEmitter<any>

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

    this.edit = new EventEmitter();
    this.delete = new EventEmitter();
  }

  ngOnInit(): void {
  }

  articoloEdit() :void { this.edit.emit({"$event":event,"codart":this.articolo.codart}) }
  articoloDelete() :void { this.delete.emit({"$event":event,"codart":this.articolo.codart}) }

}
