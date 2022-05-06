import { Component } from '@angular/core';
import { faTwitter } from '@fortawesome/free-brands-svg-icons';
import { faInstagramSquare } from '@fortawesome/free-brands-svg-icons';
import { faLinkedin } from '@fortawesome/free-brands-svg-icons';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  public Collapsed = true;
  public faTwitter = faTwitter;
  public faInstagramSquare = faInstagramSquare;
  public faLinkedin = faLinkedin;
}
