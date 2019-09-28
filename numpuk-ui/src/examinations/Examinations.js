import React from "react";
import { useExaminations } from "./useExaminations";
import { useTestTypes } from "./useTestTypes";
import { ExaminationsTable } from "./table/ExaminationsTable";
import { Filters } from "./filters/Filters";
import { Header } from "./header/Header";

export const Examinations = () => {
  const { examinations, pagination } = useExaminations();
  const [testTypes, setFamilies] = useTestTypes();
  return (
    <>
      <Header {...pagination} values={examinations}/>
      <Filters />
      <ExaminationsTable testTypes={testTypes} data={examinations.results} />
    </>
  );
};
