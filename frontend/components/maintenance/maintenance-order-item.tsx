import { View, Pressable, Text, StyleSheet } from "react-native";
import { MaintenanceOrder } from "@/types/maintenance";
import { useContext } from "react";
import { MaintenanceDispatchContext } from "@/providers/MaintenanceProvider";

export default function MaintenanceOrderItem({ order }: { order: MaintenanceOrder }) {
    const { openOrderModal, setSelectedOrder } = useContext(MaintenanceDispatchContext);
    return (
        <View style={styles.itemCard}>
            <Pressable onPress={() => {
                openOrderModal();
                setSelectedOrder(order);
            }}>
                <View style={{ flexDirection: 'row', justifyContent: 'space-between', alignItems: 'center' }}>
                    <Text style={{ fontSize: 20 }}>{order.id} ({order.status})</Text>
                    <Text>{order.startedAt}</Text>
                </View>
                <Text>{order.airplaneId}</Text>
                <Text>{order.orderTitle}</Text>
                <Text>{order.description}</Text>
            </Pressable>
        </View>
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
})