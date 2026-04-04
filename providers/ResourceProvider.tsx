import { BaseResources, personnelList } from "@/constants/resources";
import { Personnel, Resource } from "@/types/resources";
import { createContext, Dispatch, ReactNode, SetStateAction, useCallback, useState } from "react";

type Context = {
    resource: Resource[],
    personnel: Personnel[]
}

type DispatchContext = {
    setResource: Dispatch<SetStateAction<Resource[]>>,
    updateResource: (resource: Resource) => void
    setPersonnel: Dispatch<SetStateAction<Personnel[]>>,
    assignPersonnel: () => string[],
}

export const ResourceContext = createContext<Context>({
    resource: BaseResources,
    personnel: personnelList
});

export const ResourceDispatchContext = createContext<DispatchContext>({} as DispatchContext);

export function ResourceProvider({ children }: { children: ReactNode }) {
    const [currentResource, setCurrentResource] = useState<Resource[]>(BaseResources);
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

    const updateResource = useCallback(({ sku, amount }: Resource) => {
        const resource = currentResource.find((currentResource) => currentResource.sku === sku);
        if (!resource) return;

        const newResourceValue = {
            ...resource,
            amount: Math.max(0, resource.amount - amount)
        };

        setCurrentResource(prev => prev.map((resource =>
            resource.sku === resource.sku ?
                newResourceValue :
                resource))
        );

    }, [currentResource])

    return (
        <ResourceContext value={{ resource: currentResource, personnel }}>
            <ResourceDispatchContext value={{ updateResource, setResource: setCurrentResource, setPersonnel, assignPersonnel }}>
                {children}
            </ResourceDispatchContext>
        </ResourceContext>
    )
}