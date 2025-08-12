import React from "react";
import Container from "react-bootstrap/Container";
import { Title } from "./Title";

interface Props {
  title?: string;
  tabTitle?: string;
  children: React.ReactNode;
}

export const Page = ({ title, tabTitle, children }: Props) => (
  <Container className="mt-2 page-container" >
    {tabTitle && <title>{tabTitle}</title>}
    {title && <Title>{title}</Title>}
    {children}
  </Container>
);