import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { IStudent } from '../../Services/module';
import { RouterLink, ActivatedRoute } from '@angular/router';
import { ServiceDatabase } from '../../Services/service-database';

@Component({
  selector: 'app-addnewstudent',
  imports: [FormsModule, RouterLink],
  templateUrl: './addnewstudent.html',
  styleUrl: './addnewstudent.css',
})
export class clsAddnewstudent implements OnInit {
  isDisabled = false;
  private _Type: enType = enType.Add;
  constructor(private aroute: ActivatedRoute, private myservice: ServiceDatabase) {}
  formdata_student: IStudent = { id: 0, name: '', age: 0, address: '' };
  save(): void {}
  ngOnInit(): void {
    this.ifParameterExist();
  }
  ifParameterExist(): void {
    this.aroute.paramMap.subscribe((parm) => {
      let id: number = +parm.get('id')!;
      if (id) {
        this.myservice.getStudentByID(id).subscribe((data) => (this.formdata_student = data));
        this._Type = enType.Update;
      } else {
        this._Type = enType.Add;
      }
    });
  }
  Save(): void {
    this.isDisabled = true;
    if (this._Type === enType.Add) {
      this.myservice.AddNewStudent(this.formdata_student).subscribe();
    } else {
      this.myservice.UpdateStudent(this.formdata_student.id, this.formdata_student).subscribe();
    }
  }
}

enum enType {
  Add,
  Update,
}
