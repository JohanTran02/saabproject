import { MaintenanceProvider } from '@/providers/MaintenanceProvider';
import { ResourceProvider } from '@/providers/ResourceProvider';
import FontAwesome from '@expo/vector-icons/FontAwesome';
import { Tabs } from "expo-router";

export default function TabLayout() {

    return (
        <ResourceProvider>
            <MaintenanceProvider>
                <Tabs
                    screenOptions={{ headerShown: false }}>
                    <Tabs.Screen
                        name="index"
                        options={{
                            title: 'Home',
                            tabBarIcon: () => <FontAwesome size={28} name="home" />,
                        }}
                    />
                    <Tabs.Screen
                        name="tasks"
                        options={{
                            title: 'Maintenance Tasks',
                            tabBarIcon: () => <FontAwesome size={28} name="tachometer" />,
                        }}
                    />
                </Tabs>
            </MaintenanceProvider>
        </ResourceProvider>
    );
}
