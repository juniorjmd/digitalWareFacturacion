<<<<<<< HEAD
import themes from 'devextreme/ui/themes';
=======
>>>>>>> 8ed109d526751ee2a14d8ac81db21e87d531951c
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';


<<<<<<< HEAD
themes.initialized(() => {
  platformBrowserDynamic().bootstrapModule(AppModule)
    .catch(err => console.error(err));
});
=======
platformBrowserDynamic().bootstrapModule(AppModule)
  .catch(err => console.error(err));
>>>>>>> 8ed109d526751ee2a14d8ac81db21e87d531951c
