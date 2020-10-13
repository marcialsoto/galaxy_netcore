import { Component, OnInit, ViewChild } from '@angular/core';
import { OpcionService } from '../app/services/opcion.service';
import { OpcionModel } from './models/opcion.model';
import { PaginacionModel } from './models/paginacion.model';
import {MatPaginator} from '@angular/material/paginator';
import {MatDialog, MatDialogConfig, MAT_DIALOG_DATA} from '@angular/material/dialog';
import {MatTableDataSource} from '@angular/material/table';
import { ModalComponent } from '../app/components/modal/modal.component';
import {MatSnackBar} from '@angular/material/snack-bar';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'frontend';
  displayedColumns: string[] = ['codigo', 'nombre', 'enlace', 'icono', 'accion'];
  opciones: OpcionModel[] = [];
  dataSource: MatTableDataSource<OpcionModel>;
  pag: PaginacionModel = {
    NroPag: 0,
    RegPorPag: 10,
    Filtro: ''
  };

  @ViewChild(MatPaginator) paginator: MatPaginator;

  // ngAfterViewInit() {
    
  // }

  constructor(
    public opcionService: OpcionService,
    public dialog: MatDialog,
    private snackBar: MatSnackBar
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
        this.dataSource = new MatTableDataSource<OpcionModel>(res.opciones);
        this.dataSource.paginator = this.paginator;
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
      this.snackBar.open('Editado correctamente', 'OK', {
        duration: 1000,
        horizontalPosition: 'center',
        verticalPosition: 'top',
      });
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
      this.snackBar.open('Agregado correctamente', 'OK', {
        duration: 1000,
        horizontalPosition: 'center',
        verticalPosition: 'top',
      });
    });

    console.log(opcionEmpty);
  }


  eliminar(element: OpcionModel) {
    const confirmation = confirm('¿Estás seguro que desea eliminar?');

    if (!confirmation) {
      console.log('Cancelado');
    } else {
      this.opcionService.eliminarOpcion(element)
      .subscribe((msg) => {
        console.log(msg);
        this.cargarOpciones(this.pag);
        this.snackBar.open('Eliminado correctamente', 'OK', {
          duration: 1000,
          horizontalPosition: 'center',
          verticalPosition: 'top',
        });
      });
    }
  }
}
