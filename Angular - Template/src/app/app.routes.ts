import { Routes } from '@angular/router';
import { clsAdmin } from './Component/admin/admin';
import { clsAddnewstudent } from './Component/addnewstudent/addnewstudent';

export const routes: Routes = [
  {
    path: 'Admin/Home',
    component: clsAdmin,
  },
  {
    path: 'Admin/AddNewStudent',
    component: clsAddnewstudent,
  },
  {
    path: 'Admin/AddNewStudent/:id',
    component: clsAddnewstudent,
  },
  {
    path: '',
    redirectTo: 'Admin/Home',
    pathMatch: 'full',
  },
];
