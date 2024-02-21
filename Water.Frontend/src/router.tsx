import {createBrowserRouter, redirect} from "react-router-dom";
import {Login} from "./pages/Login.tsx";
import {Dashboard} from "./pages/Dashboard.tsx";
import {NotFound} from "./pages/NotFound.tsx";

export const getRouter = (isAuthenticated: boolean) => createBrowserRouter([
    {
        path: "/",
        element: <Login/>,
        errorElement: <NotFound />,
        loader: (): Response | null => {
            return isAuthenticated ? redirect("../dashboard") : null;
        },
    },
    {
        path: "dashboard",
        element: <Dashboard/>,
        errorElement: <NotFound />,
        loader: (): Response | null => {
            if (!isAuthenticated) return redirect("../");
            return null;
        }
    }
]);