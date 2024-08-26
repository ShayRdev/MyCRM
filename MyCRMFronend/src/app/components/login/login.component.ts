import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [NgbModule, RouterLink],
  template: `
  
  <div class="outer">
    <div class="container">
      <div class="row">
        <div class="offset-md-2 col-lg-5 col-md-7 offset-lg-4 offset-md-2">
          <div class="panel border bg-white">
            <div class="panel-heading">
              <h3 class="pt-3 font-weight-bold">Login</h3>
            </div>
            <div class="panel-body p-3">
              <form>
                <div class="form-group pt-3">
                  <div class="input-field">
                    <span class="fa fa-user p-2"></span>
                    <input type="text" placeholder="Username">
                  </div>
                </div>
                <div class="form-group pt-3">
                  <div class="input-field">
                    <span class="fa fa-lock p-2"></span>
                    <input type="text" placeholder="Password">
                  </div>
                </div>
                <div class="form-inline fr mt-4">
                  <a id="forgot" class="font-weight-bold">Forgot Password?</a>
                </div>
                <button type="submit" class="btn btn-primary btn-block mt-4 w-100">Login</button>
                <div class="text-center pt-4 text-muted">
                  Dont have account? <a id="forgot" routerLink="/signup">Sign Up</a>
                  
                </div>
              </form>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>  

            `,
  styleUrl: './login.component.css'
})
export class LoginComponent {

}
