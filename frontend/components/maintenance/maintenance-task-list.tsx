import { MaintenanceTask } from "@/types/maintenance";
import { FlatList, View } from "react-native";
import MaintenanceTaskItem from "./maintenance-task-item";

export default function MaintenanceTaskList({ tasks }: { tasks: MaintenanceTask[] }) {
    return (
        <View style={{ flex: 1 }}>
            <FlatList
                data={tasks}
                renderItem={({ item }) => <MaintenanceTaskItem task={item} />}
                keyExtractor={item => item.id}
            />
        </View>

    )
}