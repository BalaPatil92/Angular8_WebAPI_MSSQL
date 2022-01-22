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
  newEmployee: any = {};
  editEmployeeForm: boolean;
  editedEmployee: any = {};

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
    if (!employee) {
      this.employeeForm = false;
      return;
    }
    this.editEmployeeForm = true;
    this.editedEmployee = employee;
  }

  showAddEmployeeForm() {
    this.newEmployee = {};
    this.employeeForm = true;
    this.isNewEmployee = true;

  }

  saveEmployee(employee: Employee) {
    if (this.isNewEmployee) {
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
    }
    this.employeeForm = false;
  }

  updateEmployee() {
    this.saveEmployee(this.editedEmployee);
    this.editEmployeeForm = false;
    this.editedEmployee = {};
  }

  // removeEmployee(employee: Employee) {
  //   this.employeeService.deleteEmployee(employee);
  // }

  cancelEdits() {
    this.editedEmployee = {};
    this.editEmployeeForm = false;
  }

  cancelNewEmployee() {
    this.newEmployee = {};
    this.employeeForm = false;
  }

}
