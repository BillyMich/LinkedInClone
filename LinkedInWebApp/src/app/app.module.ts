// src/app/app.module.ts
import { NgModule, LOCALE_ID } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { WelcomeComponent } from './presentation/welcome/welcome.component';
import { LoginComponent } from './presentation/authentication/login/login.component';
import { RegisterComponent } from './presentation/authentication/register/register.component';
import { AdminComponent } from './presentation/admin/admin.component';
import { UserListComponent } from './presentation/admin/components/user-list/user-list.component';
import { UserProfileComponent } from './presentation/admin/components/user-profile/user-profile.component';
import { HomeComponent } from './presentation/home/home.component';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { RouterModule } from '@angular/router';
import { NavigationBarComponent } from './presentation/navigation-bar/navigation-bar.component';
import { SidebarComponent } from './presentation/sidebar/sidebar.component';
import { ProfileComponent } from './presentation/profile/profile.component';
import { SettingsComponent } from './presentation/settings/settings.component';
import { DiscussionsComponent } from './presentation/discussions/discussions.component';
import { NotificationsComponent } from './presentation/notifications/notifications.component';
import { NetworkComponent } from './presentation/network/network.component';
import { AdvertisementDetailComponent } from './presentation/jobs/modules/advertisement-detail/advertisement-detail.component';
import { AdvertisementUpdateComponent } from './presentation/jobs/modules/advertisement-update/advertisement-update.component';
import { AdvertisementComponent } from './presentation/jobs/advertisement.component';
import { MyAdvertisementsComponent } from './presentation/jobs/modules/my-advertisements/my-advertisements.component';
import { JobListingsComponent } from './presentation/jobs/modules/job-listings/job-listings.component';
import { ViewProfileComponent } from './presentation/view-profile/view-profile.component';
import { registerLocaleData } from '@angular/common';
import localeEl from '@angular/common/locales/el';

registerLocaleData(localeEl);

@NgModule({
  declarations: [
    AppComponent,
    WelcomeComponent,
    LoginComponent,
    RegisterComponent,
    AdminComponent,
    UserListComponent,
    UserProfileComponent,
    HomeComponent,
    NavigationBarComponent,
    SidebarComponent,
    ProfileComponent,
    SettingsComponent,
    DiscussionsComponent,
    NotificationsComponent,
    NetworkComponent,
    AdvertisementDetailComponent,
    AdvertisementUpdateComponent,
    AdvertisementComponent,
    MyAdvertisementsComponent,
    JobListingsComponent,
    ViewProfileComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    BrowserAnimationsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    RouterModule,
  ],
  providers: [
    { provide: LOCALE_ID, useValue: 'el' },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
