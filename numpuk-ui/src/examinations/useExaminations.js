import { useEffect, useContext, useState } from "react";
import { AccessContext } from "../access/AccessContext";

export const useExaminations = () => {
  const [page, setPageInternal] = useState(1);
  const [count, setCountInternal] = useState(25);

  const password = useContext(AccessContext);
  const [examinations, setExaminations] = useState({
    results: [],
    currentPage: 1
  });

  useEffect(() => {
    const url = `/values/examinations?password=${password}&page=${page}&count=${count}`;
    fetch(url)
      .then(resp => resp.json())
      .then(data => setExaminations(data));

    /*let url = `/api/values?page=${page}&count=${count}&ph=${ph[0]}&ph=${ph[1]}`;
    const consistencyArray = transformConsistency(consistency);

    if (consistencyArray.length > 0) {
      consistencyArray.map(c => (url += `&consistency=${c}`));
    }

    if (gender) {
      url += `&gender=${gender}`;
    }

    fetch(url)
      .then(resp => resp.json())
      .then(data => {
        if (isSavePages) {
          setValues(prevState => {
            if (data.currentPage > prevState.currentPage) {
              const a = prevState.results;
              const b = data.results;
              data.results = [...a, ...b];
            } else if (data.currentPage < prevState.currentPage) {
              alert("Klikanie w poprzednią stronę w tym trybie nie działa!");
            }
            return data;
          });
        } else {
          setValues(data);
        }
      });
  }, [page, gender, ph, consistency, isSavePages, count]);*/
  }, [password, page, setPageInternal, count, setCountInternal]);

  const resetPages = () => {
    setPageInternal(1);
    if (page !== 1) {
      setExaminations({ results: [], currentPage: 1 });
    }
  };

  return {
    examinations,
    pagination: {
      page,
      setPage: setPageInternal,
      count,
      setCount: c => {
        resetPages();
        setCountInternal(c);
      }
    }
  };
};
