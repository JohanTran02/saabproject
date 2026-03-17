import { View, TextInput, Button, Pressable } from "react-native"
import { useForm, Controller, SubmitHandler } from "react-hook-form"
import { Resource } from "@/types/resources"
import { maintenanceTypesList } from "@/constants/maintenance"
import { MaintenanceDispatchContext } from "@/providers/MaintenanceProvider"
import Entypo from "@expo/vector-icons/Entypo"
import React, { useContext } from "react"
import MaintenanceDatePicker from "../date-picker"
import RNPickerSelect from 'react-native-picker-select';
import { hangar } from "@/constants/airplanes"
import { MaintenanceType } from "@/types/maintenance"

type MaintenanceFormData = {
    resource: Resource,
    amount: string,
    maintenanceType: { label: MaintenanceType; value: MaintenanceType }
    airplaneId: string,
    date: Date,
}

const placeholderResource = {
    label: 'Select resource...',
    value: null
}

const placeholderMaintenance = {
    label: 'Select maintenance...',
    value: null
}

const placeholderAirplanes = {
    label: 'Select airplane...',
    value: null
}

const tempAirplanes = hangar.map((airplane) => {
    return (
        {
            label: airplane.id,
            value: airplane.id
        }
    )
})

export default function MaintenanceOrderCreateForm() {
    const {
        control,
        handleSubmit,
    } = useForm<MaintenanceFormData>({
        defaultValues: {
            resource: {},
            amount: '',
            maintenanceType: {},
            date: new Date(),
        }
    });
    const { closeCreateModal } = useContext(MaintenanceDispatchContext);
    const onSubmit: SubmitHandler<MaintenanceFormData> = (data) => console.log(data)

    return (
        <View style={{ flex: 1 }}>
            <Pressable
                onPress={closeCreateModal}
            >
                <Entypo name="cross" size={64} color="black" />
            </Pressable>
            <Controller
                control={control}
                render={({ field: { onChange, value } }) => (
                    <RNPickerSelect
                        value={value}
                        onValueChange={onChange}
                        items={[
                            { label: 'Battery', value: 'battery' },
                            { label: 'Fuel', value: 'fuel' },
                            { label: 'Ammunition', value: 'ammunition' },
                        ]}
                        placeholder={placeholderResource}
                    />
                )}
                name="resource"
            />
            <Controller
                control={control}
                render={({ field: { onChange, value } }) => (
                    <TextInput
                        onChangeText={onChange}
                        value={value}
                        placeholder="Amount"
                        keyboardType="numeric"
                    />
                )}
                name='amount'
            />
            <Controller
                control={control}
                render={({ field: { onChange, value } }) => (
                    <RNPickerSelect
                        onValueChange={onChange}
                        value={value}
                        items={maintenanceTypesList}
                        placeholder={placeholderMaintenance}
                    />
                )}
                name='maintenanceType'
            />
            <Controller
                control={control}
                render={({ field: { onChange, value } }) => (
                    <RNPickerSelect
                        onValueChange={onChange}
                        value={value}
                        items={tempAirplanes}
                        placeholder={placeholderAirplanes}
                    />
                )}
                name='airplaneId'
            />
            <Controller
                control={control}
                render={({ field: { onChange, value } }) => (
                    <MaintenanceDatePicker onChange={onChange} value={value} />
                )}
                name='date'
            />

            <View style={{ width: "50%", marginHorizontal: 'auto' }}>
                <Button title="Submit" onPress={handleSubmit(onSubmit)}
                />
            </View>
        </View>
    )
}