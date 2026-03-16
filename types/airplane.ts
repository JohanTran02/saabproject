import { Resource } from "./resources";

export type Airplane = {
    id: string;
    // weapons: Extract<Resource, { type: 'ammunition' }>[];
    ammunition: Extract<Resource, { type: 'ammunition' }>[];
    fuel: Extract<Resource, { type: 'fuel' }>;
    battery: Extract<Resource, { type: 'battery' }>;
}