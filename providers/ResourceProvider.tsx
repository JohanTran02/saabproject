import { BaseResources, personnelList } from "@/constants/resources";
import { BaseResource, Personnel } from "@/types/resources";
import { createContext, Dispatch, ReactNode, SetStateAction, useCallback, useState } from "react";

type Context = {
    resource: BaseResource,
    personnel: Personnel[]
}

type DispatchContext = {
    setResource: Dispatch<SetStateAction<BaseResource>>,
    setPersonnel: Dispatch<SetStateAction<Personnel[]>>,
    assignPersonnel: () => string[],
}

export const ResourceContext = createContext<Context>({
    resource: BaseResources,
    personnel: personnelList
});

export const ResourceDispatchContext = createContext<DispatchContext>({} as DispatchContext);

export function ResourceProvider({ children }: { children: ReactNode }) {
    const [resource, setResource] = useState<BaseResource>(BaseResources);
    const [personnel, setPersonnel] = useState<Personnel[]>(personnelList);

    const assignPersonnel = useCallback(() => {
        const technicianIds = personnel
            .filter((technician) => technician.status === 'idle')
            .slice(0, 2)
            .map(technician => technician.id);

        setPersonnel((prev =>
            prev.map(technician =>
                technicianIds.includes(technician.id)
                    ? { ...technician, status: 'active' }
                    : technician)
        ));

        return technicianIds;
    }, [personnel])

    return (
        <ResourceContext value={{ resource, personnel }}>
            <ResourceDispatchContext value={{ setResource, setPersonnel, assignPersonnel }}>
                {children}
            </ResourceDispatchContext>
        </ResourceContext>
    )
}