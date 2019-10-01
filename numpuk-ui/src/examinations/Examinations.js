import React from "react";
import { useExaminations } from "./hooks/useExaminations";
import { useTestTypes } from "./hooks/useTestTypes";
import { ExaminationsTable } from "./table/ExaminationsTable";
import { Filters } from "./filters/Filters";
import { Header } from "./header/Header";
import { useDataBuffer } from "./hooks/useDataBuffer";

export const Examinations = () => {
  const { examinations, pagination, filters } = useExaminations();
  const [testTypes, setFamilies] = useTestTypes();
  const {
    setGender,
    setConsistency,
    setPh,
    setFaecalibactriumPrausnitzii,
    setAkkermansiaMuciniphila
  } = filters;

  const { isSavePages, setIsSavePages, data } = useDataBuffer(examinations);

  return (
    <>
      <Header
        {...pagination}
        values={data}
        setIsSavePages={setIsSavePages}
        isSavePages={isSavePages}
      />
      <Filters
        onTestTypeChanged={setFamilies}
        onGenderChanged={setGender}
        onConsistencyChanged={setConsistency}
        onPhChanged={setPh}
        onFaecalibactriumPrausnitzii={setFaecalibactriumPrausnitzii}
        onAkkermansiaMuciniphila={setAkkermansiaMuciniphila}
      />
      <ExaminationsTable testTypes={testTypes} data={examinations.results} />
    </>
  );
};
