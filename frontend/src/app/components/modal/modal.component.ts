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

  actualizar(actualizarForm: NgForm) {
    if (actualizarForm.invalid) {
      return;
    }

    this.opcionService.actualizarOpcion(actualizarForm.value)
      .subscribe(msg => {
        console.log(msg);
        this.modalRef.closeAll();
      });
  }

}
