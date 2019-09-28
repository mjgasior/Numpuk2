import React, { useState } from "react";
import Dialog from "@material-ui/core/Dialog";
import DialogContent from "@material-ui/core/DialogContent";
import DialogTitle from "@material-ui/core/DialogTitle";

import { UploadButton } from "./UploadButton";
import { UploadDialogContent } from "./UploadDialogContent";

export const UploadDialog = () => {
  const [open, setOpen] = useState(false);

  const handleClickOpen = () => setOpen(true);
  const handleClose = () => setOpen(false);

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
        <DialogTitle id="alert-dialog-title">
          Dodawanie badań do bazy
        </DialogTitle>
        <DialogContent>
          <UploadDialogContent onDone={() => setOpen(false)} />
        </DialogContent>
      </Dialog>
    </div>
  );
};
