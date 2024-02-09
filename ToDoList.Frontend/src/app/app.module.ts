import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TaskListComponent } from './components/task-list/task-list.component';
import { HttpClientModule, provideHttpClient, withFetch } from '@angular/common/http';
import { AllTasksComponent } from './components/all-tasks/all-tasks.component';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { NewtaskComponent } from './components/newtask/newtask.component';
import { UpdatetaskComponent } from './components/updatetask/updatetask.component';
import { LoginComponent } from './components/login/login.component';
import { TaskgroupsComponent } from './components/taskgroups/taskgroups.component';
import { TaskgroupListComponent } from './components/taskgroup-list/taskgroup-list.component';
import { TaskgroupElementsComponent } from './components/taskgroup-elements/taskgroup-elements.component';
import { TaskgroupTaskListComponent } from './components/taskgroup-task-list/taskgroup-task-list.component';
import { RegisterComponent } from './components/register/register.component';
import { AccessibleTasksComponent } from './components/accessible-tasks/accessible-tasks.component';
import { NewTaskgroupComponent } from './components/new-taskgroup/new-taskgroup.component';
import { TaskstateValidatorDirective } from './validators/taskstate-validator.directive';
import { AspPasswordValidatorDirective } from './validators/asp-password-validator.directive';

@NgModule({
  declarations: [
    AppComponent,
    TaskListComponent,
    AllTasksComponent,
    NavBarComponent,
    NewtaskComponent,
    UpdatetaskComponent,
    LoginComponent,
    TaskgroupsComponent,
    TaskgroupListComponent,
    TaskgroupElementsComponent,
    TaskgroupTaskListComponent,
    RegisterComponent,
    AccessibleTasksComponent,
    NewTaskgroupComponent,
    TaskstateValidatorDirective,
    AspPasswordValidatorDirective,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    RouterModule
  ],
  providers: [
    provideClientHydration(), provideHttpClient(withFetch())
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
