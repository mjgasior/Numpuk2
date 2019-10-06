import React, { useRef, useState } from "react";
import { makeStyles } from "@material-ui/core/styles";
import Typography from "@material-ui/core/Typography";
import Slider from "@material-ui/core/Slider";
import { throttle } from "throttle-debounce";

const useStyles = makeStyles({
  root: {
    width: 300
  }
});

const MIN_AGE = 0;
const MAX_AGE = 140;

export const AgeSlider = ({ onAgeChanged }) => {
  const classes = useStyles();
  const [value, setValue] = useState([MIN_AGE, MAX_AGE]);

  const throttled = useRef(throttle(1000, newValue => onAgeChanged(newValue)));

  return (
    <div className={classes.root}>
      <Typography id="range-slider" gutterBottom>
        Wiek
      </Typography>
      <Slider
        min={MIN_AGE}
        max={MAX_AGE}
        step={1}
        value={value}
        onChange={(event, newValue) => {
          setValue(newValue);
          throttled.current(newValue);
        }}
        valueLabelDisplay="auto"
        aria-labelledby="range-slider"
      />
    </div>
  );
};
