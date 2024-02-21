import React from "react";

type Props = {
    value: string,
    onChange: (value: string) => void
}
export const Input: React.FC<Props> = (props: Props) => {
    return (
        <input
            className="dark:text-neutral-300 dark:placeholder:text-neutral-500 font-semibold bg-white/75 dark:bg-neutral-800/75 rounded-md p-3 focus:outline focus:outline-2 focus:outline-blue-500 mb-6"
            placeholder="Name"
            value={props.value}
            onChange={(event) => props.onChange(event.target.value)}
        />
    )
}