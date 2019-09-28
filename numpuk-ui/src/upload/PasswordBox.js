import React, { useState } from "react";
import IconButton from "@material-ui/core/IconButton";
import InputAdornment from "@material-ui/core/InputAdornment";
import TextField from "@material-ui/core/TextField";
import Visibility from "@material-ui/icons/Visibility";
import VisibilityOff from "@material-ui/icons/VisibilityOff";

export const PasswordBox = ({ password, setPassword }) => {
  const [isPasswordVisible, setIsPasswordVisible] = useState(false);

  return (
    <TextField
      id="outlined-adornment-password"
      variant="outlined"
      type={isPasswordVisible ? "text" : "password"}
      label="Password"
      value={password}
      style={{ margin: 8 }}
      onChange={event => setPassword(event.target.value)}
      InputProps={{
        endAdornment: (
          <InputAdornment position="end">
            <IconButton
              edge="end"
              aria-label="toggle password visibility"
              onClick={() => setIsPasswordVisible(isVisible => !isVisible)}
              onMouseDown={event => event.preventDefault()}
            >
              {isPasswordVisible ? <VisibilityOff /> : <Visibility />}
            </IconButton>
          </InputAdornment>
        )
      }}
    />
  );
};
