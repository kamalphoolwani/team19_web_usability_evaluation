import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Portal } from 'app/portal';
import { PortalService } from 'app/service/portal.service';


@Component({
    selector: 'portal-cmp',
    moduleId: module.id,
    templateUrl: 'portals.component.html',
    providers: [PortalService]
})

export class PortalsComponent implements OnInit{
    public portals : Portal[];
    public portalForm: FormGroup;

    constructor(private portalService: PortalService, private formBuilder: FormBuilder){

    }

    ngOnInit(){
        this.getAllPortals();
        this.portalForm = new FormGroup({
            'name': new FormControl(null),
            'testPortalUrl': new FormControl(null),
            'stakeHolderName': new FormControl(null),
            'stakeHolderEmail': new FormControl(null),
            'checkList': new FormControl(null),
        });
    }

    addPortal(){
        console.log(this.portalForm.value);
        this.portalService.savePortal(this.portalForm.value).subscribe((response) => {
            console.log(response);
            this.portalForm.reset();
            this.getAllPortals();
        });
    }

    getAllPortals(){
        this.portalService.getAllPortals().subscribe((portals) => {
            this.portals = portals;
            console.log(this.portals);
        });
    }
}