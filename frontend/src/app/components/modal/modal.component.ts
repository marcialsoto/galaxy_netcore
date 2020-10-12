import { Component, OnInit, Inject } from '@angular/core';
import { NgForm } from '@angular/forms';
import {MatDialog, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { OpcionModel } from 'src/app/models/opcion.model';
import { OpcionService } from '../../services/opcion.service';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styles: [
  ]
})
export class ModalComponent implements OnInit {

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: OpcionModel,
    public opcionService: OpcionService,
    private modalRef: MatDialog
    ) {}

  ngOnInit(): void {
  }

  agregarOactualizar(opcionForm: NgForm) {
    if (opcionForm.invalid) {
      return;
    }

    if (opcionForm.value.codigo == 0) {
      this.opcionService.agregarOpcion(opcionForm.value)
        .subscribe(() => {
          this.modalRef.closeAll();
        });
    } else {
      this.opcionService.actualizarOpcion(opcionForm.value)
        .subscribe(() => {
          this.modalRef.closeAll();
        });
    }
  }

}
