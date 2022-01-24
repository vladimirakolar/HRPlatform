import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Candidate } from '../model/candidate.model';
import { CandidateSearchResult } from '../model/candidateSearchResult.model';
import { CandidateService } from '../services/candidate.service';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent implements OnInit {

  @Output() candidateDeleted :EventEmitter<number> = new EventEmitter();
  candidateId : number = NaN;
  candidateList: Candidate[] = [];
  c: CandidateSearchResult = new CandidateSearchResult();

  constructor(private candidateService : CandidateService) { }

  ngOnInit(): void {
    this.getCandidates();
    this.refreshList();
  }

  getCandidates():void {
    this.candidateService.getAllCandidates().subscribe(x => {
      this.candidateList = x.candidates;
    })
  }

  refreshList(){
    this.candidateService.getAllCandidates().subscribe(data =>{
      this.candidateList = data.candidates;
    });
  }
 
  udateCandidate(id: number) : void {
    console.log("klik")
  }

  onDelete(id: number) : void{
    console.log("klik");
    this.candidateService.removeCandidate(id).subscribe(candidateList => {
      this.candidateDeleted.emit(this.candidateId);
    });
  }  

}
