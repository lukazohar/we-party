import { Component, OnInit } from '@angular/core';
import { from, Observable } from 'rxjs';
import { AuthService } from 'src/app/auth/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss'],
})
export class NavbarComponent implements OnInit {
  constructor(private authService: AuthService) {}

  ngOnInit() {}

  isLoggedIn(): Observable<boolean> {
    return from(this.authService.isLoggedIn());
  }

  logout() {
    this.authService.logout();
  }
}
