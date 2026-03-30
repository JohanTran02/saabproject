import { MaintenanceContext, MaintenanceDispatchContext } from "@/providers/MaintenanceProvider";
import { MaintenanceSite } from "@/types/maintenance";
import { useContext } from "react";
import { Pressable, View, Text } from "react-native";

export default function MaintenanceSiteItem({ site }: { site: MaintenanceSite }) {
    const { openOrderModal, setSelectedOrder } = useContext(MaintenanceDispatchContext);
    const { maintenance } = useContext(MaintenanceContext)

    return (
        <Pressable
            style={{ backgroundColor: 'lightgray', flex: 1 }}
            onPress={() => {
                const maintenanceOrder = maintenance.find((maintenance) => maintenance.id === site.maintenanceOrderId);
                if (!maintenanceOrder) return;

                openOrderModal();
                setSelectedOrder(maintenanceOrder);
            }}
        >
            <View style={{ height: 200 }}>
                <Text>{site.id}</Text>
                <Text>{site.status}</Text>
                <Text>{site.maintenanceOrderId}</Text>
                <Text>{site.maintenanceTaskId}</Text>
            </View>
        </Pressable>
    )
}