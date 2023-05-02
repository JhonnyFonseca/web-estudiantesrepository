import { Component} from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { EstudianteService } from 'src/app/Services/estudiante.service';


@Component({
  selector: 'app-estudiantes',
  templateUrl: './estudiantes.component.html',
  styleUrls: ['./estudiantes.component.css']
})
export class EstudiantesComponent{
  listarestudiantes: any[] = [];

  form: FormGroup;

  constructor(private fb: FormBuilder,
    private toastr: ToastrService,
    private _EstudianteService: EstudianteService){
    this.form = this.fb.group({
      numeroid:[''],
      nombre:[''],
      apellidos:[''],
      email:[''],
    })
  }

  ngOnInit(): void{
    this.obtenerestudiantes();
  }

  obtenerestudiantes(){
    this._EstudianteService.getlistarestudiantes().subscribe(data => {
      console.log(data);
      this.listarestudiantes = data;
    }, error =>{
      console.log(error);
    })
  }

  filtrarestudiantes(){

    const 
     idEstudiante = this.form.get('numeroid')?.value

    this._EstudianteService.getfiltrarestudiante(idEstudiante).subscribe(data =>{
      this.listarestudiantes = data;
      console.log(data);
      this.form.reset();
    }, error=> {
      console.log(error);
    })
  }

  agregarcurso(index: number){
    console.log(index);
  }
}
