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
