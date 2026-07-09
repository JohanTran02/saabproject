import { FlatList, Text, View } from "react-native";
import MaintenanceResourceFormItem from "./maintenance-resource-form-item";
import { useFieldArray } from "react-hook-form";
import { useMaintenanceFormContext } from "@/hooks/useMaintenanceForm";

export default function MaintenanceResourceFormList() {
    const { control } = useMaintenanceFormContext();

    const { fields } = useFieldArray({
        name: 'resources',
        control
    })

    return (
        <View style={{ flex: 1, }}>
            <Text style={{ fontSize: 24 }}>Resources used</Text>
            <FlatList
                data={fields}
                renderItem={({ item, index }) => <MaintenanceResourceFormItem {...item} index={index} />}
                keyExtractor={(resource) => resource.id}
            />
        </View>
    )
}