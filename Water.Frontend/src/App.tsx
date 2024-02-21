import React from "react";
import {RouterProvider} from "react-router-dom";
import {getRouter} from "./router.tsx";
import {useAuthInterceptor} from "./hooks/useAuthInterceptor.tsx";
import {NotFound} from "./pages/NotFound.tsx";

export const App: React.FC = () => {
    const [isReady, isAuthenticated, error] = useAuthInterceptor();

    return (
        <>
            {
                isReady &&
                <RouterProvider router={
                    getRouter(isAuthenticated)
                }/>
            }
            {
                error &&
                <NotFound />
            }
        </>
    )
}