import React, { useState } from "react";
import { makeStyles } from "@material-ui/core/styles";
import FormLabel from "@material-ui/core/FormLabel";
import FormControl from "@material-ui/core/FormControl";
import FormGroup from "@material-ui/core/FormGroup";
import FormControlLabel from "@material-ui/core/FormControlLabel";
import Checkbox from "@material-ui/core/Checkbox";

const useStyles = makeStyles(theme => ({
  root: {
    display: "flex"
  },
  formControl: {
    margin: theme.spacing(3)
  }
}));

export const PerformedTestPicker = ({ onTestChanged, testName }) => {
  const classes = useStyles();
  const [state, setState] = useState({
    positive: false,
    negative: false,
    not_performed: false
  });

  const handleChange = name => event => {
    const newState = { ...state, [name]: event.target.checked };
    setState(newState);
    onTestChanged(newState);
  };

  const { positive, negative, not_performed } = state;

  return (
    <FormControl component="fieldset" className={classes.formControl}>
      <FormLabel component="legend">{testName}</FormLabel>
      <FormGroup>
        <FormControlLabel
          control={
            <Checkbox
              checked={positive}
              onChange={handleChange("positive")}
              value="positive"
            />
          }
          label="Pozytywnie"
        />
        <FormControlLabel
          control={
            <Checkbox
              checked={negative}
              onChange={handleChange("negative")}
              value="negative"
            />
          }
          label="Negatywnie"
        />
        <FormControlLabel
          control={
            <Checkbox
              checked={not_performed}
              onChange={handleChange("not_performed")}
              value="not_performed"
            />
          }
          label="Nie wykonano"
        />
      </FormGroup>
    </FormControl>
  );
};
