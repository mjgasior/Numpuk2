import React, { useState } from "react";
import Dialog from "@material-ui/core/Dialog";
import DialogContent from "@material-ui/core/DialogContent";
import DialogTitle from "@material-ui/core/DialogTitle";

import { UploadButton } from "./UploadButton";
import { UploadDialogContent } from "./UploadDialogContent";

export const UploadDialog = () => {
  const [isOpen, setIsOpen] = useState(false);

  const handleClickOpen = () => setIsOpen(true);
  const handleClose = () => setIsOpen(false);

  return (
    <div>
      <UploadButton onClick={handleClickOpen} />
      {isOpen && (
        <Dialog
          fullWidth={true}
          maxWidth="lg"
          open={isOpen}
          onClose={handleClose}
          aria-labelledby="alert-dialog-title"
          aria-describedby="alert-dialog-description"
        >
          <DialogTitle id="alert-dialog-title">
            Dodawanie badań do bazy
          </DialogTitle>
          <DialogContent>
            <UploadDialogContent onDone={() => setIsOpen(false)} />
          </DialogContent>
        </Dialog>
      )}
    </div>
  );
};
