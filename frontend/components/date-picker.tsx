import DateTimePicker, { DateTimePickerEvent } from '@react-native-community/datetimepicker';
import React, { useState } from "react";
import { Platform, Pressable, Text, View } from "react-native";

type Props = {
    onChange: (date: Date) => void;
    value: Date;
}

export default function MaintenanceDatePicker({ onChange, value }: Props) {
    const [mode, setMode] = useState<'date' | 'time'>('time');
    const [show, setShow] = useState(false);

    // This handles the internal Picker logic and updates the Form state
    const onPickerChange = (event: DateTimePickerEvent, selectedDate?: Date) => {
        // Android closes on selection, iOS usually stays open in a modal
        if (Platform.OS === 'android') {
            setShow(false);
        }

        if (selectedDate) {
            onChange(selectedDate); // Sends the Date object back to React Hook Form
        }
    };

    const showMode = (currentMode: 'time' | 'date') => {
        setShow(true);
        setMode(currentMode);
    };

    const showDatepicker = () => {
        showMode('date');
    };

    const showTimepicker = () => {
        showMode('time');
    };

    return (
        <View>
            <Text>Pick date and time</Text>
            {
                <View>
                    <View style={{ flexDirection: 'row', gap: 15, padding: 10 }}>
                        <Pressable onPress={showDatepicker}>
                            <Text>{value.toLocaleDateString()}</Text>
                        </Pressable>

                        <Pressable onPress={showTimepicker}>
                            <Text>{value.toLocaleTimeString()}</Text>
                        </Pressable>
                    </View>

                    {show && (
                        <DateTimePicker
                            testID="dateTimePicker"
                            value={value || new Date()}
                            mode={mode}
                            is24Hour={true}
                            onChange={onPickerChange}
                        />

                    )}
                </View>
            }
        </View>
    )
}