import { Component } from '@angular/core';
import { TaskService } from '../../services/task/task.service';
import { Input } from '@angular/core';
import { Taskmodel } from '../../models/taskmodel/taskmodel.model';
import { OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-task-list',
  templateUrl: './task-list.component.html',
  styleUrl: './task-list.component.css',
  providers: [TaskService, Router]
})
export class TaskListComponent implements OnInit {

  @Input() tasks: Taskmodel[] = [];

  constructor(private taskService: TaskService, private router: Router) {
  }

  ngOnInit(): void { }

  update(taskId: number): void {
    this.router.navigate(["/updatetask", taskId]);
  }

  remove(taskId: number): void {
    if (confirm('Delete? Sure?')) {
      this.taskService.removeTask(taskId).subscribe();
      this.ngOnInit();
    }
  }
}
