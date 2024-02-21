import React from "react";
import {Layout} from "../components/Layout.tsx";
import {Heading} from "../components/Heading.tsx";
import {Paragraph} from "../components/Paragraph.tsx";
import {Waves} from "../components/Waves.tsx";

export const ServerError: React.FC = () => {
    return (
        <Layout className="flex justify-center items-center">
            <div className="bg-neutral-100/75 dark:bg-neutral-900/75 rounded-md backdrop-blur max-w-screen-sm m-6 p-6 z-10">
                <Heading level={1} style={"title"} className="mb-6">Server Error</Heading>
                <Paragraph>Something went wrong, please try again later</Paragraph>
            </div>
            <Waves className="absolute bottom-0 w-screen"/>
        </Layout>
    )
}