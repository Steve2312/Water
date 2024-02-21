import React, {ReactNode} from "react";

type Props = {
    children: ReactNode | ReactNode[]
    className?: string
}
export const Paragraph: React.FC<Props> = (props: Props) => {
    return (
        <p className={"text-black dark:text-white font-semibold " + props.className}>
            {props.children}
        </p>
    )
}