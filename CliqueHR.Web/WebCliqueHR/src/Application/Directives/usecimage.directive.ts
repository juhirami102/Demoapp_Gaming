import { Directive, Input } from '@angular/core';
import { HttpBackend, HttpClient } from '@angular/common/http';
import { DomSanitizer } from '@angular/platform-browser';

@Directive({
  selector: '[appUsecimage]',
  host: {
    '[src]':'src'
   }
})
export class UsecimageDirective {
  @Input() src:any;
  @Input('appUsecimage')
  set appSecureimage(value){
    this.DownloadImage(value);
  }
  @Input() default:string = '../../../assets/images/placeholder-loading.svg';
  constructor(private httpBackend: HttpBackend, private sanitizer: DomSanitizer) {
    this.src = this.default;
   }

   DownloadImage(url:string)
   {
     if(url != undefined && url != '')
      {
        this.src = this.default;
        var _me = this;
        // Add header to add access token to secure image.
        //const headers = new HttpHeaders({'Authorization': 'Bearer '+(this.tokenProvider.getUser() != null ? this.tokenProvider.getUser().AuthToken:"")});
        let http = new HttpClient(this.httpBackend);
        http.get(url, {
          responseType: 'blob',
          observe: 'response',
          //headers:headers
        }).toPromise().then(function(data){
          _me.src = _me.sanitizer.bypassSecurityTrustUrl(URL.createObjectURL(data.body));
        },
      function(error){
        _me.src = '../../../assets/images/image-not-available.jpg';
      });
      }else{
        this.src = '../../../assets/images/image-not-available.jpg';
      }
   }

}
