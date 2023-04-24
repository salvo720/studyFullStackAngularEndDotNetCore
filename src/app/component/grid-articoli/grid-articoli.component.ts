import { Iarticoli } from './../../model/interface/iarticoli';
import { ArticoliService } from './../../service/articoli/articoli.service';
import { Component, OnInit, EventEmitter } from '@angular/core';


@Component({
  selector: 'app-grid-articoli',
  templateUrl: './grid-articoli.component.html',
  styleUrls: ['./grid-articoli.component.css']
})
export class GridArticoliComponent implements OnInit {
  articoli$: Iarticoli[] = []
  error : string = "";

  constructor(private articoliService: ArticoliService) {  }

   ngOnInit(): void {
    this.articoliService.getAricoliByDesc('Barilla').subscribe({
      next: (risposta: Iarticoli[]) => this.articoli$ = risposta,
      error: (error: string) => this.error = error.toString()
    })
  }

  handleEdit(data: EventData) {
      let { $event, codart } = data;
    console.log("event :", $event, "cliccato tasto modifica del codice : ", codart)
  }

  handleDelete(data: EventData) {
    console.log(data)
    const { $event, codart } = data;
    console.log("event :", $event, "cliccato tasto modifica del codice : ", codart)
    this.articoli$.splice(this.articoli$.findIndex(x => x.codArt === codart), 1)
  }
}

// custom type per edit e delete typescript
type EventData = {
  $event: Event,
  codart: string
}
