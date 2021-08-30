import { Component, OnInit } from '@angular/core';
import {DeviceDetectorService, DeviceInfo} from 'ngx-device-detector';
import { DataService } from './data.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  constructor(private deviceDetectorService: DeviceDetectorService, private dataService: DataService){}

  deviceInfo!: DeviceInfo;
  deviceInfoHistory!: DeviceInfo[];
  displayedColumns: string[] = ['os','osVersion','device', 'deviceType', 'browser'];

  ngOnInit(): void {
    this.deviceInfo = this.deviceDetectorService.getDeviceInfo();
  }

  scanDeviceInfo(deviceInfo: DeviceInfo): void{
    this.dataService.sendPostRequest(deviceInfo).subscribe((data: any) => {
      this.deviceInfoHistory = data;
      console.log(this.deviceInfoHistory);
    }) 
  }

  title = 'device-detector';
}
