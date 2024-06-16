// src/app/app-routing.module.ts
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { WelcomeComponent } from './presentation/welcome/welcome.component';
import { LoginComponent } from './presentation/authentication/login/login.component';
import { RegisterComponent } from './presentation/authentication/register/register.component';
import { AdminComponent } from './presentation/admin/admin.component';
import { UserListComponent } from './presentation/admin/user-list/user-list.component';
import { UserProfileComponent } from './presentation/admin/user-profile/user-profile.component';
import { HomeComponent } from './presentation/home/home.component';
import { AuthGuard } from './services/guards/auth.guard';
import { SettingsComponent } from './presentation/settings/settings.component';
import { ProfileComponent } from './presentation/profile/profile.component';
import { LogedInGuard } from './services/guards/loged-in.guard';


const routes: Routes = [
  { path: '', component: WelcomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'admin', component: AdminComponent, canActivate: [AuthGuard] },
  { path: 'admin/users', component: UserListComponent, canActivate: [AuthGuard] },
  { path: 'admin/users/:id', component: UserProfileComponent, canActivate: [AuthGuard] },
  { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
  { path: 'profile', component: ProfileComponent, canActivate: [AuthGuard] },
  { path: 'settings', component: SettingsComponent, canActivate: [AuthGuard] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
