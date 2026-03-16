import { Resource } from "@/types/resources";
import { FlatList, Text, View } from "react-native";

export default function RequiredResourceList({ resources }: { resources: Resource[] }) {
    return (
        <View>
            <Text>Required resources:</Text>
            <FlatList
                data={resources}
                renderItem={({ item }) =>
                    <View>
                        <Text>{item.name}</Text>
                        <Text>Amount: {item.amount} {item.unit}</Text>
                    </View>
                }
                keyExtractor={task => task.sku}
            />
        </View>
    )
}