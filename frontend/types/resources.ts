import { Status } from "./general";

type ResourceBuffer = {
    maxReqAmount: number,
    optimalReqAmount: number,
    minReqAmount: number,
}

export type Personnel = {
    id: string,
    status: Status,
    // currentMaintenanceOrderId: string,
}

type ResourcesUnion = 'fuel' | 'ammunition' | 'spare_parts' | 'weapons' | 'battery' | 'equipment';

type BaseResourceProperties = {
    type: ResourcesUnion,
    sku: string;
    name: string;
    amount: number;
    buffer?: ResourceBuffer
}

type Fuel = BaseResourceProperties & {
    type: 'fuel';
    unit: 'liters';
    buffer: ResourceBuffer
}

type Ammunition = BaseResourceProperties & {
    type: 'ammunition';
    unit: 'missiles' | 'bullets';
    buffer: ResourceBuffer
}

type Battery = BaseResourceProperties & {
    type: 'battery';
    unit: 'kWh';
    buffer: ResourceBuffer
}

type GenericResource = BaseResourceProperties & {
    type: Exclude<ResourcesUnion, 'fuel' | 'ammunition' | 'battery'>;
    unit?: string;
    buffer?: ResourceBuffer
}

export type Resource = Fuel | Ammunition | Battery | GenericResource;