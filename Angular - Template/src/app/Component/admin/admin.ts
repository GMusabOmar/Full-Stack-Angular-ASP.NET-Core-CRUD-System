import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ServiceDatabase } from '../../Services/service-database';
import { IStudent } from '../../Services/module';
import { Observable, of } from 'rxjs';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-admin',
  imports: [CommonModule, RouterLink],
  templateUrl: './admin.html',
  styleUrl: './admin.css',
})
export class clsAdmin implements OnInit {
  student: Observable<Array<IStudent>> = of([]);
  model: any;
  constructor(private service: ServiceDatabase) {}
  ngOnInit(): void {
    this.getAllStudents();
  }
  getAllStudents(): void {
    this.student = this.service.getAllStudents();
  }
  deleteStudent(id: number): void {
    // this.service.DeleteStudent(id).subscribe({
    //   next: () => console.log('Done Delete'),
    //   error: (err) => console.log('Error delete : ' + err),
    // });
    // OR :
    this.service.DeleteStudent(id).subscribe();
  }
}
