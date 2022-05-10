import { Component, OnInit } from '@angular/core';

import {ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-recipes-detail',
  templateUrl: './recipes-detail.component.html',
  styleUrls: ['./recipes-detail.component.scss']
})
export class RecipesDetailComponent implements OnInit {
  title = 'Recipes';
  Id = this.route.snapshot.paramMap.get("Id");
  constructor(
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(){
    
  }

}
