import { Component, OnInit } from '@angular/core';
import { CartelaService } from '../../services/cartela.service';
import { CartelaModel } from '../../models/cartela.model';
import { Subscription } from 'rxjs/Subscription';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-cartela',
  templateUrl: './cartela.component.html',
  styleUrls: ['./cartela.component.css']
})
export class CartelaComponent implements OnInit {

  constructor(private cartelaService: CartelaService) { }
  numeros : number[] = [null, null, null, null, null, null];
  cartelas : CartelaModel[] = [];
  refresher : Subscription;

  ngOnInit() {

    this.refresher = Observable.timer(5000).repeat().subscribe(() => {
      this.cartelaService.getCartelas().then(c => {
        this.cartelas = c;
      });
    })

    
  }

  gerarCartela(){
    console.log(this.numeros);
    this.cartelaService.gerarCartela(this.numeros).then(c => console.log(c));
  }

  gerarCartelaAutomatica(){
    this.cartelaService.gerarCartelaAutomatica().then(c => console.log(c));
  }

}
