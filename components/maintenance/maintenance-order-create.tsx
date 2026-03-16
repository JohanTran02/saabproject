import { maintenanceTypesList } from "@/constants/maintenance";
import { MaintenanceContext, MaintenanceDispatchContext } from "@/providers/MaintenanceProvider";
import Entypo from "@expo/vector-icons/Entypo";
import { useContext } from "react";
import { Modal, Pressable, Text, View } from "react-native";
import RNPickerSelect from 'react-native-picker-select';


export default function MaintenanceOrderCreateModal() {
    const { createModalVisible } = useContext(MaintenanceContext);
    const { closeCreateModal } = useContext(MaintenanceDispatchContext);

    return (
        <Modal
            animationType="slide"
            visible={createModalVisible}
        >
            <View style={{ flex: 1 }}>
                <Pressable
                    onPress={closeCreateModal}
                >
                    <Entypo name="cross" size={64} color="black" />
                </Pressable>
                <View>
                    <Text style={{ fontSize: 20 }}>Type</Text>
                    <RNPickerSelect
                        onValueChange={(value) => console.log(value)}
                        items={[
                            { label: 'Battery', value: 'battery' },
                            { label: 'Fuel', value: 'fuel' },
                            { label: 'Ammunition', value: 'ammunition' },
                        ]}
                    />
                    <RNPickerSelect
                        onValueChange={(value) => console.log(value)}
                        items={maintenanceTypesList}
                    />
                </View>
            </View>
        </Modal>
    )
}