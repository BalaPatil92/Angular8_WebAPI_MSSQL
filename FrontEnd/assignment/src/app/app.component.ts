import { Component, OnInit } from '@angular/core';
import { Employee } from './models/employee';
import { EmployeeService } from './services/employee.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  employees: any;
  employeeForm: boolean;
  isNewEmployee: boolean;
  employee: any = {};
  submitted = false;

  constructor(private employeeService: EmployeeService) { }

  ngOnInit() {
    this.employees = this.getEmployees();
  }

  getEmployees(){
    try {
      this.employeeService.getEmployeesData().subscribe((response: any)=>{
        this.employees = response.data;
      }, error=>{
        alert(error);
      })
    } catch (error) {
      alert('catech ===== ' + error);
      
    }
  }

  showEditEmployeeForm(employee: Employee) {
    debugger;
    if (!employee) {
      this.employeeForm = false;
      return;
    }
    this.employeeForm = true;
    this.employee = employee;
  }

  showAddEmployeeForm() {
    this.employee = {};
    this.employeeForm = true;
  }

  saveEmployee(employee: Employee) {
      try {
        this.employeeService.addEmployee(employee).subscribe((response: any)=>{
            alert(response.message);
            this.getEmployees();
        }, error => {
            alert(error);
        });
        
      } catch (error) {
        alert('catech ===== ' + error);
        
      }
    this.employeeForm = false;
  }

  addNewEmployee(employee: Employee){
    this.submitted = true;
    this.saveEmployee(employee);
  }

  cancelEmployee() {
    this.employee = {};
    this.employeeForm = false;
  }

}
