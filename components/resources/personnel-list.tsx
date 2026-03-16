import { FlatList, Text, View } from "react-native";

export default function PersonnelList({ personnelIds }: { personnelIds: string[] }) {
    return (
        <View>
            <Text>Assigned personnel:</Text>
            <FlatList
                data={personnelIds}
                renderItem={({ item }) => <Text>{item}</Text>}
                keyExtractor={item => item}
            />
        </View>
    )
}