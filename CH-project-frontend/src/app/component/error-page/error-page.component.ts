import { Component, OnInit } from '@angular/core';

import { AppComponent } from 'src/app/app.component';

@Component({
  selector: 'app-error-page',
  templateUrl: './error-page.component.html',
  styleUrls: ['./error-page.component.scss'],
})
export class ErrorPageComponent extends AppComponent {
  title = 'Coffee break';

  ngOnInit(): void {}
}
