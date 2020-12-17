import { Component, OnInit, Inject, ChangeDetectorRef, AfterViewInit, ViewChild, QueryList, ViewChildren } from '@angular/core';
import { WebComponents } from 'src/Application/Components/componenets.api';
import { WebInterface, WebTokens } from 'src/Application/Types/types.api';
import { Components } from 'src/Application/Types/Constants';
import { CourceTypeDTConfig, CourceTitleDTConfig, MajorDTConfig, UniversityDTConfig, InstituteDTConfig } from './qualification-model';
import { UiDataTableComponent } from 'projects/clique-hrui/src/lib/ui-data-table/ui-data-table.component';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { isNullOrUndefined } from 'util';
import { CustomValidator } from 'src/Application/Utilitis/CustomValidator';
import { ValidationMessage } from '../../master/validation-message';
import { MasterService } from '../../master/master.service';
import { ValidationBuilder } from 'src/Application/Utilitis/ApplicationUtility';
import { SortType } from 'projects/clique-hrui/src/lib/ui-models';
import { forkJoin, Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Component({
  selector: 'app-qualification',
  templateUrl: './qualification.component.html',
  styleUrls: ['./qualification.component.css']
})
export class QualificationComponent extends WebComponents.ApplicationComponent implements OnInit, AfterViewInit {

  @ViewChildren(UiDataTableComponent, { read: UiDataTableComponent })
  private uiDataTableComponent: QueryList<UiDataTableComponent>;
  private CourseTypeList = new Array<any>();

  public validationMassages = ValidationMessage.data;
  public popupHeading: string = '';
  public courseTypeForm: FormGroup;
  public courseTitleForm: FormGroup;
  public courseMajorForm: FormGroup;
  public courseUniversityForm: FormGroup;
  public courseInstituteForm: FormGroup;
  public isAddMode: boolean = true;
  public opt = ['Mumbai', 'Pune', 'Nagpur'];

  constructor(
    @Inject(WebTokens.APPLICATION_SERVICE)
    protected applicationService: WebInterface.IApplicationService,
    protected changeDetection: ChangeDetectorRef,
    private fb: FormBuilder,
    private masterService: MasterService
  ) {
    super(Components.MasterComponent, applicationService, changeDetection);
  }

  public ngOnInit() {
    this.CreateCourseType();
    this.CreateCourseTitle();
    this.CreateMajor();
    this.CreateUniversity();
    this.CreateInstitute();
  }
  public ngAfterViewInit(): void {
    //CourceType
    this.SubjectDestroy.push(
      this.uiDataTableComponent.toArray()[0].fetchObs.subscribe(x => {
        console.log(x);
        this.GetCourseTypeList(x.StartRow, x.EndRow, x.Sort, x.searchText);
      })
    );
    //CourceTitle
    this.uiDataTableComponent.toArray()[1].ConstructRow([1, 2, 3], 12);
    //Major
    this.uiDataTableComponent.toArray()[2].ConstructRow([1, 2, 3], 12);
    //University
    this.uiDataTableComponent.toArray()[3].ConstructRow([1, 2, 3], 12);
    //Institute
    this.uiDataTableComponent.toArray()[4].ConstructRow([1, 2, 3], 12);
    forkJoin([
      this.GetCourseTypeList(1, this.CourseTypeConfig.PaginationPageSize, { fieldId: 'Id', direction: 'asc' })
    ]).subscribe(
      (data: any) => {
      },
      (error) => {
        console.log(error);
      });
  }
  private SetupPopupData(popupId: string, isAddModel: boolean, index: any) {
    this.isAddMode = isAddModel;
    switch (popupId) {
      case "#CourseTypePopup":
        // Specific Code
        this.CourseType(isAddModel, index);
        break;
      case "#CourseTitlePopup":
        // Specific Code
        this.CourseTitle(isAddModel, index);
        break;
      case "#MajorPopup":
        // Specific Code
        this.Major(isAddModel, index);
        break;
      case "#UniversityPopup":
        // Specific Code
        this.University(isAddModel, index);
        break;
      case "#InstitutePopup":
        // Specific Code
        this.Institute(isAddModel, index);
        break;
      default:
        break;
    }
  }
  private GetCourseTypeList(startRow: number, endRow: number, sort?: SortType, searchText?: string) {
    let paginationModel: WebInterface.PaginationModel = {
      StartRow: startRow,
      EndRow: endRow,
      SearchText: searchText || '',
      Sort: isNullOrUndefined(sort) ? null : { PropertyName: sort.fieldId, Direction: sort.direction }
    }
    this.masterService.GetAllCourseType(paginationModel).subscribe(
      (data:any) => {
        if (isNullOrUndefined(data)) {
          this.CourseTypeList = []; 
          this.uiDataTableComponent.toArray()[0].ConstructRow([], 0);
        }
        else {
          this.CourseTypeList = data.Data;
          this.uiDataTableComponent.toArray()[0].ConstructRow(data.Data, data.Total);
        }
      },
      (error) => {
        return catchError(x => error);
      }
      );
      return of(true);
  }
  private CourseType(isAddModel: boolean, index) {
    this.CreateCourseType();
    if (isAddModel) {
      this.courseTypeForm.reset();
      this.popupHeading = "Add Course Type";
    }
    else {
      this.popupHeading = "Edit Course Type";
      this.courseTypeForm.patchValue(this.CourseTypeList[index]);
    }
  }
  private CreateCourseType() {
    if (isNullOrUndefined(this.courseTypeForm)) {
      this.courseTypeForm = this.fb.group({
        TypeName: ['', [Validators.required]],
        DoNotUse: [false],
        Id:[]
      });
    }
  }
  private CourseTitle(isAddModel: boolean, index) {
    this.CreateCourseTitle();
    if (isAddModel) {
      this.popupHeading = "Add Course Title";
    }
    else {
      this.popupHeading = "Edit Course Title";
    }
  }
  private CreateCourseTitle() {
    if (isNullOrUndefined(this.courseTitleForm)) {
      this.courseTitleForm = this.fb.group({
        Name: ['', [Validators.required]],
        CourseType: ['', [CustomValidator.DropdownValidation]],
        DoNotUse: [false]
      });
    }
  }
  private Major(isAddModel: boolean, index) {
    this.CreateMajor();
    if (isAddModel) {
      this.popupHeading = "Add Major";
    }
    else {
      this.popupHeading = "Edit Major";
    }
  }
  private CreateMajor() {
    if (isNullOrUndefined(this.courseMajorForm)) {
      this.courseMajorForm = this.fb.group({
        Name: ['', [Validators.required]],
        CourseTitle: ['', [CustomValidator.DropdownValidation]],
        DoNotUse: [false]
      });
    }
  }
  private University(isAddModel: boolean, index) {
    this.CreateUniversity();
    if (isAddModel) {
      this.popupHeading = "Add University";
    }
    else {
      this.popupHeading = "Edit University";
    }
  }
  private CreateUniversity() {
    if (isNullOrUndefined(this.courseUniversityForm)) {
      this.courseUniversityForm = this.fb.group({
        Name: ['', [Validators.required]],
        Country: ['', [CustomValidator.DropdownValidation]],
        State: ['', [CustomValidator.DropdownValidation]],
        City: ['', [CustomValidator.DropdownValidation]],
        DoNotUse: [false]
      });
    }
  }
  private Institute(isAddModel: boolean, index) {
    this.CreateInstitute();
    if (isAddModel) {
      this.popupHeading = "Add Institute";
    }
    else {
      this.popupHeading = "Edit Institute";
    }
  }
  private CreateInstitute() {
    if (isNullOrUndefined(this.courseUniversityForm)) {
      this.courseUniversityForm = this.fb.group({
        Name: ['', [Validators.required]],
        UniversityName: ['', [Validators.required]],
        Country: ['', [CustomValidator.DropdownValidation]],
        State: ['', [CustomValidator.DropdownValidation]],
        City: ['', [CustomValidator.DropdownValidation]],
        DoNotUse: [false]
      });
    }
  }
  protected TriggerCommand(request: WebInterface.CommandRequest) {

  }
  public OnCourseTypeOp() {
    if (this.courseTypeForm.invalid) {
      this.triggerValidation(this.courseTypeForm);
      return;
    }
    let courseType:Observable<any>;
    if(this.isAddMode){
      courseType = this.masterService.AddCourseType(this.courseTypeForm.value);
    }
    else{
      courseType = this.masterService.UpdateCourseType(this.courseTypeForm.value);
    }
    courseType.subscribe(
      (data: any) => {
        this.CloseModelPopup('#CourseTypePopup');
        this.GetCourseTypeList(1, this.CourseTypeConfig.PaginationPageSize, { fieldId: 'Id', direction: 'asc' })
      },
      (error) => {
        if (ValidationBuilder.build(error) != null && ValidationBuilder.build(error).Messages.length > 0) {
          this.validationMessage = ValidationBuilder.build(error).Messages;
        }
      }
    )
  }
  public get CourseTypeConfig() {
    return CourceTypeDTConfig;
  }
  public get CourseTitleConfig() {
    return CourceTitleDTConfig;
  }
  public get MajorConfig() {
    return MajorDTConfig;
  }
  public get UniversityConfig() {
    return UniversityDTConfig;
  }
  public get InstituteConfig() {
    return InstituteDTConfig;
  }
  public OnOpenPopup(PopUpID: string, isAddModel: boolean, index: number) {
    this.SetupPopupData(PopUpID, isAddModel, index);
    this.OpenModelPopup(PopUpID);
    console.log(index);
  }
  public OnClosePopup(PopUpID: string) {
    this.CloseModelPopup(PopUpID);
  }
}
