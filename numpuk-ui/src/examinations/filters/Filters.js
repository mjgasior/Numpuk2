import React from "react";
import { GenderPicker } from "./GenderPicker";
import { PhSlider } from "./PhSlider";
import styled from "styled-components";
import { ConsistencyPicker } from "./ConsistencyPicker";
import { TestTypesPicker } from "./TestTypesPicker";

import { makeStyles } from "@material-ui/core/styles";
import ExpansionPanel from "@material-ui/core/ExpansionPanel";
import ExpansionPanelSummary from "@material-ui/core/ExpansionPanelSummary";
import ExpansionPanelDetails from "@material-ui/core/ExpansionPanelDetails";
import Typography from "@material-ui/core/Typography";
import ExpandMoreIcon from '@material-ui/icons/ExpandMore';

const useStyles = makeStyles(theme => ({
  root: {
    width: "90%",
    margin: 10
  },
  heading: {
    fontSize: theme.typography.pxToRem(15),
    fontWeight: theme.typography.fontWeightRegular
  }
}));

const Container = styled.div`
  margin: 10px;
  display: flex;
`;

export const Filters = ({
  onGenderChanged,
  onPhChanged,
  onConsistencyChanged,
  onTestTypeChanged
}) => {
  const classes = useStyles();

  return (
    <div className={classes.root}>
      <ExpansionPanel>
        <ExpansionPanelSummary
          expandIcon={<ExpandMoreIcon />}
          aria-controls="panel1a-content"
          id="panel1a-header"
        >
          <Typography className={classes.heading}>Filtry</Typography>
        </ExpansionPanelSummary>
        <ExpansionPanelDetails>
          <Container>
            <TestTypesPicker onTestTypeChanged={onTestTypeChanged} />
            <GenderPicker onGenderChanged={onGenderChanged} />
            <ConsistencyPicker onConsistencyChanged={onConsistencyChanged} />
            <PhSlider onPhChanged={onPhChanged} />
          </Container>
        </ExpansionPanelDetails>
      </ExpansionPanel>
    </div>
  );
};
