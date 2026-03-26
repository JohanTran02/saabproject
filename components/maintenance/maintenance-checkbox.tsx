import { Checkbox } from 'expo-checkbox';
import { FieldValues, UseControllerProps, useController } from 'react-hook-form';

export default function MaintenanceCheckbox<T extends FieldValues>({ name, ...controllerProps }: UseControllerProps<T>) {
    const { field: { onChange, value } } = useController({ name, ...controllerProps });

    return (
        <Checkbox
            value={value as boolean}
            onValueChange={onChange}
            color={value ? '#4630EB' : undefined}
        />
    )
}