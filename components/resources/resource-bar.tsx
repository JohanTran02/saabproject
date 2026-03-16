import { Resource } from "@/types/resources";
import { Text, View } from "react-native";

export default function ResourceBar({ resource }: { resource: Resource }) {
    const width = (type: Resource) => {
        if (resource.type === "fuel") {
            return resource.amount / 1250 * 100
        }
        else if (resource.type === "battery") {
            return resource.amount / 85 * 100
        }
        else if (resource.type === "ammunition") {
            return resource.amount / 5000 * 100
        }
        return 100;
    }

    const unit = resource.unit ? resource.unit : ''
    return (
        <View >
            <Text style={{ fontSize: 20 }}>{resource.name}</Text>
            <View style={{ borderRadius: 10, height: 20, backgroundColor: 'green', width: `${Math.min(width(resource), 100)}%` }}></View>
            <Text style={{ fontSize: 16 }}>{resource.amount} {unit}</Text>
        </View>
    )
}