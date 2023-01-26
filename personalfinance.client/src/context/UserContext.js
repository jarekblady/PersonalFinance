import { createContext, useContext, useState } from "react";


export const UserContext = createContext(undefined);

export function useUserContext() {
    const context = useContext(UserContext);

    if (context === undefined) {
        throw Error('Oops - we do not seem to be inside the provider');
    }

    return context;
}

export function UserProvider({ children }) {
    const [user, setUser] = useState(null);

    return (
        <UserContext.Provider value={{
            user, setUser
        }}>
            {children}
        </UserContext.Provider>
    )
}