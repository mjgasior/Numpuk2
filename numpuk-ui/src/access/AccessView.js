import React, { useState, useEffect } from "react";
import { PasswordBox } from "./PasswordBox";
import Button from "@material-ui/core/Button";

export const AccessView = ({ onPasswordSet }) => {
  const [password, setPassword] = useState("");

  useEffect(() => {
    const handler = ({ key }) => {
      if (key === "Enter") {
        onPasswordSet(password);
      }
    };
    window.addEventListener("keydown", handler);

    return () => {
      window.removeEventListener("keydown", handler);
    };
  }, [onPasswordSet, password]);

  return (
    <>
      <PasswordBox password={password} setPassword={setPassword} />
      <Button
        variant="contained"
        color="primary"
        style={{ margin: 8 }}
        onClick={() => onPasswordSet(password)}
      >
        Ustaw hasło
      </Button>
    </>
  );
};
