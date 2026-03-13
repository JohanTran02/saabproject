import { Status } from "./general";
import { MaintenanceSite, MaintenanceTask } from "./maintenance";

type ResourceBuffer = {
    maxReqAmount: number,
    optimalReqAmount: number,
    minReqAmount: number,
}

type BaseResource = {
    id: string,
    currentResources: Resource[],
}

export type Personnel = {
    id: string,
    status: Status,
    currentMaintenanceTask: MaintenanceTask,
    currentMaintenanceSite: MaintenanceSite,
}

type ResourcesUnion = 'fuel' | 'ammunition' | 'spare_parts' | 'weapons' | 'battery' | 'equipment';

type BaseResourceProperties = {
    sku: string;
    name: string;
    amount: number;
    buffer: ResourceBuffer
}

type Fuel = BaseResourceProperties & {
    type: 'fuel';
    unit: 'liters';
    buffer: {
        maxReqAmount: 0.8,
        optimalReqAmount: 0.5,
        minReqAmount: 0.2,
    }
}

type Ammunition = BaseResourceProperties & {
    type: 'ammunition';
    unit: 'missiles' | 'bullet_rounds';
    buffer: {
        maxReqAmount: 0.8,
        optimalReqAmount: 0.5,
        minReqAmount: 0.2,
    }
}

type Battery = BaseResourceProperties & {
    type: 'battery';
    unit: 'kWh';
    buffer: {
        maxReqAmount: 0.8,
        optimalReqAmount: 0.5,
        minReqAmount: 0.2,
    }
}

type GenericResource = BaseResourceProperties & {
    type: Exclude<ResourcesUnion, 'fuel' | 'ammunition' | 'battery'>;
    buffer: {
        maxReqAmount: 0.8,
        optimalReqAmount: 0.5,
        minReqAmount: 0.2,
    }
    unit?: string;
}

export type Resource = Fuel | Ammunition | Battery | GenericResource;