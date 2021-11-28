export class Feedback {
    id: number;
    name = '';
    scheduleId = '';
    testPortalId = '';
    description = '';
    
    constructor(values: Object = {}) {
      Object.assign(this, values);
    }
}