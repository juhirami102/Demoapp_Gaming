import { Component, OnInit, EmbeddedViewRef, ChangeDetectorRef, TemplateRef, EventEmitter, ViewChild, Output, ViewContainerRef, ContentChild, Input } from '@angular/core';
import { isNullOrUndefined } from 'util';
import { RequestParam, UiDataTableConfig, columnType } from '../ui-models';
import { Observable } from 'rxjs';

@Component({
  selector: 'lib-ui-data-table',
  templateUrl: './ui-data-table.component.html',
  styleUrls: ['./ui-data-table.component.css']
})
export class UiDataTableComponent implements OnInit {
  public contentLoading: boolean;
  @Input('Configuration')
  public restoGridConfig: UiDataTableConfig;
  @Output('OnFetch')
  public onFetch: EventEmitter<any> = new EventEmitter();
  @ViewChild('column', { read: TemplateRef, static: true })
  public columnTemplate: TemplateRef<any>;
  @ViewChild('columncnt', { read: ViewContainerRef, static: true })
  public columnContainer: ViewContainerRef;
  @ContentChild(TemplateRef, { read: TemplateRef, static: true })
  public rowTemplate: TemplateRef<any>;
  @ViewChild('rowcnt', { read: ViewContainerRef, static: true })
  public rowContainer: ViewContainerRef;
  @Output('FetchData')
  public fetObs$ = new EventEmitter<RequestParam>();
  @ViewChild('loadingrow', { static: true })
  public loadingRow: TemplateRef<any>;

  public sortingClass: any = {};
  public totalRows: number;
  public searchText: string;
  public navPagesSets: Array<Array<any>> = [];
  public maxPages = 5;
  public activePage = 1;
  public activePageSet = 0;

  private navPageArray: number[] = new Array<number>();
  private activeSort: { fieldId: string, direction: string };
  private pageStart: number;
  private pageEnd: number;
  private loadingViewRef: EmbeddedViewRef<any>;
  private noRowsFound: boolean = false;
  private showPagination: boolean = false;

  constructor(private changeDetection: ChangeDetectorRef) {
  }

  public ngOnInit(): void {
    this.createColumn();
    this.CreateSortClass();
  }

  public get fetchObs(): Observable<RequestParam> {
    return this.fetObs$.asObservable();
  }
  public get show(): boolean {
    return true;
  }

  public get isPrivious(): boolean {
    return this.pageStart > 1;
  }
  public get isNext(): boolean {
    return (this.pageEnd + this.restoGridConfig.PaginationPageSize) <= this.totalRows || this.pageEnd < this.totalRows;
  }

  public get currestStartPage(): number {
    return this.pageStart;
  }

  public get currestEndPage(): number {
    return this.pageEnd;
  }

  public get isRestoConfig() {
    return !isNullOrUndefined(this.restoGridConfig);
  }

  public get isNoRowsFound() {
    return this.noRowsFound;
  }

  public get isPagination(): boolean {
    return isNullOrUndefined(this.showPagination) ? false : (this.showPagination == true);
  }
  public CloumnClass(col: columnType): string {
    return this.isRestoConfig ? this.restoGridConfig.ColumnClass + ' ' + col.fieldName : col.fieldName;
  }

  public GetRowData(): void {
    let data: RequestParam = {
      StartRow: this.pageStart,
      EndRow: this.pageEnd,
      Sort: this.activeSort,
      searchText: this.searchText || ''
    };
    this.resetRows();
    this.showLoading();
    this.fetObs$.emit(data);
  }

  public ConstructRow(rowData: any[], totalData: number) {
    this.resetRows();
    if (isNullOrUndefined(rowData) || rowData.length == 0) {
      this.noRowsFound = true;
      this.showPagination = false;
      this.changeDetection.detectChanges();
      return;
    }
    let i = 0;
    for (let row of rowData) {
      this.rowContainer.createEmbeddedView(this.rowTemplate, {
        $implicit: { index: i, data: row }
      });
      i++;
    }
    let paginationReconstruct = false;
    if (this.totalRows != totalData) {
      // reconstruct pagination
      this.totalRows = totalData;
      paginationReconstruct = true;
    }
    this.showPagination = this.restoGridConfig.Pagination;
    if (this.isPagination && paginationReconstruct) {
      this.pageStart = 1;
      this.pageEnd = ((this.totalRows < this.restoGridConfig.PaginationPageSize) ? this.totalRows : this.restoGridConfig.PaginationPageSize);
      this.CreateDataTableNav();
    }
    this.changeDetection.detectChanges();
  }

  public sortData(column: columnType) {
    this.activeSort = { fieldId: column.fieldId, direction: (column.sort.direction == 'desc' ? 'asc' : 'desc') };
    let i = this.restoGridConfig.Columns.findIndex(x => x.fieldId == column.fieldId);
    this.restoGridConfig.Columns[i].sort.direction = this.activeSort.direction;
    this.CreateSortClass();
    this.GetRowData();
  }

  public nextPage() {
    var pageIndexInSet = this.navPagesSets[this.activePageSet].findIndex(x => x.page == (this.activePage + 1));
    var isLastPageSet = this.activePageSet == (this.navPagesSets.length - 1);
    if (pageIndexInSet == -1 && isLastPageSet) {
      return;
    }
    else if (pageIndexInSet == -1) {
      this.activePageSet++;
      this.activePage++;
    }
    else {
      this.activePage++;
    }
    this.UpdatePageIndex();
    this.GetRowData();
  }
  public previousPage() {
    if (this.activePage == 1) {
      return;
    }
    var pageIndexInSet = this.navPagesSets[this.activePageSet].findIndex(x => x.page == (this.activePage - 1));
    if (pageIndexInSet == -1) {
      this.activePageSet--;
      this.activePage--;
    }
    else {
      this.activePage--;
    }
    this.UpdatePageIndex();
    this.GetRowData();
  }
  private UpdatePageIndex() {
    let currentPage = this.navPagesSets[this.activePageSet].find(x => x.page == this.activePage);
    this.pageStart = currentPage.pageStart;
    this.pageEnd = (currentPage.pageStart + this.restoGridConfig.PaginationPageSize) - 1;
    this.pageEnd = this.pageEnd > this.totalRows ? this.totalRows : this.pageEnd;
  }
  public OnPageSelect(selectedPage: { page: number, pageStart: number }) {
    this.activePage = selectedPage.page;
    this.UpdatePageIndex();
    this.GetRowData();
  }
  public OnSearch() {
    this.totalRows = 0;
    this.pageStart = 1;
    this.activePage = 1;
    this.activePageSet = 0;
    this.pageEnd = this.restoGridConfig.PaginationPageSize;
    this.GetRowData();
  }
  private createColumn(): void {
    this.activeSort = this.restoGridConfig.DefaultSort;
    let isUnique = false;
    if (!isNullOrUndefined(this.restoGridConfig.UniqueRowCol)) {
      isUnique = true;
    }
    for (let col of this.restoGridConfig.Columns) {
      this.columnContainer.createEmbeddedView(this.columnTemplate, { $implicit: col });
    }
    this.showLoading();
  }

  private CreateDataTableNav() {
    this.navPageArray = [];
    if (this.totalRows <= this.restoGridConfig.PaginationPageSize) {
      this.navPageArray.push(1);
    }
    else {
      let diff = this.totalRows % this.restoGridConfig.PaginationPageSize;
      let totalPage = this.totalRows / this.restoGridConfig.PaginationPageSize;
      for (let i = 0; i < totalPage; i++) {
        if (i == 0) {
          this.navPageArray.push(1);
        }
        else {
          this.navPageArray.push(this.navPageArray[i - 1] + this.restoGridConfig.PaginationPageSize);
        }
      }
    }
    this.ConstructNavPages();
  }

  private ConstructNavPages() {
    if (this.navPageArray.length > this.maxPages) {
      let j = 1;
      let k = 0;
      this.navPagesSets[k] = new Array<{ page: number, pageStart: number }>();
      for (let i = 0; i < this.navPageArray.length; i++) {
        if ((j % this.navPageArray.length) == 0) {
          k++;
          this.navPagesSets[k] = new Array<{ page: number, pageStart: number }>();
          this.navPagesSets[k].push({ page: j, pageStart: this.navPageArray[i] });
        }
        else {
          this.navPagesSets[k].push({ page: j, pageStart: this.navPageArray[i] });
        }
        j++;
      }
    }
    else {
      this.navPagesSets[0] = new Array<{ page: number, pageStart: number }>();
      let j = 1;
      for (let i = 0; i < this.navPageArray.length; i++) {
        this.navPagesSets[0].push({ page: j, pageStart: this.navPageArray[i] });
        j++;
      }
    }
  }

  public showLoading(): void {
    this.showPagination = false;
    this.loadingViewRef = this.rowContainer.createEmbeddedView(this.loadingRow);
  }
  public hideLoading(): void {
    if (!isNullOrUndefined(this.loadingViewRef)) {
      this.loadingViewRef.destroy();
      this.loadingViewRef = null;
    }
  }
  private CreateSortClass() {
    for (let col of this.restoGridConfig.Columns) {
      this.sortingClass[col.fieldId] = this.isSorting(col);
    }
  }

  private resetRows(): void {
    this.hideLoading();
    this.noRowsFound = false;
    this.showPagination = false;
    this.rowContainer.clear();
    this.changeDetection.markForCheck();
  }
  private isSorting(column: columnType) {
    if (isNullOrUndefined(column.sort)) {
      return '';
    }
    else if (!isNullOrUndefined(this.activeSort) && column.fieldId == this.activeSort.fieldId) {
      return this.activeSort.direction == 'desc' ? { 'grid-col-sort-desc': true } : { 'grid-col-sort-asc': true };
    }
    else if (column.sort.enabled) {
      return column.sort.direction == 'desc' ? { 'grid-col-sort-desc-hvr': true } : { 'grid-col-sort-asc-hvr': true };
    }
    else {
      return '';
    }
  }

}
