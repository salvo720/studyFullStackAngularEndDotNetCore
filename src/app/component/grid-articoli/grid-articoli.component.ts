import { Iarticoli } from './../../model/interface/iarticoli';
import { ArticoliService } from './../../service/articoli/articoli.service';
import { Component, OnInit } from '@angular/core';

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

}
