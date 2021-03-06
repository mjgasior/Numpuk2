import React from "react";
import { GenderPicker } from "./components/GenderPicker";
import { PhSlider } from "./components/PhSlider";
import styled from "styled-components";
import { ConsistencyPicker } from "./components/ConsistencyPicker";
import { TestTypesPicker } from "./components/TestTypesPicker";

import { makeStyles } from "@material-ui/core/styles";
import ExpansionPanel from "@material-ui/core/ExpansionPanel";
import ExpansionPanelSummary from "@material-ui/core/ExpansionPanelSummary";
import ExpansionPanelDetails from "@material-ui/core/ExpansionPanelDetails";
import Typography from "@material-ui/core/Typography";
import ExpandMoreIcon from "@material-ui/icons/ExpandMore";
import { PerformedTestPicker } from "./components/PerformedTestPicker";
import { AgeSlider } from "./components/AgeSlider";

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
  flex-wrap: wrap;
`;

export const Filters = ({
  onGenderChanged,
  onPhChanged,
  onAgeChanged,
  onConsistencyChanged,
  onTestTypeChanged,
  onAkkermansiaMuciniphila,
  onFaecalibactriumPrausnitzii
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
            <AgeSlider onAgeChanged={onAgeChanged} />
            <GenderPicker onGenderChanged={onGenderChanged} />
            <TestTypesPicker onTestTypeChanged={onTestTypeChanged} />
            <ConsistencyPicker onConsistencyChanged={onConsistencyChanged} />
            <PerformedTestPicker onTestChanged={onAkkermansiaMuciniphila} testName={"Akkermansia Muciniphila"} />
            <PerformedTestPicker onTestChanged={onFaecalibactriumPrausnitzii} testName={"Faecalibactrium Prausnitzii"} />
            <PhSlider onPhChanged={onPhChanged} />
          </Container>
        </ExpansionPanelDetails>
      </ExpansionPanel>
    </div>
  );
};
