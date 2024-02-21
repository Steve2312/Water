import {Heading} from "../components/Heading.tsx";
import React from "react";
import {useAuth0, User} from "@auth0/auth0-react";
import {Layout} from "../components/Layout.tsx";
import {Button} from "../components/Button.tsx";
import {useQuery, UseQueryResult} from "@tanstack/react-query";
import userDal from "../dal/user.dal.ts";
import {AxiosError} from "axios";
import {ServerError} from "./ServerError.tsx";
import {Introduction} from "../components/Introduction.tsx";
import {Waves} from "../components/Waves.tsx";

export const Dashboard: React.FC = () => {
    const { logout } = useAuth0();

    const user: UseQueryResult<User, AxiosError> = useQuery({
        queryKey: ["user"],
        queryFn: userDal.getUser,
        retry: false
    });

    const handleLogout = async (): Promise<void> => {
        await logout({
            logoutParams: {
                returnTo: window.location.origin
            }
        })
    }

    return (
        <>
            {
                user.isSuccess &&
                <Layout>
                    <Heading level={1} style={"title"}>success</Heading>
                    <Button onClick={handleLogout}>Logout</Button>
                </Layout>
            }
            {
                user.error?.response?.status == 404 &&
                <Layout className="flex items-center justify-center">
                    <div className="bg-neutral-100/75 dark:bg-neutral-900/75 rounded-md backdrop-blur max-w-screen-sm m-6 p-6 w-full z-10">
                        <Introduction/>
                    </div>
                    <Waves className="absolute bottom-0 w-screen"/>
                </Layout>
            }
            {
                user.error && user.error.response == undefined &&
                <ServerError/>
            }
        </>
    )
}