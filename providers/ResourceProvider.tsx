import { BaseResources } from "@/constants/resources";
import { BaseResource } from "@/types/resources";
import { createContext, Dispatch, ReactNode, SetStateAction, useState } from "react";

export const ResourceContext = createContext<BaseResource>(BaseResources);
export const ResourceDispatchContext = createContext<Dispatch<SetStateAction<BaseResource>>>(() => { });

export function ResourceProvider({ children }: { children: ReactNode }) {
    const [resource, setResource] = useState<BaseResource>(BaseResources);

    return (
        <ResourceContext value={resource}>
            <ResourceDispatchContext value={setResource}>
                {children}
            </ResourceDispatchContext>
        </ResourceContext>
    )
}