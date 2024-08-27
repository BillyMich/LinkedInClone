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
import { AlreadyLoggedInGuard } from './services/guards/already-logged-in.guard';

const routes: Routes = [
  {
    path: '',
    component: WelcomeComponent,
    canActivate: [AlreadyLoggedInGuard],
  }, // Apply AlreadyLoggedInGuard
  {
    path: 'login',
    component: LoginComponent,
    canActivate: [AlreadyLoggedInGuard],
  }, // Apply AlreadyLoggedInGuard
  {
    path: 'register',
    component: RegisterComponent,
    canActivate: [AlreadyLoggedInGuard],
  }, // Apply AlreadyLoggedInGuard
  { path: 'admin', component: AdminComponent, canActivate: [AuthGuard] },
  {
    path: 'admin/users',
    component: UserListComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'admin/users/:id',
    component: UserProfileComponent,
    canActivate: [AuthGuard],
  },
  { path: 'home', component: HomeComponent, canActivate: [LogedInGuard] }, // Apply LogedInGuard
  { path: 'profile', component: ProfileComponent, canActivate: [LogedInGuard] }, // Apply LogedInGuard
  {
    path: 'settings',
    component: SettingsComponent,
    canActivate: [LogedInGuard],
  }, // Apply LogedInGuard
  { path: '**', redirectTo: '/home' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
