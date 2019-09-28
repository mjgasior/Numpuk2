import React from "react";
import { makeStyles } from "@material-ui/core/styles";
import Fab from "@material-ui/core/Fab";
import AddIcon from "@material-ui/icons/Add";
import styled from "styled-components";

const Container = styled.div`
  position: fixed;
  top: 8px;
  right: 8px;
`;

const useStyles = makeStyles(theme => ({
  fab: {
    margin: theme.spacing(1)
  },
  extendedIcon: {
    marginRight: theme.spacing(1)
  }
}));

export const UploadButton = ({ onClick }) => {
  const classes = useStyles();

  return (
    <Container>
      <Fab
        color="primary"
        aria-label="add"
        className={classes.fab}
        onClick={onClick}
      >
        <AddIcon />
      </Fab>
    </Container>
  );
};
