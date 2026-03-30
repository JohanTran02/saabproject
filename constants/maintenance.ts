import { MaintenanceOrder, MaintenanceSite } from "@/types/maintenance";

export const maintenanceOrders: MaintenanceOrder[] = [
    {
        id: "ORD-2026-X7",
        airplaneId: "F16-VIPER-BLUE",
        deadline: "2026-03-20T12:00:00Z",
        assignedPersonnelIds: ['Personnel-1', 'Personnel-2', 'Personnel-3'],
        reqTotalResources: [
            // This is the aggregate "Shopping List" for the whole hangar
            {
                type: 'fuel', sku: 'JF-A1', name: 'Jet A-1', amount: 1200, unit: 'liters',
                buffer: { minReqAmount: 1000, optimalReqAmount: 1800, maxReqAmount: 2000 }
            },
            {
                type: 'battery', sku: 'BT-99', name: 'Main Power Cell', amount: 2, unit: 'kWh',
                buffer: { minReqAmount: 1, optimalReqAmount: 2, maxReqAmount: 2 }
            }
        ],

        orderTitle: "Pre-Mission Overhaul",
        status: "active",
        description: "Comprehensive systems check and refueling before Mission Alpha.",
        createdAt: "2026-03-10T08:00:00Z",
        startedAt: "2026-03-11T09:00:00Z",
        updatedAt: "2026-03-13T16:00:00Z",
        endedAt: "",

        maintenanceTasks: [
            {
                id: "TSK-001",
                maintenanceOrderId: "ORD-2026-X7",
                maintenanceDuration: "3h",
                taskType: "maintenance-1",
                status: "in_progress",
                description: "Refueling internal wing tanks and leak inspection.",
                reqResources: [
                    {
                        type: 'fuel',
                        sku: 'JF-A1',
                        name: 'Jet A-1',
                        amount: 1200,
                        unit: 'liters',
                        buffer: { minReqAmount: 1000, optimalReqAmount: 1800, maxReqAmount: 2000 }
                    }
                ],
                createdAt: "2026-03-11T09:00:00Z",
                startedAt: "2026-03-11T10:00:00Z",
                updatedAt: "2026-03-13T14:00:00Z",
                endedAt: ""
            },
            {
                id: "TSK-002",
                maintenanceOrderId: "ORD-2026-X7",
                maintenanceDuration: "1.5h",
                taskType: "maintenance-4",
                status: "verification",
                description: "Swapping avionics batteries and testing HUD power.",
                reqResources: [
                    {
                        type: 'battery',
                        sku: 'BT-99',
                        name: 'Main Power Cell',
                        amount: 2,
                        unit: 'kWh',
                        buffer: { minReqAmount: 1, optimalReqAmount: 2, maxReqAmount: 2 }
                    }
                ],
                createdAt: "2026-03-11T09:00:00Z",
                startedAt: "2026-03-12T08:00:00Z",
                updatedAt: "2026-03-12T10:00:00Z",
                endedAt: ""
            }
        ]
    },
    {
        id: "ORD-2026-X8",
        airplaneId: "RAPTOR-09",
        deadline: "2026-03-14T06:00:00Z",
        assignedPersonnelIds: ['Personnel-4', 'Personnel-5'],
        reqTotalResources: [
            {
                type: 'ammunition', sku: '20MM-VUL', name: 'Vulcan Rounds', amount: 300, unit: 'bullets',
                buffer: { minReqAmount: 200, optimalReqAmount: 500, maxReqAmount: 511 }
            }
        ],
        orderTitle: "Quick Turnaround (Combat Prep)",
        status: "active",
        description: "Urgent reload and weapons system calibration.",
        createdAt: "2026-03-13T10:00:00Z",
        startedAt: "2026-03-13T11:00:00Z",
        updatedAt: "2026-03-13T12:00:00Z",
        endedAt: "",
        maintenanceTasks: [
            {
                id: "TSK-101",
                maintenanceOrderId: "ORD-2026-X8",
                maintenanceDuration: "45m",
                taskType: "maintenance-3",
                status: "in_progress",
                description: "Loading live munitions into bay 1 and 2.",
                reqResources: [
                    {
                        type: 'ammunition', sku: '20MM-VUL', name: 'Vulcan Rounds', amount: 200, unit: 'bullets',
                        buffer: { minReqAmount: 200, optimalReqAmount: 500, maxReqAmount: 511 }
                    }
                ],
                createdAt: "2026-03-13T11:00:00Z",
                startedAt: "2026-03-13T11:15:00Z",
                updatedAt: "2026-03-13T11:30:00Z",
                endedAt: ""
            }
        ]
    },
    {
        id: "ORD-2026-X9",
        airplaneId: "GHOST-X",
        deadline: "2026-03-25T18:00:00Z",
        assignedPersonnelIds: [],
        reqTotalResources: [
            {
                type: 'battery', sku: 'BT-ULTRA', name: 'Stealth-Ion Pack', amount: 100, unit: 'kWh',
                buffer: { minReqAmount: 80, optimalReqAmount: 100, maxReqAmount: 100 }
            }
        ],
        orderTitle: "Critical Electrical Repair",
        status: "idle", // Not started yet
        description: "Total avionics failure reported during taxi.",
        createdAt: "2026-03-13T15:00:00Z",
        startedAt: "",
        updatedAt: "2026-03-13T15:00:00Z",
        endedAt: "",
        maintenanceTasks: [
            {
                id: "TSK-201",
                maintenanceOrderId: "ORD-2026-X9",
                maintenanceDuration: "6h",
                taskType: "maintenance-2",
                status: "idle",
                description: "Full diagnostic of electrical bus and battery replacement.",
                reqResources: [
                    { type: 'battery', sku: 'BT-ULTRA', name: 'Stealth-Ion Pack', amount: 100, unit: 'kWh', buffer: { minReqAmount: 80, optimalReqAmount: 100, maxReqAmount: 100 } }
                ],
                createdAt: "2026-03-13T15:00:00Z",
                startedAt: "",
                updatedAt: "2026-03-13T15:00:00Z",
                endedAt: ""
            }
        ]
    }
];

export const maintenanceTypesList = [
    { label: 'Maintenance-1', value: 'maintenance-1' },
    { label: 'Maintenance-2', value: 'maintenance-2' },
    { label: 'Maintenance-3', value: 'maintenance-3' },
    { label: 'Maintenance-4', value: 'maintenance-4' }
];

export const maintenanceSites: MaintenanceSite[] = [
    {
        id: 'maintenance-site-1',
        status: 'active',
        assignedPersonnelIds: [],
        maintenanceOrderId: "ORD-2026-X7",
        maintenanceTaskId: ""
    },
    {
        id: 'maintenance-site-2',
        status: 'idle',
        assignedPersonnelIds: [],
        maintenanceOrderId: "ORD-2026-X9",
        maintenanceTaskId: ""
    },
    {
        id: 'maintenance-site-3',
        status: 'active',
        assignedPersonnelIds: [],
        maintenanceOrderId: "ORD-2026-X8",
        maintenanceTaskId: ""
    },
    {
        id: 'maintenance-site-4',
        status: 'idle',
        assignedPersonnelIds: [],
        maintenanceOrderId: "",
        maintenanceTaskId: ""
    },
]