import { Location } from "./location.model";

export interface Character {
  Id: number;
  Name: string;
  Status: string;
  Species: string;
  Type: string;
  Gender: string;
  Origin: Location;
  LocationMo: Location;
  Image: string;
  Episode: string[];
  Url: string;
  Created: string;
}
