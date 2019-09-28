import React, { useState } from "react";
import TextField from "@material-ui/core/TextField";
import Button from "@material-ui/core/Button";
import styled from "styled-components";
import { Uploading } from "./Uploading";
import { PasswordBox } from "./PasswordBox";

const Container = styled.div`
  flex-grow: 1;
`;

export const UploadDialogContent = ({ onDone }) => {
  const [directory, setDirectory] = useState();
  const [password, setPassword] = useState();
  const [isUploading, setIsUploading] = useState(false);

  return (
    <Container>
      {isUploading ? (
        <Uploading directory={directory} password={password} onDone={onDone} />
      ) : (
        <>
          <TextField
            value={directory}
            onChange={event => setDirectory(event.target.value)}
            label="Ścieżka do badań"
            style={{ margin: 8 }}
            placeholder="Przykład: C:\wyniki_badan\"
            helperText="W tym miejscu należy wkleić folder zawierający wyniki badań"
            fullWidth
            margin="normal"
            variant="outlined"
            InputLabelProps={{
              shrink: true
            }}
          />
          <PasswordBox password={password} setPassword={setPassword} />
          <Button
            variant="contained"
            color="primary"
            onClick={() => setIsUploading(true)}
          >
            Rozpocznij przetwarzanie
          </Button>
        </>
      )}
    </Container>
  );
};
