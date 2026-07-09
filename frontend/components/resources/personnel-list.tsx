import { FlatList, Text, View } from "react-native";

export default function PersonnelList({ personnelIds }: { personnelIds: string[] }) {
    return (
        <View style={{ flex: 1 }}>
            <Text>Assigned</Text>
            <FlatList
                data={personnelIds}
                renderItem={({ item }) => <Text>{item}</Text>}
                keyExtractor={item => item}
            />
        </View>
    )
}