import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import { AppService } from '../app.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})

export class AddComponent implements OnInit {

  constructor(private formBuilder: FormBuilder, private router: Router, private appService: AppService) { }

  addForm: FormGroup;

  ngOnInit() {

    this.addForm = this.formBuilder.group({
      id: [],
      name: ['', Validators.required],
      cpf: ['', Validators.required],
      phones: ['', Validators.required]
    });

  }

  onSubmit() {
    this.appService.createStudent(this.addForm.value)
      .subscribe( data => {
        this.router.navigate(['list']);
      });
  }
}
