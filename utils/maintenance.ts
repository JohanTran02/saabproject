import { MaintenanceOrder } from '@/types/maintenance';
import 'react-native-get-random-values'

export const createMaintenanceOrder = (personnelIds: string[]): MaintenanceOrder => {
    const array = new Uint16Array(1);
    const randomNumber = crypto.getRandomValues(array)[0];
    return {
        id: `MT-${randomNumber}`,
        status: 'idle',
        orderTitle: '',
        description: '',
        createdAt: new Date().toISOString(),
        endedAt: '',
        startedAt: '',
        updatedAt: '',
        deadline: '',
        reqTotalResources: [],
        assignedPersonnelIds: personnelIds,
        airplaneId: '',
        maintenanceTasks: []
    }
}