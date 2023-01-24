import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { BasketService } from 'src/app/basket/basket.service';
import { IBasket } from 'src/app/shared/models/basket';
import { ToastrService } from 'ngx-toastr';
import { CdkStep, CdkStepper } from '@angular/cdk/stepper';

@Component({
  selector: 'app-checkout-review',
  templateUrl: './checkout-review.component.html',
  styleUrls: ['./checkout-review.component.scss']
})
export class CheckoutReviewComponent implements OnInit {
  @Input() appStepper: CdkStepper;
  basket$: Observable<IBasket>;
  
  constructor(private basketSerivce: BasketService, private toastr: ToastrService ) { }

  ngOnInit() {
      this.basket$ = this.basketSerivce.basket$
  }

  createPaymentIntent() {
    return this.basketSerivce.createPaymentIntent().subscribe((response: any) => {
      this.appStepper.next();
    }, error => {
      console.log(error);
    });
    }
  }
