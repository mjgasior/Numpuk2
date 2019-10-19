import React, { useState } from "react";
import { UploadDialog } from "./upload/UploadDialog";
import { AccessContext } from "./access/AccessContext";
import { AccessView } from "./access/AccessView";
import styled from "styled-components";
import { Examinations } from "./examinations/Examinations";

const AppContainer = styled.div`
  flex-grow: 1;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  width: 100%;
`;

function App() {
  const [isPasswordIncorrect, setIsPasswordIncorrect] = useState(false);
  const [password, setPassword] = useState("");
  const [hasPassword, setHasPassword] = useState("");

  if (hasPassword) {
    return (
      <AccessContext.Provider value={password}>
        <AppContainer style={{ alignItems: "unset", justifyContent: "unset" }}>
          <UploadDialog />
          <Examinations
            onConnectionFailed={() => {
              setHasPassword(false);
              setIsPasswordIncorrect(true);
            }}
          />
        </AppContainer>
      </AccessContext.Provider>
    );
  } else {
    return (
      <AppContainer>
        <AccessView
          isPasswordIncorrect={isPasswordIncorrect}
          onPasswordSet={newPassword => {
            setPassword(newPassword);
            setHasPassword(true);
          }}
        />
      </AppContainer>
    );
  }
}

export default App;
