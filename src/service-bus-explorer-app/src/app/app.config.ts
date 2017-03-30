import { OpaqueToken } from "@angular/core";

export let APP_CONFIG = new OpaqueToken("app.config");

export class AppConfig {
    apiEndpoint: string;
    signalRHubUrl: string;
    signalRHubName: string;
};

export const APP_CONFIG_OBJECT: AppConfig = {
    apiEndpoint: "http://localhost:3000/api/",
    signalRHubUrl: "http://localhost:3000/signalr",
    signalRHubName: "serviceBusExplorerHub"
};
