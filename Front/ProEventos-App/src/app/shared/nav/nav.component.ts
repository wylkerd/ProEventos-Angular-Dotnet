import { Component, OnInit } from '@angular/core';
import { RouterLink } from "@angular/router";

import { CollapseModule } from 'ngx-bootstrap/collapse';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';

@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [
    CollapseModule,
    BsDropdownModule,
    RouterLink
  ],
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.scss'
})
export class NavComponent implements OnInit {
  isCollapsed = true;
  constructor() {}

  ngOnInit() {

  }
}
