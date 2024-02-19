import { CommonModule } from "@angular/common";
import { Component, OnInit } from '@angular/core';
import { AbstractControlOptions, FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from "@angular/forms";
import { Router, RouterLink } from "@angular/router";
import { ValidatorField } from "@app/helpers/ValidatorField";
import { User } from "@app/models/identity/User";
import { AccountService } from "@app/services/account.service";
import { ToastrService } from "ngx-toastr";

@Component({
  selector: 'app-registration',
  standalone: true,
  imports: [
    CommonModule,
    RouterLink,
    ReactiveFormsModule,
    FormsModule,
    RouterLink
  ],
  templateUrl: './registration.component.html',
  styleUrl: './registration.component.scss',
  providers: [
    AccountService,
    ToastrService
  ]
})

export class RegistrationComponent implements OnInit {
  user = {} as User;
  form!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private accountService: AccountService,
    private router: Router,
    private toaster: ToastrService
  ) {}

  ngOnInit(): void {
    this.validation();
  }

  get formValues(): any { return this.form.controls; }

  private validation(): void {

    const formOptions: AbstractControlOptions = {
      validators: ValidatorField.MustMatch('password', 'confirmePassword')
    };

    this.form = this.fb.group({
      primeiroNome: ['', Validators.required],
      ultimoNome: ['', Validators.required],
      email: ['',
        [Validators.required, Validators.email]
      ],
      userName: ['', Validators.required],
      password: ['',
        [Validators.required, Validators.minLength(4)]
      ],
      confirmePassword: ['', Validators.required],
    }, formOptions);
  }

  register(): void {
    this.user = { ...this.form.value };
    this.accountService.register(this.user).subscribe(
      () => this.router.navigateByUrl('/dashboard'),
      (error: any) => this.toaster.error(error.error)
    )
  }
}
