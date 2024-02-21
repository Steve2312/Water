import React from "react";
import {Waves} from "../components/Waves.tsx";
import {Drop} from "../components/Drop.tsx";
import {Heading} from "../components/Heading.tsx";
import {Paragraph} from "../components/Paragraph.tsx";
import {Layout} from "../components/Layout.tsx";
import {Button} from "../components/Button.tsx";
import {useAuth0} from "@auth0/auth0-react";

export const Login: React.FC = () => {
    const { loginWithRedirect } = useAuth0();

    const handleLogin = async (): Promise<void> => {
        await loginWithRedirect();
    }

    const handleRegister = async (): Promise<void> => {
        await loginWithRedirect({
            authorizationParams: {
                screen_hint: "signup"
            }
        })
    }

    return (
        <Layout className="flex justify-center items-center">
            <div className="bg-neutral-100/75 dark:bg-neutral-900/75 rounded-md backdrop-blur max-w-screen-sm m-6 p-6 z-10">
                <div className="flex gap-3 items-center mb-6">
                    <Drop className="h-7 fill-blue-500" />
                    <Heading level={1} style={"title"}>Water</Heading>
                </div>
                <Paragraph className="mb-9">
                    Dehydration can cause a health issues such as headaches, fatigue, constipation and kidney stones.
                    Therefore it is important to drink enough water throughout the day. Sign up to track your water
                    consumption based on your recommended intake per day!
                </Paragraph>
                <div className="flex gap-6 justify-end">
                    <Button onClick={handleLogin}>Log in</Button>
                    <Button onClick={handleRegister}>Sign up</Button>
                </div>
            </div>
            <Waves className="absolute bottom-0 w-screen"/>
        </Layout>
    )
}