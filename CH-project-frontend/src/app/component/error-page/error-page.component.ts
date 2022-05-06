import { Component, OnInit } from '@angular/core';
import { faMugHot } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-error-page',
  templateUrl: './error-page.component.html',
  styleUrls: ['./error-page.component.scss']
})
export class ErrorPageComponent implements OnInit {
  title = 'Coffee break';
  faMugHot = faMugHot;
  constructor() { }

  ngOnInit(): void {
  }

}
