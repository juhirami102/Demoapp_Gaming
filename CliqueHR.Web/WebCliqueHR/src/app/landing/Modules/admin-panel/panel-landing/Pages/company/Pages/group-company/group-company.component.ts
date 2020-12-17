import { Component, OnInit, Inject, ChangeDetectorRef } from '@angular/core';
import { WebComponents } from 'src/Application/Components/componenets.api';
import { WebInterface, WebTokens, MultiSelectUtil } from 'src/Application/Types/types.api';
import { Components } from 'src/Application/Types/Constants';
import { FormControl } from '@angular/forms';
import { isNullOrUndefined } from 'util';

@Component({
  selector: 'app-group-company',
  templateUrl: './group-company.component.html',
  styleUrls: ['./group-company.component.css']
})
export class GroupCompanyComponent extends WebComponents.ApplicationComponent implements OnInit {

  public companyName = new FormControl('abc');
  public countryControl = new FormControl('IN');
  public date = new FormControl('05-08-2020');
  public SearchInput = new FormControl('');
  public Countries = [
    { Text: 'India', Value: 'IN' },
    { Text: 'Japan', Value: 'JP' },
    { Text: 'USA', Value: 'USA' },
    { Text: 'UK', Value: 'UK' },
    { Text: 'China', Value: 'CN' }
  ];
  public States = [
    { Text: 'Maharastra mumbai', Value: 'MH', Selected: false },
    { Text: 'Gujrat', Value: 'GJ', Selected: false },
    { Text: 'Rajasthan royal', Value: 'RJ', Selected: true },
    { Text: 'Madhya Pradesh MP state', Value: 'MP', Selected: false }
  ];
  public ExistingState = this.States;
  public SelectedValue:string[] = [];

  constructor(
    @Inject(WebTokens.APPLICATION_SERVICE)
    protected applicationService: WebInterface.IApplicationService,
    protected changeDetection: ChangeDetectorRef
  ) {
    super(Components.GroupCompanyComponent, applicationService, changeDetection);
    this.SearchInput.valueChanges.subscribe((x:string) => {
        if(isNullOrUndefined(x) || x.trim() == ''){
          this.States = this.ExistingState;
        }
        else{
          this.States = this.ExistingState.filter(y => y.Text == x);
        }

    });
  }

  protected TriggerCommand(request: WebInterface.CommandRequest) {
  }

  ngOnInit() {
    this.SelectedValue = this.States.filter(x => x.Selected).map(x => x.Text);
  }

  OnItemSelect(index:number, isChecked) {
    this.SelectedValue = MultiSelectUtil.MultiSelectOperation.GetSelectedArray(isChecked, this.States[index].Text, this.SelectedValue);
    if(isChecked ){
      (this.States[index] as any).Selected = true;
    }
    else {
      (this.States[index] as any).Selected = false;
    }
  }
}
