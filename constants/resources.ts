import { BaseResource, Personnel } from "@/types/resources";

const DEFAULT_BUFFER = {
    maxReqAmount: 0.8,
    optimalReqAmount: 0.5,
    minReqAmount: 0.2,
} as const;

export const BaseResources: BaseResource = {
    id: 'asdofiaoisdfjoiajsdfoi',
    currentResources: {
        fuel: {
            type: 'fuel',
            unit: 'liters',
            sku: 'FUEL-DIESEL-001',
            name: 'Diesel High-Grade',
            amount: 1250,
            buffer: DEFAULT_BUFFER
        },
        ammunition: {
            sku: 'AMMO-9MM-NATO',
            name: '9mm Rounds',
            amount: 5000,
            type: 'ammunition',
            unit: 'bullets',
            buffer: DEFAULT_BUFFER
        },
        battery: {
            sku: 'BATT-LI-ION-XL',
            name: 'Lithium-Ion Cell',
            amount: 85,
            type: 'battery',
            unit: 'kWh',
            buffer: DEFAULT_BUFFER
        },

    },
};

export const personnelList: Personnel[] = [
    {
        id: "TECH-001",
        status: "idle"
    },
    {
        id: "TECH-002",
        status: "idle"
    },
    {
        id: "TECH-003",
        status: "idle"
    },
    {
        id: "TECH-004",
        status: "idle"
    },
    {
        id: "TECH-005",
        status: "idle"
    },
    {
        id: "TECH-006",
        status: "idle"
    },
    {
        id: "TECH-007",
        status: "idle"
    }
]