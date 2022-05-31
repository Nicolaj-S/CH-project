import { Component } from '@angular/core';
import { Router, Event, NavigationStart } from '@angular/router';
import { PlatformLocation } from '@angular/common';
import {
  faTwitter,
  faLinkedin,
  faInstagramSquare,
} from '@fortawesome/free-brands-svg-icons';
import { faCircleXmark, faMugHot } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  public isAdmin = true;
  public Collapsed = true;
  public faTwitter = faTwitter;
  public faInstagramSquare = faInstagramSquare;
  public faLinkedin = faLinkedin;
  public faCircleXmark = faCircleXmark;
  public faMugHot = faMugHot;

  constructor(public router: Router, location: PlatformLocation) {
    this.router.events.subscribe((event: Event) => {
      if (event instanceof NavigationStart) {
        console.log(event.navigationTrigger);
        location.onPopState(() => {
          console.log(location.onPopState);
        });
      }
    });
  }
}
