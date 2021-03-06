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

const MIN_PH = 0;
const MAX_PH = 14;

export const PhSlider = ({ onPhChanged }) => {
  const classes = useStyles();
  const [value, setValue] = useState([MIN_PH, MAX_PH]);

  const throttled = useRef(throttle(1000, newValue => onPhChanged(newValue)));

  return (
    <div className={classes.root}>
      <Typography id="range-slider" gutterBottom>
        Zakres PH
      </Typography>
      <Slider
        min={MIN_PH}
        max={MAX_PH}
        step={0.1}
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
