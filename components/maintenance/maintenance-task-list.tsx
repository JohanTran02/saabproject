import { MaintenanceOrder } from "@/types/maintenance";
import { FlatList, View, Text, StyleSheet } from "react-native";
import RequiredResourceList from "../resources/required-resources";

export default function MaintenanceTaskList({ order }: { order: MaintenanceOrder }) {
    return (
        <FlatList
            data={order.maintenanceTasks}
            renderItem={({ item }) =>
                <View style={styles.itemCard}>
                    <Text>{item.id}</Text>
                    <Text>{item.taskName}</Text>
                    <Text>CreatedAt:{order.createdAt}</Text>
                    <Text>Started:{order.startedAt}</Text>
                    <Text>Updated:{order.updatedAt}</Text>
                    <Text>Description: {item.description}</Text>
                    <Text>Maintenance Duration: {item.maintenanceDuration}</Text>
                    <RequiredResourceList resources={item.reqResources} />
                </View>
            }
            keyExtractor={item => item.id}
        />
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