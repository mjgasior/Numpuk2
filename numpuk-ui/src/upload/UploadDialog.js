import React, { useCallback, useState } from "react";
import Dialog from "@material-ui/core/Dialog";
import DialogContent from "@material-ui/core/DialogContent";
import DialogTitle from "@material-ui/core/DialogTitle";

import { makeStyles } from "@material-ui/core/styles";
import { UploadButton } from "./UploadButton";
import { Dropzone } from "./Dropzone";
import { Uploading } from "./Uploading";

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
    function readURL(file) {
      var reader = new FileReader();

      reader.onload = function(e) {
        console.log(e);
        console.log(e.target.result);
      };

      reader.readAsDataURL(file);
    }

    acceptedFiles.map(x => readURL(x));
    // setFiles(acceptedFiles);
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
          <div className={classes.root}>
            {hasNoFiles() ? (
              <Dropzone onDrop={onDrop} />
            ) : (
              <Uploading files={files} onDone={() => setOpen(false)} />
            )}
          </div>
        </DialogContent>
      </Dialog>
    </div>
  );
};
