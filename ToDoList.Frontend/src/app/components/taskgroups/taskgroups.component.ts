import { Component } from '@angular/core';
import { UserService } from '../../services/user/user.service';
import { OnInit } from '@angular/core';
import { Taskgroupmodel } from '../../models/taskgroupmodel/taskgroupmodel.model';
import { UserdataService } from '../../services/userdata/userdata.service';

@Component({
  selector: 'app-taskgroups',
  templateUrl: './taskgroups.component.html',
  styleUrl: './taskgroups.component.css'
})
export class TaskgroupsComponent implements OnInit {

  constructor(private userService: UserService, private userdataService: UserdataService) {}
  
  taskgroups : Taskgroupmodel[] = []

  isLogged() : boolean {
    return this.userdataService.isLogged();
  }

  ngOnInit(): void {
    if(this.userdataService.isLogged()) {
      this.userService.getTaskGroups().subscribe(
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
