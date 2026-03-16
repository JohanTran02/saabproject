import { MaintenanceContext } from "@/providers/MaintenanceProvider";
import { useContext } from "react";
import MaintenanceOrderItem from "./maintenance-order-item";
import { FlatList } from "react-native";


export default function MaintenanceOrderList() {
    const { maintenance } = useContext(MaintenanceContext);

    return (
        <FlatList
            data={maintenance}
            renderItem={({ item }) => <MaintenanceOrderItem order={item} />}
            keyExtractor={item => item.id}
        />
    )
}