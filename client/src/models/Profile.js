import { DatabaseItem } from "./DatabaseItem.js";

export class Profiles extends DatabaseItem {
  constructor(data) {
    super(data)
    this.name = data.name
    this.picture = data.picture
    this.id = data.id
    this.email = data.email
    this.coverImg = data.coverImg
  }
}