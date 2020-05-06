import {Client} from "shared/client"

export interface Order{
    id: number;
    client: Client;
    total: number;
    placed: Date;
    fullfilled: Date;
};