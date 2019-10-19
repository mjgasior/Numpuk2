import { useEffect, useContext, useState } from "react";
import { AccessContext } from "../../access/AccessContext";
import {
  transformConsistency,
  transformPerformedTest
} from "./../table/helpers";

export const useExaminations = onConnectionFailed => {
  const [page, setPageInternal] = useState(1);
  const [count, setCountInternal] = useState(25);

  const [age, setAgeInternal] = useState([0, 140]);
  const [gender, setGenderInternal] = useState(null);
  const [ph, setPhInternal] = useState([0, 14]);
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
    url += `&age=${age[0]}&age=${age[1]}`;

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
      .then(response => {
        if (response.status === 200) {
          return response;
        }
        onConnectionFailed();
      })
      .then(resp => resp.json())
      .then(data => setExaminations(data))
      .catch(e => console.log(e));
  }, [
    password,
    page,
    count,
    age,
    gender,
    consistency,
    ph,
    faecalibactriumPrausnitzii,
    akkermansiaMuciniphila,
    onConnectionFailed
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
      setAge: p => {
        resetPages();
        setAgeInternal(p);
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
