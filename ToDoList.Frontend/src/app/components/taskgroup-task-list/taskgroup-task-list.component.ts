import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Taskmodel } from '../../models/taskmodel/taskmodel.model';
import { TaskService } from '../../services/task/task.service';
import { TaskgroupService } from '../../services/taskgroup/taskgroup.service';

@Component({
  selector: 'app-taskgroup-task-list',
  templateUrl: './taskgroup-task-list.component.html',
  styleUrl: './taskgroup-task-list.component.css'
})
export class TaskgroupTaskListComponent implements OnInit {

  @Input() tasks: Taskmodel[] = [];
  @Input() taskgroupid: number = 0;

  constructor(private taskgroupService: TaskgroupService, private router: Router) {
  }

  ngOnInit(): void { }

  update(taskId: number): void {
    this.router.navigate(["/updatetask", taskId]);
  }

  remove(taskId: number): void {
    this.taskgroupService.removeTask(this.taskgroupid, taskId).subscribe();
    this.ngOnInit();
  }
}
