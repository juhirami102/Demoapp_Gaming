import { Component, OnInit, Inject, ChangeDetectorRef, ViewChild, AfterViewInit } from '@angular/core';
import { WebComponents } from 'src/Application/Components/componenets.api';
import { WebInterface, WebTokens, MultiSelectUtil } from 'src/Application/Types/types.api';
import { Components } from 'src/Application/Types/Constants';
import { UiDataTableConfig } from 'projects/clique-hrui/src/lib/ui-models';
import { UiDataTableComponent } from 'projects/clique-hrui/src/lib/ui-data-table/ui-data-table.component';

@Component({
  selector: 'app-entity',
  templateUrl: './entity.component.html',
  styleUrls: ['./entity.component.css']
})
export class EntityComponent extends WebComponents.ApplicationComponent implements OnInit,AfterViewInit {

  @ViewChild(UiDataTableComponent,{static:true, read: UiDataTableComponent})
  private uiDataTableComponent: UiDataTableComponent;
  public restoGridConfig: UiDataTableConfig = {
    Columns: [
      { fieldId: 'Edit', fieldName: '' },
      { fieldId: 'EntityName', fieldName: 'Entity Name' },
      { fieldId: 'EntityCode', fieldName: 'Entity Code' },
      { fieldId: 'Address', fieldName: 'Address' },
      { fieldId: 'Website', fieldName: 'Website' },
      { fieldId: 'CompanyType', fieldName: 'Company Type' },
      { fieldId: 'IncorporationDate', fieldName: 'Incorporation Date' },
      { fieldId: 'PAN', fieldName: 'PAN' },
      { fieldId: 'TAN', fieldName: 'TAN' },
      { fieldId: 'GSTIN', fieldName: 'GSTIN' },
      { fieldId: 'PF', fieldName: 'PF' },
      { fieldId: 'ESIC', fieldName: 'ESIC' },
    ],
    Pagination: true,
    PaginationPageSize: 10,
    DefaultSort: { fieldId: 'EntityCode', direction: 'asc' },
    UniqueRowCol: 'EntityCode',
    isEditable: true,
    ColumnClass: 'text-nowrap'
  };

  constructor(
    @Inject(WebTokens.APPLICATION_SERVICE)
    protected applicationService: WebInterface.IApplicationService,
    protected changeDetection: ChangeDetectorRef
  ) { 
    super(Components.EntityComponent, applicationService, changeDetection);
  }

  protected TriggerCommand(request: WebInterface.CommandRequest) {
  }
  ngOnInit() {
  }
  ngAfterViewInit(): void {
    this.uiDataTableComponent.ConstructRow([1,2,3],8);
  }
}
