import {Gender} from "./gender.model.ts";

export type User = {
    id: string,
    name: string,
    weight: number,
    gender: Gender,
}