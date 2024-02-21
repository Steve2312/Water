import React from "react";
import "./Waves.css"

type Props = {
    className: string
}
export const Waves: React.FC<Props> = (props: Props) => {
    return (
        <div className={props.className}>
            <svg
                className="w-[150%] h-[15vh] mb-[-45px] min-h-[100px] max-h-[150px]"
                xmlns="http://www.w3.org/2000/svg"
                viewBox="0 24 150 28"
                preserveAspectRatio="none"
                shapeRendering="auto"
            >
                <g className="parallax">
                    <path
                        x="48"
                        y="0"
                        fill="rgba(59,130,246,0.7)"
                        d="M-160 44c30 0 58-18 88-18s 58 18 88 18 58-18 88-18 58 18 88 18 v44h-352z"
                    />
                    <path
                        x="48"
                        y="3"
                        fill="rgba(59,130,246,0.5)"
                        d="M-160 44c30 0 58-18 88-18s 58 18 88 18 58-18 88-18 58 18 88 18 v44h-352z"
                    />
                    <path
                        x="48"
                        y="5"
                        fill="rgba(59,130,246,0.3)"
                        d="M-160 44c30 0 58-18 88-18s 58 18 88 18 58-18 88-18 58 18 88 18 v44h-352z"
                    />
                    <path
                        x="48"
                        y="7"
                        fill="rgba(59,130,246,1)"
                        d="M-160 44c30 0 58-18 88-18s 58 18 88 18 58-18 88-18 58 18 88 18 v44h-352z"
                    />
                </g>
            </svg>
            <div className="bg-blue-500 h-48 w-[150%]"/>
        </div>
    )
}