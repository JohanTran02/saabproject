import { MaintenanceContext } from "@/providers/MaintenanceProvider";
import { useContext } from "react";
import { Modal } from "react-native";
import MaintenanceOrderCreateForm from "./maintenance-create-form";


export default function MaintenanceOrderCreateModal() {
    const { createModalVisible } = useContext(MaintenanceContext);

    return (
        <Modal
            animationType="slide"
            visible={createModalVisible}
        >
            <MaintenanceOrderCreateForm />
        </Modal>
    )
}