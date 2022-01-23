import { Candidate } from "./candidate.model";

export class CandidateSearchResult{
	candidates :Candidate[];
	count :number;

	constructor(searchResult? :any){
		this.count = searchResult && searchResult.count || 0;
		this.candidates = searchResult && 
						searchResult.candidates.map( (result: any) => new Candidate(result)) || [];
	}
}
