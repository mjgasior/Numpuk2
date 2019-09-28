import React from 'react';
import { useExaminations } from './useExaminations';

export const Examinations = () => {
  const val = useExaminations();
  return (
    <div>
      {val.results.map(x => <div>{x.id}</div>)}
    </div>
  );
};
