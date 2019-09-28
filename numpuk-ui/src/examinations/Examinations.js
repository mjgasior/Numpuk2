import React from "react";
import { useExaminations } from "./useExaminations";
import { useTestTypes } from "./useTestTypes";
import { ExaminationsTable } from "./table/ExaminationsTable";
import { Filters } from "./filters/Filters";
import { Header } from "./header/Header";

export const Examinations = () => {
  const { examinations, pagination, filters } = useExaminations();
  const [testTypes, setFamilies] = useTestTypes();
  const { setGender, setConsistency, setPh } = filters;
  return (
    <>
      <Header {...pagination} values={examinations} />
      <Filters
        onTestTypeChanged={setFamilies}
        onGenderChanged={setGender}
        onConsistencyChanged={setConsistency}
        onPhChanged={setPh}
      />
      <ExaminationsTable testTypes={testTypes} data={examinations.results} />
    </>
  );
};
