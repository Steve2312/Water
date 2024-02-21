import {useAuth0} from "@auth0/auth0-react";
import {useEffect, useState} from "react";
import {instance} from "../instance.ts";

export const useAuthInterceptor = () => {
    const { isAuthenticated, isLoading, getAccessTokenSilently, error } = useAuth0();
    const [isReady, setReady] = useState<boolean>(false);

    useEffect(() => {
        if (!isLoading) {
            if (isAuthenticated) {
                getAccessTokenSilently().then(accessToken => {
                    instance.defaults.headers.common.Authorization = `Bearer ${accessToken}`
                    setReady(true);
                })
            } else {
                setReady(true);
            }
        }
    }, [isLoading, isAuthenticated, getAccessTokenSilently])

    return [isReady, isAuthenticated, error] as const
}