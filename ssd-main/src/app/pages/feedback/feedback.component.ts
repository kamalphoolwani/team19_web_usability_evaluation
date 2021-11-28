import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Feedback } from 'app/feedback';
import { PortalService } from 'app/service/portal.service';

@Component({
    selector: 'feedback-cmp',
    moduleId: module.id,
    templateUrl: 'feedback.component.html',
    providers: [PortalService]
})

export class FeedbackComponent implements OnInit{
    public feedbacks : Feedback[];
    public feedbackForm: FormGroup;

    constructor(private portalService: PortalService, private formBuilder: FormBuilder){

    }

    ngOnInit(){
        this.getAllFeedbacks();
        this.feedbackForm = new FormGroup({
            'name': new FormControl(null),
            'description': new FormControl(null)
        });
    }

    addFeedback(){
        console.log(this.feedbackForm.value);
        this.portalService.saveFeedback(this.feedbackForm.value).subscribe((response) => {
            console.log(response);
            this.feedbackForm.reset();
            this.getAllFeedbacks();
        });
    }

    getAllFeedbacks(){
        this.portalService.getAllFeedbacks().subscribe((feedbacks) => {
            this.feedbacks = feedbacks;
            console.log(this.feedbacks);
        });
    }
}