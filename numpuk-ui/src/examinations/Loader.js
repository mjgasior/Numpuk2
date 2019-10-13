import React from "react";
import CircularProgress from '@material-ui/core/CircularProgress';
import styled from 'styled-components';

const Container = styled.div`
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100%;
`;

export const Loader = () => {
  return (
    <Container><CircularProgress/></Container>
  );
};
