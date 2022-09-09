import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpService } from 'src/app/services/http.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  public typeUser: string = ('');
  public document: string = ('');

  constructor(private router: Router, private servicios: HttpService) { }

  ngOnInit(): void {
  }
  
  public login() {
    sessionStorage.clear();
    switch (this.typeUser) {
      case 'Paciente':
        this.servicios.getPacientes().subscribe((res: any) => {
          res.forEach(element => {
            if (element.numDoc == this.document) {
              this.successful('paciente', element, element.idUsuario);
            }else{
              // location.reload()
            }
          });
        });
        break;
      case 'Personal':
        this.servicios.getPersonas().subscribe((res: any) => {
          res.forEach(element => {
            if (element.numDoc == this.document) {
              this.successful('personal', element, element.idPersonal);
            }else{
              // location.reload()
            }
          });
        });
        break;
      default:
        alert('Intenta Nuevamente');
        break;
    }

  }
  private successful(data, element, id){
    if(element){
      alert('bienvenido' + ' ' + element.nombres);
      const rol = data;
      sessionStorage.setItem( 'rol', rol);
      sessionStorage.setItem( 'id', id);
      this.router.navigate(['/dashboard/home']);
    }
  }
}
