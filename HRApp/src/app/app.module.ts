import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';



import { AppComponent } from './app.component';
import { HomepageComponent } from './core/homepage/homepage.component';
import { InsertCandidateComponent } from './candidates/insert-candidate/insert-candidate.component';
import { CandidatesListComponent } from './candidates/candidates-list/candidates-list.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { SearchFormComponent } from './candidates/search-form/search-form.component';
import { TableComponent } from './candidates/table/table.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    AppComponent,
    HomepageComponent,
    InsertCandidateComponent,
    CandidatesListComponent,
    SearchFormComponent,
    TableComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule, 
    ReactiveFormsModule,
    NgbModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
