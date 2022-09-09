import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl} from '@angular/forms';
@Component({
  selector: 'app-registrar',
  templateUrl: './registrar.component.html',
  styleUrls: ['./registrar.component.scss']
})
export class RegistrarComponent implements OnInit {

  constructor() { }

  public user: FormGroup;

  ngOnInit(): void {
    this.user = new FormGroup({
      nombre: new FormControl(''),
      cedula: new FormControl(''),
      telefono: new FormControl(''),
      fech_naci: new FormControl(''),
      genero: new FormControl(''),
      cliente: new FormControl(''),
      sede: new FormControl(''),
      edad: new FormControl(''),
    });
  }

  public registrar(){
    console.log(this.user);
    
  }

}
