import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserInterface } from './list-users.component';

@Component({
  selector: 'edit-user',
  templateUrl: './edit-user.component.html'
})
export class EditUserComponent {
  name: string = '';
  email: string = '';
  password: string = '';

  constructor(public http: HttpClient, @Inject('BASE_URL') public baseUrl: string) {
    
  }

  save() {
    this.http.post<createUserRes>(this.baseUrl + 'user/save',
      { name: this.name, email: this.email, password: this.password } as createUserReq)
        .subscribe(result => {
      
    }, error => console.error(error));
  }
}

export class createUserReq {
  name!: string;
  email!: string;
  password!: string;
};
export class createUserRes { };
