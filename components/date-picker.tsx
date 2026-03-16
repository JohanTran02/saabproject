import DateTimePicker, { DateTimePickerEvent } from '@react-native-community/datetimepicker';
import React, { useState } from "react";
import { Pressable, Text, View } from "react-native";

export default function MaintenanceDatePicker() {
    const [date, setDate] = useState<Date>(new Date());
    const [mode, setMode] = useState<'date' | 'time'>('time');
    const [show, setShow] = useState(false);

    const onChange = (event: DateTimePickerEvent, selectedDate: Date) => {
        const currentDate = selectedDate;
        setShow(false);
        setDate(currentDate);
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
        <>
            <Text>Pick date and time</Text>
            <View style={{ flexDirection: 'row', gap: 15, padding: 10 }}>
                <Pressable onPress={showDatepicker}><Text>Date</Text></Pressable>
                <Pressable onPress={showTimepicker}><Text>Time</Text></Pressable>
            </View>
            <Text>selected: {date.toLocaleString()}</Text>
            {show && (
                <DateTimePicker
                    testID="dateTimePicker"
                    value={date}
                    mode={mode}
                    is24Hour={true}
                    onChange={() => onChange}
                />
            )}
        </>
    )
}