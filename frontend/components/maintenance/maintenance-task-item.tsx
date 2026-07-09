import { MaintenanceTask } from "@/types/maintenance"
import { View, Text, StyleSheet } from "react-native"
import RequiredResourceList from "../resources/required-resources"

export default function MaintenanceTaskItem({ task }: { task: MaintenanceTask }) {
    const startDate = task.startedAt ? task.startedAt : 'No date';
    return (
        <View style={styles.itemCard}>
            <Text>{task.id}</Text>
            <Text>{task.taskType}</Text>
            <Text>Started: {startDate}</Text>
            <Text>Description: {task.description}</Text>
            <Text>Expected maintenance completion: {task.maintenanceDuration}</Text>
            <RequiredResourceList resources={task.reqResources} />
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
    }
})