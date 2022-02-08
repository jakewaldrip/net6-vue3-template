import { BuildUrl } from "@/api/BaseApi";
import { HandleResponse } from "@/api/BaseApi";
import { HelloWorldResponse } from "@/types/helloworld";
import axios from "axios";

const HelloWorldGetName = async () => {
    const url = BuildUrl("HelloWorld");
    const result = await axios.get(url, {
        headers: {
            'Content-Type': 'application/json',
        }
    });

    return HandleResponse<HelloWorldResponse>(result);
}

export {
    HelloWorldGetName
}