import { Status } from "./general";
import { Resource } from "./resources";

export type MaintenanceSite = {
    id: string,
    status: Status
    assignedPersonnelIds: string[],
    maintenanceOrderId: string,
}

export type MaintenanceType = 'maintenance-1' | 'maintenance-2' | 'maintenance-3' | 'maintenance-4' | 'none';

type MaintenanceGeneric = {
    id: string,
    status: Status,
    taskName: MaintenanceType | string,
    description: string,
    createdAt: string,
    startedAt: string,
    updatedAt: string,
    endedAt: string,
}

//If the plane requires multiple maintenances create multiple MTs(Maintenance tasks) inside the order.
export type MaintenanceOrder = MaintenanceGeneric & {
    maintenanceTasks: MaintenanceTask[],
    assignedPersonnelIds: string[]
    airplaneId: string,
    deadline: string,
    reqTotalResources: Resource[]
};

export type MaintenanceTask = MaintenanceGeneric & {
    maintenanceOrderId: string,
    //assignedPersonnelIds: string[] Should at least show who works on a maintenance task? 
    maintenanceDuration: string,
    reqResources: Resource[]
}