import { HttpClient } from '@angular/common/http';
import { Iarticoli } from './../../model/interface/iarticoli';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ArticoliService {
  articoli: Iarticoli[]
  constructor(private http:HttpClient) {
    this.articoli = [
      { codart: 'codart1', descrizione: 'penne rigate barilla 1kg', um: 'PZ', pzcart: 1, peso: 1, prezzo: 1.09, active: true, data: new Date(), imageUrl: 'assets/images/prodotti/penneRigateBarlla.jpg' },
      { codart: 'codart2', descrizione: 'descrizione2', um: 'PZ', pzcart: 2, peso: 33, prezzo: 123, active: true, data: new Date(), imageUrl: 'assets/images/prodotti/barillaSalmone.jpg' },
      { codart: 'codart3', descrizione: 'descrizione3', um: 'PZ', pzcart: 3, peso: 234234, prezzo: 234, active: true, data: new Date(), imageUrl: 'assets/images/prodotti/barillaSalsa.jpg' },
      { codart: 'codart4', descrizione: 'descrizione4', um: 'PZ', pzcart: 4, peso: 324234, prezzo: 1.235, active: true, data: new Date(), imageUrl: 'assets/images/prodotti/capitanfindus_Croccole.png' },
      { codart: 'codart5', descrizione: 'descrizione5', um: 'PZ', pzcart: 5, peso: 345453, prezzo: 253, active: true, data: new Date(), imageUrl: 'assets/images/prodotti/findusFioriDiMerluzzo.jpg' },
    ];
  }

  getArticoli(): Iarticoli[] {
    return this.articoli;
  }


  getAricoliByDesc(descrizione : string) {
    const url = `https://localhost:7285/api/articoli/cerca/descrizione/${descrizione}`;
    return this.http.get<Iarticoli[]>(url);

  }

  getArticoliByCode(codart: string): Iarticoli {
    const index = this.articoli.findIndex(articoli => articoli.codart === codart);
    return this.articoli[index];
  }
}
