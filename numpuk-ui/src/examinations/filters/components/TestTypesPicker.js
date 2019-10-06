import React from "react";
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

export const TestTypesPicker = ({ onTestTypeChanged }) => {
  const classes = useStyles();
  const [state, setState] = React.useState({
    anaerobic: false,
    gramMinus: false,
    gramPlus: false,
    fungi: false
  });

  const handleChange = name => event => {
    const newState = { ...state, [name]: event.target.checked };
    setState(newState);
    onTestTypeChanged(newState);
  };

  const { anaerobic, gramMinus, gramPlus, fungi } = state;

  return (
    <FormControl component="fieldset" className={classes.formControl}>
      <FormLabel component="legend">Rodzina</FormLabel>
      <FormGroup>
        <FormControlLabel
          control={
            <Checkbox
              checked={anaerobic}
              onChange={handleChange("anaerobic")}
              value="anaerobic"
            />
          }
          label="Tlenowe"
        />
        <FormControlLabel
          control={
            <Checkbox
              checked={gramPlus}
              onChange={handleChange("gramPlus")}
              value="gramPlus"
            />
          }
          label="Gram +"
        />
        <FormControlLabel
          control={
            <Checkbox
              checked={gramMinus}
              onChange={handleChange("gramMinus")}
              value="gramMinus"
            />
          }
          label="Gram -"
        />
        <FormControlLabel
          control={
            <Checkbox
              checked={fungi}
              onChange={handleChange("fungi")}
              value="fungi"
            />
          }
          label="Fungi"
        />
      </FormGroup>
    </FormControl>
  );
};
