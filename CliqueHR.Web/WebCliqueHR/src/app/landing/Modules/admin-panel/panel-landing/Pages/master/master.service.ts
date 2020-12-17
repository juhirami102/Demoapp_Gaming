import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CourseType } from './master-model';
import { environment } from 'src/environments/environment';
import { WebInterface } from 'src/Application/Types/types.api';

@Injectable()
export class MasterService {

  constructor(private httpClient: HttpClient) { }

  /**
   * AddCourseType
   */
  public AddCourseType(courseType: CourseType) {
    return this.httpClient.post(environment.api_baseurl + "api/Qualification/AddCourseType", courseType);
  }
  /**
   * GetAllCourseType
   */
  public GetAllCourseType(model: WebInterface.PaginationModel) {
    return this.httpClient.post(environment.api_baseurl + "api/Qualification/GetAllCourseType", model);
  }
  /**
   * UpdateCourseType
   */
  public UpdateCourseType(courseType: CourseType) {
    return this.httpClient.post(environment.api_baseurl + "api/Qualification/UpdateCourseType", courseType);
  }
}
