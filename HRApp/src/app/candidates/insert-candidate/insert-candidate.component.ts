import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Candidate } from '../model/candidate.model';
import { CandidateSearchResult } from '../model/candidateSearchResult.model';
import { CandidateService } from '../services/candidate.service';

@Component({
  selector: 'app-insert-candidate',
  templateUrl: './insert-candidate.component.html',
  styleUrls: ['./insert-candidate.component.css']
})
export class InsertCandidateComponent implements OnInit {

  constructor(private fb: FormBuilder, private candidateService :CandidateService, private http: HttpClient) { }

  ngOnInit(): void {
    
  }

  saveCandidate(){
    console.log("save");
  }

}
