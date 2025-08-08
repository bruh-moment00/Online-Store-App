import { Carousel } from "react-bootstrap"
import { server } from "commonlib/src/AppSettings";

interface Props {
    data: string[] | undefined
}

export const ImagesCarousel = ({ data }: Props) => {
    if (data) return (
        <Carousel controls indicators variant="dark">
            {data!.map((image) => (
                <Carousel.Item key={image}>
                    <img src={server + "/" + image} width={500} height={500}/>
                </Carousel.Item>
            ))}
        </Carousel>
    )
};