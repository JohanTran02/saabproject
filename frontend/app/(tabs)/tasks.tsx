import MaintenanceTaskPage from "@/components/maintenance/maintenance-task";
import { SafeAreaView } from "react-native-safe-area-context";

export default function MaintenanceTasks() {

    return (
        <SafeAreaView style={{ flex: 1 }}>
            <MaintenanceTaskPage />
        </SafeAreaView>
    )
}