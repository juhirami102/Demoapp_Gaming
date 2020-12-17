export class ApplicationVeriable {
    public static AuthTokenKey: string = '';
}
export class ValidationType {
    public static required: string = "required";
    public static minlength: string = "minlength";
    public static maxlength: string = "maxlength";
    public static pattern: string = "pattern";
    public static valueMismatch: string = "valueMismatch";
    public static email: string = "email";
}
export class Components {
    public static LandingComponent = "LandingComponent";
    public static HeaderComponent = "HeaderComponent";
    public static ChangeTheamComponent = "ChangeTheamComponent";
    public static PanelLandingComponent = "PanelLandingComponent";
    public static CompanyComponent = "CompanyComponent";
    public static GroupCompanyComponent = "GroupCompanyComponent";
    public static EntityComponent = "EntityComponent";
    public static MasterComponent = "MasterComponent";
}

export class Dashboard {
    public static MyAppData = [
        {
            Name: 'Home',
            RouteLink: '',
            Code: 'home'
        },
        {
            Name: 'Admin Panel',
            RouteLink: 'admin-panel',
            Code: 'admin-panel'
        },
        {
            Name: 'Reminders',
            RouteLink: '',
            Code: 'reminders'
        },
        {
            Name: 'Approvals',
            RouteLink: '',
            Code: 'approvals'
        },
        {
            Name: 'HR Policy',
            RouteLink: '',
            Code: 'hr-policy'
        },
        {
            Name: 'Employee Directory',
            RouteLink: '',
            Code: 'employee-directory'
        },
        {
            Name: 'Attendance',
            RouteLink: '',
            Code: 'attendance'
        },
        {
            Name: 'Leave',
            RouteLink: '',
            Code: 'leave'
        }
    ]
}

export class RequestTypes {
    public static ChangeTheme: 'ChangeTheme';
}