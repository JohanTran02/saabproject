import MaintenanceOrderCreateModal from "@/components/maintenance/maintenance-create-modal";
import MaintenanceSiteModal from "@/components/maintenance/maintenance-site-modal";
import MaintenanceSitesList from "@/components/maintenance/maintenance-sites";
import ResourceContainer from "@/components/resources/resources";
import { MaintenanceContext } from "@/providers/MaintenanceProvider";
import { useContext } from "react";
import { View } from "react-native";
import { SafeAreaView } from "react-native-safe-area-context";

export default function MaintenanceHome() {
    const { selectedOrder } = useContext(MaintenanceContext);

    return (
        <SafeAreaView style={{ flex: 1, height: '100%' }}>
            <MaintenanceOrderCreateModal />
            {selectedOrder && <MaintenanceSiteModal order={selectedOrder} />}
            <View style={{ flex: 1 }}>
                <ResourceContainer />
                <MaintenanceSitesList />
            </View>
        </SafeAreaView>
    )
}