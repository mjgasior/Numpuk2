import React from "react";
import { makeStyles } from "@material-ui/core/styles";
import Table from "@material-ui/core/Table";
import TableBody from "@material-ui/core/TableBody";
import TableCell from "@material-ui/core/TableCell";
import TableHead from "@material-ui/core/TableHead";
import TableRow from "@material-ui/core/TableRow";
import Paper from "@material-ui/core/Paper";
import {
  getConsistencyLabel,
  getLabel,
  getValue,
  getGender,
  getAge
} from "./helpers";
import { DoubleScrollbar } from "./DoubleScrollbar";

const useStyles = makeStyles(theme => ({
  root: {
    margin: 10
  },
  paper: {
    borderTop: "#eee solid 1px",
    marginTop: theme.spacing(3),
    width: "98%",
    overflowX: "auto",
    marginBottom: theme.spacing(2),
    paddingBottom: theme.spacing(4)
  },
  table: {
    minWidth: 650
  }
}));

export const ExaminationsTable = ({ data, testTypes }) => {
  const classes = useStyles();

  if (!data) {
    return null;
  }

  return (
    <div className={classes.root}>
      <Paper className={classes.paper}>
        <DoubleScrollbar>
          <Table className={classes.table} size="small">
            <TableHead>
              <TableRow>
                <TableCell>Płeć</TableCell>
                <TableCell align="right">Wiek</TableCell>
                <TableCell align="right">PH</TableCell>
                <TableCell align="right">Konsystencja</TableCell>
                <TableCell align="right">Ilość bakterii</TableCell>
                <TableCell align="right">Akkermansia Muciniphila</TableCell>
                <TableCell align="right">Faecalibactrium Prausnitzii</TableCell>
                {testTypes.map(x => (
                  <TableCell key={x} align="right">
                    {x}
                  </TableCell>
                ))}
              </TableRow>
            </TableHead>
            <TableBody>
              {data.map(
                ({
                  id,
                  client,
                  results,
                  phValue,
                  consistency,
                  generalNumberOfBacteria,
                  hasAkkermansiaMuciniphila,
                  hasFaecalibactriumPrausnitzii
                }) => (
                  <TableRow key={id}>
                    <TableCell component="th" scope="row">
                      {getGender(client.gender)}
                    </TableCell>
                    <TableCell align="right">
                      {getAge(client.age)}
                    </TableCell>
                    <TableCell align="right">{phValue}</TableCell>
                    <TableCell align="right">
                      {getConsistencyLabel(consistency)}
                    </TableCell>
                    <TableCell align="right">
                      {generalNumberOfBacteria}
                    </TableCell>
                    <TableCell align="right">
                      {getLabel(hasAkkermansiaMuciniphila)}
                    </TableCell>
                    <TableCell align="right">
                      {getLabel(hasFaecalibactriumPrausnitzii)}
                    </TableCell>
                    {testTypes.map((x, i) => (
                      <TableCell key={x + i} align="right">
                        {getValue(x, results)}
                      </TableCell>
                    ))}
                  </TableRow>
                )
              )}
            </TableBody>
          </Table>
        </DoubleScrollbar>
      </Paper>
    </div>
  );
};
