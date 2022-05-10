import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-recipes',
  templateUrl: './recipes.component.html',
  styleUrls: ['./recipes.component.scss']
})
export class RecipesComponent implements OnInit {
  title = 'Recipes';
  constructor(
    private router: Router,
  ) { }

  ngOnInit(): void {
  }

  goToDetail(Id: any){
    this.router.navigate(['/Recipes/', Id])
  }

}
