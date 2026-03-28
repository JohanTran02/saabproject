import { MaintenanceTask } from "@/types/maintenance"
import { View, Text, StyleSheet } from "react-native"
import RequiredResourceList from "../resources/required-resources"

export default function MaintenanceTaskItem({ task }: { task: MaintenanceTask }) {
    return (
        <View style={styles.itemCard}>
            <Text>{task.id}</Text>
            <Text>{task.taskType}</Text>
            <Text>CreatedAt:{task.createdAt}</Text>
            <Text>Started:{task.startedAt}</Text>
            <Text>Updated:{task.updatedAt}</Text>
            <Text>Description: {task.description}</Text>
            <Text>Expected maintenance Duration: {task.maintenanceDuration}</Text>
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