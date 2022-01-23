import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Candidate } from '../model/candidate.model';
import { CandidateService } from '../services/candidate.service';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent implements OnInit {
  
  candidateList: Candidate[] = [];

  constructor(private candidateService : CandidateService) { }

  ngOnInit(): void {
    this.getCandidates();
  }

  getCandidates():void {
    this.candidateService.getAllCandidates().subscribe(x => {
      this.candidateList = x.candidates;
    })
  }


}
