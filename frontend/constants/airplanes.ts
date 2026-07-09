import { Airplane } from "@/types/airplane";

export const hangar: Airplane[] = [
    {
        id: "F16-VIPER-01",
        fuel: {
            type: 'fuel',
            sku: 'JF-A1',
            name: 'Main Tank A1',
            amount: 450, // Needs a refill (min is 1000)
            unit: 'liters',
            buffer: { minReqAmount: 1000, optimalReqAmount: 1800, maxReqAmount: 2000 }
        },
        battery: {
            type: 'battery',
            sku: 'BT-X1',
            name: 'Avionics Battery',
            amount: 2,
            unit: 'kWh',
            buffer: { minReqAmount: 1, optimalReqAmount: 2, maxReqAmount: 2 }
        },
        ammunition: [
            {
                type: 'ammunition',
                sku: 'AIM-9',
                name: 'Sidewinder',
                amount: 2,
                unit: 'missiles',
                buffer: { minReqAmount: 2, optimalReqAmount: 4, maxReqAmount: 4 }
            }
        ]
    },
    {
        id: "F16-VIPER-02",
        fuel: {
            type: 'fuel',
            sku: 'JF-A1',
            name: 'Main Tank A1',
            amount: 1950, // Fully fueled
            unit: 'liters',
            buffer: { minReqAmount: 1000, optimalReqAmount: 1800, maxReqAmount: 2000 }
        },
        battery: {
            type: 'battery',
            sku: 'BT-X1',
            name: 'Avionics Battery',
            amount: 1, // Low battery
            unit: 'kWh',
            buffer: { minReqAmount: 1, optimalReqAmount: 2, maxReqAmount: 2 }
        },
        ammunition: [] // Completely unarmed
    },
    {
        id: "F16-VIPER-03",
        fuel: {
            type: 'fuel',
            sku: 'JF-A1',
            name: 'Main Tank A1',
            amount: 0, // Out of service
            unit: 'liters',
            buffer: { minReqAmount: 1000, optimalReqAmount: 1800, maxReqAmount: 2000 }
        },
        battery: {
            type: 'battery',
            sku: 'BT-X1',
            name: 'Avionics Battery',
            amount: 0,
            unit: 'kWh',
            buffer: { minReqAmount: 1, optimalReqAmount: 2, maxReqAmount: 2 }
        },
        ammunition: [
            {
                type: 'ammunition',
                sku: '20MM-VUL',
                name: 'Vulcan Cannon',
                amount: 511, // Maxed out
                unit: 'bullets',
                buffer: { minReqAmount: 200, optimalReqAmount: 500, maxReqAmount: 511 }
            }
        ]
    }
];