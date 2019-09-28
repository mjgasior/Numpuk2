import React from "react";
import { useExaminations } from "./useExaminations";
import { useTestTypes } from "./useTestTypes";
import { ExaminationsTable } from "./table/ExaminationsTable";
import { Filters } from "./filters/Filters";
import { Header } from "./header/Header";

export const Examinations = () => {
  const val = useExaminations();
  const [testTypes, setFamilies] = useTestTypes();
  return (
    <>
      <Header page={1} values={{ pageCount: 1 }}/>
      <Filters />
      <ExaminationsTable testTypes={testTypes} data={val.results} />
    </>
  );
};
