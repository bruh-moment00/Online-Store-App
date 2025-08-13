import { type User } from "commonlib/src/Models/Data/User"
import { getCurrentUserId } from "commonlib/src/Services/AuthService";
import { getUserById } from "commonlib/src/Services/DataOperations/UsersService";
import React from "react";
import { Page } from "../../Components/Layout/Page";
import { ChangePasswordForm } from "../../Components/Profile/ChangePasswordForm";
import { EditProfileForm } from "../../Components/Profile/EditProfileForm";
import { useNavigate } from "react-router-dom";

export const EditProfilePage = () => {
    const [user, setUser] = React.useState<User | undefined>(undefined);

    const navigate = useNavigate();

    React.useEffect(() => {
            let cancelled = false;
    
            const doGetUser = async () => {
                const id = await getCurrentUserId();
                if (id) {
                    const foundUser = await getUserById(id);
                    if (foundUser){
                        setUser(foundUser);
                    }
                }
                else 
                    navigate('login');
            } 
            doGetUser();
    
            return () => {
                cancelled = true;
            };
        }, []);

    return (
        <Page title="Редактирование профиля" tabTitle="Редактирование профиля">
            <div>
                {user ? <EditProfileForm user={user}/> : <></>}
                <hr/>
                {user ? <ChangePasswordForm id={user.id}/> : <></>} 
            </div>
        </Page>
    )
}