import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { EstudiantesComponent } from '../components/estudiantes/estudiantes.component';

@Injectable({
  providedIn: 'root'
})
export class EstudianteService {

  private myAppUrl = 'https://localhost:44364/';
  private myApiUrl = 'api/Estudiantes/';

  constructor(private Http: HttpClient) { }

  getlistarestudiantes(): Observable<any>{
    return this.Http.get<EstudianteService>(this.myAppUrl + this.myApiUrl)
  }

  getfiltrarestudiante(idEstudiante: number):Observable<any> {
    return this.Http.get(this.myAppUrl + this.myApiUrl + idEstudiante);
  }
}
