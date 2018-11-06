import { Guid } from 'guid-typescript';
import { AppService } from './../app.service';
import { Component, OnInit } from '@angular/core';
import { Student } from 'src/modules/student.model';
import {Router} from "@angular/router";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {first} from "rxjs/operators";

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})

export class EditComponent implements OnInit {

  student: Student;
  editForm: FormGroup;
  constructor(private formBuilder: FormBuilder,private router: Router, private appService: AppService) { }

  ngOnInit() {
    let studentId = localStorage.getItem("editStudentId");

    if(!studentId) {
      alert("Invalid action.")
      this.router.navigate(['list-user']);
      return;
    }

    this.editForm = this.formBuilder.group({
      studentId: [],
      name: ['', Validators.required],
      cpf: ['', Validators.required],
      phones: ['', Validators.required]
    });
    this.appService.getStudentById(studentId)
      .subscribe( data => {
        this.editForm.setValue(data);
      });
  }

  onSubmit() {
    this.appService.updateStudent(this.editForm.value)
      .pipe(first())
      .subscribe(
        data => {
          this.router.navigate(['list']);
        },
        error => {
          alert(error);
        });
  }

}
