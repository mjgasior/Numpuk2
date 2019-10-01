import { useEffect, useContext, useState } from "react";
import { AccessContext } from "../../access/AccessContext";
import {
  transformConsistency,
  transformPerformedTest
} from "./../table/helpers";

export const useExaminations = () => {
  const [page, setPageInternal] = useState(1);
  const [count, setCountInternal] = useState(25);

  const [ph, setPhInternal] = useState([0, 14]);
  const [gender, setGenderInternal] = useState(null);
  const [consistency, setConsistencyInternal] = useState({});

  const [
    faecalibactriumPrausnitzii,
    setFaecalibactriumPrausnitziiInternal
  ] = useState({});
  const [akkermansiaMuciniphila, setAkkermansiaMuciniphilaInternal] = useState(
    {}
  );

  const password = useContext(AccessContext);
  const [examinations, setExaminations] = useState({
    results: [],
    currentPage: 1
  });

  useEffect(() => {
    let url = `/values/examinations?password=${password}&page=${page}&count=${count}`;
    url += `&ph=${ph[0]}&ph=${ph[1]}`;

    if (gender) {
      url += `&gender=${gender}`;
    }

    const consistencyArray = transformConsistency(consistency);
    if (consistencyArray.length > 0) {
      consistencyArray.map(c => (url += `&consistency=${c}`));
    }

    const faecalibactriumPrausnitziiArray = transformPerformedTest(
      faecalibactriumPrausnitzii
    );
    if (faecalibactriumPrausnitziiArray.length > 0) {
      faecalibactriumPrausnitziiArray.map(
        fp => (url += `&faecalibactriumPrausnitzii=${fp}`)
      );
    }

    const akkermansiaMuciniphilaArray = transformPerformedTest(
      akkermansiaMuciniphila
    );
    if (akkermansiaMuciniphilaArray.length > 0) {
      akkermansiaMuciniphilaArray.map(
        am => (url += `&akkermansiaMuciniphila=${am}`)
      );
    }

    fetch(url)
      .then(resp => resp.json())
      .then(data => setExaminations(data));
  }, [
    password,
    page,
    count,
    gender,
    consistency,
    ph,
    faecalibactriumPrausnitzii,
    akkermansiaMuciniphila
  ]);

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
    },
    filters: {
      setGender: g => {
        resetPages();
        setGenderInternal(g);
      },
      setConsistency: c => {
        resetPages();
        setConsistencyInternal(c);
      },
      setPh: p => {
        resetPages();
        setPhInternal(p);
      },
      setFaecalibactriumPrausnitzii: fp => {
        resetPages();
        setFaecalibactriumPrausnitziiInternal(fp);
      },
      setAkkermansiaMuciniphila: am => {
        resetPages();
        setAkkermansiaMuciniphilaInternal(am);
      }
    }
  };
};
