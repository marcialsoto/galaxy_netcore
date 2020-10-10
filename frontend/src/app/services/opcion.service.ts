import { Injectable } from '@angular/core';
import { from, Observable } from 'rxjs';
import { HttpParams, HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { PaginacionModel } from '../models/paginacion.model';
import { OpcionModel } from '../models/opcion.model';


@Injectable({
  providedIn: 'root'
})
export class OpcionService {

  constructor( private http: HttpClient) { }

  cargarOpciones(paginacion: PaginacionModel): Observable<any> {
    const params = new HttpParams()
      .append('Filtro', `${paginacion.Filtro}`)
      .append('NroPag', `${paginacion.NroPag}`)
      .append('RegPorPag', `${paginacion.RegPorPag}`)
      .append('NroRegTotal', `${paginacion.NroRegTotal}`);

    return this.http.get<any>(`${environment.api}/Opcion`, {
      params,
    });
  }

  actualizarOpcion(opcion: OpcionModel): Observable<any> {
    return this.http
      .put(
        `${environment.api}/Opcion`,
        opcion
      );
      // .pipe(
      //   map((res: any) => {
      //     this.message.create('success', 'Hospital actualizado con éxito');

      //     return res.hospital;
      //   })
      // );
  }
}
