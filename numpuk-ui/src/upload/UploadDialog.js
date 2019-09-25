import React, { useCallback, useState } from "react";
import Dialog from "@material-ui/core/Dialog";
import DialogContent from "@material-ui/core/DialogContent";
import DialogContentText from "@material-ui/core/DialogContentText";
import DialogTitle from "@material-ui/core/DialogTitle";

import { makeStyles } from "@material-ui/core/styles";
import { UploadButton } from "./UploadButton";
import { Dropzone } from "./Dropzone";

const useStyles = makeStyles(theme => ({
  root: {
    flexGrow: 1
  },
  paper: {
    padding: theme.spacing(2),
    textAlign: "center",
    color: theme.palette.text.secondary
  }
}));

export const UploadDialog = () => {
  const [open, setOpen] = useState(false);
  const [files, setFiles] = useState([]);

  function handleClickOpen() {
    setOpen(true);
  }

  function handleClose() {
    setOpen(false);
  }

  const classes = useStyles();

  const onDrop = useCallback(acceptedFiles => {
    console.log(acceptedFiles);
    setFiles(acceptedFiles);
  }, []);

  function hasNoFiles() {
    return files.length === 0;
  }

  return (
    <div>
      <UploadButton onClick={handleClickOpen} />
      <Dialog
        fullWidth={true}
        maxWidth="lg"
        open={open}
        onClose={handleClose}
        aria-labelledby="alert-dialog-title"
        aria-describedby="alert-dialog-description"
      >
        <DialogTitle id="alert-dialog-title">Przeciągnij pliki</DialogTitle>
        <DialogContent>
          <DialogContentText id="alert-dialog-description">
            <div className={classes.root}>
              {hasNoFiles() ? <Dropzone onDrop={onDrop} /> : <p>Mamy pliki</p>}
            </div>
          </DialogContentText>
        </DialogContent>
      </Dialog>
    </div>
  );
};
