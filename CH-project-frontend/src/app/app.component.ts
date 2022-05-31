import { Component } from '@angular/core';
import { Router, Event, NavigationStart } from '@angular/router';
import { PlatformLocation } from '@angular/common';
import { faTwitter } from '@fortawesome/free-brands-svg-icons';
import { faInstagramSquare } from '@fortawesome/free-brands-svg-icons';
import { faLinkedin } from '@fortawesome/free-brands-svg-icons';

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
