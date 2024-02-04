import { Component } from '@angular/core';
import { Taskmodel } from '../../models/taskmodel/taskmodel.model';
import { TaskService } from '../../services/task/task.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-updatetask',
  templateUrl: './updatetask.component.html',
  styleUrl: './updatetask.component.css',
  providers: [TaskService, Router]
})
export class UpdatetaskComponent {

  initialTaskModel : Taskmodel = {
    id: 0,
    deadLine: '',
    description: '',
    name: '',
    state: -1
  }
  taskmodel : Taskmodel =
  {
    id: 0,
    deadLine: '',
    description: '',
    name: '',
    state: -1
  }

  constructor(private taskService: TaskService, private route: ActivatedRoute, private router: Router) {}

  ngOnInit(): void {
     this.route.params.subscribe(params => {
       this.taskmodel.id = params['id'];
     });
     this.taskService.getTask(this.taskmodel.id).subscribe(
      response =>
      {
        if(response.isSuccess) {
          this.taskmodel = response.result;
          this.initialTaskModel = {...this.taskmodel};
        }
        else {
          this.router.navigate(["/"]);
        }
      }
     )
  }

  update() : void {
    this.taskmodel.deadLine = (new Date(this.taskmodel.deadLine)).toISOString()
    this.taskmodel.state = this.taskmodel.state - 0;
    this.taskService.updateTask(this.taskmodel.id, this.taskmodel).subscribe();
  }

  getStateText(state : number) : string {
    switch(state) {
      case 0:
        return 'Complete';
      case 1:
        return 'Not Started';
      case 2:
        return 'Failed';
      case 3:
        return 'Started';
    }
    return "";
  }
}
