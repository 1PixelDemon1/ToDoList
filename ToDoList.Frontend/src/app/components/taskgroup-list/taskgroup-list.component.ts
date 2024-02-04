import { Component, Input } from '@angular/core';
import { Taskgroupmodel } from '../../models/taskgroupmodel/taskgroupmodel.model';
import { Router } from '@angular/router';
import { TaskgroupService } from '../../services/taskgroup/taskgroup.service';


@Component({
  selector: 'app-taskgroup-list',
  templateUrl: './taskgroup-list.component.html',
  styleUrl: './taskgroup-list.component.css'
})
export class TaskgroupListComponent {
  @Input() taskgroups : Taskgroupmodel[] = [];

  constructor(private router: Router, private taskgroupService : TaskgroupService) {}

  view(taskgroupId: number) : void {
    this.router.navigate(["taskgroup", taskgroupId]);
  }

  remove(taskgroupId: number) : void {
    if (confirm('Delete? Sure?')) {
      this.taskgroupService.removeTaskGroup(taskgroupId).subscribe();
    }
  }
}
