import { CommonModule } from "@angular/common";
import { Component, OnInit } from '@angular/core';
import { Router, RouterLink } from "@angular/router";

import { CollapseModule } from 'ngx-bootstrap/collapse';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { AccountService } from "../../services/account.service";
import { FontAwesomeModule } from "@fortawesome/angular-fontawesome";
import { faUsers } from "@fortawesome/free-solid-svg-icons";

@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [
    CommonModule,
    CollapseModule,
    BsDropdownModule,
    RouterLink,
    FontAwesomeModule
  ],
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.scss'
})
export class NavComponent implements OnInit {
  isCollapsed = true;
  faUsers = faUsers;

  constructor(
    public accountService: AccountService,
    private router: Router
  ) {}

  ngOnInit(): void {}

  logout(): void {
    this.accountService.logout();
    this.router.navigateByUrl('/user/login');
  }

  showMenu(): boolean {
    return this.router.url !== '/user/login';
  }
}
