import { MaintenanceOrder } from "@/types/maintenance";
import { FlatList } from "react-native";
import MaintenanceTaskItem from "./maintenance-task-item";

export default function MaintenanceTaskList({ order }: { order: MaintenanceOrder }) {
    return (
        <FlatList
            data={order.maintenanceTasks}
            renderItem={({ item }) => <MaintenanceTaskItem task={item} />}
            keyExtractor={item => item.id}
        />
    )
}