import { Text, View } from "react-native";
import MaintenanceTaskButton from "./maintenance-task-button";

export default function MaintenanceTaskPage() {
    return (
        <View style={{ flex: 1, justifyContent: 'space-between', alignItems: 'center', flexDirection: 'row', marginHorizontal: 80 }}>
            <View>
                <Text>Task requirement</Text>
            </View>
            <View style={{ height: 200, width: 200 }}>
                <MaintenanceTaskButton />
            </View>
        </View>
    )
}