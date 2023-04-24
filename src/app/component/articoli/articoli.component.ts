import { ArticoliService } from './../../service/articoli/articoli.service';
import { Iarticoli } from './../../model/interface/iarticoli';
import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-articoli',
  templateUrl: './articoli.component.html',
  styleUrls: ['./articoli.component.css']
})
export class ArticoliComponent implements OnInit {
  articoli$:Iarticoli[] = [] ;
  error : string = "";
  constructor( private articoliService:ArticoliService) {
    /*
    this.articoli$ = [
      {codart:'codart1',descrizione:'descrizione1',um:'PZ',pzcart : 1,peso:1,prezzo:1.09,active:true,data:new Date(),imageUrl:''},
      {codart:'codart2',descrizione:'descrizione2',um:'PZ',pzcart : 2,peso:33,prezzo:123 ,active:true,data:new Date(),imageUrl:''},
      {codart:'codart3',descrizione:'descrizione3',um:'PZ',pzcart : 3,peso:234234,prezzo:234 , active:true,data:new Date(),imageUrl:''},
      {codart:'codart4',descrizione:'descrizione4',um:'PZ',pzcart : 4,peso:324234,prezzo:1.235 , active:true,data:new Date(),imageUrl:''},
      {codart:'codart5',descrizione:'descrizione5',um:'PZ',pzcart : 5,peso:345453,prezzo:253 , active:true,data:new Date(),imageUrl:''},
    ]
    */
  }

  ngOnInit(): void {
    this.articoliService.getAricoliByDesc('Barilla').subscribe({
      next : (risposta : Iarticoli[] ) => this.articoli$ = risposta ,
      error : (error : string ) => this.error = error.toString()
     });
  }

}
