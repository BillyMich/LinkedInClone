import { Component, OnInit, HostListener } from '@angular/core';
import { JobService } from '../../services/job.service';
import { AuthService } from '../../services/auth-service/auth.service';

@Component({
  selector: 'app-jobs',
  templateUrl: './jobs.component.html',
  styleUrls: ['./jobs.component.css'],
})
export class JobsComponent implements OnInit {
  jobListings: any[] = [];
  user: any;
  newJob: any = {
    title: '',
    description: '',
    skillsRequired: '',
  };
  showJobForm: boolean = false;

  constructor(
    private jobService: JobService,
    private authService: AuthService
  ) {}

  ngOnInit() {
    this.user = this.authService.getCurrentUser();
    this.loadJobListings();
  }

  loadJobListings() {
    this.jobService.getJobListings().subscribe((data) => {
      this.jobListings = data;
    });
  }

  applyForJob(jobId: string) {
    this.jobService.applyForJob(jobId).subscribe((response) => {
      console.log('Applied for job', response);
    });
  }

  toggleJobForm() {
    this.showJobForm = !this.showJobForm;
  }

  postJob() {
    if (this.newJob.title && this.newJob.description) {
      this.jobService.postJob(this.newJob).subscribe((response) => {
        console.log('Job posted', response);
        this.loadJobListings();
        this.newJob = { title: '', description: '', skillsRequired: '' };
        this.showJobForm = false; 
      });
    }
  }

  @HostListener('document:keydown', ['$event'])
  handleKeyDown(event: KeyboardEvent) {
    if (event.key === 'Escape' && this.showJobForm) {
      this.showJobForm = false;
    }
  }
}
