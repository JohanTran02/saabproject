import { Status } from "./general";
import { Resource } from "./resources";

export type MaintenanceSite = {
    id: string,
    status: Status
    assignedPersonnelIds: string[],
    maintenanceOrderId: string,
    maintenanceTaskId: string,
}

export type MaintenanceType = 'maintenance-1' | 'maintenance-2' | 'maintenance-3' | 'maintenance-4' | 'none';

type MaintenanceGeneric = {
    id: string,
    status: Status,
    description: string,
    createdAt: string,
    startedAt: string,
    updatedAt: string,
    endedAt: string,
}

//If the plane requires multiple maintenances create multiple MTs(Maintenance tasks) inside the order.
export type MaintenanceOrder = MaintenanceGeneric & {
    maintenanceTasks: MaintenanceTask[],
    orderTitle: string
    assignedPersonnelIds: string[]
    airplaneId: string,
    deadline: string,
    reqTotalResources: Resource[]
};

export type MaintenanceTask = MaintenanceGeneric & {
    taskType: MaintenanceType | (string & {}),
    maintenanceOrderId: string,
    maintenanceDuration: string,
    reqResources: Resource[]
}