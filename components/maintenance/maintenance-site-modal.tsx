import { MaintenanceOrder } from "@/types/maintenance";
import Entypo from "@expo/vector-icons/Entypo";
import { useContext } from "react";
import { Modal, View, Pressable, Text, StyleSheet } from "react-native";
import PersonnelList from "../resources/personnel-list";
import { MaintenanceContext, MaintenanceDispatchContext } from "@/providers/MaintenanceProvider";
import MaintenanceTaskList from "./maintenance-task-list";

export default function MaintenanceSiteModal({ order }: { order: MaintenanceOrder }) {
    const { orderModalVisible } = useContext(MaintenanceContext);
    const { closeOrderModal } = useContext(MaintenanceDispatchContext);

    return (
        <Modal
            animationType="slide"
            visible={orderModalVisible}
        >
            <View style={{ flex: 1 }}>
                <Pressable
                    onPress={closeOrderModal}
                >
                    <Entypo name="cross" size={64} color="black" />

                </Pressable>
                <View style={styles.itemOrder}>
                    <View style={{ flexDirection: 'row', justifyContent: 'space-between', alignItems: 'center' }}>
                        <Text style={{ fontSize: 20 }}>{order.id} ({order.status})</Text>
                        <Text>{new Date(order.createdAt).toLocaleString()}</Text>
                    </View>
                    <View style={{ flexDirection: 'row' }}>
                        <PersonnelList personnelIds={order.assignedPersonnelIds} />
                        <View>
                            <Text>Airplane</Text>
                            <Text>{order.airplaneId}</Text>
                        </View>
                    </View>
                    <MaintenanceTaskList tasks={order.maintenanceTasks} />
                </View>
            </View>
        </Modal>
    )
}

const styles = StyleSheet.create({
    itemOrder: {
        flex: 1,
        padding: 20,
        borderRadius: 20,
        marginVertical: 8,
        gap: 8
    },
})