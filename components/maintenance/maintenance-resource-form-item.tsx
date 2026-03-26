import { View } from "react-native";
import MaintenanceCheckbox from "./maintenance-checkbox";
import { Resource } from "@/types/resources";
import MaintenanceFormField from "./maintenance-formfield";

export default function MaintenanceResourceFormItem({ resource, index }: {
    resource: Resource,
    index: number,
}) {
    return (
        <View style={{ flexDirection: 'row', alignItems: 'center', justifyContent: 'space-between' }}>
            <View style={{}}>
                <MaintenanceFormField label={resource.name} value={`${resource.amount} ${resource.unit}`} />
            </View>
            <MaintenanceCheckbox name={`resources.${index}.resourceUsed`} />
        </View>
    )
}