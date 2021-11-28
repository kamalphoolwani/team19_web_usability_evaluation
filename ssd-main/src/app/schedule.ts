export class Schedule {
    id: number;
    viewerName = '';
    viewerEmail = '';
    startDateTime = new Date();
    testPortalId = '';
    description = '';
  
    constructor(values: Object = {}) {
      Object.assign(this, values);
    }
  }