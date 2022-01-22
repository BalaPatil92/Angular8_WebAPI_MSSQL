import { Injectable } from '@angular/core';
import { Employee } from '../models/employee';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  

  constructor(private api: ApiService) { }

  getEmployeesData(){
    return this.api.get('employee');
  }

  addEmployee(employee: Employee) {
    return this.api.post(`employee`, employee);
  }

}
