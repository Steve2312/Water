import {instance} from "../instance.ts";
import {User} from "@auth0/auth0-react";

class UserDal {
    public getUser = async () => {
        const response = await instance.get<User>("user")
        return response.data;
    }
}
export default new UserDal();