import { maintenanceOrders } from "@/constants/maintenance";
import { MaintenanceOrder } from "@/types/maintenance";
import { createContext, Dispatch, ReactNode, SetStateAction, useCallback, useState } from "react";

type Context = {
    maintenance: MaintenanceOrder[],
    selectedOrder: MaintenanceOrder | null,
    createModalVisible: boolean,
    orderModalVisible: boolean
}

type DispatchContext = {
    setMaintenance: Dispatch<SetStateAction<MaintenanceOrder[]>>,
    setSelectedOrder: Dispatch<SetStateAction<MaintenanceOrder | null>>,
    openCreateModal: () => void,
    closeCreateModal: () => void,
    closeOrderModal: () => void,
    openOrderModal: () => void,
}


export const MaintenanceContext = createContext<Context>({} as Context);
export const MaintenanceDispatchContext = createContext<DispatchContext>({} as DispatchContext);

export function MaintenanceProvider({ children }: { children: ReactNode }) {
    const [maintenance, setMaintenance] = useState<MaintenanceOrder[]>(maintenanceOrders);
    const [selectedOrder, setSelectedOrder] = useState<MaintenanceOrder | null>(null);
    const [createModalVisible, setCreateModalVisible] = useState<boolean>(false);
    const [orderModalVisible, setOrderModalVisible] = useState<boolean>(false);

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
        <MaintenanceContext value={{ maintenance, selectedOrder, createModalVisible, orderModalVisible }}>
            <MaintenanceDispatchContext value={{ setSelectedOrder, setMaintenance, openCreateModal, closeCreateModal, openOrderModal, closeOrderModal }}>
                {children}
            </MaintenanceDispatchContext>
        </MaintenanceContext>
    )
}