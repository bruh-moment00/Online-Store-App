import { server } from "commonlib/src/AppSettings";
import { deleteImage, renameImage } from "commonlib/src/Services/DataOperations/ProductImagesService";
import React from "react";
import { Button, Table } from "react-bootstrap";

interface Props {
    imageURL: string;
}

export const EditProductImage = ({ imageURL }: Props) => {
    const getFileName = (path: string) => {
        return path.substring(path.lastIndexOf('/') + 1, path.lastIndexOf('.'));
    }

    const [filePath, setFilePath] = React.useState<string>(imageURL);
    const [fileName, setFileName] = React.useState<string>(getFileName(imageURL))

    React.useEffect(() => {
        setFileName(getFileName(filePath));
    }, [filePath]);

    const handleDelete = async (event: React.MouseEvent<HTMLButtonElement>) => {
        if (confirm("Точно удалить данное изображение?")) {
            const result = await deleteImage(filePath);
            if (result) {
                window.location.reload();
            }     
        }
    }

    const handleRename = async (event: React.MouseEvent<HTMLButtonElement>) => {
        let newName = prompt("Введите новое название", fileName)
        if (newName) {
            const result = await renameImage(filePath, newName);
            if (result) {
                setFilePath(filePath.replace(fileName, newName))
            }     
        }
    }

    return(
        <Table bordered>
            <tbody>
                <tr>
                    <td>
                        <img src={server + "/" + imageURL} />
                    </td>
                    <td>
                        <h4>{fileName}</h4>
                        <Button onClick={handleRename}>Переименовать</Button>
                        <hr />
                        <Button variant="danger" onClick={handleDelete}>Удалить</Button>
                    </td>
                </tr>
            </tbody>
        </Table>
    )
}