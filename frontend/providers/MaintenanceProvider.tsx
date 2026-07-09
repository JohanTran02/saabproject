import { maintenanceOrders, maintenanceSites } from "@/constants/maintenance";
import { MaintenanceOrder, MaintenanceSite } from "@/types/maintenance";
import { createMaintenanceOrder } from "@/utils/maintenance";
import { createContext, Dispatch, ReactNode, SetStateAction, useCallback, useContext, useState } from "react";
import { ResourceDispatchContext } from "./ResourceProvider";

type Context = {
    maintenance: MaintenanceOrder[],
    sites: MaintenanceSite[],
    selectedOrder: MaintenanceOrder | null,
    createModalVisible: boolean,
    orderModalVisible: boolean
}

type DispatchContext = {
    setMaintenance: Dispatch<SetStateAction<MaintenanceOrder[]>>,
    setSites: Dispatch<SetStateAction<MaintenanceSite[]>>,
    setSelectedOrder: Dispatch<SetStateAction<MaintenanceOrder | null>>,
    assignMaintenanceSite: () => void,
    openCreateModal: () => void,
    closeCreateModal: () => void,
    closeOrderModal: () => void,
    openOrderModal: () => void,
}

export const MaintenanceContext = createContext<Context>({} as Context);
export const MaintenanceDispatchContext = createContext<DispatchContext>({} as DispatchContext);

export function MaintenanceProvider({ children }: { children: ReactNode }) {
    const { assignPersonnel } = useContext(ResourceDispatchContext);
    const [maintenance, setMaintenance] = useState<MaintenanceOrder[]>(maintenanceOrders);
    const [sites, setSites] = useState<MaintenanceSite[]>(maintenanceSites);
    const [selectedOrder, setSelectedOrder] = useState<MaintenanceOrder | null>(null);
    const [createModalVisible, setCreateModalVisible] = useState<boolean>(false);
    const [orderModalVisible, setOrderModalVisible] = useState<boolean>(false);

    const assignMaintenanceSite = useCallback(() => {
        const technicians = assignPersonnel();
        const maintenanceOrder = createMaintenanceOrder(technicians);

        setMaintenance([...maintenance, maintenanceOrder]);

        const idleSite = sites.find((site) => site.status === 'idle');

        if (!idleSite) return;

        setSites(prev => prev.map((site) => {
            if (site.id === idleSite.id) {
                return {
                    ...site,
                    status: 'in_progress',
                    maintenanceOrderId: maintenanceOrder.id,
                    assignedPersonnelIds: maintenanceOrder.assignedPersonnelIds
                }
            } else {
                return site;
            }
        }))
    }, [maintenance, sites, assignPersonnel])

    const openCreateModal = useCallback(() => {
        setCreateModalVisible(true);
    }, []);

    const closeCreateModal = useCallback(() => {
        setCreateModalVisible(false);
    }, []);

    const openOrderModal = useCallback(() => {
        setOrderModalVisible(true);
    }, []);

    const closeOrderModal = useCallback(() => {
        setOrderModalVisible(false);
    }, []);


    return (
        <MaintenanceContext value={{ sites, maintenance, selectedOrder, createModalVisible, orderModalVisible }}>
            <MaintenanceDispatchContext value={{ assignMaintenanceSite, setSites, setSelectedOrder, setMaintenance, openCreateModal, closeCreateModal, openOrderModal, closeOrderModal }}>
                {children}
            </MaintenanceDispatchContext>
        </MaintenanceContext>
    )
}