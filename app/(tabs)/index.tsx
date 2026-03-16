import MaintenanceOrderCreateModal from "@/components/maintenance/maintenance-order-create";
import MaintenanceOrderList from "@/components/maintenance/maintenance-order-list";
import MaintenanceOrderModal from "@/components/maintenance/maintenance-order-modal";
import ResourceContainer from "@/components/resources/resources";
import { BaseResources } from "@/constants/resources";
import { MaintenanceContext, MaintenanceDispatchContext } from "@/providers/MaintenanceProvider";
import { ResourceDispatchContext } from "@/providers/ResourceProvider";
import AntDesign from '@expo/vector-icons/AntDesign';
import { useContext } from "react";
import { Alert, Pressable, StyleSheet, Text, View } from "react-native";
import { SafeAreaView } from "react-native-safe-area-context";

export default function MaintenanceHome() {
    const { selectedOrder } = useContext(MaintenanceContext);
    const { openCreateModal } = useContext(MaintenanceDispatchContext)
    const setResources = useContext(ResourceDispatchContext);

    return (
        <SafeAreaView style={{ flex: 1 }}>
            <MaintenanceOrderCreateModal />
            {selectedOrder && <MaintenanceOrderModal order={selectedOrder} />}
            <View style={styles.mainContainer}>
                <ResourceContainer />
                <MaintenanceOrderList />
                <View style={styles.buttonContainer}>
                    <Pressable style={styles.buttonStyle}
                        onPress={() => {
                            Alert.alert('Refilled');
                            setResources(BaseResources);
                        }}
                    >
                        <Text style={{ fontSize: 20 }}>Refill</Text>
                    </Pressable>
                    <Pressable style={styles.buttonStyle}
                        onPress={openCreateModal}
                    >
                        <AntDesign name="plus" size={32} color="black" />
                    </Pressable>
                </View>
            </View>
        </SafeAreaView>
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