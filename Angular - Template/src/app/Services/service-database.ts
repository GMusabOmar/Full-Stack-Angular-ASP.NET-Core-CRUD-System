import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IStudent } from './module';

@Injectable({
  providedIn: 'root',
})
export class ServiceDatabase {
  constructor(private http: HttpClient) {}
  getAllStudents(): Observable<Array<IStudent>> {
    let URLAPI = 'http://localhost:5117/api/Students/GetAllStudents';
    return this.http.get<Array<IStudent>>(URLAPI);
  }
  getStudentByID(id: number): Observable<IStudent> {
    let URLAPI = 'http://localhost:5117/api/Students/GetStudentByID/' + id;
    return this.http.get<IStudent>(URLAPI);
  }
  AddNewStudent(stDOT: IStudent): Observable<IStudent> {
    let URLAPI = 'http://localhost:5117/api/Students/AddNewStudent';
    return this.http.post<IStudent>(URLAPI, stDOT);
  }
  UpdateStudent(id: number, stDOT: IStudent): Observable<IStudent> {
    let URLAPI = 'http://localhost:5117/api/Students/UpdateStudent/' + id;
    return this.http.put<IStudent>(URLAPI, stDOT);
  }
  DeleteStudent(id: number): Observable<void> {
    let URLAPI = 'http://localhost:5117/api/Students/DeleteStudent/' + id;
    return this.http.delete<void>(URLAPI);
  }
}
