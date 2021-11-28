import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Schedule } from 'app/schedule';
import { PortalService } from 'app/service/portal.service';


@Component({
    selector: 'schedule-cmp',
    moduleId: module.id,
    templateUrl: 'schedule.component.html'
})

export class ScheduleComponent implements OnInit{
    public schedules : Schedule[];
    public scheduleForm: FormGroup;

    constructor(private portalService: PortalService, private formBuilder: FormBuilder){

    }

    ngOnInit(){
        this.getAllSchedules();
        this.scheduleForm = new FormGroup({
            'viewerName': new FormControl(null),
            'viewerEmail': new FormControl(null),
            'startDateTime': new FormControl(null),
            'description': new FormControl(null),
        });
    }

    addSchedule(){
        console.log(this.scheduleForm.value);
        this.portalService.saveSchedule(this.scheduleForm.value).subscribe((response) => {
            console.log(response);
            this.scheduleForm.reset();
            this.getAllSchedules();
        });
    }

    getAllSchedules(){
        this.portalService.getAllSchedules().subscribe((portals) => {
            this.schedules = portals;
            console.log(this.schedules);
        });
    }
}