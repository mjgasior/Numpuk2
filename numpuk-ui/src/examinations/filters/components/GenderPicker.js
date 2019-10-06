import React from "react";
import { makeStyles } from "@material-ui/core/styles";
import Radio from "@material-ui/core/Radio";
import RadioGroup from "@material-ui/core/RadioGroup";
import FormControlLabel from "@material-ui/core/FormControlLabel";
import FormControl from "@material-ui/core/FormControl";
import FormLabel from "@material-ui/core/FormLabel";

const useStyles = makeStyles(theme => ({
  formControl: {
    margin: theme.spacing(3)
  }
}));

export const GenderPicker = ({ onGenderChanged }) => {
  const classes = useStyles();
  const [value, setValue] = React.useState("off");

  function handleChange(event) {
    setValue(event.target.value);
    switch (event.target.value) {
      case "female":
        onGenderChanged(2);
        break;
      case "male":
        onGenderChanged(1);
        break;
      default:
        onGenderChanged(null);
        break;
    }
  }

  return (
    <div>
      <FormControl component="fieldset" className={classes.formControl}>
        <FormLabel component="legend">Płeć</FormLabel>
        <RadioGroup
          aria-label="gender"
          name="gender1"
          value={value}
          onChange={handleChange}
        >
          <FormControlLabel value="off" control={<Radio />} label="wyłącz" />
          <FormControlLabel
            value="female"
            control={<Radio />}
            label="Kobiety"
          />
          <FormControlLabel
            value="male"
            control={<Radio />}
            label="Mężczyźni"
          />
        </RadioGroup>
      </FormControl>
    </div>
  );
};
