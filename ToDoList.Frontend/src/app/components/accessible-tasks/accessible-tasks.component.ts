import { Component, OnInit } from '@angular/core';
import { Taskgroupmodel } from '../../models/taskgroupmodel/taskgroupmodel.model';
import { UserService } from '../../services/user/user.service';
import { UserdataService } from '../../services/userdata/userdata.service';

@Component({
  selector: 'app-accessible-tasks',
  templateUrl: './accessible-tasks.component.html',
  styleUrl: './accessible-tasks.component.css'
})
export class AccessibleTasksComponent implements OnInit {

  constructor(private userService: UserService, private userdataService: UserdataService) {}
  
  taskgroups : Taskgroupmodel[] = []

  isLogged() : boolean {
    return this.userdataService.isLogged();
  }

  ngOnInit(): void {
    if(this.userdataService.isLogged()) {
      this.userService.getAccessibleGroups().subscribe(
        response => 
        {
         if(response.isSuccess) {
          this.taskgroups = response.result;
         }
        }
      );
    }
  }
}
