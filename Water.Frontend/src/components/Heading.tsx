import React, {ReactNode} from "react";

type Props = {
    level: 1
    style: "title",
    className?: string
    children: ReactNode | ReactNode[]
}
export const Heading: React.FC<Props> = (props: Props) => {
    const tag = "h" + props.level;
    const getClassName = (): string => {
        switch (props.style)
        {
            case "title":
                return "text-black dark:text-white text-4xl font-bold"
        }
    }

    return (
        React.createElement(
            tag,
            {
                className: getClassName() + " " + props.className
            },
            props.children
        )
    )
}