import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AllTasksComponent } from './components/all-tasks/all-tasks.component';
import { UpdatetaskComponent } from './components/updatetask/updatetask.component';
import { LoginComponent } from './components/login/login.component';
import { TaskgroupsComponent } from './components/taskgroups/taskgroups.component';
import { TaskgroupElementsComponent } from './components/taskgroup-elements/taskgroup-elements.component';
import { RegisterComponent } from './components/register/register.component';
import { AccessibleTasksComponent } from './components/accessible-tasks/accessible-tasks.component';

const routes: Routes = [
  {path: 'alltasks', component: AllTasksComponent},
  {path: 'updatetask/:id', component: UpdatetaskComponent},
  {path: 'taskgroup/:id', component: TaskgroupElementsComponent},
  {path: 'taskgroups', component: TaskgroupsComponent},
  {path: 'accessiblegroups', component: AccessibleTasksComponent},
  {path: 'login', component: LoginComponent},
  {path: 'register', component: RegisterComponent},
  {path: '', redirectTo: 'alltasks', pathMatch: 'full'},
  {path: '**', component: AllTasksComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
