import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';

const URL = environment.url;

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  httpOptions: { headers; observe; } = {
    headers: new HttpHeaders({
      'Content-Type': 'application/x-www-form-urlencoded'
    }),
    observe: 'response'
  };
  constructor(private http: HttpClient) { }

  public login(usuario: string, clave: string ){
    const data = `usuario=${usuario}&clave=${clave}`;
    return this.http.post(`${URL}/auth`,
    {usuario, clave},
    {responseType: 'text'});
  }
  public getPacientes(){
    return this.http.get(`${URL}paciente`);
  }
  public getPersonas(){
    return this.http.get(`${URL}personal`);
  }
  public getAgenda(){
    return this.http.get(`${URL}agenda`);
  }
  public regAgend(form){
    return this.http.post(`${URL}agenda`, form);
  }
}
