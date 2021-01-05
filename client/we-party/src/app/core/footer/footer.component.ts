import { Component, OnInit } from '@angular/core';
import { from, Observable } from 'rxjs';
import { AuthService } from 'src/app/auth/auth.service';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss'],
})
export class FooterComponent implements OnInit {
  constructor(private authService: AuthService) {}

  ngOnInit() {}

  isLoggedIn(): Observable<boolean> {
    return from(this.authService.isLoggedIn());
  }
}
