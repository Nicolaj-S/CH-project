import { Component, ViewChild } from '@angular/core';
import { NgbCarousel, NgbSlideEvent, NgbSlideEventSource } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  title = 'Coffee House';
  images = [1,2,3].map((n) => `../../../assets/Images/imageSlider${n}.jpg`)

  paused = false;
  pauseOnFocus = true;

  onSlide(slideEvent: NgbSlideEvent) {
    if (slideEvent.paused &&
      (slideEvent.source === NgbSlideEventSource.ARROW_LEFT || slideEvent.source === NgbSlideEventSource.ARROW_RIGHT)) {
    }
    if (!slideEvent.paused && slideEvent.source === NgbSlideEventSource.INDICATOR) {
    }
  }

}
