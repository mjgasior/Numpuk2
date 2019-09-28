import { useEffect, useState } from "react";

export const useTestTypes = () => {
  const [families, setFamilies] = useState([]);
  const [testTypes, setTestTypes] = useState([]);

  useEffect(() => {
    let url = "/values/testTypes?";
    const familiesArray = transformFamilies(families);

    if (familiesArray.length > 0) {
      familiesArray.map(c => (url += `&families=${c}`));
    }

    fetch(url)
      .then(resp => resp.json())
      .then(data => setTestTypes(data));
  }, [families]);

  return [testTypes, setFamilies];
};

const transformFamilies = ({ anaerobic, gramMinus, gramPlus, fungi }) => {
  const array = [];
  if (anaerobic) {
    array.push("anaerobic");
  }

  if (gramMinus) {
    array.push("gram_minus");
  }

  if (gramPlus) {
    array.push("gram_plus");
  }

  if (fungi) {
    array.push("fungi");
  }

  return array;
};
