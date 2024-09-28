// src/app/app-routing.module.ts
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DiscussionsComponent } from './presentation/discussions/discussions.component';
import { NotificationsComponent } from './presentation/notifications/notifications.component';
import { WelcomeComponent } from './presentation/welcome/welcome.component';
import { LoginComponent } from './presentation/authentication/login/login.component';
import { RegisterComponent } from './presentation/authentication/register/register.component';
import { AdminComponent } from './presentation/admin/admin.component';
import { UserListComponent } from './presentation/admin/components/user-list/user-list.component';
import { UserProfileComponent } from './presentation/admin/components/user-profile/user-profile.component';
import { HomeComponent } from './presentation/home/home.component';
import { SettingsComponent } from './presentation/settings/settings.component';
import { ProfileComponent } from './presentation/profile/profile.component';
import { LogedInGuard } from './services/guards/loged-in.guard';
import { AlreadyLoggedInGuard } from './services/guards/already-logged-in.guard';
import { NetworkComponent } from './presentation/network/network.component';
import { ViewProfileComponent } from './presentation/view-profile/view-profile.component';
import { AdvertisementUpdateComponent } from './presentation/jobs/modules/advertisement-update/advertisement-update.component';
import { AdvertisementComponent } from './presentation/jobs/advertisement.component';
import { MyAdvertisementsComponent } from './presentation/jobs/modules/my-advertisements/my-advertisements.component';
import { JobListingsComponent } from './presentation/jobs/modules/job-listings/job-listings.component';

const routes: Routes = [
  {
    path: '',
    component: WelcomeComponent,
    canActivate: [AlreadyLoggedInGuard],
  },
  {
    path: 'login',
    component: LoginComponent,
    canActivate: [AlreadyLoggedInGuard],
  },
  {
    path: 'register',
    component: RegisterComponent,
    canActivate: [AlreadyLoggedInGuard],
  },
  {
    path: 'admin',
    component: AdminComponent,
    canActivate: [LogedInGuard],
    children: [
      {
        path: 'users',
        component: UserListComponent,
        canActivate: [LogedInGuard],
      },
      {
        path: 'users/:id',
        component: UserProfileComponent,
        canActivate: [LogedInGuard],
      },
    ],
  },
  { path: 'home', component: HomeComponent, canActivate: [LogedInGuard] },
  { path: 'profile', component: ProfileComponent, canActivate: [LogedInGuard] },
  {
    path: 'settings',
    component: SettingsComponent,
    canActivate: [LogedInGuard],
  },
  {
    path: 'jobs',
    component: AdvertisementComponent,
    canActivate: [LogedInGuard],
    children: [
      { path: 'updateAdvertisement', component: AdvertisementUpdateComponent },
      {
        path: 'updateAdvertisement/update/:id',
        component: AdvertisementUpdateComponent,
      },
      { path: 'my-advertisements', component: MyAdvertisementsComponent },
      { path: 'advertisements', component: JobListingsComponent },
    ],
  },
  {
    path: 'discussions',
    component: DiscussionsComponent,
    canActivate: [LogedInGuard],
  },
  {
    path: 'notifications',
    component: NotificationsComponent,
    canActivate: [LogedInGuard],
  },
  {
    path: 'network',
    component: NetworkComponent,
    canActivate: [LogedInGuard],
  },
  { path: 'view-profile/:id', component: ViewProfileComponent },
  { path: '**', redirectTo: '/home' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
