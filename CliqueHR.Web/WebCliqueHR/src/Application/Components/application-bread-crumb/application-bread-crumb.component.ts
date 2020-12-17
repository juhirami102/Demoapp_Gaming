import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { WebAppModels } from 'src/Application/Models/models.api';

@Component({
  selector: 'app-application-bread-crumb',
  templateUrl: './application-bread-crumb.component.html',
  styleUrls: ['./application-bread-crumb.component.css']
})
export class ApplicationBreadCrumbComponent implements OnInit {

  @Input('BreadcrumData')
  data:WebAppModels.BreadCrumb;
  
  constructor() { }

  ngOnInit() {
  }

}
