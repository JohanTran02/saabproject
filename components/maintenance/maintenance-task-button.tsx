import { SubmitHandler } from "react-hook-form"
import { View, Pressable, Text } from "react-native"
import { MaintenanceFormData } from "./maintenance-task-form"
import { useMaintenanceFormContext } from "@/hooks/useMaintenanceForm"

export default function MaintenanceTaskButton() {
    const { handleSubmit } = useMaintenanceFormContext();
    const onSubmit: SubmitHandler<MaintenanceFormData> = (data) => console.log(data)

    return (
        <View >
            <Pressable
                onPress={handleSubmit(onSubmit)}
                style={{ backgroundColor: 'lightblue', padding: 8, borderRadius: 10 }}
            >
                <Text style={{ fontSize: 20, textAlign: "center" }}>Submit</Text>
            </Pressable>
        </View>
    )
}