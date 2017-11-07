import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/Rx';
import { environment } from "../../environments/environment";
import { ChartApiService } from '../chart-api.service';

@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.css']
})
export class UploadComponent implements OnInit {

  @ViewChild('uploadInput')
  public uploadInput: ElementRef;

  public errorMessage: string;

  constructor(private chartApiAService: ChartApiService, private router: Router) { }

  ngOnInit() {
  }

  fileChange(event) {
    let fileList: FileList = event.target.files;

    if (fileList.length > 0) {
      let file: File = fileList[0];
      let formData: FormData = new FormData();
      formData.append('uploadFile', file, file.name);

      this.chartApiAService.uploadDataFile(formData)
        .subscribe(
        data => {
          console.log(data);
          this.router.navigateByUrl('chart')
        },
        error => {
          error = error.json();
          console.log(error);
          this.errorMessage = error.exceptionMessage  ;
        },
        () => this.uploadInput.nativeElement.value = ''
        )
    }
  }
}