import { Component, OnInit } from '@angular/core';
import { faChartBar } from "@fortawesome/free-solid-svg-icons";
import { TituloComponent } from "../../shared/titulo/titulo.component";

@Component({
  selector: 'app-dashboard',
  standalone: true,
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
  imports: [TituloComponent]
})
export class DashboardComponent implements OnInit {
  faChartBar = faChartBar;

  constructor() { }

  ngOnInit() {
  }

}
