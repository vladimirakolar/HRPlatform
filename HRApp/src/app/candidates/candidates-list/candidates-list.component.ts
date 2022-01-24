import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Candidate } from '../model/candidate.model';
import { CandidateService } from '../services/candidate.service';

@Component({
  selector: 'app-candidates-list',
  templateUrl: './candidates-list.component.html',
  styleUrls: ['./candidates-list.component.css']
})
export class CandidatesListComponent implements OnInit {

  candidates: Candidate = new Candidate();
  candidateList :Candidate[] = [];
	count :number = 0;

  constructor(private candidateService: CandidateService) { }

  ngOnInit(): void {
    
  }

  

}
