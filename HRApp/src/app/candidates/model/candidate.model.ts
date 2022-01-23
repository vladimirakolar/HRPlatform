export class Candidate {
	id: number;
	name: string;
	dateOfBirth: string;
	contactNumber: string;
	email: string;
	skills: Skills[];

	constructor(obj?: any){
		this.id = obj && obj.id || null;
		this.name = obj && obj.name || null;
		this.dateOfBirth = obj && obj.dateOfBirth || null;
		this.contactNumber = obj && obj.contactNumber || null;
		this.email = obj && obj.email || null;
		this.skills = obj && obj.skills && obj.skills.map((x:any)=> new Skills(x)) || [];
	}
}

export class Skills {

    id: number;
    name: string;

    constructor(obj?: any){
		this.id = obj && obj.id || null;
		this.name = obj && obj.name || null;
	}

}
