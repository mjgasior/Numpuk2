import React, { useState, useContext } from "react";
import TextField from "@material-ui/core/TextField";
import Button from "@material-ui/core/Button";
import styled from "styled-components";
import { Uploading } from "./Uploading";
import { AccessContext } from "../access/AccessContext";

const Container = styled.div`
  flex-grow: 1;
  display: flex;
  flex-direction: column;
`;

const SecondRow = styled.div`
  flex-grow: 1;
  display: flex;
`;

export const UploadDialogContent = ({ onDone }) => {
  const [directory, setDirectory] = useState();
  const [isUploading, setIsUploading] = useState(false);
  const password = useContext(AccessContext);
  
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
          <SecondRow>
            <Button
              variant="contained"
              color="primary"
              style={{ margin: 8 }}
              onClick={() => setIsUploading(true)}
            >
              Rozpocznij przetwarzanie
            </Button>
          </SecondRow>
        </>
      )}
    </Container>
  );
};
