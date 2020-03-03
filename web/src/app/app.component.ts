import { Component } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { NzI18nService, en_US, zh_CN } from 'ng-zorro-antd';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  isCollapsed = false;
  switchValue = true;

  constructor(private translateService: TranslateService, private i18n: NzI18nService) { }

  ngOnInit() {
    // --- set i18n begin ---
    this.translateService.addLangs(["zh", "en"]);
    this.translateService.setDefaultLang("en");
    const browserLang = this.translateService.getBrowserLang();
    //this.translateService.use(browserLang.match(/zh|en/) ? browserLang : 'en');
    this.translateService.use('zh');
    // --- set i18n end ---
  }

  switchLanguage() {
    //console.log(this.switchValue);
    
    if (this.switchValue) {
      this.translateService.use('zh');
      this.i18n.setLocale(zh_CN);
    }
    else {
      this.translateService.use('en');
      this.i18n.setLocale(en_US);
    }
  }
}
