import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, NgForm } from '@angular/forms';
import { umask } from 'process';
import { HttpService } from 'src/app/services/http.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  constructor(private servicios: HttpService) { }

  public user: FormGroup;
  public listPersonalMedic: string[];
  public numberAgend = 26;
  private idp: number;
  ngOnInit(): void {
    this.listAgenda();
    this.listPersonal();
    this.consulId();

    this.user = new FormGroup({
      codAgenda: new FormControl( this.numberAgend ),
      fechaAgenda: new FormControl('', [Validators.required]),
      idPersonalAgenda: new FormControl(this.idp , [Validators.required]),
      idPersonalRecibe: new FormControl ( this.idp, [Validators.required]),
      idUsuario: new FormControl( this.idp, [Validators.required]),
      observaciones: new FormControl('', [Validators.required]),
    });
  }

  public registrar() {
    
    const data = this.user.value;
    console.log(this.user.value);
    
    this.servicios.regAgend(data).subscribe((res: any) => {
      console.log(res);

    });
  }

  private listPersonal() {
    this.servicios.getPersonas().subscribe((res: any) => {
      this.listPersonalMedic = res;
    });
  }
  private listAgenda() {
    let num: number;
    this.servicios.getAgenda().subscribe((res: any) => {
      res.forEach(element => {
        for (let i = 0; i <= element.codAgenda; i++) {
          num = i;
        }
      });
    });
  }
  private consulId() {
    this.idp = Number.parseInt(sessionStorage.getItem('id'));
  }
}
