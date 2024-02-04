import { Component, OnInit } from '@angular/core';
import { Taskmodel } from '../../models/taskmodel/taskmodel.model';
import { UserService } from '../../services/user/user.service';
import { UserdataService } from '../../services/userdata/userdata.service';

@Component({
  selector: 'app-all-tasks',
  templateUrl: './all-tasks.component.html',
  styleUrl: './all-tasks.component.css',
})
export class AllTasksComponent implements OnInit{

  tasks : Taskmodel[] = [];

  constructor(private userService: UserService, private userdataService : UserdataService) {}

  isLogged() : boolean {
    return this.userdataService.isLogged();
  }

  ngOnInit(): void {
    if(this.isLogged()) {
      this.userService.getTasks().subscribe(
        (response) => 
        {
          if(response.isSuccess == true) {
            this.tasks = response.result;
          }
        }
      )
    }
  }
}
