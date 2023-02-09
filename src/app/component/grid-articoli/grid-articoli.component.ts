import { Iarticoli } from './../../model/interface/iarticoli';
import { ArticoliService } from './../../service/articoli/articoli.service';
import { Component, OnInit, EventEmitter } from '@angular/core';


@Component({
  selector: 'app-grid-articoli',
  templateUrl: './grid-articoli.component.html',
  styleUrls: ['./grid-articoli.component.css']
})
export class GridArticoliComponent implements OnInit {
  articoli$: Iarticoli[]
  constructor(private articoliService: ArticoliService) {
    this.articoli$ = [];
  }
  ngOnInit(): void {
    this.articoli$ = this.articoliService.getArticoli();
    console.log('articoli$ : ',this.articoli$)
  }

  handleEdit(data:EventData){
    let { $event , codart } =data;
    console.log("event :" , $event , "cliccato tasto modifica del codice : " , codart)
  }

  handleDelete(data:EventData){
    console.log(data)
      const { $event, codart } = data;
      console.log("event :" , $event , "cliccato tasto modifica del codice : " , codart)
      this.articoli$.splice(this.articoli$.findIndex(x=> x.codart === codart),1)
      console.log("event :" , $event , "cliccato tasto modifica del codice : " , codart)

  }
}

// custom type per edit e delete typescript
type EventData = {
  $event : Event,
  codart : string
}
