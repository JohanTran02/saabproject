import { Text, View } from "react-native";

export default function MaintenanceFormField({ label, value }: { label: string, value: string }) {
    return (
        <View>
            <Text style={{ fontSize: 20 }}>{label}</Text>
            <Text style={{ fontSize: 16 }}>{value}</Text>
        </View>
    )
}