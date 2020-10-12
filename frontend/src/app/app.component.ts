import { Component, OnInit } from '@angular/core';
import { OpcionService } from '../app/services/opcion.service';
import { OpcionModel } from './models/opcion.model';
import { PaginacionModel } from './models/paginacion.model';
import {MatDialog, MatDialogConfig, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { ModalComponent } from '../app/components/modal/modal.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'frontend';
  displayedColumns: string[] = ['codigo', 'nombre', 'enlace', 'icono', 'accion'];
  opciones: OpcionModel[] = [];
  pag: PaginacionModel = {
    NroPag: 0,
    RegPorPag: 10,
    Filtro: ''
  };

  constructor(
    public opcionService: OpcionService,
    public dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.cargarOpciones(this.pag);
  }

  cargarOpciones(paginacion: PaginacionModel) {
    this.opcionService.cargarOpciones(paginacion)
      .subscribe( (res: any) => {
        // console.log(res);
        this.pag.NroRegTotal = res.totalReg;
        this.opciones = res.opciones;
      });
  }

  editar(element: OpcionModel) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;

    const dialogRef = this.dialog.open(ModalComponent, {
      data: element
    });

    dialogRef.afterClosed().subscribe(() => {
      this.cargarOpciones(this.pag);
    });
  }

  agregar() {
    const opcionEmpty: OpcionModel = {
      codigo: 0,
      nombre: '',
      enlace: '',
      icono: ''
    };

    const dialogRef = this.dialog.open(ModalComponent, {
      data: opcionEmpty
    });

    dialogRef.afterClosed().subscribe(() => {
      this.cargarOpciones(this.pag);
    });

    console.log(opcionEmpty);
  }


  eliminar(element: OpcionModel) {
    this.opcionService.eliminarOpcion(element)
    .subscribe((msg) => {
      console.log(msg);
      this.cargarOpciones(this.pag);
    });
  }
}
