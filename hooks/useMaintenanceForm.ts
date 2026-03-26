import { MaintenanceFormData } from "@/components/maintenance/maintenance-task-form";
import { useFormContext } from "react-hook-form";

export const useMaintenanceFormContext = () => {
    return useFormContext<MaintenanceFormData>();
};