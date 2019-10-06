import React from "react";
import styled from "styled-components";
import { Pager } from "./Pager";
import Switch from "@material-ui/core/Switch";
import MenuItem from "@material-ui/core/MenuItem";
import Select from "@material-ui/core/Select";

const Container = styled.div`
  display: flex;
  width: 90%;
  justify-content: space-between;
`;

const SwitchContainer = styled.div`
  margin: 5px;
`;

export const Header = ({
  page,
  values,
  setPage,
  isSavePages,
  setIsSavePages,
  count,
  setCount
}) => {
  return (
    <Container>
      <Pager
        isPreviousButtonHidden={isSavePages}
        page={page}
        pageCount={values.pageCount}
        totalCount={values.rowCount}
        currentPage={values.currentPage}
        setPage={setPage}
      />
      <Select
        disabled={isSavePages}
        value={count}
        onChange={event => setCount(event.target.value)}
        inputProps={{
          name: "page",
          id: "[age-simple"
        }}
      >
        <MenuItem value={10}>10 wpisów na stronę</MenuItem>
        <MenuItem value={25}>25 wpisów na stronę</MenuItem>
        <MenuItem value={50}>50 wpisów na stronę</MenuItem>
        <MenuItem value={100}>100 wpisów na stronę</MenuItem>
      </Select>
      <SwitchContainer>
        <Switch
          color="secondary"
          checked={isSavePages}
          onChange={event => setIsSavePages(event.target.checked)}
        />
        Zapisuj poprzednie strony
      </SwitchContainer>
    </Container>
  );
};
