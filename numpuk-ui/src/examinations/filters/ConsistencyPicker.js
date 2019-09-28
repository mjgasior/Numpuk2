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

export const ConsistencyPicker = ({ onConsistencyChanged }) => {
  const classes = useStyles();
  const [state, setState] = React.useState({
    liquid: false,
    halfLiquid: false,
    rigid: false,
    unknown: false
  });

  const handleChange = name => event => {
    const newState = { ...state, [name]: event.target.checked };
    setState(newState);
    onConsistencyChanged(newState);
  };

  const { liquid, halfLiquid, rigid } = state;

  return (
    <FormControl component="fieldset" className={classes.formControl}>
      <FormLabel component="legend">Konsystencja</FormLabel>
      <FormGroup>
        <FormControlLabel
          control={
            <Checkbox
              checked={liquid}
              onChange={handleChange("liquid")}
              value="liquid"
            />
          }
          label="Płynna"
        />
        <FormControlLabel
          control={
            <Checkbox
              checked={halfLiquid}
              onChange={handleChange("halfLiquid")}
              value="halfLiquid"
            />
          }
          label="Półpłynna"
        />
        <FormControlLabel
          control={
            <Checkbox
              checked={rigid}
              onChange={handleChange("rigid")}
              value="rigid"
            />
          }
          label="Stała"
        />
      </FormGroup>
    </FormControl>
  );
};
