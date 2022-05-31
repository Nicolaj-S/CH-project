import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IRecipes } from '../../backendComponents/interface/Model/IRecipes';
import { IUser } from '../../backendComponents/interface/Model/IUser';
import { AppComponent } from 'src/app/app.component';

@Component({
  selector: 'app-recipes',
  templateUrl: './recipes.component.html',
  styleUrls: ['./recipes.component.scss'],
})
export class RecipesComponent extends AppComponent {
  title = 'Recipes';
  contentLoad = false;
  cardForRecipes = [
    {
      Id: 1,
      Title: 'Recipe-title-1',
      Image: '../../../assets/Images/shopItemImage.jpg',
      Description:
        "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum",
      IUser: 1,
    },
    {
      Id: 2,
      Title: 'Recipe-title-2',
      Image: '../../../assets/Images/shopItemImage.jpg',
      Description:
        "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum",
      IUser: 1,
    },
    {
      Id: 3,
      Title: 'Recipe-title-3',
      Image: '../../../assets/Images/shopItemImage.jpg',
      Description:
        "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum",
      IUser: 2,
    },
    {
      Id: 4,
      Title: 'Recipe-title-4',
      Image: '../../../assets/Images/shopItemImage.jpg',
      Description:
        "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum",
      IUser: 1,
    },
    {
      Id: 5,
      Title: 'Recipe-title-5',
      Image: '../../../assets/Images/shopItemImage.jpg',
      Description:
        "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum",
      IUser: 2,
    },
  ];

  ngOnInit() {
    setTimeout(() => {
      this.contentLoad = true;
    }, 1000);
  }

  goToDetail(Id: any) {
    this.router.navigate(['/Recipes/', Id]);
  }
  deleteItem(Id: any) {
    this.cardForRecipes = this.cardForRecipes.filter((item) => item.Id !== Id);
    console.log('this id for recipes has been clicked ' + Id);
  }
}
