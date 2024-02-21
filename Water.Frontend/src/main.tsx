import ReactDOM from 'react-dom/client'
import './index.css'
import {App} from "./App.tsx";
import React from "react";
import {Auth0Provider} from "@auth0/auth0-react";
import {QueryClient, QueryClientProvider} from "@tanstack/react-query";

const client = new QueryClient();

ReactDOM.createRoot(document.getElementById('root')!).render(
    <React.StrictMode>
        <Auth0Provider
            domain="dev-whuc7tr4.us.auth0.com"
            clientId="f9C3B9o68MgyiXKkFPSUMe8eaIPEFmyX"
            cacheLocation="localstorage"
            authorizationParams={{
                redirect_uri: window.location.origin,
                audience: "https://api.water.steve2312.net"
            }}
        >
            <QueryClientProvider client={client}>
                <App />
            </QueryClientProvider>
        </Auth0Provider>
    </React.StrictMode>
)
