import { Status } from "./general";
import { Personnel, Resource } from "./resources";

export type MaintenanceSite = {
    id: string,
    status: Status
    personnel: Personnel[],
    maintenanceOrder: MaintenanceOrder,
}

type MaintenanceType = 'maintenance-1' | 'maintenance-2' | 'maintenance-3' | 'maintenance-4';

type MaintenanceGeneric = {
    id: string,
    status: Status,
    issue: MaintenanceType,
    description: string,
    assignedPersonnel: Personnel[]
    reqResources: Resource[]
    airplaneId: string,
    deadline: string,
    createdAt: string,
    startedAt: string,
    updatedAt: string,
    endedAt: string,
}

//If the plane requires multiple maintenances create multiple MTs(Maintenance tasks) inside the order.
type MaintenanceOrder = MaintenanceGeneric & {
    maintenanceTasks: MaintenanceTask[],
};

export type MaintenanceTask = MaintenanceGeneric & {
    maintenanceOrder: MaintenanceOrder,
    maintenanceDuration: string,
}