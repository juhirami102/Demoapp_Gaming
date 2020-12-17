import { UiDataTableConfig } from 'projects/clique-hrui/src/lib/ui-models';

export const CourceTypeDTConfig: UiDataTableConfig = {
    Columns: [
        { fieldId: 'ID', fieldName: '' },
        { fieldId: 'CourseType', fieldName: 'Course Type' }
    ],
    Pagination: true,
    PaginationPageSize: 10,
    DefaultSort: { fieldId: 'ID', direction: 'asc' },
    UniqueRowCol: 'ID',
    isEditable: true,
    ColumnClass: 'text-nowrap'
};
export const CourceTitleDTConfig: UiDataTableConfig = {
    Columns: [
        { fieldId: 'ID', fieldName: '' },
        { fieldId: 'CourseTitle', fieldName: 'Course Title' },
        { fieldId: 'CourseType', fieldName: 'Course Type' }
    ],
    Pagination: true,
    PaginationPageSize: 10,
    DefaultSort: { fieldId: 'ID', direction: 'asc' },
    UniqueRowCol: 'ID',
    isEditable: true,
    ColumnClass: 'text-nowrap'
};
export const MajorDTConfig: UiDataTableConfig = {
    Columns: [
        { fieldId: 'ID', fieldName: '' },
        { fieldId: 'MajorName', fieldName: 'Major Name' },
        { fieldId: 'CourseType', fieldName: 'Course Type' }
    ],
    Pagination: true,
    PaginationPageSize: 10,
    DefaultSort: { fieldId: 'ID', direction: 'asc' },
    UniqueRowCol: 'ID',
    isEditable: true,
    ColumnClass: 'text-nowrap'
};
export const UniversityDTConfig: UiDataTableConfig = {
    Columns: [
        { fieldId: 'ID', fieldName: '' },
        { fieldId: 'UniversityName', fieldName: 'University Name' },
        { fieldId: 'Country', fieldName: 'Country' },
        { fieldId: 'State', fieldName: 'State' },
        { fieldId: 'City', fieldName: 'City' },
        { fieldId: 'Blacklist', fieldName: 'Blacklist' }
    ],
    Pagination: true,
    PaginationPageSize: 10,
    DefaultSort: { fieldId: 'ID', direction: 'asc' },
    UniqueRowCol: 'ID',
    isEditable: true,
    ColumnClass: 'text-nowrap'
};
export const InstituteDTConfig: UiDataTableConfig = {
    Columns: [
        { fieldId: 'ID', fieldName: '' },
        { fieldId: 'InstituteName', fieldName: 'Institute Name' },
        { fieldId: 'UniversityName', fieldName: 'University Name' },
        { fieldId: 'Country', fieldName: 'Country' },
        { fieldId: 'State', fieldName: 'State' },
        { fieldId: 'City', fieldName: 'City' },
        { fieldId: 'Blacklist', fieldName: 'Blacklist' }
    ],
    Pagination: true,
    PaginationPageSize: 10,
    DefaultSort: { fieldId: 'ID', direction: 'asc' },
    UniqueRowCol: 'ID',
    isEditable: true,
    ColumnClass: 'text-nowrap'
};