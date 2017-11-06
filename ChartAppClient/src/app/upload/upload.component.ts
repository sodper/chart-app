import { Component, OnInit, ViewChild } from '@angular/core';
import { Http, RequestOptions, Headers, Response } from '@angular/http';
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
  uploadInput: any;

  constructor(private http: Http, private chartApiAService: ChartApiService) { }

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
          data => console.log(data),
          error => console.log(error),
          () => this.uploadInput.nativeElement.value = ''
        )
    }
  }
}