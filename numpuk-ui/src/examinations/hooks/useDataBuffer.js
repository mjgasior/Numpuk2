import { useState, useEffect } from "react";

export const useDataBuffer = examinations => {
  const [isSavePages, setIsSavePages] = useState(false);
  const [data, setData] = useState(examinations);

  useEffect(() => {
    if (isSavePages) {
      setData(prevState => {
        if (examinations.currentPage > prevState.currentPage) {
          const a = prevState.results;
          const b = examinations.results;
          examinations.results = [...a, ...b];
        } else if (examinations.currentPage < prevState.currentPage) {
          alert("Klikanie w poprzednią stronę w tym trybie nie działa!");
        }
        return examinations;
      });
    } else {
      setData(examinations);
    }
  }, [examinations, isSavePages]);

  return { isSavePages, setIsSavePages, data };
};
