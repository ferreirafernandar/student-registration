import { Component, OnInit } from '@angular/core';
import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { AppService } from '../app.service';
import { Router } from '@angular/router';
import {Student} from '../../modules/student.model';

@Component({
  selector: 'app-lista',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {
  title = 'app';
  students: Array<any> = [];

  constructor(private appService: AppService, private router: Router) {}

  ngOnInit() {
    this.getStudents();
  }

  getStudents() {
    this.appService.getStudents().subscribe(
      (response: any) => {
        this.students = response;
        console.log(this.students)
      },
      error => {
        console.log('error ', error);
      }
    );
  }

  deleteStudent(student: Student): void {
    this.appService.deleteStudent(student.studentId)
      .subscribe( data => {
        this.students = this.students.filter(u => u !== student);
      })
  };

  editStudent(student: Student): void {
    localStorage.removeItem("editStudentId");
    localStorage.setItem("editStudentId", student.studentId);
    this.router.navigate(['edit']);
  };

  addStudent(): void {
    this.router.navigate(['add']);
  };

  // onCheck(e) {
  //   if (e.target.checked) {
  //     const findEl = this.movies.find(filme => filme.id === e.target.value);
  //     if (this.selectedMovies.length >= 16) {
  //       e.stopPropagation();
  //       return alert('Você só pode adicionar 16 filmes seu imbecil!');
  //     }
  //     this.selectedMovies.push(findEl);
  //   } else {
  //     const index = this.movies.indexOf(filme => filme.id === e.target.value);
  //     this.selectedMovies.splice(index, 1);
  //   }
  // }

  // gerarCampeonato() {
  //   this.appService.set(this.selectedMovies);
  //   this.router.navigate(['/campeonato']);
  // }
}
