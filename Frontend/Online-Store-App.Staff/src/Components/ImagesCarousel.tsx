import { Carousel } from "react-bootstrap"
import { server } from "../AppSettings"

interface Props {
    data: string[] | undefined
}

export const ImagesCarousel = ({ data }: Props) => {
    if (data) return (
        <Carousel controls indicators variant="dark">
            {data!.map((image) => (
                <Carousel.Item key={image}>
                    <img src={server + "/" + image} />
                </Carousel.Item>
            ))}
        </Carousel>
    )
};