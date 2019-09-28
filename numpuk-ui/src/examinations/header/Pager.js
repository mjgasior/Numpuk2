import React from "react";
import styled from "styled-components";
import Button from "@material-ui/core/Button";

const Container = styled.div`
  display: flex;
  margin: 5px;
`;

const Text = styled.div`
  padding: 6px 18px;
`;

export const Pager = ({ page, pageCount, currentPage, setPage }) => {
  const hasPrevious = page > 1;
  const hasNext = page < pageCount;
  const isLoading = page !== currentPage;

  const previousButtonStyle = hasPrevious ? {} : { visibility: "hidden" };

  return (
    <Container>
      <Button
        disabled={isLoading}
        style={previousButtonStyle}
        onClick={() => setPage(page - 1)}
      >
        Poprzednia strona
      </Button>

      <Text>
        {currentPage} / {pageCount}
      </Text>
      {hasNext && (
        <Button disabled={isLoading} onClick={() => setPage(page + 1)}>
          Następna strona
        </Button>
      )}
    </Container>
  );
};
