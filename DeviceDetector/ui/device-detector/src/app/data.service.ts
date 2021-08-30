import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DeviceInfo } from 'ngx-device-detector';

@Injectable({
    providedIn: 'root'
  })
  export class DataService {
  
    private REST_API_SERVER = "http://localhost:5000/deviceInfo";
  
    constructor(private httpClient: HttpClient) { }

    public sendGetRequest(){
        return this.httpClient.get(this.REST_API_SERVER);
      }
    
      public sendPostRequest(deviceInfo: DeviceInfo) {
        return this.httpClient.post(this.REST_API_SERVER, deviceInfo);
      }
  }
  