import React from 'react';
import { useExaminations } from './useExaminations';
import { useTestTypes } from './useTestTypes';
import { ExaminationsTable } from './ExaminationsTable';

export const Examinations = () => {
  const val = useExaminations();
  const testTypes = useTestTypes();
  return (
    <ExaminationsTable testTypes={testTypes} data={val.results} />
  );
};
