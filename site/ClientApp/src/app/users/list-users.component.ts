import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'users-data',
  templateUrl: './list-user.component.html'
})
export class ListUserComponent {
  public users: UserInterface[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, public route: Router) {
    http.get<UserInterface[]>(baseUrl + 'user/Listar').subscribe(result => {
      this.users = result;
    }, error => console.error(error));
  }

  add() {
    this.route.navigate(['/edit-user'])
  }
}

export interface UserInterface {
  id: number,
  name: string,
  email: string,
  password: string
}
