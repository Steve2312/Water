import React, {ReactNode} from "react";

type Props = {
    onClick?: () => void
    children: ReactNode | ReactNode[]
    className?: string
}
export const Button: React.FC<Props> = (props: Props) => {
    return (
        <button
            className={"bg-blue-600 text-white font-bold px-6 py-3 rounded-md " + props.className}
            onClick={props.onClick}
        >
            {props.children}
        </button>
    )
}