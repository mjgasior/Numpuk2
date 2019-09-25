import React from "react";
import { makeStyles } from '@material-ui/core/styles';
import Fab from '@material-ui/core/Fab';
import AddIcon from '@material-ui/icons/Add';

const useStyles = makeStyles(theme => ({
  fab: {
    margin: theme.spacing(1),
  },
  extendedIcon: {
    marginRight: theme.spacing(1),
  },
}));

export const UploadButton = ({ onClick }) => {
  const classes = useStyles();

  return (
    <Fab color="primary" aria-label="add" className={classes.fab} onClick={onClick}>
      <AddIcon />
    </Fab>
  );
};
