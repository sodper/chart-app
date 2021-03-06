import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';  

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UploadComponent } from './upload/upload.component';
import { ChartComponent } from './chart/chart.component';
import { ChartApiService } from './chart-api.service';

@NgModule({
  declarations: [
    AppComponent,
    UploadComponent,
    ChartComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpModule
  ],
  providers: [ChartApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
