import { Pressable, Text, View } from "react-native";
import AntDesign from '@expo/vector-icons/AntDesign';
import { FieldValues, useController, UseControllerProps } from "react-hook-form";

export default function MaintenanceDurationInput<T extends FieldValues>({ name, ...controllerProps }: UseControllerProps<T>) {
    const { field: { onChange, value } } = useController({ name, ...controllerProps });

    const adjustValue = (amount: number) => {
        const currentValue = parseInt(value as string || "0", 10);
        const newValue = Math.max(0, currentValue + amount);
        onChange(newValue.toString());
    };

    return (
        <View style={{ alignItems: 'center', flexDirection: 'row', gap: 10 }}>
            <Pressable
                onPress={() => adjustValue(-1)}
            >
                <AntDesign name="minus" size={30} color="black" />
            </Pressable>
            <Text style={{ fontSize: 30 }}>{value}</Text>
            <Pressable
                onPress={() => adjustValue(1)}
            >
                <AntDesign name="plus" size={30} color="black" />
            </Pressable>
        </View >
    )
}