import React from "react"

import { Link, useParams } from "react-router";
import { Button } from "react-bootstrap";
import type { User } from "commonlib/src/Models/Data/User";
import { Page } from "../../Components/Layout/Page";
import { getCurrentUserId } from "commonlib/src/Services/AuthService";
import { getUserById } from "commonlib/src/Services/DataOperations/UsersService";

export const ProfilePage = () => {
    const [user, setUser] = React.useState<User | undefined>(undefined);

    const { userId } = useParams();

    React.useEffect(() => {
        let cancelled = false;

        const doGetUser = async () => {
            const id = userId ? Number(userId) : await getCurrentUserId();
            if (id) {
                const foundUser = await getUserById(id);
                if (foundUser){
                    setUser(foundUser);
                }
            }
            
        } 
        doGetUser();

        return () => {
            cancelled = true;
        };
    }, [userId]);

    const dateParse = (date: Date) => {
        const dateString = new Date(date).toLocaleDateString();
        return (
            dateString
        );
    }

    const dateTimeParse = (date: Date) => {
        const dateString = new Date(date).toLocaleString();
        return (
            dateString
        );
    }

    const getGenderString = (gender: boolean | undefined) => {
        if (gender === true)
            return "Мужской"
        else if (gender === false)
            return "Женский"
        else
            return "Не указан"
    }

    return(
        <Page title="Профиль" tabTitle="Профиль">
            <div>
                <dl className="row">
                    <dt className="col-sm-2">Имя</dt>
                    <dd className="col-sm-10">{user?.firstName}</dd>
                    <dt className="col-sm-2">Фамилия</dt>
                    <dd className="col-sm-10">{user?.lastName}</dd>
                    <dt className="col-sm-2">Пол</dt>
                    <dd className="col-sm-10">{getGenderString(user?.gender)}</dd>
                    <dt className="col-sm-2">Электронная почта</dt>
                    <dd className="col-sm-10">{user?.email}</dd>
                    <dt className="col-sm-2">Номер телефона</dt>
                    <dd className="col-sm-10">{user?.phoneNum}</dd>
                    {user?.birthDate ? 
                    <div>
                        <dt className="col-sm-2">Дата рождения</dt>
                        <dd className="col-sm-10">{dateParse(user.birthDate)}</dd>
                    </div> : <></>
                    }
                    {user?.createdDateTime ?
                    <div>
                        <dt className="col-sm-2">Дата создания аккаунта</dt>
                        <dd className="col-sm-10">{dateTimeParse(user?.createdDateTime)}</dd>
                    </div> : <></>
                    }                
                </dl>
            </div>
            <div className="col-sm-6">
                <Link to="edit">
                    <Button>Редактировать</Button>
                </Link>
            </div>
        </Page>
    )
}