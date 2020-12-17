import { ECalendarValue } from 'ng2-date-picker';

export interface UiConfig {
    isEditable: boolean;
}
export interface UiTextbox extends UiConfig {
    isNumeric?: boolean;
    isDecimal?: boolean;
    Type?: string;
    PlaceHolder?: string;
}
export interface UiTextArea extends UiConfig {
    PlaceHolder?: string;
    Rows: number;
}
export interface UiDropDown extends UiConfig {
}
export interface UiDatepicker extends UiConfig {
    max?: any;
    min?: any;
    disabled?: boolean;
    plcaeholder?: string;
    ReturnDateFormat?: DateFormat;
}
export interface UiMultiselect extends UiConfig {
    Placeholder?: string;
}
export interface UiSingleselect extends UiConfig {
    Placeholder?: string;
}
export interface UiDataTableConfig extends UiConfig {
    Pagination?: boolean;
    PaginationPageSize?: number;
    ShowSearch?: boolean;
    DefaultSort?: { fieldId: string, direction: string };
    Columns: columnType[];
    UniqueRowCol: string;
    ColumnClass?:string;
}
export interface columnType {
    fieldId: string;
    fieldName: string;
    sort?: { enabled: boolean, direction?: string };
}
export interface RequestParam {
    StartRow: number;
    EndRow: number;
    Sort: SortType;
    searchText: string;
}
export interface SortType {
    fieldId: string;
    direction: string;
}
export enum DateFormat {
    STRING = 0,
    DATE_OBJECT
}