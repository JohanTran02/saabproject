import { BaseResources } from "@/constants/resources";
import { Resource } from "@/types/resources";
import { Text, View } from "react-native";

export default function ResourceBar<T extends Resource>({ resource }: { resource: T }) {
    const width = (resource: Resource) => {
        const currentResource = BaseResources.find((baseResource) => baseResource.sku === resource.sku);
        if (!currentResource) return 0;

        return resource.amount / currentResource.amount * 100;
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