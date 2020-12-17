import { isNullOrUndefined } from 'util';

export namespace MultiSelectUtil {
    export class MultiSelectOperation{
        public static GetSelectedArray(isChecked:boolean, value:any, ExistingSelectedArray:string[]){
            if(isNullOrUndefined(ExistingSelectedArray)){
                ExistingSelectedArray = [];
            }
            let i = ExistingSelectedArray.findIndex(x => x == value);
            if(isChecked){
                if(i == -1){
                    ExistingSelectedArray.push(value);
                }
            }
            else if(i != -1){
                ExistingSelectedArray.splice(i,1);   
            }
            return JSON.parse(JSON.stringify(ExistingSelectedArray));
        }
    }
}