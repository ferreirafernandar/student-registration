import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Guid } from "guid-typescript";

@Injectable()
export class AppService {

  storedData;

  constructor(private http: HttpClient) {

  }

  getStudents(): Observable<Object> {
    const headers = {
      'Access-Control-Allow-Origin': '*'
    };

    return this.http
      .get('http://localhost:62909/api/students/GetAll', { headers });
  }

  getStudentById(id: string): Observable<Object> {
    const headers = {
      'Access-Control-Allow-Origin': '*'
    };
    
    return this.http
      .get('http://localhost:62909/api/students/GetById/' + id, { headers });
  }

  createStudent(students) {
    const headers = {
      'Access-Control-Allow-Origin': '*'
    };
    return this.http
      .post('http://localhost:62909/api/students/Add', { students }, { headers });
  }

  updateStudent(students) {
    const headers = {
      'Access-Control-Allow-Origin': '*'
    };
    return this.http
      .put('http://localhost:62909/api/students/Update', { students }, { headers });
  }

  deleteStudent(id: string) {
    const headers = {
      'Access-Control-Allow-Origin': '*'
    };
    return this.http
      .delete('http://localhost:62909/api/students/Remove/' + id, { headers });
  }

  returnGame(): Observable<Object> {
    const headers = {
      'Access-Control-Allow-Origin': '*'
    };
    return this.http
      .get('http://localhost:54431/api/movies/game', { headers });
  }

  postMovies(movies) {
    const headers = {
      'Access-Control-Allow-Origin': '*'
    };
    return this.http
      .post('http://localhost:54431/api/movies/game', { movies }, { headers });
  }

  public get() {
    return this.storedData;
  }

  public set(data) {
    this.storedData = data;
  }
}
