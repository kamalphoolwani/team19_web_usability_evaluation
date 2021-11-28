export class Portal {
    id: number;
    name = '';
    testPortalUrl = '';
    stakeHolderName = '';
    stakeHolderEmail = '';
    checkList = '';
  
    constructor(values: Object = {}) {
      Object.assign(this, values);
    }
  }