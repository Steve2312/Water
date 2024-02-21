import React, {ReactNode} from "react";

type Props = {
    children: ReactNode | ReactNode[]
    className?: string
}
export const Layout: React.FC<Props> = (props: Props) => {
    return (
        <div className={"relative h-screen w-screen overflow-hidden " + props.className}>
            {props.children}
        </div>
    )
}