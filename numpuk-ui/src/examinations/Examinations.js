import React from "react";
import { useExaminations } from "./useExaminations";
import { useTestTypes } from "./useTestTypes";
import { ExaminationsTable } from "./table/ExaminationsTable";
import { Filters } from "./filters/Filters";

export const Examinations = () => {
  const val = useExaminations();
  const [testTypes, setFamilies] = useTestTypes();
  return (
    <>
      <Filters />
      <ExaminationsTable testTypes={testTypes} data={val.results} />
    </>
  );
};
