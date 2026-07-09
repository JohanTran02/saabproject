import { MaintenanceContext } from "@/providers/MaintenanceProvider";
import { useContext } from "react";
import { View, FlatList } from "react-native";
import MaintenanceSite from "./maintenance-site";

export default function MaintenanceSitesList() {

    const { sites } = useContext(MaintenanceContext);
    return (
        <View style={{ flex: 1, paddingHorizontal: 20 }}>
            <FlatList
                style={{ flex: 1 }}
                contentContainerStyle={{ gap: 10 }}
                columnWrapperStyle={{ gap: 10 }}
                data={sites}
                numColumns={2}
                renderItem={({ item }) => <MaintenanceSite site={item} />}
                keyExtractor={(item) => item.id}
            />
        </View>
    )
}