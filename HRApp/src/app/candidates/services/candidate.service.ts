import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map } from 'rxjs/operators';
import { Candidate } from "../model/candidate.model";
import { CandidateSearchResult } from "../model/candidateSearchResult.model";

const baseUrl = "https://localhost:44315/api/candidates";

@Injectable({
	providedIn: 'root'
})

export class CandidateService {

    constructor(private http :HttpClient) {}

    getAllCandidates() :Observable<CandidateSearchResult> {

     return this.http.get(baseUrl).pipe(map( 
           response => { return new CandidateSearchResult(response); }
         ));
    }

    getOneCandidate(id: number): Observable<Candidate> {
        return this.http.get(`${baseUrl}/${id}`).pipe(map(response => {
          return new Candidate(response);
        }))
    }

    add(newCandidate :Candidate) :Observable<Candidate>{
        return this.http.post(baseUrl, newCandidate).pipe(map(
          response => { return new Candidate(response); }
        ));
    }

    update(editedCandidate :Candidate) :Observable<Candidate>{
        return this.http.put(baseUrl + "/" + editedCandidate.id, editedCandidate).pipe(map(
          response => { return new Candidate(response); }
        ));
    }

    remove(id :number) :Observable<Candidate>{
        return this.http.delete(`${baseUrl}/${id}`).pipe(map(
          response => { return new Candidate(response); }
        ));
    }

}