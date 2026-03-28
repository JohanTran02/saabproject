import { MaintenanceOrder } from "@/types/maintenance";
import Entypo from "@expo/vector-icons/Entypo";
import { useContext } from "react";
import { Modal, View, Pressable, Text, StyleSheet } from "react-native";
import PersonnelList from "../resources/personnel-list";
import RequiredResourceList from "../resources/required-resources";
import { MaintenanceContext, MaintenanceDispatchContext } from "@/providers/MaintenanceProvider";
import MaintenanceTaskList from "./maintenance-task-list";

export default function MaintenanceOrderModal({ order }: { order: MaintenanceOrder }) {
    const { orderModalVisible } = useContext(MaintenanceContext);
    const { closeOrderModal } = useContext(MaintenanceDispatchContext);

    return (
        <Modal
            animationType="slide"
            visible={orderModalVisible}
        >
            <View style={styles.centeredView}>
                <Pressable
                    onPress={closeOrderModal}
                >
                    <Entypo name="cross" size={64} color="black" />

                </Pressable>
                <View style={styles.itemOrder}>
                    <View style={{ flexDirection: 'row', justifyContent: 'space-between', alignItems: 'center' }}>
                        <Text style={{ fontSize: 20 }}>{order.id} ({order.status})</Text>
                        <Text>{order.createdAt}</Text>
                    </View>
                    <Text>Airplane: {order.airplaneId}</Text>
                    <Text>Task: {order.orderTitle}</Text>
                    <Text>Description: {order.description}</Text>
                    <Text>Started:{order.startedAt}</Text>
                    <Text>Updated:{order.updatedAt}</Text>
                    <Text>Deadline:{order.deadline}</Text>
                    <PersonnelList personnelIds={order.assignedPersonnelIds} />
                    <RequiredResourceList resources={order.reqTotalResources} />
                    <MaintenanceTaskList order={order} />
                </View>
            </View>
        </Modal>
    )
}

const styles = StyleSheet.create({
    itemCard: {
        flex: 1,
        padding: 20,
        backgroundColor: 'lightgray',
        borderRadius: 20,
        marginVertical: 8,
        gap: 4
    },
    itemOrder: {
        flex: 1,
        padding: 20,
        borderRadius: 20,
        marginVertical: 8,
        gap: 8
    },
    mainContainer: {
        flex: 1,
        justifyContent: 'space-between'
    },
    centeredView: {
        flex: 1,
    },
    container: {
        padding: 20,
        gap: 20
    },
    buttonContainer: {
        width: '100%',
        height: 'auto',
        flexDirection: 'row',
        justifyContent: 'space-between',
        paddingHorizontal: 20,
        backgroundColor: 'rgba(0, 0, 0, 0)'
    },
    buttonStyle: {
        justifyContent: 'center',
        alignItems: 'center',
        height: 60,
        width: 60,
        borderRadius: '50%',
        textAlign: 'center',
        textAlignVertical: 'center',
        backgroundColor: 'lightblue'
    }
})