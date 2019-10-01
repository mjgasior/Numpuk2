export const getAge = age => {
  if (age < 1) {
    return age.toFixed(2);
  }
  console.log(age);
  return Math.floor(age).toFixed(0);
}

export const getGender = enumValue => {
  switch (enumValue) {
    case 1:
      return "Mężczyzna";
    case 2:
      return "Kobieta";
    default:
      return "Brak";
  }
};

export const getLabel = threeStateValue => {
  if (threeStateValue === false) {
    return "Nie";
  } else if (threeStateValue === true) {
    return "Tak";
  } else {
    return "";
  }
};

export const getValue = (name, results) => {
  for (let i = 0; i < results.length; i++) {
    if (results[i].name === name) {
      return results[i].value;
    }
  }
};

export const transformPerformedTest = ({ positive, negative, not_performed }) => {
  const array = [];
  if (positive) {
    array.push("POSITIVE");
  }

  if (negative) {
    array.push("NEGATIVE");
  }

  if (not_performed) {
    array.push("NOT_PERFORMED");
  }

  return array;
};

export const transformConsistency = ({
  liquid,
  halfLiquid,
  rigid,
  unknown
}) => {
  const array = [];
  if (liquid) {
    array.push("liquid");
  }

  if (halfLiquid) {
    array.push("half_Liquid");
  }

  if (rigid) {
    array.push("rigid");
  }

  if (unknown) {
    array.push("unknown");
  }

  return array;
};

export const getConsistencyLabel = enumValue => {
  switch (enumValue) {
    case 0:
      return "Płynna";
    case 1:
      return "Półpłynna";
    case 2:
      return "Stała";
    default:
      return "Niezidentyfikowana";
  }
};
