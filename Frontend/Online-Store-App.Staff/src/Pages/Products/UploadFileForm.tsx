import { uploadImage } from "commonlib/src/Services/DataOperations/ProductImagesService";
import { Button, Form } from "react-bootstrap"
import { useForm } from "react-hook-form";

type FormData = {
    productId: number;
    file: FileList;
}

interface Props {
    productId: number;
}

export const UploadFileForm = ({ productId }: Props) => {
    const {register, handleSubmit} = useForm<FormData>({mode: "onSubmit"});

    const submitForm = async (data: FormData) => {
        const result = await uploadImage(data.file[0], data.productId);
        if (result) {
            window.location.reload();
        }
    }

    return(
        <form onSubmit={handleSubmit(submitForm)}>
            <input type="hidden" value={productId} {...register('productId', {required: true})}/>
            <label>Выбрать файл с диска</label>
            <Form.Control type="file" {...register('file', {required: true})}/>
            <Button type="submit">Загрузить</Button>
        </form>
        
    )
    
}