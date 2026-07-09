import { View, Text, } from "react-native";
import { FormProvider, useForm } from "react-hook-form";
import MaintenanceDurationInput from "./maintenance-durationbox";
import { Resource } from "@/types/resources";
import MaintenanceResourceFormList from "./maintenance-resource-form-list";
import MaintenanceTaskButton from "./maintenance-task-button";
import MaintenanceFormField from "./maintenance-formfield";

export type MaintenanceFormData = {
    maintenanceEstimatedDuration: string,
    resources: {
        resource: Resource,
        resourceUsed: boolean
    }[]
}

export default function MaintenanceTaskForm() {
    const methods = useForm<MaintenanceFormData>({
        defaultValues: {
            maintenanceEstimatedDuration: '0',
            resources: [{
                resource: {
                    type: 'ammunition', sku: 'AIM-120', name: 'AMRAAM', amount: 4, unit: 'missiles',
                    buffer: { minReqAmount: 2, optimalReqAmount: 4, maxReqAmount: 4 },
                },
                resourceUsed: false
            },
            {
                resource: {
                    type: 'ammunition', sku: '20MM-VUL', name: 'Vulcan Rounds', amount: 500, unit: 'bullets',
                    buffer: { minReqAmount: 200, optimalReqAmount: 500, maxReqAmount: 511 }
                },
                resourceUsed: false
            }]
        }
    });

    return (
        <FormProvider {...methods}>
            <View style={{ flex: 1, paddingHorizontal: 20, gap: 10 }}>
                <View>
                    <View style={{ flexDirection: "row", gap: 10 }}>
                        <View style={{ gap: 10 }}>
                            <MaintenanceFormField label="Airplane" value="Airplane 1" />
                            <MaintenanceFormField label="Site" value="Maintenance Site 1" />
                            <MaintenanceFormField label="Type" value="Maintenance Type 1" />
                            <MaintenanceFormField label="Estimated Duration" value="25-03-2026" />
                        </View>
                        <View style={{ flex: 1 }}>
                            <Text style={{ fontSize: 24 }}>Description</Text>
                            <Text style={{ flex: 1, fontSize: 16 }}>
                                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus et tempor erat. Fusce porta vel massa id posuere.
                            </Text>
                        </View>
                    </View>
                </View>
                <MaintenanceResourceFormList />
                <View style={{ marginHorizontal: "auto", paddingBottom: 20 }}>
                    <MaintenanceDurationInput name='maintenanceEstimatedDuration' />
                </View>
                <MaintenanceTaskButton />
            </View>
        </FormProvider>
    )
}