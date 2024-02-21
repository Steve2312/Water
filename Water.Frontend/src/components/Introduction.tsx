import {Heading} from "./Heading.tsx";
import React, {useState} from "react";
import {Paragraph} from "./Paragraph.tsx";
import {Button} from "./Button.tsx";
import { Input } from "./Input.tsx";

export const Introduction: React.FC = () => {
    const [stage, setStage] = useState<"introduction" | "name" | "gender" | "weight">("introduction");
    const [name, setName] = useState<string>("");

    const handleIntroduction = () => {
        setStage("name")
    }

    const handleName = () => {
        if (name) {
            setStage("gender")
        }
    }

    const handleGender = () => {
        setStage("weight")
    }

    const handleWeight = () => {
        setStage("name")
    }

    return (
        <div className="flex flex-col w-full">
            {
                stage == "introduction" &&
                <>
                    <Heading level={1} style={"title"} className="mb-6">Hey, we haven't seen you before</Heading>
                    <Paragraph className="mb-12">
                        Since this is your first time around here, we will ask your name, gender and weight to determine your daily recommended water consumption.
                    </Paragraph>
                    <Button onClick={handleIntroduction}>Bring them on!</Button>
                </>
            }
            {
                stage == "name" &&
                <>
                    <Heading level={1} style={"title"} className="mb-6">How should we call you?</Heading>
                    <Paragraph className="mb-6">
                        This can be your firstname, lastname, nickname, whatever you like!
                    </Paragraph>
                    <Input value={name} onChange={setName} />
                    <Button onClick={handleName}>Submit</Button>
                </>
            }
            {
                stage == "gender" &&
                <>
                    <Heading level={1} style={"title"} className="mb-6">Hey {name}, what is your gender?</Heading>
                    <Paragraph className="mb-6">
                        We believe that there are 2 genders, but if you feel differently then choose "other"
                    </Paragraph>
                    <button onClick={handleGender}>

                    </button>
                </>
            }
            {
                stage == "weight" &&
                <>
                    <label className="text-black dark:text-white font-semibold mb-3">What is your weight?</label>
                    <Button onClick={handleWeight}>Submit</Button>
                </>
            }
        </div>
    )
}