import { ResourceContext } from "@/providers/ResourceProvider";
import { useContext } from "react";
import { StyleSheet, View } from "react-native";
import ResourceBar from "./resource-bar";

export default function ResourceContainer() {
    const { resource } = useContext(ResourceContext);

    return (
        <View style={styles.container}>
            {Object.entries(resource).map(([key, value]) => (
                <ResourceBar
                    key={key}
                    resource={value}
                />
            ))}
        </View>
    )
}

const styles = StyleSheet.create({
    itemCard: {
        flex: 1,
        padding: 20,
        backgroundColor: 'lightgray',
        borderRadius: 20,
        marginVertical: 8,
        gap: 4
    },
    itemOrder: {
        flex: 1,
        padding: 20,
        borderRadius: 20,
        marginVertical: 8,
        gap: 8
    },
    mainContainer: {
        flex: 1,
        justifyContent: 'space-between'
    },
    centeredView: {
        flex: 1,
    },
    container: {
        padding: 20,
        gap: 20
    },
    buttonContainer: {
        width: '100%',
        height: 'auto',
        flexDirection: 'row',
        justifyContent: 'space-between',
        paddingHorizontal: 20,
        backgroundColor: 'rgba(0, 0, 0, 0)'
    },
    buttonStyle: {
        justifyContent: 'center',
        alignItems: 'center',
        height: 60,
        width: 60,
        borderRadius: '50%',
        textAlign: 'center',
        textAlignVertical: 'center',
        backgroundColor: 'lightblue'
    }
})