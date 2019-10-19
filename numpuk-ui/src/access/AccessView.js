import React, { useState, useEffect } from "react";
import { PasswordBox } from "./PasswordBox";
import Button from "@material-ui/core/Button";
import logo from "./../resources/logofull.png";

export const AccessView = ({ onPasswordSet, isPasswordIncorrect }) => {
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
      <img src={logo} alt="Logo" />
      <PasswordBox
        password={password}
        setPassword={setPassword}
        isPasswordIncorrect={isPasswordIncorrect}
      />
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
